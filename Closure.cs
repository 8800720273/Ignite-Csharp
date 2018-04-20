using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Closure
    {
        [STAThread]
        public static void Main()
        {
            using (var ignite = Ignition.StartFromApplicationConfiguration())
            {
                Console.WriteLine();
                Console.WriteLine(">>> Closure execution example started.");


                ICollection<string> words = "Count characters using closure".Split().ToList();

                Console.WriteLine();
                Console.WriteLine(">>> Calculating character count with manual reducing:");

                var res = ignite.GetCompute().Apply(new CharacterCountClosure(), words);

                int totalLen = res.Sum();

                Console.WriteLine(">>> Total character count: " + totalLen);
                Console.WriteLine();
                Console.WriteLine(">>> Calculating character count with reducer:");

                totalLen = ignite.GetCompute().Apply(new CharacterCountClosure(), words, new CharacterCountReducer());

                Console.WriteLine(">>> Total character count: " + totalLen);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
            Console.ReadKey();

        }
    }
}
