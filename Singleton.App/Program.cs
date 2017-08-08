using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Barber barber1 = Barber.Instance;

            Barber barber2 = Barber.Instance;

            barber1.CutHair();
            barber2.CutHair();

            Debug.WriteLine(barber1.Id.Equals(barber2.Id));

            Console.ReadKey();

            Console.WriteLine("Switching to thread safe tests...");

            Parallel.For(1, 10, x =>
            {
                var barber = Barber.Instance;
                barber.CutHair();
            });

            Console.ReadKey();
        }
    }
}
