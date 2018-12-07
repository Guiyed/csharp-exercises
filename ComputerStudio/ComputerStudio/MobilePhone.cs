using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStudio
{
    class MobilePhone : Computer
    {

        public MobilePhone(string name, string os) : base(name, os)
        {
            AddHardware("Celular Network");
            AddHardware("Wifi");
            AddHardware("Battery");
        }

        public override string ToString()
        {
            string result = "MobilePhone ";
            return Description(result);
        }

    }
}
