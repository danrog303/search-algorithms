# search-algorithms  
![Continious Integration](https://github.com/danrog303/search-algorithms/actions/workflows/ci.yml/badge.svg)
![PRs](https://shields.io/github/issues-pr-closed-raw/danrog303/search-algorithms)
![Contributors](https://shields.io/github/contributors/danrog303/search-algorithms)
> Aplikacja prezentująca i porównująca algorytmy wyszukiwania podłańcuchów. 

Angielska wersja pliku readme 🇬🇧 [jest dostępna tutaj](https://github.com/danrog303/search-algorithms/blob/main/README.md).

## ✨ Funkcje
1. Aplikacja pozwala na wpisanie dwóch podłańcuchów i wyszukanie wszystkich wystąpień krótszego podłańcucha w tym dłuższym
2. Aplikacja uruchamia 6 różnych algorytmów wyszukiwania (patrz poniżej) i pozwala na porównanie ich czasu wykonania
3. Aplikacja posiada przejrzysty graficzny interfejs użytkownika

## ⚙ Dostępne algorytmy
- Algorytm Knutha-Morrisa-Pratta
- Algorytm Boyer-Moore
- Algorytm wyszukiwania w drzewie binarnym
- Algorytm wyszukiwania przez hashowanie
- Algorytm Rabina Karpa
- Algorytm wyszukiwania sekwencyjnego

## 🔧 Jak zbudować aplikację?
Aplikacja została stworzona w języku C# przy użyciu .NET Framework 4.8. Przed skompilowaniem projektu należy zainstalować narzędzia **Nuget** oraz **MSBuild**. Ponieważ graficzny interfejs użytkownika korzysta z biblioteki WinForms, aplikacja może zostać skompilowana i uruchomiona wyłącznie na systemach z rodziny Windows.
```
git clone https://github.com/danrog303/search-algorithms
cd search-algorithm/src
nuget restore
msbuild.exe
```

## 🎓 Informacja
Aplikacja została stworzona jako projekt zaliczeniowy podczas drugiego semestru studiów na [Politechnice Bydgoskiej](https://pbs.edu.pl/).

## 📔 Dokumentacja
Szczegółową dokumentację projektu znajdziesz [na naszej GitHub Wiki](https://github.com/danrog303/search-algorithms/wiki).
