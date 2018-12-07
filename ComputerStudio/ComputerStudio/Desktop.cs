using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStudio
{
    class Desktop : Computer
    {
       
        public Desktop(string name, string os): base(name, os)
        {
            AddHardware("Eth");
            AddHardware("Monitor");
            AddHardware("Keyboard");
            AddHardware("Mouse");
        }



        public override string ToString()
        {
            string result = "Desktop ";
            return Description(result);
        }




    }
}
