namespace RoboTupiniquim.ConsoleApp;
public class Robos
{
    public static int posicaoInicialX1 = 0;
    public static int posicaoInicialY1 = 0;
    public static string olharInicial1 = "";

    public static int posicaoInicialX2 = 0;
    public static int posicaoInicialY2 = 0;
    public static string olharInicial2 = "";

    public static int Menu()
    {
        int areaValida;
        Console.Clear();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Digite o tamanho da área em metros onde os robôs irão se movimentar ");
        Console.WriteLine("(ex: 5 para uma área de 5x5 metros)");
        Console.WriteLine("--------------------------------------------------");
        int area = Convert.ToInt32(Console.ReadLine())!;

        if (int.TryParse(Convert.ToString(area), out areaValida))
        {
            if (areaValida > 0)
            {
                Console.Write("\nCriando sua área de busca");

                for (int i = 0; i < 3; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(400);
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
                return Menu(); //tentar novamente
            }
        }
        else
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Entrada inválida. Digite apenas números.");
            Console.WriteLine("-------------------------------------");
            Console.Write("Pressione ENTER para continuar");
            Console.ReadLine();
            return Menu();
        }

        return areaValida;
    }

    public static (string[], string[]) PosicaoInicial(int areaValida)
    {
        Console.Clear();
        Console.WriteLine($"Área X: {areaValida}m² Área Y: {areaValida}m²");
        Console.WriteLine("Descreva a posição inicial primeiro robô: ");
        Console.WriteLine("(ex: 0,0,N)");
        Console.SetCursorPosition(42, 1);

        string input1 = Console.ReadLine()!;

        string[] posicoes1 = input1.Split(' ', ',');

        Robos.posicaoInicialX1 = Convert.ToInt32(posicoes1[0]);
        Robos.posicaoInicialY1 = Convert.ToInt32(posicoes1[1]);
        Robos.olharInicial1 = posicoes1[2].ToUpper();

        Console.WriteLine("\nDescreva a posição inicial segundo robô: ");
        Console.WriteLine("(ex: 0,0,N)");
        Console.SetCursorPosition(41, 3);

        string input2 = Console.ReadLine()!;

        string[] posicoes2 = input2.Split(' ', ',');

        Robos.posicaoInicialX2 = Convert.ToInt32(posicoes2[0]);
        Robos.posicaoInicialY2 = Convert.ToInt32(posicoes2[1]);
        Robos.olharInicial2 = posicoes2[2].ToUpper();

        Console.WriteLine($"\nÁrea X: {areaValida}m² Área Y: {areaValida}m²");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("A posição inicial do primeiro robô é:");
        Console.WriteLine($"X: {Robos.posicaoInicialX1}");
        Console.WriteLine($"Y: {Robos.posicaoInicialY1}");
        Console.WriteLine($"Direção: {Robos.olharInicial1}");

        Console.SetCursorPosition(39, 3);
        Console.WriteLine("| A posição inicial do segundo robô é:");
        Console.SetCursorPosition(39, 4);
        Console.WriteLine($"| X: {Robos.posicaoInicialX2}");
        Console.SetCursorPosition(39, 5);
        Console.WriteLine($"| Y: {Robos.posicaoInicialY2}");
        Console.SetCursorPosition(39, 6);
        Console.WriteLine($"| Direção: {Robos.olharInicial2}");
        Console.WriteLine("------------------------------------------------------------------------------");

        if (Robos.posicaoInicialX1 > areaValida || Robos.posicaoInicialY1 > areaValida)
        {
            Console.Clear();
            Console.WriteLine("Posição inicial do robô é maior que a área de busca. Tente novamente.");
            Console.Write("Pressione ENTER para continuar");
            Console.ReadLine();
        }
        else if (!("NSLO".Contains(Robos.olharInicial1)) || !("NSLO".Contains(Robos.olharInicial2)))
        {
            Console.Clear();
            Console.WriteLine($"O Ponto Cardial {Robos.olharInicial1} não existe, tente abreviado (N, S, L ou O). Tente novamente.");
            Console.Write("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        return (posicoes1, posicoes2);
    }

    public static (string, string) InstrucoesRobos(int areaValida)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"\nÁrea X: {areaValida}m² Área Y: {areaValida}m²");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("A posição inicial do primeiro robô é:");
            Console.WriteLine($"X: {Robos.posicaoInicialX1}");
            Console.WriteLine($"Y: {Robos.posicaoInicialY1}");
            Console.WriteLine($"Direção: {Robos.olharInicial1}");

            Console.SetCursorPosition(39, 3);
            Console.WriteLine("| A posição inicial do segundo robô é:");
            Console.SetCursorPosition(39, 4);
            Console.WriteLine($"| X: {Robos.posicaoInicialX2}");
            Console.SetCursorPosition(39, 5);
            Console.WriteLine($"| Y: {Robos.posicaoInicialY2}");
            Console.SetCursorPosition(39, 6);
            Console.WriteLine($"| Direção: {Robos.olharInicial2}");
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

            string olharRobo1 = Robos.olharInicial1;
            int posicaoX1 = Robos.posicaoInicialX1;
            int posicaoY1 = Robos.posicaoInicialY1;

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

            string olharRobo2 = Robos.olharInicial2;
            int posicaoX2 = Robos.posicaoInicialX2;
            int posicaoY2 = Robos.posicaoInicialY2;

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

            Robos.olharInicial1 = olharRobo1;
            Robos.posicaoInicialX1 = posicaoX1;
            Robos.posicaoInicialY1 = posicaoY1;

            Robos.olharInicial2 = olharRobo2;
            Robos.posicaoInicialX2 = posicaoX2;
            Robos.posicaoInicialY2 = posicaoY2;

            return (instrucoes1, instrucoes2);
        }
    }

    public static bool OpcaoSair()
    {
        Console.WriteLine("Deseja movimentar o robo novamente? [S/N] ");
        string opcaoSair = Console.ReadLine()!.ToUpper();

        if (opcaoSair != "S")
            return true;

        else
            return false;
    }

}
