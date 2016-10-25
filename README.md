# Sorting algorithms [![Build Status](https://travis-ci.org/Silvochka/algorithms.svg?branch=master)](https://travis-ci.org/Silvochka/algorithms) [![Build status](https://ci.appveyor.com/api/projects/status/i9w52t621058hwln/branch/master?svg=true)](https://ci.appveyor.com/project/Silvochka/algorithms/branch/master) [![Coverage Status](https://coveralls.io/repos/github/Silvochka/algorithms/badge.svg?branch=master)](https://coveralls.io/github/Silvochka/algorithms?branch=master)

This repo is a C# library with implemented sorting alrogithms.

Stable, generic:
  - [Bubble sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Stable/BubbleSorter.cs) 
  - [Cocktail sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Stable/CocktailSorter.cs) 
  - [Gnome sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Stable/GnomeSorter.cs) 
  - [Insertion sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Stable/InsertionSorter.cs) 
  - [Merge sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Stable/MergeSorter.cs) 
  - [OddEven sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Stable/OddEvenSorter.cs) 

Unstable, generic:
  - [Heap sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Unstable/HeapSorter.cs) 
  - [Quick sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Unstable/QuickSorter.cs) 
  - [Selection sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Unstable/SelectionSorter.cs) 
  - [Shell sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/Unstable/ShellSorter.cs) 

Non-comparison based algorithms:
  - [Bucket sort](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/NonComparison/BucketSorter.cs)  - implemented for integer
  - [Couting sort (stable)](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/NonComparison/CountingStableSorter.cs)  - implemented for integer
  - [Couting sort (unstable)](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/NonComparison/CountingSorter.cs)  - implemented for integer
  - [LSD Radix](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/NonComparison/LSDRadixSorter.cs) - implemented for integer
  - [MSD Radix](https://github.com/Silvochka/algorithms/blob/master/Algorithms/SortAlgorithms/NonComparison/MSDRadixSorter.cs) - implemented for strings

### Test framework

This library has generic tests for each sorter. New added sorter is testing automatically using Reflection. Currently it tests next types of array:
  - Integer
  - Double
  - String
  - Char

Each type tested on next inputs:
  - Sorted sequense
  - Reverted sorted sequense
  - Random shuffled sequense
  - Empty array

This is young repo so I have plans to 
  - log statistic for each sorter:
    - Time of sorting depends on elements count
  - implement structures and work with them
