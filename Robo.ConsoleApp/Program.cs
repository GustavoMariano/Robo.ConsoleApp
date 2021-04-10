using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tamanho da nave
            Console.WriteLine("Digite o tamanho da nave");

            string strTamanhoTerreno = Console.ReadLine();

            string[] numeros = strTamanhoTerreno.Split(' '); //Separando os membros em cada posição do array String

            int[] membrosSeparados = new int[2];

            for (int i = 0; i < membrosSeparados.Length; i++)
            {
                membrosSeparados[i] = Convert.ToInt32(numeros[i]);
            }

            int comprimentoNave = membrosSeparados[0]; // Posição 0 do array é o comprimento da nave.

            int larguraNave = membrosSeparados[1];// Posição 1 do array é a largura da nave.

            #endregion

            #region Localização do Robo
            char auxVisaoRobo = ' ';

            Console.WriteLine("Digite a localização inicial do robo 1");

            string strLocalizacaoInicialRobo = Console.ReadLine().ToUpper();

            string[] pontoInicial = strLocalizacaoInicialRobo.Split(' '); //Separando os membros em cada posição do array String

            int[] pontoInicialRoboSeparado = new int[3];

            for(int i = 0; i < pontoInicial.Length; i++)
            {
                bool ehNumero = Int32.TryParse(pontoInicial[i], out pontoInicialRoboSeparado[i]);

                if(ehNumero != true)
                {
                    switch (pontoInicial[i]) //Atribuindo a letra (N, S, L , O) inserida pelo usuario a uma variavel
                    {
                        case "N": auxVisaoRobo = 'N'; break;
                        case "S": auxVisaoRobo = 'S'; break;
                        case "L": auxVisaoRobo = 'L'; break;
                        case "O": auxVisaoRobo = 'O'; break;
                        default:
                            break;
                    }
                }
                else
                {
                    pontoInicialRoboSeparado[i] = Convert.ToInt32(pontoInicial[i]); //Atribuindo o primeiro e segundo numero na array pontoInicialRoboSeparado
                }                                
            }

            int posicaoRoboComprimento = pontoInicialRoboSeparado[0];// Posição 0 do array é o a posição do robo no comprimento da nave.

            int posicaoRoboLargura = pontoInicialRoboSeparado[1]; // Posição 1 do array é o a posição do robo na largura da nave.

            #endregion

            #region Movimentando o Robo
            Console.WriteLine("Digite os movimentos que o robo 1 deve realizar");

            string strMovimentosRobo = Console.ReadLine().ToUpper();

            char[] movimentosRobo = strMovimentosRobo.ToCharArray(); //Carregando a posição inicial do robo em uma array

            for (int i = 0; i < movimentosRobo.Length; i++)
            {
                 //Armazena o lado para onde o robo estará olhando
                int percursoRoboComprimento = 0;
                int percursoRoboLargura = 0;
            }
            #endregion
        }
    }
}
