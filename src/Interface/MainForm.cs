using SearchAlgorithms.BaseInterfaceClass;
using SearchAlgorithms.TestAlgorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Interface
{
    public partial class MainForm : Form
    {
        private List<int> resultList;
        private bool isResultList;
        private string lookingString;
        private string longString;
        private Series series;
        private List<Task<Tuple<string,long>>> tasksList;
        private Random random;
        private Title chartTitle;
        public MainForm()
        {
            InitializeComponent();

            chart.Series.Clear();

            progressBar.MarqueeAnimationSpeed = 2;

            chartTitle = new Title("Wykres Czasu");
            chart.Titles.Add(chartTitle);

            chart.ChartAreas["ChartArea1"].AxisY.Title = "[ms]";
            random = new Random();
        }
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
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

        private void richTextBoxLookingString_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckRichTextBox())
                {
                    StartSerch();
                }
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (CheckRichTextBox())
            {
            StartSerch();
            }
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
            return result;
        }


        public async void StartSerch()
        {
            buttonSearch.Enabled = false;
            chart.UseWaitCursor = true;
            isResultList = false;
            resultList = null;

            richTextBoxLongString.SelectionStart = 0;
            richTextBoxLongString.SelectionLength = richTextBoxLongString.Text.Length;
            richTextBoxLongString.SelectionColor = Color.Black;

            progressBar.Style = ProgressBarStyle.Marquee;

            lookingString = richTextBoxLookingString.Text;
            longString = richTextBoxLongString.Text;

            seriesReset();

            chartTitle.Text = "Trwa wyszukiwanie...";

            tasksList = new List<Task<Tuple<string, long>>>();

            tasksList.Add(new Task<Tuple<string, long>>(() => { return Serch(() => new FirstAlgorithm(random.Next())); }));
            tasksList.Add(new Task<Tuple<string, long>>(() => { return Serch(() => new FirstAlgorithm(random.Next())); }));
            tasksList.Add(new Task<Tuple<string, long>>(() => { return Serch(() => new FirstAlgorithm(random.Next())); }));
            tasksList.Add(new Task<Tuple<string, long>>(() => { return Serch(() => new FirstAlgorithm(random.Next())); }));
            tasksList.Add(new Task<Tuple<string, long>>(() => { return Serch(() => new FirstAlgorithm(random.Next())); }));
            tasksList.Add(new Task<Tuple<string, long>>(() => { return Serch(() => new FirstAlgorithm(random.Next())); }));

            foreach (Task<Tuple<string, long>> i in tasksList)
            {
                i.Start();
            }

            while (tasksList.Count != 0)
            {
                var completeTask = await Task<Tuple<string, long>>.WhenAny(tasksList);
                var swr = completeTask.Result;
                tasksList.Remove(completeTask);
                series.Points.ElementAt(series.Points.AddXY(swr.Item1, swr.Item2)).Color = Color.FromArgb(random.Next() % 255, random.Next() % 255, random.Next() % 255);
                if (!isResultList)
                {
                    tabControl.SelectedIndex = 0;
                    var cpu = new ManagementObjectSearcher("select name from Win32_Processor").Get().Cast<ManagementObject>().First();
                    chartTitle.Text = cpu.GetPropertyValue("name").ToString();
                    isResultList = true;
                    markSubString();
                }
            }

            chart.UseWaitCursor = false;
            buttonSearch.Enabled = true;
            progressBar.Style = ProgressBarStyle.Blocks;
        }

        private void seriesReset()
        {
            chart.Series.Clear();
            
            series = chart.Series.Add("TimeSeries");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.IsVisibleInLegend = false;
            series.IsValueShownAsLabel = true;
            
            //series.Font = new Font(series.Font.Name, series.Font.Size + 5, series.Font.Style, series.Font.Unit);

        }

        private Tuple<string, long> Serch(Func<SearchAlgorithmInterface> algo)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SearchAlgorithmInterface fa = algo();
            List<int> rl = fa.search(lookingString, longString);
            long swResult = sw.ElapsedMilliseconds;
            sw.Stop();

            if (resultList == null)
            {
                resultList = rl;
            }        
            return new Tuple<string,long>(fa.name(),swResult);
        }

        private async void markSubString()
        {
            await Task.Run(() => Thread.Sleep(1));

            foreach (var i in resultList)
            {
                richTextBoxLongString.SelectionStart = i;
                richTextBoxLongString.SelectionLength = richTextBoxLookingString.Text.Length;
                richTextBoxLongString.SelectionColor = Color.Red;
            }
            richTextBoxLongString.SelectionStart = richTextBoxLongString.TextLength;

            richTextBoxLongString.SelectionColor = Color.Black;
        }

    }
}
