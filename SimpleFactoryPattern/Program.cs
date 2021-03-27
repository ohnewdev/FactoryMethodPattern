using System;
using System.Collections;


// HeadFirst Factory Method 패턴.
namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;
            Console.WriteLine("Hello World!");
            //NYPizzaFactory nyFactory = new NYPizzaFactory();
            //PizzaStore nyStore = new NYPizzaStore(nyFactory);
            PizzaStore nyStore = new NYPizzaStore();
            pizza = nyStore.OrderPizza("cheese");
            Console.WriteLine("A ordered : " + pizza.Name);

            //ChicagoPizzaFactory chicagoPizzaFactory = new ChicagoPizzaFactory();
            //PizzaStore chicagoStore = new ChicagoPizzaStore(chicagoPizzaFactory);
            PizzaStore chicagoStore = new ChicagoPizzaStore();
            chicagoStore.OrderPizza("cheese");
            Console.WriteLine("B ordered : " + pizza.Name);


            PizzaStore cfStore = new CalifoniaStore();
            pizza = cfStore.OrderPizza("cheese");
            Console.WriteLine("C ordered : " + pizza.Name);


        }
    }


    public abstract class PizzaStore
    {
        //protected PizzaStore()
        //{
        //}

        //private SimplePizzaFactory factory = null;

        //public PizzaStore(SimplePizzaFactory factory)
        //{
        //    this.factory = factory;
        //}



        public Pizza OrderPizza(string type)
        {
            Pizza pizza = null;

            pizza = CreatePizza(type); // factory.CreatePizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;

        }

        protected abstract Pizza CreatePizza(string type);
    }

    class CalifoniaStore : PizzaStore
    {

        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new CFStyleCheesePizza();
            }
            else if (type.Equals("peperoni"))
            {
                pizza = new CFStylePeperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new CFStyleVeggiePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new CFStyleClamPizza();
            }
            return pizza;
        }
    }

    internal class CFStyleClamPizza : Pizza
    {
    }

    internal class CFStyleVeggiePizza : Pizza
    {
    }

    internal class CFStylePeperoniPizza : Pizza
    {
    }

    internal class CFStyleCheesePizza : Pizza
    {

        public CFStyleCheesePizza()
        {

            Name = "CF Style Sauce and Cheese Pizza";
            Dough = "THin Crust Dough";
            Sauce = "Marinara SAuce";
            Topping.Add("Grated Reggiano Cheese");
        }

        public override void cut()
        {
            Console.WriteLine("CF : Cutting the pizza into square slice!!!");
        }
    }

    class NYPizzaStore : PizzaStore
    {
        //public NYPizzaStore(SimplePizzaFactory factory) : base(factory)
        //{
        //    Console.WriteLine("NYPizzaStore!!");
        //}

        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new NYStyleCheesePizza();
            }
            else if (type.Equals("peperoni"))
            {
                pizza = new NYStylePeperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new NYStyleVeggiePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new NYStyleClamPizza();
            }

            return pizza;
        }
    }

    internal class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            Name = "NY Style Sauce and Clam Pizza";
            Dough = "THin Crust Dough";
            Sauce = "Marinara SAuce";
            Topping.Add("Grated Reggiano Clam");
        }
    }

    internal class NYStyleVeggiePizza : Pizza
    {
    }

    internal class NYStylePeperoniPizza : Pizza
    {
    }

    internal class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {

            Name = "NY Style Sauce and Cheese Pizza";
            Dough = "THin Crust Dough";
            Sauce = "Marinara SAuce";
            Topping.Add("Grated Reggiano Cheese");
        }

    }

    class ChicagoPizzaStore : PizzaStore
    {
        //public ChicagoPizzaStore(SimplePizzaFactory factory) : base(factory)
        //{
        //    Console.WriteLine("ChicagoPizzaStore!!");
        //}

        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new ChicagoStyleCheesePizza();
            }
            else if (type.Equals("peperoni"))
            {
                pizza = new ChicagoStylePeperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new ChicagoStyleVeggiePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new ChicagoStyleClamPizza();
            }

            return pizza;
        }
    }

    internal class ChicagoStyleClamPizza : Pizza
    {
    }

    internal class ChicagoStyleVeggiePizza : Pizza
    {
    }

    internal class ChicagoStylePeperoniPizza : Pizza
    {
    }

    internal class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {

            Name = "Chicago Style Sauce and Cheese Pizza";
            Dough = "THin Crust Dough";
            Sauce = "Marinara SAuce";
            Topping.Add("Grated Reggiano Cheese");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slice!!!");
        }
    }

    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {

                pizza = new CheezePizza();
            }
            else if (type.Equals("peperoni"))
            {
                pizza = new Peperoni();
            }
            else if (type.Equals("clam"))
            {
                pizza = new Clam();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new Veggie();
            }

            return pizza;
        }
    }




    public class NYPizzaFactory : SimplePizzaFactory
    {

    }
    public class ChicagoPizzaFactory : SimplePizzaFactory
    {

    }

    public class CPizzaFactory : SimplePizzaFactory
    {

    }
    public class Veggie : Pizza
    {
    }

    internal class Clam : Pizza
    {
    }

    internal class Peperoni : Pizza
    {
    }

    internal class CheezePizza : Pizza
    {

    }

    public abstract class Pizza
    {
        private string name;
        private string dough;
        private string sauce;
        private ArrayList topping = new ArrayList();

        public string Name { get => name; set => name = value; }
        protected string Dough { get => dough; set => dough = value; }
        protected string Sauce { get => sauce; set => sauce = value; }
        public ArrayList Topping { get => topping; set => topping = value; }

        public Pizza()
        {
        }

        public virtual void prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Console.WriteLine("Adding topping :");
            for (int i = 0; i < topping.Count; i++)
            {
                Console.WriteLine(" " + topping[i].ToString());
            }

            Console.WriteLine("prepare");
        }
        public virtual void bake() { Console.WriteLine("bake"); }
        public virtual void cut() { Console.WriteLine("cut"); }
        public virtual void box() { Console.WriteLine("box"); }

    }
}
