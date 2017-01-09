using System.Text;
using Algorithms.Helpers;

namespace Algorithms.Interview.Chapter1
{
    /// <summary>
    /// Solutions for tasks from chapter1: strings and arrays
    /// </summary>
    public static class String
    {
        private static int asciiLength = 256;

        /// <summary>
        /// This methos guess that string is using only ASCII
        /// </summary>
        /// <param name="s">String to check</param>
        /// <returns>True if all chars are unique</returns>
        public static bool IsUniqueChars(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            /// ASCII has only 256 characters
            if (s.Length > asciiLength)
            {
                return false;
            }

            var presenceCheck = new bool[asciiLength];
            for (var i = 0; i < s.Length; i++)
            {
                var charCode = s[i];
                if (presenceCheck[charCode])
                {
                    return false;
                }

                presenceCheck[charCode] = true;
            }

            return true;
        }

        /// <summary>
        /// Reverse string
        /// </summary>
        /// <param name="s">String to reverse</param>
        public static string Reverse(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            var charArray = s.ToCharArray();
            for (var i = 0; i < s.Length / 2; i++)
            {
                var endIndex = s.Length - i - 1;
                SortHelper.swap(charArray, i, endIndex);
            }

            return new string(charArray);
        }

        /// <summary>
        /// Checks if this string is permutation of another string
        /// </summary>
        /// <param name="s1">String to check</param>
        /// <param name="s2">Another string</param>
        /// <returns>True if this string is permutation</returns>
        /// <remarks>
        /// Case sensitive? Assume yes
        /// Space sensitive? Assume yes
        /// ASCII or UNICODE? Assume ASCII
        /// </remarks>
        public static bool IsPermutationOf(this string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return false;
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            var counter = getAsciiCounter(s1);

            for (var i = 0; i < s2.Length; i++)
            {
                if (--counter[s2[i]] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Replace space to %20
        /// </summary>
        /// <param name="s">input string</param>
        /// <returns>String with replacements</returns>
        public static string ReplaceSpace(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var spaceCounts = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    spaceCounts++;
                }
            }

            if (spaceCounts == 0)
            {
                return s;
            }

            var inputArray = s.ToCharArray();
            var currentLength = inputArray.Length + spaceCounts * 2;
            var result = new char[currentLength];
            currentLength--;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    result[currentLength--] = '0';
                    result[currentLength--] = '2';
                    result[currentLength--] = '%';
                }
                else
                {
                    result[currentLength--] = s[i];
                }
            }

            return new string(result);
        }

        /// <summary>
        /// Check is current string is permutation of palindrome
        /// </summary>
        /// <param name="s">String to check</param>
        /// <returns>True if current string is permutation of palindrome</returns>
        /// <remarks>
        /// Case sensetive? Assume, yes
        /// Space sensitive? Assume, yes
        /// ASCII or UNICODE? Assume ASCII
        /// </remarks>
        public static bool IsPermutationOfPalindrome(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            var counter = new bool[asciiLength];
            for (var i = 0; i < s.Length; i++)
            {
                counter[s[i]] = !counter[s[i]];
            }

            var hasSingleChar = false;
            for (var i = 0; i < counter.Length; i++)
            {
                if (counter[i])
                {
                    if (hasSingleChar)
                    {
                        return false;
                    }
                    else
                    {
                        hasSingleChar = true;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check if current string differ from another with just 1 edit/add/remove
        /// </summary>
        /// <param name="s1">Current string</param>
        /// <param name="s2">Another string</param>
        /// <returns>True of current string differ from another with just 1 edit/add/remove</returns>
        public static bool IsSimilarLike(this string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return false;
            }

            var l1 = s1.Length;
            var l2 = s2.Length;

            if (l1 == l2)
            {
                return checkSingleEdit(s1, s2);
            }
            else if (l1 - l2 == 1)
            {
                return checkSingleRemoval(s1, s2);
            }
            else if (l2 - l1 == 1)
            {
                return checkSingleRemoval(s2, s1);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Archiving string: aaabbc -> a3b2c1 only if result less than origin
        /// </summary>
        /// <param name="s">Origin string to acrhive</param>
        /// <returns>Archived string or origin of its less</returns>
        public static string Archive(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            var result = new StringBuilder();
            char currentChar = s[0];
            var currentLength = 1;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] != currentChar)
                {
                    result.Append(currentChar);
                    result.Append(currentLength);
                    currentChar = s[i];
                    currentLength = 1;
                }
                else
                {
                    currentLength++;
                }
            }

            result.Append(currentChar);
            result.Append(currentLength);

            return s.Length >= result.Length ? result.ToString() : s;
        }

        /// <summary>
        /// Using Contains method, checks is other string - cycle shift of original
        /// </summary>
        /// <param name="s1">Original string</param>
        /// <param name="s2">String to check</param>
        /// <returns>True if other string is cycle substring of origin</returns>
        public static bool IsCycleShift(this string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return false;
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            return (s2 + s2).Contains(s1);
        }

        private static int[] getAsciiCounter(string s)
        {
            var counter = new int[asciiLength];

            for (var i = 0; i < asciiLength; i++)
            {
                counter[i] = 0;
            }

            for (var i = 0; i < s.Length; i++)
            {
                counter[s[i]]++;
            }

            return counter;
        }

        private static bool checkSingleEdit(string s1, string s2)
        {
            var foundEdit = false;
            for (var i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundEdit)
                    {
                        return false;
                    }

                    foundEdit = true;
                }
            }

            return true;
        }

        /// <summary>
        /// Check can we remove 1 char from s1 and get s2
        /// </summary>
        /// <param name="s1">String where we can remove 1 symbol</param>
        /// <param name="s2">String where 1 symbol already removed</param>
        /// <returns>True if we remove 1 char from s1 and get s2</returns>
        private static bool checkSingleRemoval(string s1, string s2)
        {
            var index1 = 0;
            var index2 = 0;

            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }

                    index1++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }

            return true;
        }
    }
}
