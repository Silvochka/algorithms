# Sorting algorithms [![Build Status](https://travis-ci.org/Silvochka/algorithms.svg?branch=master)](https://travis-ci.org/Silvochka/algorithms)

This repo is a C# library with implemented sorting alrogithms.

Stable, generic:
  - Bubble sort
  - Cocktail sort
  - Gnome sort
  - Insertion sort
  - Merge sort
  - OddEven sort

Unstable, generic:
  - Heap sort
  - Quick sort
  - Selection sort
  - Shell sort

Non-comparison based algorithms:
  - Bucket sort - implemented for integer
  - Couting sort (unstable and stable) - implemented for integer
  - Radix (LSD, MSD)

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

This is young repo so I have plans to log statistic for each sorter:
  - Time of sorting depends on elements count
  - How much switches/smth else was done
