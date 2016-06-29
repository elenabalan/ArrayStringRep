using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArrayTasks
{
    class Program
    {
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0}  ", arr[i]);
            Console.WriteLine();
        }
        public static void PrintTable(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i,j]+"\t");
                Console.WriteLine();
            }
        }

        #region Delete Even Numbers
        public static int[] DeleteEvenElements(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 == 0)
                {
                    Array.Clear(arr, i, 1);
                    count++;
                }
            int[] rez = new int[arr.Length - count];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0)
                {
                    rez[j] = arr[i];
                    j++;
                }
            return rez;
        }
        #endregion

        #region Insert 777 after all elements beginning with the digit 5
        public static int[] Insert777After5(int[] arr)
        {
            int count = 0;
            string[] temp = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i].ToString();
                if (Equals(temp[i].Substring(0, 1), "5"))
                    count++;
            }
            Console.WriteLine(count);
            int[] rez = new int[arr.Length + count];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                rez[j] = arr[i];
                j++;
                if (temp[i][0] == '5')
                {
                    rez[j] = 777;
                    j++;
                }
            }

            return rez;
        }
        #endregion

        #region Delete repeatings elements
        public static int[] DeleteRepeatingElements(int[] arr)
        {
            int count = 0;
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    for (j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            Array.Clear(arr, j, 1);
                            count++;
                        }
                    }
            }

            int[] rez = new int[arr.Length - count];
            j = 0;
                
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0)
                {
                    rez[j] = arr[i];
                    j++;
                }
            return rez;
        }
        #endregion

        #region Minimal element in 2-Dim table  ------    Insert a row
        public static int[,] InsertLineAfterMin(int[,] arr)
        {
            int targetRow = 0;
            int min=arr[0,0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if ( arr[i, j]<min)
                    {
                        min = arr[i, j];
                        targetRow = i;
                    }
            }
            //Console.WriteLine("min= {0}",min);
            //Console.WriteLine("targetRow= {0}", targetRow);

            int[,] rez = new int[arr.GetLength(0) + 1, arr.GetLength(1)];
            //Console.WriteLine("arr.GetLengt(0)= {0}, rez.GetLengt(0)= {1}", arr.GetLength(0),rez.GetLength(0));
            //Console.WriteLine("arr.GetLengt(1)= {0}, rez.GetLengt(1)= {1}", arr.GetLength(1),rez.GetLength(1));

            int ir = 0;
            int jr;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                jr = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    rez[ir, jr] = arr[i, j];
                    jr++;
                }
                
                ir++;
                if (i == targetRow)
                {
                    for (jr = 0; jr < arr.GetLength(1); jr++)
                        rez[ir, jr] = 77;
                    ir++;
                }    
            }

            return rez;
        }
        #endregion

        #region Delete all columns, containing only positive elements
        public static int[,] DeleteColPozElem(int[,] arr)
        {
            int[,] temp;
            bool exist = false;
            int row = 0;
            int countPoz=0;
            int countDeleteRow = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                countPoz = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    if (arr[i, j] > 0) countPoz++;

                if (countPoz == arr.GetLength(0))
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                        arr[i, j] = 0;
                    countDeleteRow++;
                }
            }

           // PrintTable(arr);
            int[,] rez = new int[arr.GetLength(0), arr.GetLength(1) - countDeleteRow];
          //  Console.WriteLine("Dimensiuneile : {0}  {1}", rez.GetLength(0), rez.GetLength(1));
            int ir=0, jr=0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int countZero = 0;
                //ir = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    if (arr[i, j] == 0) countZero++;
                if (countZero != arr.GetLength(0))
                {
                    ir = 0;
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        //Console.WriteLine("ir={0}  ,  jr= {1}", ir, jr);
                        rez[ir, jr] = arr[i, j];
                        ir++;
                    }
                    jr++;
                }
                
            }
            return rez;
        }
        #endregion
        static void Main(string[] args)
        {
            #region one-dimensional array of integers 
            Console.WriteLine("--------- ONE-DIMENSIONAL ARRAY -------------");
            Console.WriteLine("****   Delete all even numbers    ****");
            int[] n = new int[10] { 9, 5, 4, 7, 6, 3, 2, 8, 9, 4 }; //n.Length = 10
            
            PrintArray(n);
            int[] delN = DeleteEvenElements(n);
            PrintArray(delN);


            Console.WriteLine("****   Insert new element after all elements beginning with the indicated digit    ****");
            int[] n2 = new int[] { 12, 59, 5, 78, 63, 345, 558, 6987, 145 };
            PrintArray(n2);
            int[] insertN = Insert777After5(n2);
            PrintArray(insertN);


            Console.WriteLine("****   Delete from array all repeating elements except of their first occurrence.   ****");
            int[] n3 = new int[10] { 9, 7, 4, 7, 6, 3, 2, 7, 9, 4 }; //n.Length = 10

            PrintArray(n3);
            int[] delRepeat = DeleteRepeatingElements(n3);
            PrintArray(delRepeat);
            #endregion

            #region two-dimensional array of integers 

            Console.WriteLine("--------- TWO-DIMENSIONAL ARRAY -------------");
            Console.WriteLine();
            Console.WriteLine("****   Insert new line after line containing the first occurrence of the minimal element    ****");
            int[,] table = new int[4,3] { { 4, 5, 9 }, { 6, 2, 5 }, { 7, 3, 1 }, { 1, 9, 1 } };
            PrintTable(table);
            Console.WriteLine();
            int[,] insertLine = InsertLineAfterMin(table);
            PrintTable(insertLine);

            Console.WriteLine();
            Console.WriteLine("****   Delete all columns, containing only positive elements    ****");
            int[,] table3 = new int[,] { { -4, 5, 9, 9 }, 
                                         { 6, 2, 5, 5 }, 
                                         { 7, 3, 1, 7 }, 
                                         { 1, 9, 1, -88 } };
            PrintTable(table3);
            Console.WriteLine();
            int[,] DeleteRow = DeleteColPozElem(table3);
            PrintTable(DeleteRow);
            #endregion

            Console.ReadKey();
                
        }
    }
}
