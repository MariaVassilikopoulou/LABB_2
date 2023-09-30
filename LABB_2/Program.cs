namespace LABB_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingSystem shoppingSystem = new ShoppingSystem();

            Console.WriteLine("HELLO, this is your Shop Market");
            shoppingSystem.DisplayMenu();
        }
    }
}