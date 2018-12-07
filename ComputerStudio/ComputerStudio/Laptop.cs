using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStudio
{
    class Laptop : Computer
    {
        public Laptop(string name, string os) : base(name, os)
        {
            AddHardware("Wifi");
            AddHardware("Battery");
        }


        public override string ToString()
        {
            string result = "Laptop ";
            return Description(result);
        }



    }
}
