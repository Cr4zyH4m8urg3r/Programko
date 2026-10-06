using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO.IsolatedStorage;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace Ukol1
{
    internal class Program
    {

        static char[,] Ctecka()
        {
            int sirka = int.Parse(Console.ReadLine());
            int vyska = int.Parse(Console.ReadLine());

            char[,] ohrada = new char[sirka, vyska];

            for (int i = 0; i <vyska; i++) 
            {
                string vrstevnice=(Console.ReadLine());
                for (int j = 0; j < sirka; j++) 
                {
                    ohrada[j, i] = vrstevnice[j];
                }
            }
            return ohrada;
        }
        
        public class Beastie
        {
            public Beastie(int x,int y,int d) 
            {
                Shapes = ['>','^','<','V'];
                Coords = [x, y];
                Direction = d;
            }
        public char [] Shapes { get; set; }
        public int[] Coords { get; set; }
        public int Direction { get; set; }
        }
        public class Zoo 
        {   private bool Atemptmove(Beastie B) 
            {
                bool roundcornermove = false;
                if (Zahrada[B.Coords[0] + Vektorlookup[(2*B.Direction-1+8008)%8][0], B.Coords[1] + Vektorlookup[(2*B.Direction-1+8008)%8][1]] =='X' 
                && Zahrada[B.Coords[0] + Vektorlookup[(2 * B.Direction + 8008) % 8][0], B.Coords[1] + Vektorlookup[(2 * B.Direction+8008 ) % 8][1]] =='.'
               
                ) 
                {
                    return true;
                }
                if (Zahrada[B.Coords[0] + Vektorlookup[(2 * B.Direction - 2 + 8008) % 8][0], B.Coords[1] + Vektorlookup[(2 * B.Direction - 2 + 8008) % 8][1]] == 'X'
                && Zahrada[B.Coords[0] + Vektorlookup[(2 * B.Direction + 8008) % 8][0], B.Coords[1] + Vektorlookup[(2 * B.Direction + 8008) % 8][1]] == '.'
               
                )
                {
         
                    return true;
                }
                else 
                {   
                     return false; 
                }
            }
            public void Move(Beastie B) 
            {
               Zahrada[B.Coords[0], B.Coords[1]] = '.';
                B.Coords[0]+= Vektorlookup[2 * B.Direction][0];
                B.Coords[1]+= Vektorlookup[2 * B.Direction][1];
               Zahrada[B.Coords[0], B.Coords[1]] = B.Shapes[B.Direction];
               

               
            }
            public void Turn(Beastie B) 
            {
                if (Zahrada[B.Coords[0] + Vektorlookup[(2 * B.Direction - 2 + 8008) % 8][0], B.Coords[1] + Vektorlookup[(2 * B.Direction - 2 + 8008) % 8][1]] == 'X'
                && Zahrada[B.Coords[0] + Vektorlookup[(2 * B.Direction + 8008) % 8][0], B.Coords[1] + Vektorlookup[(2 * B.Direction + 8008) % 8][1]] == 'X')
                {
                    B.Direction += 1;
                    B.Direction %= 4;
                    Zahrada[B.Coords[0], B.Coords[1]] = B.Shapes[B.Direction];
                }
                else 
                {
                    B.Direction += 3;
                    B.Direction %= 4;
                    Zahrada[B.Coords[0], B.Coords[1]] = B.Shapes[B.Direction];
                }
            }
            public void Tick()
            {
                foreach (Beastie B in Beastielist)
                {
                    
                    if (Atemptmove(B))
                    {
                        Move(B);
                        
                    }
                    else
                    {
                        Turn(B);
                    }
                }
            }
            public void Malir()
            {
                StringBuilder malir = new StringBuilder();
                for (int i = 0; i < Zahrada.GetLength(1); i++)
                {
                    for (int j = 0; j < Zahrada.GetLength(0); j++) 
                    { 
                        malir.Append(Zahrada[j,i]);
                    }
                    malir.Append('\n');
                }
                Console.WriteLine(malir.ToString());
            }
            public Zoo(char[,] zahrada)
            {
                Zahrada = zahrada;
                Beastielist = new List<Beastie>();
                Vektorlookup= [[1, 0],[1, -1],[0, -1],[-1, -1],[-1, 0],[-1, 1],[0, 1],[1, 1]];
                                for (int i = 0; i < zahrada.GetLength(0); i++)
                {
                    for (int j = 0; j < zahrada.GetLength(1); j++)
                    {
                        if (zahrada[i, j] == '>')
                        {
                            int smer = 0;
                            int[] pozice = new int[]{j,i};
                            Beastielist.Add(new Beastie(pozice[0], pozice[1],smer));
                        }
                        else if (zahrada[i,j] == 'Λ')
                        {
                            int smer = 1;
                            int[] pozice = new int[] { j, i };
                            Beastielist.Add(new Beastie(pozice[0], pozice[1], smer));
                        }
                        else if (zahrada[i, j] == '<')
                        {
                            int smer = 2;
                            int[] pozice = new int[] { j, i };
                            Beastielist.Add(new Beastie(pozice[0], pozice[1], smer));
                        }
                        else if (zahrada[i, j] == 'V')
                        {
                            int smer = 3;
                            int[] pozice = new int[] { j, i };
                            Beastielist.Add(new Beastie(pozice[0], pozice[1], smer));
                        }
                    }

                }
                
            }
            public char[,] Zahrada {get;}
            public int[][] Vektorlookup {get;}
            List<Beastie> Beastielist {get;}
            

        }

        static void Main(string[] zahrada)
        {
            Zoo klec = new Zoo(Ctecka());
            for (int i = 0; i <= 19; i++) 
            {
                klec.Malir();
                klec.Tick();
            }        
        }
    }
}
