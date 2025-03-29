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
                        Thread.Sleep(00);
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

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Área X: {areaValida}m² Área Y: {areaValida}m²");
            Console.WriteLine("Descreva a posição inicial do robô: ");
            Console.WriteLine("(ex: 0,0,N)");
            Console.SetCursorPosition(36, 1);

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

            }
            else if (!("NSLO".Contains(olharInicial)))
            {
                Console.WriteLine();
                Console.WriteLine("Este Ponto Cardial não existe, tente abreviado (N, S, L ou O). Tente novamente.");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
                continue;

            }

            //robo instrucoes
            //char[] instrucoes = "E".ToCharArray();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Área X: {areaValida}m² Área Y: {areaValida}m²");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("A posição inicial do robo é:");
            Console.WriteLine($"X: {posicaoInicialX}");
            Console.WriteLine($"Y: {posicaoInicialY}");
            Console.WriteLine($"Direção: {olharInicial}");
            Console.WriteLine();
            Console.WriteLine($"------------------------------");

            Console.SetCursorPosition(7, 10);
            Console.WriteLine("x--------------x");
            Console.SetCursorPosition(7, 11);
            Console.WriteLine("| MOVIMENTAÇÃO |");
            Console.SetCursorPosition(7, 12);
            Console.WriteLine("x--------------x");
            Console.WriteLine($"------------------------------");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"---------------------------------");
                Console.WriteLine("Digite as instruções para o robô: ");
                string instrucoes = Console.ReadLine()!.ToUpper();

                char[] instrucoesArray = instrucoes.ToCharArray();

                string olharRobo = olharInicial;
                int posicaoX = posicaoInicialX;
                int posicaoY = posicaoInicialY;

                foreach (char instrucao in instrucoesArray)
                {
                    if (instrucao == 'E')
                    {
                        if (olharRobo == "N")
                            olharRobo = "O";

                        else if (olharRobo == "O")
                            olharRobo = "S";

                        else if (olharRobo == "S")
                            olharRobo = "L";

                        else if (olharRobo == "L")
                            olharRobo = "N";

                    }
                    else if (instrucao == 'D')
                    {
                        if (olharRobo == "N")
                            olharRobo = "L";

                        else if (olharRobo == "L")
                            olharRobo = "S";

                        else if (olharRobo == "S")
                            olharRobo = "O";

                        else if (olharRobo == "O")
                            olharRobo = "N";
                    }

                    else if (instrucao == 'M')
                    {
                        if (olharRobo == "N")
                            posicaoY += 1;

                        else if (olharRobo == "S")
                            posicaoY -= 1;

                        else if (olharRobo == "O")
                            posicaoX -= 1;

                        else if (olharRobo == "L")
                            posicaoX += 1;
                    }
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"Área X: {areaValida}m² Área Y: {areaValida}m²");
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
                Console.WriteLine("A posição atual do robo é:");
                Console.WriteLine($"X: {posicaoX}");
                Console.WriteLine($"Y: {posicaoY}");
                Console.WriteLine($"Direção: {olharRobo}");
                Console.WriteLine();
                Console.WriteLine($"------------------------------");

                Console.SetCursorPosition(7, 10);
                Console.WriteLine("x--------------x");
                Console.SetCursorPosition(7, 11);
                Console.WriteLine("| MOVIMENTAÇÃO |");
                Console.SetCursorPosition(7, 12);
                Console.WriteLine("x--------------x");
                Console.WriteLine($"------------------------------");
                Console.WriteLine();

                olharInicial = olharRobo;
                posicaoInicialX = posicaoX;
                posicaoInicialY = posicaoY;

                Console.WriteLine("Deseja mover o robo novamente? [S/N]");
                string opcaoSair = Console.ReadLine()!.ToUpper();
                if (opcaoSair != "S")
                    break;
            }

            Console.ReadLine();
        }


    }

}
