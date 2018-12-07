using System;
using System.Collections.Generic;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu myMenu = new Menu("Specials", "Fall");

            myMenu.AddItem(new MenuItem("banana", "it's yellow", "fruit", 12.0));
            myMenu.AddItem(new MenuItem("orange", "it's orange", "fruit", 12.0));
            myMenu.AddItem(new MenuItem("lime", "it's green", "fruit", 12.0));
            myMenu.AddItem(new MenuItem("strawberry", "it's red", "fruit", 12.0));

            Console.WriteLine(myMenu);
            Console.ReadLine();
        }
    }


    class Menu
    {
        string name, season;
        List<MenuItem> menuItems = new List<MenuItem>();

        public Menu(string name, string season)
        {
            this.name = name;
            this.season = season;
        }

        public void AddItem(MenuItem newItem)
        {
            this.menuItems.Add(newItem);
        }

        public override string ToString()
        {
            string result = "Menu: " + this.name + "\nseason:" + this.season + "\n";
            foreach (MenuItem item in menuItems)
            {
                result += item.name + " ($" + item.price + ") : " + item.description + "\n";
            }

            return result;
        }

    }

    class MenuItem
    {
        public string name, description, category;
        public double price;
        private bool newItem = true;

        private string last_updated;
        public string LastUpdated
        {
            get { return last_updated; }
            private set { last_updated = DateTime.Now.ToString("hh:mm:ss"); }
        }

        public MenuItem(string name, string description, string category, double price)
        {
            this.name = name;
            this.description = description;
            this.category = category;
            this.price = price;
        }

        public override string ToString()
        {
            string result = this.name + " (" + this.price + ") : " + this.description;
            return result;
        }

    }

}

