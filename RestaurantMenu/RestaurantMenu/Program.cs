using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RestaurantMenu
{
    class Program
    {
        static void Main(string[] args)
        {           
            Menu menuPrincipal = new Menu("Principal");

            MenuItem ensalada = new MenuItem("Ensalada Cesar", "La clásica ensalada césar preparada con el toque especial: " +
                "lechuga, parmesano, croutons de pan tostado, pollo y salsa césar.", 7.59, "first");
            MenuItem pollo = new MenuItem("Pollo a la Parmiggiana", "Chicken breast lightly breaded, flash fried and finished" +
                " in the oven. Covered with our 'vine - ripened' tomato sauce and lots of melted mozzarella cheese. " +
                "Served with penne pasta with tomato sauce.", 13.25, "main");
            MenuItem carne = new MenuItem("Carne Asada","2");
            carne.Description = "Jugosa carne de res acompañada de tacos dorados de queso panela, " +
                "papas cambray, nopal y queso asado";
            carne.Price = 15.99; 
            MenuItem helado = new MenuItem("Helado Cookies & Cream", "Nuestro delicioso helado de mantecado" +
                "preparado con gallets trituradas.", 5, "dessert");
            MenuItem Soup = new MenuItem("Soup of the Day", "Delicisiosa Sopa del dia, hecha con los mejores " +
                "ingredientes del mercado", 3.99, "1");

            

            menuPrincipal.AddMenuItem(ensalada);
            menuPrincipal.AddMenuItem(pollo);
            menuPrincipal.AddMenuItem(carne);
            menuPrincipal.AddMenuItem(helado);

            Menu menuSecundario = new Menu("Secundario", menuPrincipal);

            Console.WriteLine("----- TESTING -----");
            Console.WriteLine(helado);
            Console.WriteLine("Item " + helado.Name +" es nuevo? " + helado.IsNew);           
            Console.WriteLine("Item " + helado.Name + " es igual a " + carne.Name +" ? " + helado.Equals(carne));
            Console.WriteLine("Item " + helado.Name + " es igual a " + helado.Name + " ? " + helado.Equals(helado));
            Console.WriteLine("Hash code de " + helado.Name + ": " + helado.GetHashCode());
            Console.WriteLine("Hash code de " + carne.Name + ": " + carne.GetHashCode());
            Console.WriteLine("El menu " + menuPrincipal.Name + " fue actualizado el: " + menuPrincipal.LastUpdated);                       
            Console.WriteLine("El Menu " + menuPrincipal.Name + " es igual al menu " + menuSecundario.Name + "? " + menuPrincipal.Equals(menuSecundario));
            Console.WriteLine(menuPrincipal);
            Console.WriteLine(menuSecundario);
            Console.WriteLine(menuPrincipal.PrintFormattedMenu());
            /*
            Console.WriteLine("\n\tMenu Version: " + menuPrincipal.MenuVersion + " Last Updated: "+ menuPrincipal.LastUpdated);
            foreach (MenuItem item in menuPrincipal.RestaurantMenu)
                Console.WriteLine(item);
                */

            Console.ReadLine();

            Console.WriteLine("\n---------- Modificando el Menu Pricipal ----------\n");

            menuPrincipal.UpdateMenu();
            menuPrincipal.AddMenuItem(new MenuItem("torta","chocolate",6.99,"des"));
            menuPrincipal.DeleteMenuItem(helado);

            Console.WriteLine("El Menu " + menuPrincipal.Name + " es igual al menu " + menuSecundario.Name + "? " + menuPrincipal.Equals(menuSecundario));
            Console.WriteLine(menuPrincipal + "\n");
            Console.WriteLine(menuSecundario + "\n");
            
            Console.ReadLine();

            Console.WriteLine("\n---------- Modificando el Menu Pricipal por Segunda vez ----------\n");

            menuPrincipal.UpdateMenu();
            menuPrincipal.AddMenuItem(helado);
            MenuItem torta = menuPrincipal.GetMenuItem(5);
            //menuPrincipal.DeleteMenuItem(torta);
            menuPrincipal.AddMenuItem(Soup);

            Console.WriteLine("El Menu " + menuPrincipal.Name + " es igual al menu " + menuSecundario.Name + "? " + menuPrincipal.Equals(menuSecundario));
            Console.WriteLine(menuPrincipal + "\n");
            Console.WriteLine(menuSecundario + "\n");

            Console.ReadLine();


            Console.WriteLine("\n---------- Imprimiendo el Menu Pricipal Formateado ----------\n");
            Console.WriteLine(menuPrincipal.PrintFormattedMenu());
            Console.WriteLine(menuSecundario.PrintFormattedMenu());

            Console.ReadLine();
        }
    }





    public class Menu
    {
        //Properties
        private List<MenuItem> menu;
        public List<MenuItem> RestaurantMenu {
            get { return menu; }
            set { menu = value; }
        }
        public string Name { get; set; }
        public DateTime LastUpdated { get; internal set; }
        public int MenuVersion { get; internal set; }

        //Constructors 
        public Menu(string name)
        {
            this.RestaurantMenu = new List<MenuItem>();
            this.Name = name;
            this.LastUpdated = DateTime.Now;
            this.MenuVersion = 1;
        }

        public Menu(string name, Menu existingMenu)
        {
            this.RestaurantMenu = new List<MenuItem>(existingMenu.RestaurantMenu);
            this.Name = name;
            this.LastUpdated = DateTime.Now;
            this.MenuVersion = 1;
        }

        //Methods
        public void AddMenuItem(MenuItem newItem)
        {
            newItem.UpdateMenuItem(this.MenuVersion);
            this.RestaurantMenu.Add(newItem);
            
        }

        public void DeleteMenuItem(MenuItem existingItem)
        {
            this.RestaurantMenu.Remove(existingItem);
        }

        public MenuItem GetMenuItem (int id)
        {
            foreach (MenuItem item in this.RestaurantMenu)
            {
                if (item.ItemId == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void EraseMenu()
        {
            foreach (MenuItem item in this.RestaurantMenu)
            {
                DeleteMenuItem(item);
            }
        }

        public void UpdateMenu()
        {
            this.MenuVersion++;
            foreach (MenuItem item in this.RestaurantMenu)
            {
                item.UpdateMenuItem(this.MenuVersion);
            }
            this.LastUpdated = DateTime.Now;
        }




        public string PrintFormattedMenu()
        {
            string menu;
            List<string> categories = new List<string>();
            
            /*
            foreach (MenuItem x in (from item in this.RestaurantMenu
                                   orderby item.Categoria.Item1 ascending
                                   select item))
                
            //foreach (MenuItem x in this.RestaurantMenu)
            {
                if (!categories.Contains(x.Category))
                    categories.Add(x.Category);
            }
            */

            foreach (MenuItem x in (from item in this.RestaurantMenu
                                    orderby item.Categoria.Item1 ascending
                                    select item))

            {
                if (!categories.Contains(x.Categoria.Item2))
                    categories.Add(x.Categoria.Item2);
            }


            menu = "\n------------------------------------------------------------------------------------------------" +
                "\n\t\t\t\t\t MENU " + this.Name.ToUpper() + "\n\n";
            /*
            foreach (string category in categories)
            {
                if (MenuItem.option.TryGetValue(category.ToLower(), out string subtitle)) {
                    
                }
                else
                {
                    subtitle = "other";
                }
                */
            foreach (string category in categories)
            {
                if (!MenuItem.option2.TryGetValue(category.ToLower(), out Tuple<int,string> subtitle))
                {                                    
                    subtitle = (4,"Other").ToTuple();
                }
                menu += "\n -" + subtitle.Item2.ToUpper() +"-";

                menu += "\n\n";

                foreach (MenuItem item in (from item in this.RestaurantMenu
                                          orderby item.Name ascending
                                          select item))
                {
                    if (item.Categoria.Item2 == subtitle.Item2)
                    {
                        //menu += item.IsNew ? "NEW": "   ";
                        menu += String.Format("   * {0,-70} Price:{1,9:C2}\n", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Name) + (item.IsNew ? "  (NEW)" : " "), item.Price);
                        menu += String.Format("{0}\n\n", WrapText(item.Description,65));
                    }
                }
                 

            }

            menu += "\n\n\t\t\t\t\t\t\tLast Updated: " + this.LastUpdated +
                "\n------------------------------------------------------------------------------------------------";

            return menu;
        }

        public override String ToString()
        {
            string menu;
            menu = "\n\t\t\t Menu " + this.Name + "\n\tVersion: " + this.MenuVersion + " -  Last Updated: " + this.LastUpdated;
            foreach (MenuItem item in RestaurantMenu)
            {
                menu = menu + "\n " + item;
            }
            return menu;
        }

        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o == null)
            {
                return false;
            }
            if (o.GetType() != GetType())
            {
                return false;
            }
            Menu menuObj = o as Menu;

            var sortedmenu1 = from item in menuObj.RestaurantMenu
                                orderby item.ItemId ascending
                                select item;

            var sortedmenu2 = from item2 in this.RestaurantMenu
                              orderby item2.ItemId ascending
                              select item2;

            return sortedmenu1.SequenceEqual(sortedmenu2);
        }

        public static string WrapText(string text, int size = 80)
        {
            string paragraph ="";
            var words = text.Split(' ');
            var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
            {
                if (l.Last().Length + w.Length >= size)
                    l.Add(w);
                else
                    l[l.Count - 1] += " " + w;
                return l;
            });

            foreach (string line in lines)
                paragraph += "\t" + line + "\n";
            return paragraph;
        }


    }




    public class MenuItem
    {
        //Properties
        /*
        internal static readonly Dictionary<string, string> option = new Dictionary<string, string>()
        { {"1","Appetizer" },
            {"first","Appetizer" },            
            {"apt","Appetizer" },
            {"appt","Appetizer" },
            {"appetizer","Appetizer" },
          {"2","Main Course" },
            {"second","Main Course" },
            {"mc","Main Course" },            
            {"main","Main Course" },
            {"maincourse","Main Course" },
            {"main course","Main Course" },
            {"entre","Main Course" },
          {"3","Dessert" },
            {"third","Dessert" },
            {"dess","Dessert" },
            {"desrt","Dessert" },
            {"dsrt","Dessert" },
            {"dessert","Dessert"},
         {"4","Other" },
            {"other","Other" }
        };
        */

        internal static readonly Dictionary<string, Tuple<int, string>> option2 = new Dictionary<string, Tuple<int, string>>()
        { {"1",(1,"Appetizer").ToTuple() },
            {"first",(1,"Appetizer").ToTuple() },
            {"apt",(1,"Appetizer").ToTuple() },
            {"appt",(1,"Appetizer").ToTuple() },
            {"appetizer",(1,"Appetizer").ToTuple() },
          {"2",(2,"Main Course").ToTuple() },
            {"second",(2,"Main Course").ToTuple() },
            {"mc",(2,"Main Course").ToTuple() },
            {"main",(2,"Main Course").ToTuple() },
            {"maincourse",(2,"Main Course").ToTuple() },
            {"main course",(2,"Main Course").ToTuple() },
            {"entre",(2,"Main Course").ToTuple() },
          {"3",(3,"Dessert").ToTuple() },
            {"third",(3,"Dessert").ToTuple() },
            {"dess",(3,"Dessert").ToTuple() },
            {"desrt",(3,"Dessert").ToTuple() },
            {"dsrt",(3,"Dessert").ToTuple() },
            {"dessert",(3,"Dessert").ToTuple()},
          {"4",(4,"Other").ToTuple() },
            {"other",(4,"Other").ToTuple() }
        };
    




        public readonly string Name;
        private static int nextItemId = 1;
        public int ItemId { get; internal set; }
        public double Price { get; internal set; }
        public string Description { get; set; }
        //public string Category{ get; internal set; }
        public Tuple<int,string> Categoria { get; internal set; }
        public bool IsNew { get; private set; }
        internal int itemMenuVersion;

        //Constructors
        public MenuItem(string name, string category)
        {
            /*
            if (option.TryGetValue(category, out string value))
            {
                this.Category = value;
            }
            else
            {
                this.Category = "other";
            }
            */
            //test
            if (option2.TryGetValue(category, out Tuple<int, string> value2))
            {
                this.Categoria = value2;
            }
            else
            {
                this.Categoria = (4, "Other").ToTuple();
            }

            this.Name = name;
            this.Description = "";
            this.Price = 0;
            this.IsNew = true;
            this.itemMenuVersion = 0;

        }

        public MenuItem(string name, string description, double price, string category)
        {
            /*
            if (option.TryGetValue(category, out string value)){                
                this.Category = value;
            }
            else
            {
                this.Category = "Other";
            }
            */
            //test
            if (option2.TryGetValue(category, out Tuple<int,string> value2))
            {
                this.Categoria = value2;
            }
            else
            {
                this.Categoria = (4,"Other").ToTuple();
            }

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.IsNew = true;
            this.itemMenuVersion = 0;
            this.ItemId = nextItemId++;

        }

        //Methods
        public void UpdateMenuItem(int menuVersion)
        {
            this.itemMenuVersion = (this.itemMenuVersion == 0)? menuVersion: this.itemMenuVersion;            

            if (menuVersion > this.itemMenuVersion)
            {
                this.IsNew = false;
            }
        }

        public override string ToString()
        {
            /*
             * return(this.Name + "\n   ID: " + this.ItemId + "\n   Descripcion: " + this.Description + "\n   precio: " + this.Price + "\n   Nuevo: " + this.IsNew + 
                "\n   Menu version: " + this.itemMenuVersion + "\n   Categoria: " + this.Category + ".........." + this.Categoria.Item1 + " " + this.Categoria.Item2);
            */
            return (this.Name + "\n   ID: " + this.ItemId + "\n   Descripcion: " + this.Description + "\n   precio: " + this.Price + "\n   Nuevo: " + this.IsNew +
                   "\n   Menu version: " + this.itemMenuVersion + "\n   Categoria: " + this.Categoria.Item1 + "." + this.Categoria.Item2);
        }

        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o == null)
            {
                return false;
            }
            if (o.GetType() != GetType())
            {
                return false;
            }
            MenuItem menuItemObj = o as MenuItem;
            return ItemId == menuItemObj.ItemId;
        }

        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }


       

    }

}
