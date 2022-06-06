using SearchAlgorithms.Core.Algorithms;
using SearchAlgorithms.Core.Testing.Timers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SearchAlgorithms.Interface
{
    public partial class MainForm : Form
    {
        // private List<int> resultList;
        private bool isResultList;
        private bool isSearching = false;
        private string lookingString;
        private string longString;
        private string errorMessage;
        private Series series;
        private List<Task<Tuple<string, double, List<int>>>> tasksList;
        private readonly Random random;
        private readonly Title chartTitle;
        private readonly Dictionary<string, Func<ISearchAlgorithm>> algoMap = new Dictionary<string, Func<ISearchAlgorithm>>();
        private readonly Dictionary<string, List<int>> resultList;
        public MainForm()
        {

            InitializeComponent();
            chart.Series.Clear();
            progressBar.MarqueeAnimationSpeed = 2;

            chartTitle = new Title("Wykres Czasu");
            chart.Titles.Add(chartTitle);

            chart.ChartAreas["ChartArea1"].AxisY.Title = "[jednostki pomiaru]";
            random = new Random();

            algoMap.Add("BinarySerch", () => new BinarySearch());
            algoMap.Add("BoyerMooreSearch", () => new BoyerMooreSearch());
            algoMap.Add("HashSearch", () => new HashSearch());
            algoMap.Add("KMPSearch", () => new KMPSearch());
            algoMap.Add("RabinKarpSearch", () => new RabinKarpSearch());
            algoMap.Add("SequenceSearch", () => new SequenceSearch());
            resultList = new Dictionary<string, List<int>>();
        }

        private void Event_toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"c:\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //var filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    richTextBoxLongString.Text = reader.ReadToEnd();
                }
            }
        }

        private async void Event_richTextBoxLookingString_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckRichTextBox())
                {
                    await StartSerch();
                }
            }
        }

        private async void Event_buttonSearch_Click(object sender, EventArgs e)
        {
            buttonSearch.Enabled = false;
            if (CheckRichTextBox())
            {
                isResultList = false;
                resultList.Clear();
                await StartSerch();
            }
            buttonSearch.Enabled = true;
        }

        private bool CheckRichTextBox()
        {
            bool result = true;
            if (richTextBoxLongString.TextLength == 0)
            {
                errorProviderLong.SetError(richTextBoxLongString, "Podaj napis do przeszykania!");
                result = false;
            }
            else
            {
                errorProviderLong.Clear();
            }
            if (richTextBoxLookingString.TextLength == 0)
            {
                errorProviderLooking.SetError(richTextBoxLookingString, "Podaj szukany napis!");
                result = false;
            }
            else
            {
                errorProviderLooking.Clear();
            }
            if (!result)
            {

            }
            return result;
        }


        public async Task StartSerch()
        {
            if (!isSearching)
            {
                isSearching = true;
                errorMessage = "";
                chart.UseWaitCursor = true;
                isResultList = false;

                richTextBoxLongString.SelectionStart = 0;
                richTextBoxLongString.SelectionLength = richTextBoxLongString.Text.Length;
                richTextBoxLongString.SelectionColor = Color.Black;

                progressBar.Style = ProgressBarStyle.Marquee;

                lookingString = richTextBoxLookingString.Text;
                longString = richTextBoxLongString.Text;

                ChartSeriesReset();

                chartTitle.Text = "Trwa wyszukiwanie...";

                tasksList = new List<Task<Tuple<string, double, List<int>>>>
                {
                    new Task<Tuple<string, double, List<int>>>(() => { return Search(algoMap["BoyerMooreSearch"]); }),
                    new Task<Tuple<string, double, List<int>>>(() => { return Search(algoMap["BinarySerch"]); }),
                    new Task<Tuple<string, double, List<int>>>(() => { return Search(algoMap["HashSearch"]); }),
                    new Task<Tuple<string, double, List<int>>>(() => { return Search(algoMap["KMPSearch"]); }),
                    new Task<Tuple<string, double, List<int>>>(() => { return Search(algoMap["RabinKarpSearch"]); }),
                    new Task<Tuple<string, double, List<int>>>(() => { return Search(algoMap["SequenceSearch"]); })
                };

                foreach (Task<Tuple<string, double, List<int>>> i in tasksList)
                {
                    i.Start();
                }

                tabControl.SelectedIndex = 0;
                var cpu = new ManagementObjectSearcher("select name from Win32_Processor").Get().Cast<ManagementObject>().First();
                chartTitle.Text = cpu.GetPropertyValue("name").ToString();

                while (tasksList.Count != 0)
                {
                    Task<Tuple<string, double, List<int>>> completeTask;

                    completeTask = await Task<Tuple<string, double, List<int>>>.WhenAny(tasksList);
                    var swr = completeTask.Result;
                    tasksList.Remove(completeTask);
                    series.Points.ElementAt(series.Points.AddXY(swr.Item1, swr.Item2)).Color = Color.FromArgb(random.Next() % 255, random.Next() % 255, random.Next() % 255);
                    if(completeTask.Result.Item3 != null)
                    {
                        resultList[completeTask.Result.Item1] = completeTask.Result.Item3;
                    }
                }

                isResultList = true;
                Console.WriteLine(resultList.Count);
                string s = resultList.ElementAt((random.Next() % resultList.Count)).Key;

                textBoxMarkAlgo.Text = s;
                MarkSubstring(s);

                chart.UseWaitCursor = false;
                progressBar.Style = ProgressBarStyle.Blocks;

                errorProviderChart.SetError(chart, errorMessage);
                isSearching = false;
            }
        }

        private void ChartSeriesReset()
        {
            chart.Series.Clear();

            series = chart.Series.Add("TimeSeries");
            series.ChartType = SeriesChartType.Column;
            series.IsVisibleInLegend = false;
            series.IsValueShownAsLabel = true;
        }

        private Tuple<string, double, List<int>> Search(Func<ISearchAlgorithm> algo)
        {
            List<int> rl = null;
            ISearchAlgorithm fa = null;
            PrimeNumbersTimeMeasure tm = new PrimeNumbersTimeMeasure();

            void measuredAction()
            {
                fa = algo();
                rl = fa.Search(lookingString, longString);
            }

            double swResult;
            try
            {
                swResult = tm.UnifiedUnitMeasure(measuredAction).OriginalResult;
                //resultList[fa.Name()] = rl;
            }
            catch (Exception ex)
            {
                swResult = -1;
                Console.WriteLine(ex.Message);
                errorMessage = ex.Message + "\n" + errorMessage;
            }
            return new Tuple<string, double, List<int>>(fa.Name(), swResult, rl);
        }

        private void MarkSubstring(string algoName)
        {
            foreach (var i in resultList[algoName])
            {
                richTextBoxLongString.SelectionStart = i;
                richTextBoxLongString.SelectionLength = richTextBoxLookingString.Text.Length;
                richTextBoxLongString.SelectionColor = Color.Red;
            }
            richTextBoxLongString.SelectionStart = richTextBoxLongString.TextLength;

            richTextBoxLongString.SelectionColor = Color.Black;
        }

        private void Event_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1&&isResultList)
            {
                int maxSize = resultList.Values.Max(item => item.Count); ;
                dataGridViewIndex.Columns.Clear();
                dataGridViewIndex.Rows.Clear();
                dataGridViewIndex.Columns.Add("LP", "LP");

                dataGridViewIndex.Rows.Add(maxSize);
                for (int i = 0; i < maxSize; i++)
                {
                    dataGridViewIndex[0, i].Value = i+1;
                }

                int ci = 1, ri = 0;
                foreach (var i in resultList)
                {
                    dataGridViewIndex.Columns.Add(i.Key, i.Key);
                    ri = 0;
                    foreach (var j in resultList[i.Key])
                    {
                        dataGridViewIndex[ci, ri].Value = j;
                        ri++;
                    }
                    ci++;
                }
            }
        }

        /// <summary>
        /// Clears formatting when long string input has focus.
        /// </summary>
        private void Event_richTextBoxLongString_Enter(object sender, EventArgs e)
        {
            richTextBoxLongString.SelectionStart = 0;
            richTextBoxLongString.SelectionLength = richTextBoxLongString.Text.Length;
            richTextBoxLongString.SelectionColor = Color.Black;
        }
    }
}
