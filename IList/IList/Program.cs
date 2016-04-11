using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            UniCall<int> U = new UniCall<int>();
            U.Add(1);
            U.Add(2);
            U.RemoveAt(0);
           
            Console.WriteLine( U.Contains(1));
            foreach (int item in U)
            {
                Console.WriteLine(item);
            }

            

          
        }
    }
}
