using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozniczkowanieNumeryczne
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tab_x = new double[] {0.2,0.5,0.8,1.1,1.4,1.7,2};
            double[][] tab_fx = new double[tab_x.Length][];
            int i,j;
            tab_fx[0] = new double[] {5,2.5,1.56,1.15,1.1,0.8,0.6};
            for (i=1;i< tab_x.Length; i++)
            {
                tab_fx[i] = new double[tab_x.Length - i];
            }

            for (i = 1; i < tab_x.Length ; i++)
            {
                for (j = 0; j < tab_fx[i].Length; j++)
                {
                    tab_fx[i][j] = tab_fx[i - 1][j + 1] - tab_fx[i - 1][j];
                }
            }

            for (i = 0; i < tab_x.Length; i++)
            {
                    Console.ForegroundColor = ConsoleColor.White;
                if (i>0)
                    System.Console.Write($"d^{i}f(x)");
                else
                    System.Console.Write($"f(x)   ");
                for (j = 0; j < tab_fx[i].Length; j++)
                {
                        Console.ForegroundColor = ConsoleColor.White;
                    if (j== tab_fx[i].Length-1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write("{0,12:N5} ", tab_fx[i][j]);
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            double h = tab_x[1] - tab_x[0];
            double wynik=0;
            string napis="f^(1)= "+1/h+"[";
            Console.ForegroundColor = ConsoleColor.White;
            for (i=1;i<tab_x.Length;i++)
            {
                if(tab_fx[i][tab_fx[i].Length - 1]<0)
                    napis += "1/" + i + " * " + "("+Math.Round((tab_fx[i][tab_fx[i].Length - 1]),5)+ ")" + "  " ;
                else
                    napis +="1/"+  i + " * " + Math.Round((tab_fx[i][tab_fx[i].Length - 1]), 5) + "  ";
                if (i < tab_x.Length - 1)
                    napis += " + ";
                wynik =wynik + (1.0/i)*(tab_fx[i][tab_fx[i].Length-1]);
            }
            wynik = wynik * (1 / h);
            napis += "]= " + Math.Round(wynik,5);
            System.Console.WriteLine(napis);
            Console.ReadKey();
        }
    }
}
