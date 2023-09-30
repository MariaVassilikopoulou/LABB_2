using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABB_2
{
    internal class ShoppingSystem
    {

        private List<Customer> customers = new List<Customer>();
        private List<Product> shoppingCarts = new List<Product>();           
        private State currentState = State.CustomerMenu;

        public int sumOfTotalCostProduct = 0;                                  
        bool shoppingcart_empty = false;                                       

        private enum State
        {
            CustomerMenu,
            ProductMenu
        }

        public void DisplayMenu()
        {
            switch (currentState)
            {
                case State.CustomerMenu:
                    Console.WriteLine("What do you want to do? Here are your choices:");
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Log in");
                    Console.WriteLine("3. Log out/ Exit");
                  
                    break;

                case State.ProductMenu:
                    Console.WriteLine("What do you want to do? Here are your choices:");
                    Console.WriteLine("1. Buy products");
                    Console.WriteLine("2. See shopping cart");
                    Console.WriteLine("3. Go to checkout");
                    Console.WriteLine("4. Log out");
                    Console.WriteLine("5. Exit ");
                    break;
            }

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (currentState)
                {
                    case State.CustomerMenu:
                        HandleCustomerMenuChoice(choice);
                        break;

                    case State.ProductMenu:
                        HandleProductMenuChoice(choice);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("The input is in the wrong format. Use numbers!");
            }
            //currentState = State.ProductMenu;
            DisplayMenu();
        }

        private void HandleCustomerMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    RegisterCustomer();
                    break;
                case 2:
                    LogIn();
                    CheckPurchase();
                    break;
               
                case 3:
                    Console.WriteLine("Thank you for visiting shopping market");
                    Environment.Exit(0);
                    break;
                case 4:
                    currentState = State.CustomerMenu;
                    DisplayMenu();
                    //currentState = State.ProductMenu;
                    //HandleProductMenuChoice();
                    break;
                default:
                    Console.WriteLine("Choose 1, 2, or 3!");
                    break;
            }

        }

        private void HandleProductMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    BuyProducts();
                    currentState = State.ProductMenu;
                    break;
               
                case 2:
                    CheckPurchase();
                    currentState = State.ProductMenu;
                    break;
               
                case 3:
                    PayPurchase();
                    currentState = State.ProductMenu;
                    break;
                case 4:
                    Console.WriteLine("Thank you for visiting Shop Market");
                    HandleCustomerMenuChoice(4);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choose 1, 2, 3, or 4!");
                    break;
            }
        }

        public void RegisterCustomer()
        {


            Console.Write("Write your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Write your user name: ");
            string userName = Console.ReadLine();
            Console.Write("Write your password: ");
            string pass = Console.ReadLine();



            bool userNameExists = false;
            foreach (Customer customer in customers)
            {
                if (customer.UserName.ToLower() == userName.ToLower())
                {
                    userNameExists = true;
                    break; 
                }
            }

            if (userNameExists)
            {
                Console.WriteLine("Username is already taken. Please choose a different username.");
            }
            else
            {
                
                Customer customer = new Customer(firstName.ToLower(), userName.ToLower(), pass.ToLower());
                customers.Add(customer);

                Console.WriteLine("You are now registered, thank you!");
                Console.WriteLine("Continue with step 2 (log in) from the menu!");
            }
        }

        public void LogIn()
        {
            Console.Write("Write your user name: ");
            string userName = Console.ReadLine();
            Console.Write("Write your password: ");
            string password = Console.ReadLine();


            bool successfulLogIn = false;                     

            foreach (Customer customer in customers)
            {
                if (customer.UserName == userName.ToLower() && customer.Pass == password.ToLower())
                {
                    successfulLogIn = true;                    
                    Console.WriteLine("You have successfully logged in!");
                    currentState = State.ProductMenu;           
                    break;  

                               
                }
            }

            if (!successfulLogIn)                         
            {
                Console.WriteLine("It seems that your username or password is incorrect. Please try again.");
            }

        }




        public void BuyProducts()
        {

            Console.WriteLine("What do you want to buy?: ");
            Console.WriteLine("1. : sausage ");
            Console.WriteLine("2. : drink");
            Console.WriteLine("3. : apple ");



            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                string productName = "sausage";
                int costPerProduct = 10;
                Console.WriteLine("How many sausage do you want?");
                int numberOfProduct = Convert.ToInt32(Console.ReadLine());
                int totalCostProduct = numberOfProduct * costPerProduct;


                Product shoppingcard1 = new Product(productName, costPerProduct, numberOfProduct, totalCostProduct);
                Console.WriteLine(shoppingcard1.ToString());
                shoppingCarts.Add(shoppingcard1);                          

                SetSumOfTotalCostProduct(shoppingcard1.GetTotalCostProduct()); 

                                      
            }

            else if (choice == 2)
            {
                string productName = "drink";
                int costPerProduct = 15;
                Console.WriteLine("How many drinks do you want?");
                int numberOfProduct = Convert.ToInt32(Console.ReadLine());
                int totalCostProduct = numberOfProduct * costPerProduct;


                Product shoppingcard1 = new Product(productName, costPerProduct, numberOfProduct, totalCostProduct);
                Console.WriteLine(shoppingcard1.ToString());
                shoppingCarts.Add(shoppingcard1);                                    

                SetSumOfTotalCostProduct(shoppingcard1.GetTotalCostProduct());      

                                             
            }
            else
            {
                string productName = "apple";
                int costPerProduct = 5;
                Console.WriteLine("How many apples do you want?");
                int numberOfProduct = Convert.ToInt32(Console.ReadLine());
                int totalCostProduct = numberOfProduct * costPerProduct;


                Product shoppingcard1 = new Product(productName, costPerProduct, numberOfProduct, totalCostProduct);
                Console.WriteLine(shoppingcard1.ToString());
                shoppingCarts.Add(shoppingcard1);                                  

                SetSumOfTotalCostProduct(shoppingcard1.GetTotalCostProduct());     

                                            
            }

            shoppingcart_empty = true;                                            
        }

        public void CheckPurchase()  
        {
            

            foreach (Product shoppingcart in shoppingCarts)  
            { 
                Console.WriteLine(shoppingcart.ToString());
               

            } 
            if (!shoppingcart_empty) 
            { 
                Console.WriteLine("Your shoppingcart seems to be empty, please choose  from the menu below "); 
            } 

        }

        

        public void SetSumOfTotalCostProduct(int totalCost)
        {
            sumOfTotalCostProduct += totalCost;
        }

        public int GetSumOfTotalCostProduct()
        {
            return sumOfTotalCostProduct;
        }

        public void PayPurchase()
        {
            if (!shoppingcart_empty)
            {
                Console.WriteLine("You have not bought anything yet, please choose 1 (Buy products) from the menu below in order to start shopping ");
            }
            else
            {
                Console.WriteLine("Here is the last step of your purchase, please pay " + GetSumOfTotalCostProduct() + " crowns");

            }


           


        }



    }
}

