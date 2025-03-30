using System;
using System.Linq;

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
                    Console.Write("\nCriando sua área de busca");

                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(00);
                    }

                    areaValida = area * area;

                    Console.WriteLine("\n\n-------------------------------------");
                    Console.WriteLine($"Sua area de busca é: {areaValida}m²");
                    Console.WriteLine("Mova o Robô de acordo.");
                    Console.WriteLine("-------------------------------------");
                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Digite apenas números maiores de zero");
                    Console.WriteLine("-------------------------------------");
                    Console.Write("Pressione ENTER para continuar");
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
            Console.WriteLine("Descreva a posição inicial do robô 1: ");
            Console.WriteLine("(ex: 0,0,N)");
            Console.SetCursorPosition(38, 1);

            string input1 = Console.ReadLine()!;

            string[] posicoes1 = input1.Split(' ', ',');

            Console.WriteLine();
            Console.WriteLine("Descreva a posição inicial do robô 2: ");
            Console.WriteLine("(ex: 0,0,N)");
            Console.SetCursorPosition(38, 3);

            string input2 = Console.ReadLine()!;

            string[] posicoes2 = input2.Split(' ', ',');

            //problema em digitar ', '(espaco e virgula) continuamente

            int posicaoInicialX1 = Convert.ToInt32(posicoes1[0]);
            int posicaoInicialY1 = Convert.ToInt32(posicoes1[1]);
            string olharInicial1 = posicoes1[2].ToUpper();

            int posicaoInicialX2 = Convert.ToInt32(posicoes2[0]);
            int posicaoInicialY2 = Convert.ToInt32(posicoes2[1]);
            string olharInicial2 = posicoes2[2].ToUpper();

            Console.WriteLine("A posição inicial do primeiro robô é:");
            Console.WriteLine($"X: {posicaoInicialX1}");
            Console.WriteLine($"Y: {posicaoInicialY1}");
            Console.WriteLine($"Direção: {olharInicial1}");

            Console.WriteLine("A posição inicial do segundo robô é:");
            Console.WriteLine($"X: {posicaoInicialX2}");
            Console.WriteLine($"Y: {posicaoInicialY2}");
            Console.WriteLine($"Direção: {olharInicial2}");

            if (posicaoInicialX1 > areaValida || posicaoInicialY1 > areaValida || posicaoInicialX2 > areaValida || posicaoInicialY2 > areaValida)
            {
                Console.Clear();
                Console.WriteLine("Posição inicial do robô é maior que a área de busca. Tente novamente.");
                Console.Write("Pressione ENTER para continuar");
                Console.ReadLine();
                continue;

            }
            else if (!("NSLO".Contains(olharInicial1)))
            {
                Console.Clear();
                Console.WriteLine($"O Ponto Cardial {olharInicial1} não existe, tente abreviado (N, S, L ou O). Tente novamente.");
                Console.Write("Pressione ENTER para continuar");
                Console.ReadLine();
                continue;

            }

            //robos instrucoes
            //char[] instrucoes = "E".ToCharArray();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nÁrea X: {areaValida}m² Área Y: {areaValida}m²");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("A posição inicial do primeiro robô é:");
                Console.WriteLine($"X: {posicaoInicialX1}");
                Console.WriteLine($"Y: {posicaoInicialY1}");
                Console.WriteLine($"Direção: {olharInicial1}");

                Console.SetCursorPosition(39, 3);
                Console.WriteLine("| A posição inicial do segundo robô é:");
                Console.SetCursorPosition(39, 4);
                Console.WriteLine($"| X: {posicaoInicialX2}");
                Console.SetCursorPosition(39, 5);
                Console.WriteLine($"| Y: {posicaoInicialY2}");
                Console.SetCursorPosition(39, 6);
                Console.WriteLine($"| Direção: {olharInicial2}");
                Console.WriteLine("------------------------------------------------------------------------------");

                Console.SetCursorPosition(10, 8);
                Console.WriteLine("x--------------x             |");
                Console.SetCursorPosition(10, 9);
                Console.WriteLine("| MOVIMENTAÇÃO |             |");
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("x--------------x             |");
                Console.WriteLine("----------------------------------------\n");
                Console.Write("Digite as instruções para o primeiro robô: ");
                string instrucoes1 = Console.ReadLine()!.ToUpper();
                Console.WriteLine();

                char[] instrucoesArray1 = instrucoes1.ToCharArray();

                string olharRobo1 = olharInicial1;
                int posicaoX1 = posicaoInicialX1;
                int posicaoY1 = posicaoInicialY1;

                foreach (char instrucao in instrucoesArray1)
                {
                    if (instrucao == 'E')
                    {
                        if (olharRobo1 == "N")
                            olharRobo1 = "O";

                        else if (olharRobo1 == "O")
                            olharRobo1 = "S";

                        else if (olharRobo1 == "S")
                            olharRobo1 = "L";

                        else if (olharRobo1 == "L")
                            olharRobo1 = "N";

                    }
                    else if (instrucao == 'D')
                    {
                        if (olharRobo1 == "N")
                            olharRobo1 = "L";

                        else if (olharRobo1 == "L")
                            olharRobo1 = "S";

                        else if (olharRobo1 == "S")
                            olharRobo1 = "O";

                        else if (olharRobo1 == "O")
                            olharRobo1 = "N";
                    }

                    else if (instrucao == 'M')
                    {
                        if (olharRobo1 == "N")
                            posicaoY1 += 1;

                        else if (olharRobo1 == "S")
                            posicaoY1 -= 1;

                        else if (olharRobo1 == "O")
                            posicaoX1 -= 1;

                        else if (olharRobo1 == "L")
                            posicaoX1 += 1;
                    }
                }

                Console.Write("Digite as instruções para o segundo robô: ");
                string instrucoes2 = Console.ReadLine()!.ToUpper();

                char[] instrucoesArray2 = instrucoes2.ToCharArray();

                string olharRobo2 = olharInicial2;
                int posicaoX2 = posicaoInicialX2;
                int posicaoY2 = posicaoInicialY2;

                foreach (char instrucao in instrucoesArray2)
                {
                    if (instrucao == 'E')
                    {
                        if (olharRobo2 == "N")
                            olharRobo2 = "O";

                        else if (olharRobo2 == "O")
                            olharRobo2 = "S";

                        else if (olharRobo2 == "S")
                            olharRobo2 = "L";

                        else if (olharRobo2 == "L")
                            olharRobo2 = "N";

                    }
                    else if (instrucao == 'D')
                    {
                        if (olharRobo2 == "N")
                            olharRobo2 = "L";

                        else if (olharRobo2 == "L")
                            olharRobo2 = "S";

                        else if (olharRobo2 == "S")
                            olharRobo2 = "O";

                        else if (olharRobo2 == "O")
                            olharRobo2 = "N";
                    }

                    else if (instrucao == 'M')
                    {
                        if (olharRobo2 == "N")
                            posicaoY2 += 1;

                        else if (olharRobo2 == "S")
                            posicaoY2 -= 1;

                        else if (olharRobo2 == "O")
                            posicaoX2 -= 1;

                        else if (olharRobo2 == "L")
                            posicaoX2 += 1;
                    }
                }

                if (posicaoX1 < 0 || posicaoY1 < 0 || posicaoX1 > areaValida || posicaoY1 > areaValida)
                {
                    Console.WriteLine($"A posição X: {posicaoX1}, Y: {posicaoY1} do robô 1 é inválida. Tente novamente.");
                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();
                    continue;

                }
                else if (posicaoX2 < 0 || posicaoY2 < 0 || posicaoX2 > areaValida || posicaoY2 > areaValida)
                {
                    Console.WriteLine($"A posição X: {posicaoX2}, Y: {posicaoY2} do robô 2 é inválida. Tente novamente.");
                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();
                    continue;

                }
                else if (!("NSLO".Contains(olharRobo1)) || !("NSLO".Contains(olharRobo2)))
                {
                    Console.WriteLine("O Ponto Cardial digitado não existe, tente abreviado (N, S, L ou O). Tente novamente.");
                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();
                    continue;

                }

                Console.Clear();
                Console.WriteLine($"\nÁrea X: {areaValida}m² Área Y: {areaValida}m²");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("A posição atual do primeiro robô é:");
                Console.WriteLine($"X: {posicaoX1}");
                Console.WriteLine($"Y: {posicaoY1}");
                Console.WriteLine($"Direção: {olharRobo1}");

                Console.SetCursorPosition(39, 3);
                Console.WriteLine("| A posição atual do segundo robô é:");
                Console.SetCursorPosition(39, 4);
                Console.WriteLine($"| X: {posicaoX2}");
                Console.SetCursorPosition(39, 5);
                Console.WriteLine($"| Y: {posicaoY2}");
                Console.SetCursorPosition(39, 6);
                Console.WriteLine($"| Direção: {olharRobo2}");
                Console.WriteLine($"------------------------------------------------------------------------------");

                Console.SetCursorPosition(10, 8);
                Console.WriteLine("x--------------x             |");
                Console.SetCursorPosition(10, 9);
                Console.WriteLine("| MOVIMENTAÇÃO |             |");
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("x--------------x             |");
                Console.WriteLine($"----------------------------------------");
                Console.WriteLine();

                olharInicial1 = olharRobo1;
                posicaoInicialX1 = posicaoX1;
                posicaoInicialY1 = posicaoY1;

                olharInicial2 = olharRobo2;
                posicaoInicialX2 = posicaoX2;
                posicaoInicialY2 = posicaoY2;


                Console.WriteLine("Deseja mover os robos mais uma vez? [S/N]");
                string opcaoContinuar = Console.ReadLine()!.ToUpper();

                if (opcaoContinuar != "S")
                    break;

                else
                {
                    Console.Clear();
                    Console.WriteLine($"\nÁrea X: {areaValida}m² Área Y: {areaValida}m²");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("A posição atual do primeiro robô é:");
                    Console.WriteLine($"X: {posicaoInicialX1}");
                    Console.WriteLine($"Y: {posicaoInicialY1}");
                    Console.WriteLine($"Direção: {olharInicial1}");

                    Console.SetCursorPosition(39, 3);
                    Console.WriteLine("| A posição atual do segundo robô é:");
                    Console.SetCursorPosition(39, 4);
                    Console.WriteLine($"| X: {posicaoInicialX2}");
                    Console.SetCursorPosition(39, 5);
                    Console.WriteLine($"| Y: {posicaoInicialY2}");
                    Console.SetCursorPosition(39, 6);
                    Console.WriteLine($"| Direção: {olharInicial2}");
                    Console.WriteLine("------------------------------------------------------------------------------");

                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine("x--------------x             |");
                    Console.SetCursorPosition(10, 9);
                    Console.WriteLine("| MOVIMENTAÇÃO |             |");
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine("x--------------x             |");
                    Console.WriteLine("----------------------------------------\n");
                    continue;
                }
            }

            break;
        }

    }
}
