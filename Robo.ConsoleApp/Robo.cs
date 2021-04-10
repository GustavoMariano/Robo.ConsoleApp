using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.ConsoleApp
{
    class Robo
    {
        public string localizacaoInicialRobo = "0 0 N"; //Localização inicial do robo
        public string movimentosRobo = ""; //Movimento do robo
        public string localizacaoFinalRobo = ""; //Localização que o robo parou

        char[] arrayTamanhoNave = new char[2];

        public void MovimentarRobo(string tamanhoNave)
        {
            int tamanhoHorizontalNave, tamanhoVerticalNave;

            for (int i = 0; i < tamanhoNave.Length; i++)
            {
                arrayTamanhoNave[i] =Convert.ToChar(tamanhoNave.Split(' '));

                Console.WriteLine(arrayTamanhoNave[i]);
            }            
        }
    }
}
