using System;
using System.Linq;
using System.Threading.Channels;

namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        int areaValida = Robos.Menu();

        Robos.PosicaoInicial(areaValida);

        while (true)
        {
            Robos.InstrucoesRobos(areaValida);

            Robos.OpcaoSair();
        }
    }
}
