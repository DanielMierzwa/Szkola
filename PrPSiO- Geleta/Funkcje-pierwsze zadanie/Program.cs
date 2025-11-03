using System.Linq;
using System;
using System.Collections.Generic;



public class Program
{
    public static void Main(string[] args)
    {
        bool flag = true;
        while (flag)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Wybierz podproblem:\n0)\n1)\n2)\n3)\n4)\n5)\n6)\n>");
            string input = Console.ReadLine();
            int number;
            if (!int.TryParse(input, out number)) 
            {
                number = -1;
            }
            int[] tab = getRandomTab(5);
            Random random = new Random();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            switch (number)
            {
                case 0:
                    Console.WriteLine("0)");
                    Console.WriteLine("WE: " + string.Join(", ", tab));
                    Console.WriteLine("WY: " + function0(tab));
                    break;
                case 1:
                    Console.WriteLine("1)");
                    Console.WriteLine("WE: " + string.Join(", ", tab));
                    Console.WriteLine("WY: " + string.Join(", ", function1(tab)));
                    break;
                case 2:
                    Console.WriteLine("2)");
                    Console.WriteLine("WE: " + tab[0].ToString() + ", " + tab[1].ToString());
                    Console.WriteLine("WY: " + function2(tab[0], tab[1]));
                    break;
                case 3:
                    int[] tab2 = { 1, 2, 3 };
                    Console.WriteLine("3)");
                    Console.WriteLine("WE: " + string.Join(", ", tab2));
                    Console.WriteLine("WY: " + function3(tab2));
                    break;
                case 4:
                    Console.WriteLine("4)");
                    Console.WriteLine("WE: " + string.Join(", ", tab));
                    Console.WriteLine("WY: " + string.Join(", ", function4(tab)));
                    break;
                case 5:
                    int mayPrime = random.Next(5, 40);
                    Console.WriteLine("5)");
                    Console.WriteLine("WE: " + mayPrime);
                    Console.WriteLine("WY: " + function5(mayPrime));
                    break;
                case 6:
                    int n = random.Next(1, 5);
                    Console.WriteLine("6)");
                    Console.WriteLine("WE: " + n);
                    Console.WriteLine("WY: " + function6(n));
                    break;
                default:
                    Console.WriteLine("exit");
                    flag = false;
                    break;
            }
            Console.WriteLine("\n>");
            Console.ReadLine();

        }
        Console.WriteLine("end=============");


        




    }

    private static int[] getRandomTab(int n)
    {
        Random random = new Random();
        int[] tablica = new int[n];

        for (int i = 0; i < n; i++)
        {
            tablica[i] = random.Next(1, 11);
        }

        return tablica;
    }
    private static int function0(int[] tab)
    {
        int minIndex = 0;
        int min = tab[0];
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i] < min)
            {
                minIndex = i;
                min = tab[i];
            }
        }
        return minIndex + 1;
    }
    private static int[] function1(int[] tab)
    {
        int[] result = tab;
        List<int> unsorted = new List<int>(tab);

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (int)unsorted[function0(unsorted.ToArray()) - 1];
            unsorted.Remove(result[i]);
        }

        return result;
    }

    private static float function2(float x, float y)
    {
        return (float)Math.Sqrt((double)(x * x + y * y));
    }

    public static double function3(int[] tab)
    {
        double med = 0;
        foreach (int x in tab)
        {
            med += x;
        }
        med /= tab.Length;

        double sumSqrt = 0;
        foreach (int x in tab)
        {
            sumSqrt += Math.Pow(x - med, 2);
        }

        return Math.Sqrt(sumSqrt / tab.Length);
    }

    private static int[] function4(int[] tab)
    {
        Array.Reverse(tab);
        return tab;
    }

    private static bool function5(int x)
    {
        for (int i = 2; i < x; i++)
        {
            if (x % i == 0) return false;
        }
        return true;
    }

    private static int function6(int n)
    {
        int sum = 0;
        for (int i = 0; i < n + 1; i++)
        {
            sum += i * (i + 1) * (i + 1);
        }

        return (int)sum;
    }
}