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
            int contadorRobos = 1;

            while (true)
            {
                char[] auxVisaoRobo = new char[2];
                int[] posicaoX = new int[2];
                int[] posicaoY = new int[2];


                #region Tamanho da nave
                Console.WriteLine("Digite o tamanho da nave (Q para sair)");

                string strTamanhoTerreno = Console.ReadLine();

                if (EhOpcaoSair(strTamanhoTerreno))
                {
                    break;
                }

                string[] numeros = SeparaLetrasENumeros(strTamanhoTerreno); //Separando os membros em cada posição do array String

                int[] membrosSeparados = new int[2]; //Criação de array para armazenar os numeros

                CarregaArrayComNumeros(numeros, membrosSeparados);

                ArmazenaXYEmInt(membrosSeparados); //Separa X e Y da array e guarda em variavel int

                #endregion

                #region Localização do Robo 
                for (int c = 0; c < 2; c++)
                {
                    SolicitaPosicacaoRobo(); //Solicita a posição do robo opção de sair

                    string strLocalizacaoInicialRobo = Console.ReadLine().ToUpper(); //Deixa em maiuscula todas as letras

                    string[] pontoInicial = SeparaLetrasENumeros(strLocalizacaoInicialRobo); //Separando os membros em cada posição do array String

                    int[] pontoInicialRoboSeparado = new int[3];

                    for (int i = 0; i < pontoInicial.Length; i++)
                    {
                        bool ehNumero = VerificaSeEhNumero(pontoInicial, pontoInicialRoboSeparado, i);

                        AtribuiNumerosELetrasParaArrayCorreta(auxVisaoRobo, c, pontoInicial, pontoInicialRoboSeparado, i, ehNumero);

                        posicaoY[c] = pontoInicialRoboSeparado[1];// Posição 0 do array é o a posição do robo no comprimento da nave.

                        posicaoX[c] = pontoInicialRoboSeparado[0]; // Posição 1 do array é o a posição do robo na largura da nave.
                    }

                    #endregion

                    #region Movimentando o Robo
                    SolicitaMovimentoRobos();

                    string strMovimentosRobo = Console.ReadLine().ToUpper();

                    char[] movimentosRobo = strMovimentosRobo.ToCharArray(); //Carregando a posição inicial do robo em uma array

                    for (int i = 0; i < movimentosRobo.Length; i++)
                    {

                        if (EhEsquerda(movimentosRobo, i))
                        {
                            PreencheCharParaEsquerda(auxVisaoRobo, c);
                        }
                        else if (EhDireita(movimentosRobo, i))
                        {
                            PreencheCharParaDireita(auxVisaoRobo, c);
                        }
                        else
                        {
                            MovimentaRobo(auxVisaoRobo, posicaoX, posicaoY, c);
                        }
                    }
                    contadorRobos++;

                    // ------ Mostrar um de cada vez
                    //MostraPosicaoFinal(auxVisaoRobo, posicaoX, posicaoY, c); 

                }
                for (int i = 0; i < 2; i++)
                {
                    MostraPosicaoFinal(auxVisaoRobo, posicaoX, posicaoY, i);
                }

                Console.ReadLine();

                Console.Clear();
                #endregion

                contadorRobos = 1; //Reseta contador quando While recomeça.
            }

            #region Funções

            void SolicitaPosicacaoRobo()
            {
                Console.WriteLine($"Digite a localização inicial do robo {contadorRobos}");
            }

            void SolicitaMovimentoRobos()
            {
                Console.WriteLine($"Digite os movimentos que o robo {contadorRobos} deve realizar");
            }

            #endregion
        }

        #region Metodos

        private static void MovimentaRobo(char[] auxVisaoRobo, int[] posicaoX, int[] posicaoY, int c)
        {
            switch (auxVisaoRobo[c])
            {
                case 'N': posicaoY[c]++; break;
                case 'S': posicaoY[c]--; break;
                case 'L': posicaoX[c]++; break;
                case 'O': posicaoX[c]--; break;
                default:
                    break;
            }
        }

        private static void PreencheCharParaDireita(char[] auxVisaoRobo, int c)
        {
            switch (auxVisaoRobo[c])
            {
                case 'N': auxVisaoRobo[c] = 'L'; break;
                case 'S': auxVisaoRobo[c] = 'O'; break;
                case 'L': auxVisaoRobo[c] = 'S'; break;
                case 'O': auxVisaoRobo[c] = 'N'; break;
                default:
                    break;
            }
        }

        private static void PreencheCharParaEsquerda(char[] auxVisaoRobo, int c)
        {
            switch (auxVisaoRobo[c])
            {
                case 'N': auxVisaoRobo[c] = 'O'; break;
                case 'S': auxVisaoRobo[c] = 'L'; break;
                case 'L': auxVisaoRobo[c] = 'N'; break;
                case 'O': auxVisaoRobo[c] = 'S'; break;
                default:
                    break;
            }
        }

        private static bool EhDireita(char[] movimentosRobo, int i)
        {
            return movimentosRobo[i] == 'D';
        }

        private static bool EhEsquerda(char[] movimentosRobo, int i)
        {
            return movimentosRobo[i] == 'E';
        }

        private static void MostraPosicaoFinal(char[] auxVisaoRobo, int[] posicaoX, int[] posicaoY, int i)
        {
            Console.WriteLine($"{posicaoX[i]} {posicaoY[i]} {auxVisaoRobo[i]}");
        }

        private static bool VerificaSeEhNumero(string[] pontoInicial, int[] pontoInicialRoboSeparado, int i)
        {
            return Int32.TryParse(pontoInicial[i], out pontoInicialRoboSeparado[i]);
        }

        private static void AtribuiNumerosELetrasParaArrayCorreta(char[] auxVisaoRobo, int c, string[] pontoInicial, int[] pontoInicialRoboSeparado, int i, bool ehNumero)
        {
            if (ehNumero != true)
            {
                switch (pontoInicial[i]) //Atribuindo a letra (N, S, L , O) inserida pelo usuario a uma variavel
                {
                    case "N": auxVisaoRobo[c] = 'N'; break;
                    case "S": auxVisaoRobo[c] = 'S'; break;
                    case "L": auxVisaoRobo[c] = 'L'; break;
                    case "O": auxVisaoRobo[c] = 'O'; break;
                    default:
                        break;
                }
            }
            else
            {
                pontoInicialRoboSeparado[i] = Convert.ToInt32(pontoInicial[i]); //Atribuindo o primeiro e segundo numero na array pontoInicialRoboSeparado
            }
        }

        private static void ArmazenaXYEmInt(int[] membrosSeparados)
        {
            int posicaoXNave = membrosSeparados[0];

            int posicaoYNave = membrosSeparados[1];
        }

        private static void CarregaArrayComNumeros(string[] numeros, int[] membrosSeparados)
        {
            for (int i = 0; i < membrosSeparados.Length; i++)
            {
                membrosSeparados[i] = Convert.ToInt32(numeros[i]);
            }
        }

        private static string[] SeparaLetrasENumeros(string str)
        {
            return str.Split(' ');
        }

        private static bool EhOpcaoSair(string strTamanhoTerreno)
        {
            return strTamanhoTerreno.Equals("q", StringComparison.OrdinalIgnoreCase);
        }
        #endregion
    }
}
