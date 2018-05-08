using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeFights
{
    static class Arcade
    {
        public static bool checkPalindrome(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                if (inputString.Length.Equals(1))
                {
                    return true;
                }
                else
                {
                    bool isPalindrom = false;
                    int indexStart = 0;
                    int indexEnd = inputString.Length - 1;

                    for (int i = 0; i < inputString.Length / 2; i++)
                    {
                        if (inputString[indexStart++].
                            Equals(inputString[indexEnd--]))
                        {
                            isPalindrom = true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (isPalindrom) return true; else return false;
                }
            }
            else return false;
        }

        public static int adjacentElementsProduct(int[] inputArray)
        {
            if (inputArray.Length > 1)
            {
                int largestProduct = inputArray[0] * inputArray[1];

                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    int product = inputArray[i] * inputArray[i + 1];
                    if (product > largestProduct) largestProduct = product;
                }

                return largestProduct;
            }
            else
            {
                return -1;
            }
        }

        public static int matrixElementsSum(int[][] matrix)
        {
            int value = 0;

            bool[] isColumnEnabled = new bool[matrix[0].Length];
            for (int i = 0; i < isColumnEnabled.Length; i++) isColumnEnabled[i] = true;

            for (int v = 0; v < matrix.Length; v++)
            {
                for (int h = 0; h < matrix[v].Length; h++)
                {
                    if (matrix[v][h].Equals(0)) isColumnEnabled[h] = false;
                    if (isColumnEnabled[h]) value = value + matrix[v][h];
                }
            }

            return value;
        }

        public static string[] allLongestStrings(string[] inputArray)
        {
            int longestStringLength = 0;
            List<string> outputList = new List<string>();

            for (int i = 0; i < inputArray.Length; i++)
                if (inputArray[i].Length > longestStringLength) longestStringLength = inputArray[i].Length;

            for (int i = 0; i < inputArray.Length; i++)
                if (inputArray[i].Length == longestStringLength) outputList.Add(inputArray[i]);

            return outputList.ToArray();
        }

        public static int commonCharacterCount(string s1, string s2)
        {
            int commonCharacters = 0;
            char[] alpha = "abcdefghijklmnoprqrstuvwxyz".ToCharArray();
            int[] alphaInts1 = new int[alpha.Length];
            int[] alphaInts2 = new int[alpha.Length];

            if (!String.IsNullOrEmpty(s1) && !String.IsNullOrEmpty(s2))
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    for (int z = 0; z < alpha.Length; z++)
                        if (alpha[z].Equals(s1.ElementAt(i))) alphaInts1[z]++;
                }

                for (int i = 0; i < s2.Length; i++)
                {
                    for (int z = 0; z < alpha.Length; z++)
                        if (alpha[z].Equals(s2.ElementAt(i))) alphaInts2[z]++;
                }
            }

            for (int i = 0; i < alphaInts1.Length; i++)
            {
                Console.WriteLine($"i: { i } \t s1: { alphaInts1[i] } s2: { alphaInts2[i] }");
            }

            for (int i = 0; i < alphaInts1.Length; i++)
            {
                if (alphaInts1[i] > 0 && alphaInts2[i] > 0)
                {
                    if (alphaInts1[i] >= alphaInts2[i])
                        commonCharacters += alphaInts2[i];
                    else
                        commonCharacters += alphaInts1[i];
                }
            }

            return commonCharacters;
        }

        public static bool isLucky(int n)
        {
            if ((n.ToString().Length % 2) == 0)
            {
                int leftValue  = 0, rightValue = 0;
                int lenghtHalf = n.ToString().Length / 2;
                string number  = n.ToString();

                string leftHalf  = number.Substring(0, lenghtHalf);
                string rightHalf = number.Substring(lenghtHalf);

                Console.WriteLine($"firstHalf: { leftHalf } secondHalf: {rightHalf}");

                for (int i = 0; i < leftHalf.Length; i++)
                {
                    leftValue += int.Parse(leftHalf[i].ToString());
                    rightValue += int.Parse(rightHalf[i].ToString());
                }

                if (leftValue == rightValue) return true;
                else return false;
            }
            else return false;
        }

        public static int[] sortByHeight(int[] a)
        {
            int newTableLength = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    newTableLength++;
                }
            }

            int[] tableToSort = new int[newTableLength];

            for (int i = 0, k = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    tableToSort[k++] = a[i];
                }
            }

            bool isChanged = false;

            // Bubble sort
            do
            {
                isChanged = false;

                for (int i = 0; i < tableToSort.Length - 1; i++)
                {
                    if (tableToSort[i] > tableToSort[i + 1])
                    {
                        int temporaryItem = tableToSort[i];
                        tableToSort[i] = tableToSort[i + 1];
                        tableToSort[i + 1] = temporaryItem;
                        isChanged = true;
                    }
                }
            } while (isChanged == true);

            for (int i = 0, k = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    a[i] = tableToSort[k++];
                }
            }

            return a;
        }

        public static string reverseParentheses(string s)
        {
            string strParam = s;
            bool isThereStillBrackects;

            if (strParam.Contains("(")) isThereStillBrackects = true;
            else return strParam;

            do
            {
                int leftBracketIndex = 0;
                int rightBracketIndex = 0;

                for (int i = 0; i < strParam.Length; i++)
                {
                    if (strParam.ElementAt(i).ToString() == "(")
                        leftBracketIndex = i;

                    if (strParam.ElementAt(i).ToString() == ")")
                    {
                        rightBracketIndex = i;
                        break;
                    }
                }

                string leftContent = strParam.Substring(0, leftBracketIndex);
                string rightContent = strParam.Substring(rightBracketIndex + 1);
                string insideContent = strParam.Substring(leftBracketIndex + 1, rightBracketIndex - leftBracketIndex - 1);
                Console.WriteLine($"strParam: {strParam}");
                Console.WriteLine($"leftBracketIndex: \t{ leftBracketIndex } \nrightBracketIndex: \t{ rightBracketIndex }");
                Console.WriteLine($"leftContent: \t{ leftContent } \nrightContent: \t{ rightContent }");
                Console.WriteLine($"insideContent: { insideContent }");

                string insideContentReverse = String.Empty;
                for (int i = insideContent.Length - 1; i >= 0; i--)
                {
                    insideContentReverse += insideContent.ElementAt(i);
                }

                Console.WriteLine($"insideContent (reverse): { insideContentReverse }");

                strParam = leftContent + insideContentReverse + rightContent;
                Console.WriteLine($"strParam: { strParam }\n");


                if (strParam.Contains("(")) isThereStillBrackects = true;
                else isThereStillBrackects = false;
            } while (isThereStillBrackects);

            return strParam;
        }

        public static int[] alternatingSums(int[] a)
        {
            int[] alternatingSums = { 0, 0 };

            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                    alternatingSums[0] += a[i];
                else
                    alternatingSums[1] += a[i];
            }

            return alternatingSums;
        }

        public static string[] addBorder(string[] picture)
        {
            int width = picture[0].Length + 2;
            int height = picture.Length + 2;

            string[] pictureWithBorder = new string[height];

            string topBorder = String.Empty;
            string bottomBorder = String.Empty;
            for (int i = 0; i < width; i++)
            {
                topBorder += "*";
            }

            bottomBorder = topBorder;

            pictureWithBorder[0] = topBorder;
            for (int i = 1, k = 0; i < pictureWithBorder.Length - 1; i++)
            {
                pictureWithBorder[i] = "*" + picture[k++] + "*";
            }
            pictureWithBorder[height - 1] = bottomBorder;

            foreach (var i in pictureWithBorder)
            {
                Console.WriteLine(i);
            }

            return pictureWithBorder;
        }

        public static bool areSimilar(int[] a, int[] b)
        {
            int notSimilarIndexes = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) notSimilarIndexes++;
            }

            if (notSimilarIndexes > 2)
                return false;
            else if (notSimilarIndexes == 2)
            {
                int[] indexesToSwap = new int[2];

                for (int i = 0, k = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i]) indexesToSwap[k++] = i;
                }

                Console.WriteLine($"indexToSwap[0]: {indexesToSwap[0]}, indexToSwap[1]: {indexesToSwap[1]}");

                var temp = a[indexesToSwap[0]];
                a[indexesToSwap[0]] = a[indexesToSwap[1]];
                a[indexesToSwap[1]] = temp;

                int differentValueOfIndex = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i]) differentValueOfIndex++;
                }

                if (differentValueOfIndex > 0) return false; else return true;
            }
            else if (notSimilarIndexes == 1) return false;
            else return true;
        }

        public static int arrayChange(int[] inputArray)
        {
            int moves = 0;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i + 1] < inputArray[i])
                {
                    int differentValue = 0;
                    differentValue = inputArray[i] - inputArray[i + 1] + 1;

                    inputArray[i + 1] += differentValue;

                    moves += differentValue;
                }
                else if (inputArray[i + 1] == inputArray[i])
                {
                    inputArray[i + 1]++;
                    moves++;
                }
            }

            return moves;
        }

        public static bool palindromeRearranging(string inputString)
        {
            inputString = inputString.ToLower();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (!(inputString.ElementAt(i) >= 'a' && inputString.ElementAt(i) <= 'z')) { return false; }
            }


            if (inputString.Length == 1) return true;
            else if (inputString.Length > 1 && inputString.Length <= 50)
            {
                int oddCount = 0;
                List<char> lista = new List<char>();

                for (int i = 0; i < inputString.Length; i++)
                {
                    char character = inputString.ElementAt(i);
                    int charOccur = 0;

                    if (lista.Contains(character)) continue;
                    else lista.Add(character);

                    for (int j = 0; j < inputString.Length; j++)
                    {
                        if (inputString.ElementAt(j).Equals(character)) charOccur++;
                    }

                    if ((charOccur % 2) != 0)
                    {
                        oddCount++;
                    }
                }

                if (oddCount > 1) return false;
                else return true;

            }
            else return true;
        }

        public static bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            if (
                ((yourLeft + friendsRight) == (yourRight + friendsLeft) || (yourLeft + friendsLeft) == (yourRight + friendsRight))
                &&
                (yourLeft + yourRight) == (friendsLeft + friendsRight)
               ) return true;
            else return false;
        }

        static int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            int maximalAdjacentDifference = 0;

            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int adjecentDifference = Math.Abs(inputArray[i + 1] - inputArray[i]);

                if (adjecentDifference > maximalAdjacentDifference) maximalAdjacentDifference = adjecentDifference;
            }

            return maximalAdjacentDifference;
        }

        public static bool isIPv4Address(string inputString)
        {
            Console.Write("\n" + inputString + "\n");

            string[] list = inputString.Split('.');

            if (list.Length == 4)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    int value = 0;

                    try
                    {
                        value = int.Parse(list[i]);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }

                    if (value >= 0 && value <= 255)
                    {
                        Console.Write(value + "\t");
                    }
                    else return false;
                }

                return true;
            }
            else return false;
        }

        public static int avoidObstacles(int[] inputArray)
        {
            int[] sortedInput = (from element in inputArray
                                 orderby element
                                 ascending
                                 select element).ToArray();

            int longestObstacle = 1;
            int obstacle = 1;

            for (int i = 0; i < sortedInput.Length - 1; i++)
            {
                if (sortedInput[i] == (sortedInput[i + 1] - 1))
                {
                    obstacle++;
                }
                else
                {
                    if (obstacle > longestObstacle)
                    {
                        longestObstacle = obstacle;
                    }

                    obstacle = 1;
                }
            }

            int max = sortedInput.Max();
            bool leaped;

            do
            {
                Console.WriteLine($"LongestObstacle: {longestObstacle}");
                leaped = true;

                for (int i = 0; i < max; /*   */)
                {
                    i += longestObstacle;

                    if (sortedInput.Contains(i))
                    {
                        longestObstacle++;
                        leaped = false;
                        break;
                    }
                }

            } while (!leaped);

            return longestObstacle;
        }

        public static int[][] boxBlur(int[][] image)
        {
            int y = image.Length;
            int x = image[0].Length;
            Console.WriteLine($"x: {x} \ty: {y}");

            // inputArrayOutput
            for (int i = 0; i < image.Length; i++)
            {
                for (int k = 0; k < image[0].Length; k++)
                {
                    Console.Write(image[i][k] + "\t");
                }
                Console.WriteLine();
            }

            int[][] newArray = new int[y - 2][];

            // x (horizontal size)
            for (int i = 0; i < y - 2; i++)
                newArray[i] = new int[x - 2];

            // main
            for (int i = 0; i < newArray.Length; i++)
            {
                for (int k = 0; k < newArray[0].Length; k++)
                {
                    int value = 0;

                    for (int ii = 0 + i; ii < 3 + i; ii++)
                    {
                        for (int kk = 0 + k; kk < 3 + k; kk++)
                        {
                            value += image[ii][kk];
                        }
                    }

                    newArray[i][k] = value / 9;
                }
            }

            int yNew = newArray.Length;
            int xNew = newArray[0].Length;
            Console.WriteLine($"x: {xNew} \ty: {yNew}");

            // newArrayOutput
            for (int i = 0; i < newArray.Length; i++)
            {
                for (int k = 0; k < newArray[0].Length; k++)
                {
                    Console.Write(newArray[i][k] + "\t");
                }
                Console.WriteLine();
            }

            return newArray;
        }

        public static int[][] minesweeper(bool[][] matrix)
        {
            int y = matrix.Length;
            int x = matrix[0].Length;

            int[][] newArray = new int[y][];

            // x (horizontal size)
            for (int i = 0; i < y; i++)
                newArray[i] = new int[x];


            for (int i = 0; i < newArray.Length; i++)
            {
                for (int k = 0; k < newArray[0].Length; k++)
                {
                    int value = 0;

                    for (int ii = -1 + i; ii < 2 + i; ii++)
                    {
                        for (int kk = -1 + k; kk < 2 + k; kk++)
                        {
                            try
                            {
                                if (!(i == ii && k == kk))
                                {
                                    if (matrix[ii][kk] == true) value++;
                                }
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                Console.WriteLine($"{e.Message}\nIndexOutOfRangeException: \nx: {kk} \ny: {ii}\n");
                            }
                        }
                    }

                    newArray[i][k] = value;
                }
            }

            return newArray;
        }

        public static int[] arrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (elemToReplace == inputArray[i])
                {
                    inputArray[i] = substitutionElem;
                }
            }

            return inputArray;
        }

        public static bool evenDigitsOnly(int n)
        {
            return n.ToString().All(item => item % 2 == 0);
        }

        public static bool variableName(string name)
        {
            Regex reg = new Regex("^[a-zA-Z][a-zA-Z0-9_]*$");
            return reg.IsMatch(name);
        }

        public static string alphabeticShift(string inputString)
        {
            string newString = String.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString.ElementAt(i).Equals('z'))
                    newString += 'a';
                else
                    newString += (char)((int)inputString.ElementAt(i) + 1);
            }

            return newString;
        }

        public static bool chessBoardCellColor(string cell1, string cell2)
        {
            cell1 = cell1.ToUpper();
            cell2 = cell2.ToUpper();
            int c1_Y, c2_Y, c1_X, c2_X;

            try
            {
                c1_Y = int.Parse(cell1[1].ToString());
                c2_Y = int.Parse(cell2[1].ToString());
                c1_X = (int)cell1.First() - 64;
                c2_X = (int)cell2.First() - 64;

                Console.WriteLine($"{cell1}: {c1_X} \tand   {c1_Y}\n" +
                                    $"{cell2}: {c2_X} \tand   {c2_Y}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            if (c1_Y > 8 || c1_X > 8 || c2_X > 8 || c2_Y > 8) return false;
            if (c1_Y < 0 || c1_Y < 0 || c1_Y < 0 || c1_Y < 0) return false;

            c1_Y += 2;
            c1_X += 2;
            c2_Y += 2;
            c2_X += 2;

            if (((c1_X + c1_Y) % 2 == 0) && ((c2_X + c2_Y) % 2 == 0)) return true;
            else if (((c1_X + c1_Y) % 3 == 0) && ((c2_X + c2_Y) % 3 == 0)) return true;
            else return false;
        }

        public static int circleOfNumbers(int n, int firstNumber)
        {
            if ((firstNumber + (n / 2)) < n)
                return firstNumber + n / 2;
            else
                return firstNumber - n / 2;
        }

        public static int depositProfit(int deposit, int rate, int threshold)
        {
            double depositDouble = deposit;
            int years = 0;

            if (deposit <= 0) return -1;
            if (deposit > threshold) return years;

            else
            {
                do
                {
                    depositDouble += (depositDouble * rate) / 100;
                    years++;
                } while (depositDouble < threshold);

                return years;
            }
        }

        public static int[] extractEachKth(int[] inputArray, int k)
        {
            List<int> newArray = new List<int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!((i + 1) % k == 0))
                {
                    newArray.Add(inputArray[i]);
                }
            }

            return newArray.ToArray();
        }

        public static char firstDigit(string inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] >= '0' && inputString[i] <= '9') return (char)inputString[i];
            }

            return '0';
        }

        public static int differentSymbolsNaive(string s)
        {
            List<char> listChar = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!listChar.Contains(s.ElementAt(i))) listChar.Add(s.ElementAt(i));
            }

            return listChar.Count;
        }

        public static int arrayMaxConsecutiveSum(int[] inputArray, int k)
        {
            int maxSum = 0;
            for (int i = 0; i + k <= inputArray.Length; i++)
            {
                int sum = 0;
                for (int n = i; n < k + i; n++)
                {
                    sum += inputArray[n];
                }

                Console.WriteLine($"iteration: {i}\t sum: {sum}");

                if (sum > maxSum) maxSum = sum;
            }

            return maxSum;
        }

        public static int growingPlant(int upSpeed, int downSpeed, int desiredHeight)
        {
            int height = 0;
            int day = 0;
            do
            {
                day++;
                height += upSpeed;

                if (height >= desiredHeight) break;

                height -= downSpeed;

            } while (height < desiredHeight);

            return day;
        }

        public static int knapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            if (weight1 <= maxW && weight2 <= maxW)
            {
                if ((weight1 + weight2) > maxW)
                {
                    if (value1 > value2)
                        return value1;
                    else
                        return value2;
                }
                else
                {
                    return value1 + value2;
                }
            }
            else if (weight1 <= maxW) return value1;
            else if (weight2 <= maxW) return value2;
            else
            {
                return 0;
            }
        }

        public static string longestDigitsPrefix(string inputString)
        {
            string prefix = String.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (!(inputString.ElementAt(i) >= '0' && inputString.ElementAt(i) <= '9'))
                {
                    break;
                }
                else
                {
                    prefix = String.Concat(prefix, inputString.ElementAt(i));
                }
            }

            return prefix;
        }

        public static int digitDegree(int n)
        {
            string nStr = n.ToString();
            int degree = 0;
            int value;

            while (nStr.Length > 1)
            {
                value = 0;

                for (int i = 0; i < nStr.Length; i++)
                    value += int.Parse(nStr.ElementAt(i).ToString());

                nStr = value.ToString();
                degree++;
            }

            return degree;
        }

        public static bool bishopAndPawn(string bishop, string pawn)
        {
            bishop = bishop.ToUpper();
            pawn = pawn.ToUpper();
            int b_Y, p_Y, b_X, p_X;

            try
            {
                b_Y = int.Parse(bishop[1].ToString());
                p_Y = int.Parse(pawn[1].ToString());
                b_X = (int)bishop.First() - 64;
                p_X = (int)pawn.First() - 64;

                Console.WriteLine($"{bishop}: bX: {b_X} \tand bY: {b_Y}\n" +
                                    $"{pawn}: pX: {p_X} \tand pY: {p_Y}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            if ((b_X - p_X) == 0)
            {
                Console.WriteLine("Divided by zero! False.");
                return false;
            }



            double slope = ((double)(b_Y - p_Y) / (double)(b_X - p_X));

            if (slope == 1 || slope == -1) return true;
            else return false;
        }

        public static bool isBeautifulString(string inputString)
        {
            for (int i = 'a'; i < 'z'; i++)
            {
                if (!(inputString.Count(x => x == i) >= inputString.Count(x => x == (char)(i + 1))))
                {
                    return false;
                }
            }

            return true;
        }

        public static string findEmailDomain(string address)
        {
            int atIndex = address.LastIndexOf('@') + 1;
            return address.Substring(atIndex);
        }

        public static string buildPalindrome(string st) // Not implemented yet
        {
            Console.WriteLine($"InputStr: {st}");
            string buildedString = string.Empty;
            bool startPalindrom = false;
            int indexOfStartPalindrom = 0;

            for (int i = 0, k = st.Length - 1; i < st.Length;)
            {
                if (i == k && startPalindrom == false)
                {
                    indexOfStartPalindrom = 0;
                    break;
                }

                if (st.ElementAt(i) == st.ElementAt(k))
                {
                    if (startPalindrom == false)
                    {
                        indexOfStartPalindrom = i;
                        startPalindrom = true;
                    }

                    i++; k--;
                }
                else
                {
                    i++;
                    startPalindrom = false;
                }

                if (i == (k + 1))
                {
                    break;
                }
            }

            return buildedString;
        }

        public static bool isDigit(char symbol)
        {
            Regex reg = new Regex("^[0-9]*$");
            if (reg.IsMatch(symbol.ToString())) return true;
            else return false;
        }

        public static string lineEncoding(string s)
        {
            string newString = string.Empty;
            char currentChar = s.ElementAt(0);
            int counterChar = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s.ElementAt(i) != currentChar)
                {
                    if (counterChar > 1)
                    {
                        newString += counterChar.ToString() + currentChar;
                        counterChar = 1;
                    }
                    else newString += currentChar;
                }
                else
                    counterChar++;

                currentChar = s.ElementAt(i);

                if (i == (s.Length - 1))
                {
                    if (counterChar == 1)
                        newString += s.ElementAt(i);
                    else
                        newString += counterChar.ToString() + s.ElementAt(i);
                }
            }

            return newString;
        }

        public static int chessKnight(string cell)
        {
            List<Point> points = new List<Point>();
            cell = cell.ToUpper();
            int cellX;
            int cellY;
            int countOfPossibleMoves = 0;

            try
            {
                cellX = cell.ElementAt(0) - 64;
                cellY = int.Parse(cell.ElementAt(1).ToString());

                points.Add(new Point(cellX - 2, cellY + 1));
                points.Add(new Point(cellX - 2, cellY - 1));

                points.Add(new Point(cellX + 2, cellY + 1));
                points.Add(new Point(cellX + 2, cellY - 1));

                points.Add(new Point(cellX + 1, cellY + 2));
                points.Add(new Point(cellX - 1, cellY + 2));

                points.Add(new Point(cellX + 1, cellY - 2));
                points.Add(new Point(cellX - 1, cellY - 2));
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (Point p in points)
            {
                if (p.x > 0 && p.x < 9 && p.y > 0 && p.y < 9) countOfPossibleMoves++;
            }

            return countOfPossibleMoves;
        }

        public struct Point
        {
            public int x, y;

            public Point(int X, int Y)
            {
                x = X;
                y = Y;
            }
        }

        public static int deleteDigit(int n)
        {
            int maximalDigit = 0;
            string nStr = n.ToString();

            for (int i = 0; i < nStr.Length; i++)
            {
                string newNumber = string.Empty;

                for (int k = 0; k < nStr.Length; k++)
                {
                    if (i != k)
                    {
                        newNumber += nStr.ElementAt(k);
                    }
                }

                int actualValue = int.Parse(newNumber);

                if (actualValue > maximalDigit) maximalDigit = actualValue;
            }

            return maximalDigit;
        }

        public static string longestWord(string text)
        {
            Regex reg = new Regex("^[a-zA-Z]$");
            List<string> listString = new List<string>();

            string newStr = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (reg.IsMatch(text.ElementAt(i).ToString()))
                {
                    newStr += text.ElementAt(i);
                }
                else
                {
                    listString.Add(newStr);
                    newStr = string.Empty;
                }
            }

            if (listString.Count == 0) listString.Add(newStr);

            return listString.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
        }

        public static bool validTime(string time)
        {
            Regex r0 = new Regex("^[0-1][0-9][:][0-5][0-9]$");
            Regex r1 = new Regex("^[2][0-3][:][0-5][0-9]$");

            return (r0.IsMatch(time) || r1.IsMatch(time));
        }

        public static int sumUpNumbers(string inputString)
        {
            Regex regex = new Regex("[0-9]");
            List<int> list = new List<int>();
            string number = string.Empty;
            int sum = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (regex.IsMatch(inputString[i].ToString()))
                {
                    number = number + inputString[i];

                    if (i == inputString.Length - 1)
                    {
                        list.Add(int.Parse(number));
                    }
                }
                else
                {
                    try
                    {
                        list.Add(int.Parse(number));
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    number = String.Empty;
                }
            }

            if (list.Count == 0)
            {
                try
                {
                    list.Add(int.Parse(number));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (int value in list)
            {
                sum += value;
            }

            return sum;
        }

        public static int differentSquares(int[][] matrix)
        {
            List<string> list = new List<string>();
            int x = matrix[0].Length;
            int y = matrix.Length;

            for (int i = 0; i < y - 1; i++)
            {
                for (int k = 0; k < x - 1; k++)
                {
                    string newStr = string.Empty;

                    for (int ii = i; ii < i + 2; ii++)
                    {
                        for (int kk = k; kk < k + 2; kk++)
                        {
                            newStr += matrix[ii][kk];
                        }
                    }

                    if (!list.Contains(newStr)) list.Add(newStr);
                }
            }

            foreach (string square in list)
            {
                Console.WriteLine(square);
            }

            return list.Count;
        }

        public static int digitsProduct(int product)
        {
            if (product == 0) return 10;
            if (product == 1) return 1;
            string digits = string.Empty;

            for (int divisor = 9; divisor > 1; divisor--)
            {
                while (product % divisor == 0)
                {
                    product /= divisor;
                    digits = divisor.ToString() + digits;
                }
            }

            if (product > 1) return -1;

            return int.Parse(digits);
        }

        public static string[] fileNaming(string[] names) // Not implemented yet
        {
            bool[] modified = new bool[names.Length];

            for (int i = 0; i < modified.Length; i++)
            {
                modified[i] = false;
            }

            for (int i = 0; i < names.Length; i++)
            {
                if (modified[i] != true)
                {
                    string loadElement = names.ElementAt(i);

                    for (int k = 0, index = 1; k < names.Length; k++)
                    {
                        if (i != k && names.ElementAt(k) == loadElement && modified[k] == false)
                        {
                            index = 1;
                            while (names.Contains(loadElement + $"({index})"))
                            {
                                index++;
                            }
                            names[k] = loadElement + $"({index})";
                            modified[k] = true;
                        }
                    }
                }
            }

            return names;
        }

        public static string messageFromBinaryCode(string code)
        {
            string binaryLetter = string.Empty;
            string outputMessage = string.Empty;

            for (int i = 0; i < code.Length; i++)
            {
                binaryLetter += code[i];

                if (i % 8 == 0)
                {
                    Console.WriteLine(binaryLetter);
                    Console.WriteLine(Convert.ToInt32(binaryLetter, 2));
                    outputMessage += (char)Convert.ToInt32(binaryLetter, 2);
                    binaryLetter = string.Empty;
                }
            }

            return outputMessage;
        }

        public static int[][] spiralNumbers(int n)
        {
            int items = n * n;
            int counter = 1;

            int[][] spiralNum = new int[n][];

            for (int i = 0; i < n; i++)
            {
                spiralNum[i] = new int[n];
            }

            int rightStart = 0, rightEnd = n - 1,
                downStart = 0, downEnd = n - 1,
                leftStart = n - 1, leftEnd = 0,
                upStart = n - 1, upEnd = 0;

            int yTop = 0, yBot = n - 1,
                xLeft = 0, xRight = n - 1;

            do
            {
                for (int i = rightStart; i <= rightEnd; i++)
                {
                    if (!(spiralNum[yTop][i] > 0))
                    {
                        spiralNum[yTop][i] = counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                yTop++; rightStart++; rightEnd--;


                downStart++;
                for (int i = downStart; i <= downEnd; i++)
                {
                    if (!(spiralNum[i][xRight] > 0))
                    {
                        spiralNum[i][xRight] = counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                xRight--; downEnd--;


                leftStart--;
                for (int i = leftStart; i >= leftEnd; i--)
                {
                    if (!(spiralNum[yBot][i] > 0))
                    {
                        spiralNum[yBot][i] = counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                yBot--; leftEnd++;


                upEnd++;
                for (int i = upStart - 1; i >= upEnd - 1; i--)
                {
                    if (!(spiralNum[i][xLeft] > 0))
                    {
                        spiralNum[i][xLeft] = counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                xLeft++; upStart--;


                if (counter > items)
                {
                    for (int y = 0; y < n; y++)
                    {
                        for (int x = 0; x < n; x++)
                        {
                            Console.Write(spiralNum[y][x] + "\t");
                        }
                        Console.WriteLine("\n");
                    }

                    return spiralNum;
                }
            } while (true);
        }

        public static bool sudoku(int[][] grid) // not implemented yet
        {
            bool isSudokuCorrect = true;

            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[0].Length; x++)
                {

                }
            }

            return isSudokuCorrect;
        }
    }
}
