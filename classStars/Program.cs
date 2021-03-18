using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classStars
{
    class Stars
    {
        int nrRows;
        public Stars(int nrRows)
        {
            this.nrRows = nrRows;

        }
        public void drawTheStars()
        {
            for(int i=1;i <=nrRows;i++)
            {
                for (int j=1; j<=i;j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        ~Stars()
        {
            Console.WriteLine("Clasa distrusa");  //destructor
        }
        class Program
        {
            static void Main(string[] args)
            {

                Stars s = new Stars(10);  //numarul de coloane
                s.drawTheStars();
                Console.ReadKey();
            }
        }
    }
}


