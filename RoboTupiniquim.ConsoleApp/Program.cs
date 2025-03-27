using System;

namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            //menu
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Digite o tamanho da Área em que os Robôs andarão: ");
            Console.WriteLine("--------------------------------------------------");
            Console.SetCursorPosition(50, 1);
            int area = Convert.ToInt32(Console.ReadLine())!;

            int areaValida;

            if (int.TryParse(Convert.ToString(area), out areaValida))
            {
                if (areaValida > 0)
                {
                    Console.WriteLine();
                    Console.Write("Criando sua área de busca");

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(00);
                    }

                    areaValida = area * area;

                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Sua area de busca é: {areaValida}");
                    Console.WriteLine("-------------------------------------");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Digite apenas números maiores de zero");
                    Console.WriteLine("-------------------------------------");
                    Console.ReadLine();
                    continue;
                }
                
            }
            //robo



        }
        Console.ReadLine();
    }
}
