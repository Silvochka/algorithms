# Sorting and data structure algorithms [![Build Status](https://travis-ci.org/Silvochka/algorithms.svg?branch=dev)](https://travis-ci.org/Silvochka/algorithms) [![Build status](https://ci.appveyor.com/api/projects/status/i9w52t621058hwln/branch/dev?svg=true)](https://ci.appveyor.com/project/Silvochka/algorithms/branch/dev) [![Coverage Status](https://coveralls.io/repos/github/Silvochka/algorithms/badge.svg?branch=dev&bust=1)](https://coveralls.io/github/Silvochka/algorithms?branch=dev)

This repo is a C# library with implemented sorting alrogithms, structures and its algorithms.

SortingAlgorithms:
  - Stable, generic:
    - [Bubble sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Stable/BubbleSorter.cs) 
    - [Cocktail sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Stable/CocktailSorter.cs) 
    - [Gnome sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Stable/GnomeSorter.cs) 
    - [Insertion sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Stable/InsertionSorter.cs) 
    - [Merge sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Stable/MergeSorter.cs) 
    - [OddEven sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Stable/OddEvenSorter.cs) 
  - Unstable, generic:
    - [Heap sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Unstable/HeapSorter.cs) 
    - [Quick sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Unstable/QuickSorter.cs) 
    - [Selection sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Unstable/SelectionSorter.cs) 
    - [Shell sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/Unstable/ShellSorter.cs) 
  - Non-comparison based algorithms:
    - [Bucket sort](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/NonComparison/BucketSorter.cs)  - implemented for integer
    - [Couting sort (stable)](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/NonComparison/CountingStableSorter.cs)  - implemented for integer
    - [Couting sort (unstable)](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/NonComparison/CountingSorter.cs)  - implemented for integer
    - [LSD Radix](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/NonComparison/LSDRadixSorter.cs) - implemented for integer
    - [MSD Radix](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/SortAlgorithms/NonComparison/MSDRadixSorter.cs) - implemented for strings

Data stuctures:
  - [Hash tables](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/HashTable/IHashTable.cs)
    - Implementations
      - [With linked list usage](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/HashTable/HashTableWithLinkedList.cs)
      - [With linear probing](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/HashTable/LinearHashTable.cs)
      - [With quadratic probing](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/HashTable/QuadraticHashTable.cs)
      - [With double hashing probing](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/HashTable/DoubleHashTable.cs)
    - Algorithms
      - Add
      - Contains
      - Remove
      - Clear
  - [Binary search tree](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs)
    - [Insert](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L33)
    - [Find](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L55)
    - [Remove](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L70)
    - [Traverse](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L99)
      - Infix ([recursive](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L691) and [iteration](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L714) implementation)
      - Prefix ([recursive](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L698) and [iteration](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L734) implementation)
      - Postfix ([recursive](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L705) and [iteration](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L756) implementation)
      - Breadth ([iteration](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L787) implementation)
    - [Verify](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L139)
    - [GetMin](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L153)
    - [GetMax](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L173)
    - [GetPredecessor](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L194)
    - [GetSuccessor](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L234)
    - [GetKElementInOrder](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L274)
    - [SplitByKey](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L290)
    - [Merge](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L351) (with tree where keys > than keys in this tree)
    - [RotateLeft](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L375)
    - [RotateRight](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L383)
    - [GetCommonRoot(key1, key2)](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L394)
    - [GetDistance(key1, key2)](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTree.cs#L439)
  - [Binary search tree node](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs)
    - [HasParent](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L66)
    - [IsTerminate](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L58)
    - [Count](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L74)
    - [Height](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L82)
    - [Degree](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L91)
    - [Depth](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L96)
    - [Level](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/BinarySearchTreeNode.cs#L109)
  - [AVL tree](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTree.cs)
    - [Insert](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTree.cs#L32)
    - [Verify](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTree.cs#L82)
    - [Remove](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTree.cs#L91)
    - [RebalanceIn](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTree.cs#L118)
  - [AVL tree node](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTreeNode.cs)
    - [Balance factor](https://github.com/Silvochka/algorithms/blob/dev/Algorithms/DataStructures/Tree/AVLTreeNode.cs#L18)

### Tests

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

Each implemented data structures has tests which covering as much as possible.
