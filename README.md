# search-algorithms  
![Continious Integration](https://github.com/danrog303/search-algorithms/actions/workflows/ci.yml/badge.svg)
![PRs](https://shields.io/github/issues-pr-closed-raw/danrog303/search-algorithms)
![Contributors](https://shields.io/github/contributors/danrog303/search-algorithms)
> Application which presents and compares various substring searching algorithms.  

Polish version of readme file 🇵🇱 [is available here](https://github.com/danrog303/search-algorithms/blob/main/README.polish.md). 

## ✨ Features
1. Application allows to type two strings (haystack and needle) and it will find all occurences of needle in haystack
2. It will run 6 different algorithms (look below) and will allow you to compare their execution times
3. The application has a pretty nice and clear graphical user interface

## ⚙ Available algorithms
- Knuth-Morris-Pratt Algorithm
- Boyer-Moore Algorithm
- Binary Search Algorithm
- Hash Search Algorithm
- Rabin Karp Algorithm
- Sequence Search Algorithm

## 🔧 How to build?
Application has been written in C#, using .NET Framework 4.8. You have to install **Nuget** and **MSBuild** before compiling this project. Because the GUI uses WinForms library, the application can only be compiled on Windows systems.
```
git clone https://github.com/danrog303/search-algorithms
cd search-algorithm/src
nuget restore
msbuild.exe
```

## 🎓 Note
The application was created as an project assignment during the second semester of studies at [Bydgoszcz University of Science and Technology](https://pbs.edu.pl/).

## 📔 Documentation
You can find detailed documentation of the project [here on our GitHub Wiki](https://github.com/danrog303/search-algorithms/wiki).  
Unfortunately, Wiki is available only in Polish 🇵🇱.
