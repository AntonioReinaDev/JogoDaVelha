using System;

namespace JogoVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] sharp = new string[3, 3];
            string escolha, Jogador1 = null, Jogador2 = null;
            int velha = 0, Jogador_1 = 0, Jogador_2 = 0, vezPlayer = 0;
            bool vencedor1 = false, vencedor2 = false;

            escolha = Menu();
            if (escolha == "1" || escolha == "SIM")
            {
                Console.Write("Informe o nome do jogador 1: ");
                Jogador1 = Console.ReadLine();
                Console.Write("Informe o nome do jogador 2: ");
                Jogador2 = Console.ReadLine();
                Console.Clear();
                PosicoesMatriz(sharp);
            }
            while (escolha == "1" || escolha == "SIM")
            {
                Console.Clear();
                Console.WriteLine($"Pontuação - {Jogador1}:{Jogador_1} - {Jogador2}:{Jogador_2} - Velha:{velha}\n\n");
                MostraSharp(sharp);
                vezPlayer = VezJogador(vezPlayer, Jogador1, Jogador2);
                VerificaPosicao(sharp, vezPlayer);
                if (vezPlayer >= 5)
                {
                    vencedor1 = VerificaJogador1(sharp, Jogador1, vencedor1);
                    vencedor2 = VerificaJogador2(sharp, Jogador2, vencedor2);
                    if (vencedor1 == true)
                    {
                        Console.WriteLine($" ----- O JOGADOR {Jogador1} GANHOU! ----- ");
                        Jogador_1++;
                        PosicoesMatriz(sharp);
                        vencedor1 = false;
                        escolha = Menu();
                    }
                    else if (vencedor2 == true)
                    {
                        Console.WriteLine($" ----- O JOGADOR {Jogador2} GANHOU! ----- ");
                        Jogador_2++;
                        PosicoesMatriz(sharp);
                        vencedor2 = false;
                        escolha = Menu();
                    }
                    else if ((vencedor1 == false && vencedor2 == false) && Velha(sharp) == true)
                    {
                        Console.WriteLine(" ---- VELHA ---- ");
                        velha++;
                        PosicoesMatriz(sharp);
                        escolha = Menu();
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("-------------------- JOGO FINALIZADO --------------------");
            Console.ReadLine();
        }
        public static string Menu()
        {
            Console.WriteLine("Deseja um novo jogo? [1 - Sim] [2 - Não]");
            string escolha = Console.ReadLine().ToUpper();
            return escolha;
        }
        public static bool Velha(string[,] sharp)
        {
            bool verificaVelha = false;
            for (int l = 0; l < sharp.GetLength(0); l++)
            {
                for (int c = 0; c < sharp.GetLength(0); c++)
                {
                    if (sharp[l, c] == "O" || sharp[l,c] == "X")
                    {
                        verificaVelha = true;
                    }
                    else
                    {
                        verificaVelha =  false;
                    }
                }
            }
            return verificaVelha;
        }
        public static bool VerificaJogador1(string[,] sharp, string Jogador1, bool vencedor1)
        {
            bool Vencedor = vencedor1;
            int contadorLinha = 0, contadorColuna = 0;
            for (int l = 0; l < sharp.GetLength(0); l++)
            {
                for (int c = 0; c < sharp.GetLength(0); c++)
                {
                    if (sharp[l, c] == "O")
                    {
                        contadorLinha++;
                        if (contadorLinha == 3)
                        {
                            Vencedor = true;
                            break;
                        }
                    }
                }
                contadorLinha = 0;
            }

            for (int c = 0; c < sharp.GetLength(0); c++)
            {
                for (int l = 0; l < sharp.GetLength(0); l++)
                {
                    if (sharp[l, c] == "O")
                    {
                        contadorColuna++;
                        if (contadorColuna == 3)
                        {
                            Vencedor = true;
                            break;
                        }
                    }
                }
                contadorColuna = 0;
            }

            if (sharp[0, 0] == "O" && sharp[1, 1] == "O" && sharp[2, 2] == "O")
            {
                Vencedor = true;
            }
            else if (sharp[0, 2] == "O" && sharp[1, 1] == "O" && sharp[2, 0] == "O")
            {
                Vencedor = true;
            }
            return Vencedor;
        }
        public static bool VerificaJogador2(string[,] sharp, string Jogador2, bool vencedor2)
        {
            int contadorLinha = 0, contadorColuna = 0;
            bool Vencedor = vencedor2;
            for (int l = 0; l < sharp.GetLength(0); l++)
            {
                for (int c = 0; c < sharp.GetLength(0); c++)
                {
                    if (sharp[l, c] == "X")
                    {
                        contadorLinha++;
                        if (contadorLinha == 3)
                        {
                            Vencedor = true;
                            break;
                        }
                    }
                }
                contadorLinha = 0;
            }

            for (int c = 0; c < sharp.GetLength(0); c++)
            {
                for (int l = 0; l < sharp.GetLength(0); l++)
                {
                    if (sharp[l, c] == "X")
                    {
                        contadorColuna++;
                        if (contadorColuna == 3)
                        {
                            Vencedor = true;
                            break;
                        }
                    }
                }
                contadorColuna = 0;
            }
            if (sharp[0, 0] == "X" && sharp[1, 1] == "X" && sharp[2, 2] == "X")
            {
                Vencedor = true;
            }
            else if (sharp[0, 2] == "X" && sharp[1, 1] == "X" && sharp[2, 0] == "X")
            {
                Vencedor = true;
            }
            return Vencedor;
        }
        public static void VerificaPosicao(string[,] sharp, int vezJogador)
        {
            string posicaoSharp;
            bool verificacao = false;
            int VezJogador = vezJogador;
            do
            {
                Console.Write("Digite a numeração que deseja marcar: ");
                posicaoSharp = Console.ReadLine();

                for (int l = 0; l < sharp.GetLength(0); l++)
                {
                    for (int c = 0; c < sharp.GetLength(0); c++)
                    {
                        if (posicaoSharp == sharp[l, c])
                        {
                            if (VezJogador % 2 == 0)
                            {
                                sharp[l, c] = "X";
                                verificacao = true;
                                break;
                            }
                            else
                            {
                                sharp[l, c] = "O";
                                verificacao = true;
                                break;
                            }
                        }

                    }
                }
                if (verificacao == false)
                {
                    Console.WriteLine("Número invalido, tente novamente.");
                }
            } while (verificacao != true);
        }
        public static int VezJogador(int vezPlayer, string Jogador1, string Jogador2)
        {
            int VezPlayer = vezPlayer;

            if (VezPlayer % 2 == 0)
            {
                Console.WriteLine($"\n|Vez do jogador {Jogador1} [O]|\n".ToUpper());
                VezPlayer++;
            }
            else
            {
                Console.WriteLine($"\n|Vez do jogador {Jogador2} [X]|\n".ToUpper());
                VezPlayer++;
            }
            return VezPlayer;
        }
        public static void PosicoesMatriz(string[,] sharp)
        {
            int contador = 1;

            for (int l = 0; l < sharp.GetLength(0); l++)
            {
                for (int c = 0; c < sharp.GetLength(0); c++)
                {
                    sharp[l, c] = contador.ToString();
                    contador++;
                }
            }
        }
        public static void MostraSharp(string[,] sharp)
        {
            for (int l = 0; l < sharp.GetLength(0); l++)
            {
                Console.WriteLine("-------------------------------------------------");
                for (int c = 0; c < sharp.GetLength(0); c++)
                {
                    Console.Write($"\t{sharp[l, c]}\t|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}