using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator
{
    class DragonCombat
    {
        //declaring member variables
        static Random rng = new Random();
        static int playerHP = 100, dragonHP = 200;
        static string player;
        static bool won = false;

        static void Main(string[] args)
        {
            //Greet the player
            Greet();

            //loop while game is on
            while (won == false)
            {
                Console.WriteLine("\nIt's your turn now");

                PlayersHit(PlayersChoice()); //Function call for Play's Hit
                PrintResults(); //Function call to print results after player's Hit

                if (won == false)
                {
                    Console.WriteLine("\nIt's Dragon's turn now");
                    DragonsHit(); //Function call for Dragon's Hit
                    PrintResults(); //Function call to print results after dragon's Hit
                }
            }
        }

        static void Greet()
        {
            Console.Write("Enter your name: ");
            player = Console.ReadLine();

            Console.WriteLine("\nWelcome to DRAGON HIT, " +player);
            Console.WriteLine("\nPress enter to skip the introduction \n or type \"yes\" for the introduction:");
            string temp = Console.ReadLine();

            if (temp == "")
                return;
            else if(temp.ToLower() == "yes")
            {
                Console.WriteLine(@"
THE STORY: There once was kingdom full of riches. 
One day a very big dragon came to the kingdom. 
It started destroying the kingdom , and everyone got scared.
Everyone except king, queen and few brave warriors fled the kingdom. 
They fight with the dragon, but sadly there was only one warrior and king were left alive.
Now it's that brave warriors turn to kill the dragon and save the king and his kingdom. 

THAT WARRIOR IS YOU. 

You will have 3 choices to hit the Dragon. 
SWORD: 70% chance. It will do 20-35 damage.
FIREBALL: Always hits. It will do 10-15 damage.
HEAL: Heals the player for 10-20 HP

After your hit, Dragon's turn to hit you.
You have 100 hitpoits and Dragon will have 200 hit points to start with.

Welcome to the game: DRAGON HIT!

    ");
                return;
            }
                else
                {
                    Console.WriteLine("sorry you have entered a wrong choice");
                    won = true;
                    return;
                }
            
        }

        static int PlayersChoice()
        {
            string choice = "";

            //this loop is for exception handling. If user accidentaly presses enter, it will ask for choice again
            while (choice == "") 
            {
                //PrintResults();
                Console.WriteLine(@"Make your choice
Enter 1 for Sword.
Enter 2 for Fire ball
Enter 3 for Heal
             ");
                choice = Console.ReadLine().ToString();
            }

            return int.Parse(choice);
        }

        //Function for Player's Hit
        static void PlayersHit(int choice)
        {
            switch (choice)
            {
                //case int.Parse(null):
                //    Console.WriteLine("You have entered wrong choice. Try again");
                //    PlayersHit(PlayersChoice());
                //    return;
                case 1: //user selected the sword
                    int hit = rng.Next(1, 101);
                    if (hit <= 70) //user got a hit
                    {
                        //Decrease Dragon's HP points from 20 - 25
                        dragonHP = dragonHP - (rng.Next(20, 26));
                        Console.WriteLine("Congrats you got a hit!");
                    }
                    else //user missed it
                    {
                        Console.WriteLine("\n OOPS...You have missed");
                    }
                    break;

                case 2: //user selected the fire ball
                    dragonHP = dragonHP - (rng.Next(10, 16));
                    break;
                case 3: //user selected heal
                    if (playerHP == 100)
                    {
                        Console.WriteLine("Sorry, you already have max HP points. Make a new choice");
                        PlayersHit(PlayersChoice());
                        return;
                    }
                    else
                    {
                        playerHP = playerHP + (rng.Next(10, 21));
                    }
                    break;
                default:
                    Console.WriteLine("You have entered wrong choice. Try again");
                    PlayersHit(PlayersChoice());
                    return;
            }

            return;
        }

        //Function for Dragon's Hit
        static void DragonsHit()
        {
            int random = rng.Next(1, 101);
            if (random <= 80) //means dragon got hit
            {
                playerHP = playerHP - (rng.Next(5, 16));
                Console.WriteLine("\nDragon got the hit");
            }
            else //means dragon missed
            {
                Console.WriteLine("\nDragon missed!!!!");
            }

            //Console.WriteLine("\nIt's your turn now");
            }
            

        //Function to print the facts after a user's or dragon's attach
        static void PrintResults()
        {
            
            if (playerHP <= 0) //means player lost
            {
                Console.WriteLine("\nSorry! You have lost\n");
                won = true;
                return;
            }
            else if (dragonHP <= 0) //means dragon lost
            {
                Console.WriteLine("\nHooray!!!\nCongratulations " +player +" .......You killed the dragon\n");
                won = true;
                return;
            }
            Console.WriteLine("\nYou have " + playerHP + " hit points");
            Console.WriteLine("\nDragon has " + dragonHP + " hit points");
            Console.WriteLine("\nPress Enter to continue\n\n");
            Console.ReadKey(); //this will keep console window open, so that user can read the details after hit
            return;
        }

    }
}
