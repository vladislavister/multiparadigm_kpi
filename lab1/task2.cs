using System;

namespace vladislavister
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currWord = "";
            string[] wordsArr = new string[100000];
            string[,] pagesArr = new string[10000, 10000];
            int amountOfWords = 0;
            int amountOfRows = 0;
            int amountOfPages = 0;
            int amountOfWordsOnPage = 0;
            string text = File.ReadAllText(@"text.txt");
            int lengthOfText = text.Length;
            int i = 0;

        counter_point:
            if ((text[i] >= 65) && (text[i] <= 90) || (text[i] >= 97) && (text[i] <= 122)
                || text[i] == 45 || text[i] == 234 || text[i] == 225 || text[i] == 224)
            {
                if ((text[i] >= 65) && (text[i] <= 90))
                    currWord += (char)(text[i] + 32);
                else
                    currWord += text[i];
            }
            else
            {
                if (text[i] == '\n')
                    amountOfRows++;
                if (amountOfRows > 45)
                {
                    amountOfPages++;
                    amountOfWordsOnPage = 0;
                    amountOfRows = 0;
                }
                if (currWord != "" && currWord != null && currWord != "-"
                    && currWord != "no" && currWord != "from" && currWord != "the"
                    && currWord != "by" && currWord != "and" && currWord != "i"
                    && currWord != "in" && currWord != "or" && currWord != "any"
                    && currWord != "for" && currWord != "to" && currWord != "\""
                    && currWord != "a" && currWord != "on" && currWord != "of"
                    && currWord != "at" && currWord != "is" && currWord != "\n"
                    && currWord != "\r" && currWord != "\r\n" && currWord != "\n\r")
                {

                    wordsArr[amountOfWords] = currWord;
                    amountOfWords++;
                    pagesArr[amountOfPages, amountOfWordsOnPage] = currWord;
                    amountOfWordsOnPage++;
                }
                currWord = "";
            }
            i++;
            if (i < lengthOfText)
                goto counter_point;
            else
            {
                if (currWord != "" && currWord != null && currWord != "-"
                    && currWord != "no" && currWord != "from" && currWord != "the"
                    && currWord != "by" && currWord != "and" && currWord != "i"
                    && currWord != "in" && currWord != "or" && currWord != "any"
                    && currWord != "for" && currWord != "to" && currWord != "\""
                    && currWord != "a" && currWord != "on" && currWord != "of"
                    && currWord != "at" && currWord != "is" && currWord != "\n"
                    && currWord != "\r" && currWord != "\r\n" && currWord != "\n\r")
                {
                    wordsArr[amountOfWords] = currWord;
                    amountOfWords++;
                }
            }
            string[] wordsOnlyOnceArr = new string[100000];
            int[] wordsOnceCountArr = new int[100000];
            int amount_of_words = wordsArr.Length;
            i = 0;
            int insertPos = 0;
            int j = 0;
            int dubs = 0;

        outCount_point:
            insertPos = 0;
            int current_length = wordsOnlyOnceArr.Length;
            j = 0;
        innerCount_point:
            if (j < current_length && wordsOnlyOnceArr[j] != null)
            {
                if (wordsOnlyOnceArr[j] == wordsArr[i])
                {
                    insertPos = j;
                    goto endCount_point;
                }
                j++;
                goto innerCount_point;
            }
        endCount_point:
            if (insertPos == 0)
            {
                wordsOnlyOnceArr[i - dubs] = wordsArr[i];
                wordsOnceCountArr[i - dubs] = 1;
            }
            else
            {
                wordsOnceCountArr[insertPos] += 1;
                dubs++;
            }
            i++;
            if (i < amount_of_words && wordsArr[i] != null)
                goto outCount_point;

            int length = wordsOnceCountArr.Length;
            int k = 0;
            string[] wordsOnlyOnceArrLessThan100 = new string[100000];
            int LastInsert = 0;
        extensionHundred_point:
            if (k < length && wordsOnlyOnceArr[k] != null)
            {
                if (wordsOnceCountArr[k] <= 100)
                {
                    wordsOnlyOnceArrLessThan100[LastInsert] = wordsOnlyOnceArr[k];
                    LastInsert++;
                }
                k++;
                goto extensionHundred_point;
            }

            int write = 0;
            int sort = 0;
            bool toSwapWords = false;
            int counter = 0;
            int wordLenthCurren = 0;
            int wordLenthNext = 0;
        outerBubbleSort_point:
            if (write < wordsOnlyOnceArrLessThan100.Length && wordsOnlyOnceArrLessThan100[write] != null)
            {
                sort = 0;
            innerBubbleSort_point:
                if (sort < wordsOnlyOnceArrLessThan100.Length - write - 1 && wordsOnlyOnceArrLessThan100[sort + 1] != null)
                {
                    wordLenthCurren = wordsOnlyOnceArrLessThan100[sort].Length;
                    wordLenthNext = wordsOnlyOnceArrLessThan100[sort + 1].Length;

                    int compareLenth = wordLenthCurren > wordLenthNext ? wordLenthNext : wordLenthCurren;

                    toSwapWords = false;
                    counter = 0;
                check_alphabet:

                    if (wordsOnlyOnceArrLessThan100[sort][counter] > wordsOnlyOnceArrLessThan100[sort + 1][counter])
                    {
                        toSwapWords = true;
                        goto checkAlphabetEnd_point;
                    }
                    if (wordsOnlyOnceArrLessThan100[sort][counter] < wordsOnlyOnceArrLessThan100[sort + 1][counter])
                        goto checkAlphabetEnd_point;
                    counter++;
                    if (counter < compareLenth)
                        goto check_alphabet;
                    checkAlphabetEnd_point:
                    if (toSwapWords)
                    {
                        string temp = wordsOnlyOnceArrLessThan100[sort];
                        wordsOnlyOnceArrLessThan100[sort] = wordsOnlyOnceArrLessThan100[sort + 1];
                        wordsOnlyOnceArrLessThan100[sort + 1] = temp;
                    }
                    sort++;
                    goto innerBubbleSort_point;
                }
                write++;
                goto outerBubbleSort_point;
            }
            k = 0;
            int less_than_100_length = wordsOnlyOnceArrLessThan100.Length;
        print_point:
            if (k < less_than_100_length && wordsOnlyOnceArrLessThan100[k] != null)
            {
                Console.Write("{0} - ", wordsOnlyOnceArrLessThan100[k]);
                int firstDim = 0;
                int secondDim = 0;
                int[] wordPages = new int[100];
                int pageInsert = 0;

            checkPage_point:
                if (firstDim < 10000 && pagesArr[firstDim, 0] != null)
                {
                    secondDim = 0;
                checkPageWord_point:
                    if (secondDim < 10000 && pagesArr[firstDim, secondDim] != null)
                    {
                        if (pagesArr[firstDim, secondDim] == wordsOnlyOnceArrLessThan100[k])
                        {
                            wordPages[pageInsert] = firstDim + 1;
                            pageInsert++;
                            firstDim++;
                            goto checkPage_point;
                        }
                        secondDim++;
                        goto checkPageWord_point;
                    }

                    firstDim++;
                    goto checkPage_point;
                }
                int tiredCounte = 0;
            pagination_point:
                if (tiredCounte < 100 && wordPages[tiredCounte] != 0)
                {
                    if (tiredCounte != 99 && wordPages[tiredCounte + 1] != 0)
                        Console.Write("{0}, ", wordPages[tiredCounte]);
                    else
                        Console.Write("{0}", wordPages[tiredCounte]);
                    tiredCounte++;
                    goto pagination_point;
                }
                Console.WriteLine();
                k++;
                goto print_point;
            }
        }
    }
}
