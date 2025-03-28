using System;

namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        int areaValida;

        while (true)
        {
            //menu
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Digite o tamanho da Área em que os Robôs andarão: ");
            Console.WriteLine("--------------------------------------------------");
            Console.SetCursorPosition(50, 1);
            int area = Convert.ToInt32(Console.ReadLine())!;

            

            if (int.TryParse(Convert.ToString(area), out areaValida))
            {
                if (areaValida > 0)
                {
                    Console.WriteLine();
                    Console.Write("Criando sua área de busca");

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(400);
                    }

                    areaValida = area * area;

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Sua area de busca é: {areaValida}m²");
                    Console.WriteLine("Mova o Robô de acordo.");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Digite apenas números maiores de zero");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadLine();
                    continue;
                }

            }

            break;
        }

        //robo posicao inicial
        //char[] instrucoes = "E".ToCharArray();

        while (true)
        { 
            Console.Clear();
            Console.WriteLine($"Área X: {areaValida}m² Área Y: {areaValida}m²");

            Console.Write("Descreva a posição inicial do robô: ");
            Console.WriteLine("(ex: 0,0,N)");
            string input = Console.ReadLine()!;

            string[] posicoes = input.Split(' ', ',');

            //problema em digitar ', '(espaco e virgula) continuamente

            int posicaoInicialX = Convert.ToInt32(posicoes[0]);
            int posicaoInicialY = Convert.ToInt32(posicoes[1]);
            string olharInicial = posicoes[2].ToUpper();

            Console.WriteLine("A posição inicial do robo é:");
            Console.WriteLine($"X: {posicaoInicialX}");
            Console.WriteLine($"Y: {posicaoInicialY}");
            Console.WriteLine($"Direção: {olharInicial}");

            if (posicaoInicialX > areaValida || posicaoInicialY > areaValida)
            {
                Console.WriteLine();
                Console.WriteLine("Posição inicial do robô é maior que a área de busca. Tente novamente.");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
                continue;

            } else if (!("NSLO".Contains(olharInicial)))
            {
                Console.WriteLine();
                Console.WriteLine("Este Ponto Cardial não existe, tente abreviado (N, S, L ou O). Tente novamente.");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
                continue;

            }









                Console.ReadLine();
        }

    }
}
