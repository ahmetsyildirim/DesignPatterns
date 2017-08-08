using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.App
{
    public sealed class Barber
    {
        private static string id;
        private static Barber instance;
        private static object sync = new object();

        private Barber()
        {
        }

        public static Barber Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            //generating unique id for the singleton object.
                            //Just to be able to test each instance we request has the same id.  
                            id = Guid.NewGuid().ToString();
                            instance = new Barber();
                        }
                    }
                }
                return instance;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public void CutHair()
        {
            //printing id to see each instance is same object
            Console.WriteLine("You haircut is done and my Id is: " + id);
        }
    }
}
