using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record
{
    internal class PassWordCheck
    {
        public void Check()
        {

            int tries = 3;

            string password = "pokedance";

            

            bool pass = false;

            while (!pass) 
            {
               var userInput=Console.ReadLine();

                if(userInput.Equals(password))
                {
                    pass = true;
                }
                else
                {
                    tries--;
                    Console.WriteLine("Wrong password try again");
                    Console.WriteLine("Tries left: " + tries);
                }
                if (tries == 0)
                {
                    Console.WriteLine("You guessed wrong to many times, deleting files...");
                    File.Delete("records.txt");
                    break;
                }
            }
        }
    }
}
