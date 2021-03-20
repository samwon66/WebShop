using System;

namespace WebShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var webbShop = new WebbShopAPI();
            var id = webbShop.LogIn("Sammy Wong", "CodicRulez");
            Console.WriteLine(id);

            //webbShop.LogOut(1);
        }
    }
}
