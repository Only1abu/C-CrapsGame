using System;
using System.Linq;
// Name: Abiel Yohannes

namespace CrapsGameoYohannes
{
    class PlayGame
    {


        static void Main(string[] args)
        {
            int bank;
            int point;

            Console.WriteLine("To play the game, you will roll a pair of dice. After the dice come to rest, the sum of the faces of the 2 die is calculated." +
                    "If the sum is 7 or 11 on the first throw, you win and the game is over. If the sum is 2, 3, or 12 on the first throw, you lose and the game is over." +
                    "If the sum is 4, 5, 6, 8, 9, or 10 on the first throw, then that sum is known as point." +
                    "To win, he must keep throwing the dice until you makes point, that is, the sum of the dice is equal to" +
                    "point. The player loses if he throws a 7 before making his point. In either case, the game is over." +
                    "The player will be assigned 100 chips before beginning to play the game. Each time the game is played," +
                    "you will be asked to make a wager.If the player wins the game, s(he) receives double his wager. If you" +
                    "lose, then the wager is lost. The game is played until you no longer wish to play or until the chips are" +
                    "all used. Do you wish to play? (Type yes or no)");

            string input = Console.ReadLine();

            if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    bank = 100;
                    askGameQuestion(bank);
                }
            else
                return;

            void askGameQuestion(int b)// created a method to ask the wager question to avoid code redudancy. This method takes in the bank value as a parameter.
            {
                Console.WriteLine("How much would you like to wager? Current bank : {0} chips", b);
                string input = Console.ReadLine();
                int wagerInt2 = int.Parse(input);
                if (wagerInt2 > b)
                    {
                        Console.WriteLine("Wager amount must be less than bank.");
                        askGameQuestion(b);

                    }
                else
                    playGame(wagerInt2);
            }

            void playGame(int wager)
            {

                int[] losingNumbers = { 2, 3, 12 };

                
                if (bank > 0)// ensures user has enough chips to continue playing
                {

                    Random rand1 = new Random();
                    Random rand2 = new Random();
                    int roll1 = rand1.Next(1, 7);
                    int roll2 = rand2.Next(1, 7);
                    point = roll1 + roll2;

                    if (point == 7 || point == 11)
                    {
                        bank += wager * 2;
                        Console.WriteLine("You won! You rolled a {0} and a {1}, You now have {2} chips. Do you wish to play again? (Type yes or no)", roll1, roll2, bank);
                        string input = Console.ReadLine();

                        if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            askGameQuestion(bank);
                        else
                        {
                            Console.WriteLine("You have {0} chips remaining.", bank);
                            return;
                        }

                    }

                    else if (losingNumbers.Contains(point)) // created an array and used the Contains method from System.linq to compare 2,3, 12 instead of 3 separate or statements.
                    {

                        bank -= wager;
                        Console.WriteLine("You lost! You rolled a {0} and a {1}, You now have {2} chips. Do you wish to play again? (Type yes or no)", roll1, roll2, bank);
                        string input = Console.ReadLine();

                        if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            askGameQuestion(bank);
                        else
                        {
                            Console.WriteLine("You have {0} chips remaining.", bank);
                            return;
                        }
                    }

                    else
                    {
                        Console.WriteLine("You rolled a {0} and a {1}, Your point is {2}. You must keep rolling the die until you roll your point again or roll a 7.", roll1, roll2, point);
                        Console.WriteLine("Press any key to continue a");
                        Console.ReadLine();
                        rollAgain(point, wager);
                    }

                }

                else
                {
                    Console.WriteLine("You no longer have enough chips to continue playing.");
                    return;
                }

            }


            void rollAgain(int userPoint, int userWager)// the roll again method is called upon to generate new random numbers. The user's point and wager amount are passed in as parameters.
            {
                Random rand3 = new Random();
                Random rand4 = new Random();
                int roll3 = rand3.Next(1, 7);
                int roll4 = rand4.Next(1, 7);
                int point2 = roll3 + roll4;


                if (point2 == 7)
                {
                    bank -= userWager;
                    Console.WriteLine("You lost! You rolled a {0} and a {1}, You now have {2} chips. Do you wish to play again? (Type yes or no)", roll3, roll4, bank);
                    string input = Console.ReadLine();

                    if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                        askGameQuestion(bank);
                    else
                    {
                        Console.WriteLine("You have {0} chips remaining.", bank);
                        return;
                    }
                }

                else if (point2 == userPoint)
                {
                    bank += userWager * 2;
                    Console.WriteLine("You won! You rolled a {0} and a {1}, You now have {2} chips. Do you wish to play again? (Type yes or no)", roll3, roll4, bank);
                    string input5 = Console.ReadLine();
                    if (input5.Equals("yes", StringComparison.OrdinalIgnoreCase))
                        askGameQuestion(bank);
                    else
                        {
                            Console.WriteLine("You have {0} chips remaining.", bank);
                            return;
                        }

                }

                else
                    rollAgain(point2, userWager);


            }

        }

    }

}
