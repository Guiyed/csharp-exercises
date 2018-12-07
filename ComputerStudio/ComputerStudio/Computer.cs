using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStudio
{
    class Computer : AbstractEntity
    {
        /*
         * private int id;
        public int ID
        {
            get { return this.id; }
            private set { this.id = value; }
        }
        */
                
        public string Name, OS;
    

        public List<string> hardwareList = new List<string>(new string[] { "Motherboard", "CPU", "RAM", "HDD"});
        internal Dictionary<string, string> Hardware = new Dictionary<string, string>();

        public List<string> Interfaces = new List<string>(new string[] { "power", "sleep", "Login", "thinking", "input","output","internet"});
        private Dictionary<string, bool> Status = new Dictionary<string, bool>();

        public Computer(string name, string os)
        {
            this.Name = name;
            this.OS = os;

            foreach (string hard in this.hardwareList)
            {
                AddHardware(hard);
            }
            
        }

        public bool SetHardware(string type, string info)
        {
            if (Hardware.ContainsKey(type)){
                Hardware[type] = info;
                return true;
            }
            return false;            
        }

        public bool AddHardware(string type,string info = "Not installed")
        {
            return Hardware.TryAdd(type, info);
        }

        public void PowerOn()
        {
            Console.WriteLine("Powering Computer ON");
            Status["power"] = true;
            Status["sleep"] = false;
        }

        public void Shutdown()
        {
            Console.WriteLine("Shutting Down Computer");
            Status["power"] = false;
        }

        public void Sleep()
        {
            Console.WriteLine("Computer going to sleep");
            Status["sleep"] = true;
        }

        public void LogIn()
        {
            Console.WriteLine("User Logged In");
            Status["loggin"] = true;
        }

        public void LogOut()
        {
            Console.WriteLine("User Logged Out");
            Status["loggin"] = false;
        }

        public bool Execute(string action)
        {
            return true;
        }

        public bool SurfInternet()
        {
            return true;
        }

        public override string ToString()
        {
            string result = "Computer ";
            return Description(result);
        }

        internal string Description(string result)
        {
            result += this.Name + " (ID: " + this.Id + ") \n";
            result += "  'Operative System: " + OS + "'\n";
            foreach (KeyValuePair<string, string> kvp in this.Hardware)
            {
                result += String.Format("  {0}: {1}\n", kvp.Key, kvp.Value);
            }

            return result;

        }

    }
}


  