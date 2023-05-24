using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge nameThineself = new Challenge("What is my name? 1) Merlin 2) NK ", 1, 10);
            Challenge seeker = new Challenge("What do I seek? 1) BWILAs 2) A pillow", 1, 20);
            //bool to play again or not
            bool playAgain;

            do
            {
                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class
                //Adventurer theAdventurer = new Adventurer("Jack");
                //prompt user for their name
                Console.Write("What is your name, weary traveller? ");
                //create robe for adventurer
                Robe adventurersRobe = new Robe();
                adventurersRobe.Colors = new List<string> { "red", "yellow", "blue" };
                adventurersRobe.Length = 20;
                //create a hat for the adventurer
                Hat adventurersHat = new Hat();
                adventurersHat.ShininessLevel = 10;
                //create a new adventurer with the users first name, a robe, and a hat
                string name = Console.ReadLine();
                Adventurer theAdventurer = new Adventurer(name, adventurersRobe, adventurersHat);

                //create a prize!
                Prize adventurersPrize = new Prize("A maiden!");

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                nameThineself,
                seeker
            };

                //create list of five random challenges
                Random random = new Random();
                List<Challenge> randomChallenges = challenges.OrderBy(x => random.Next()).Take(5).ToList();

                // Loop through the five challenges and subject the Adventurer to them
                foreach (Challenge challenge in randomChallenges)
                {
                    challenge.RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                adventurersPrize.ShowPrize(theAdventurer);
                Console.Write("Would ye like to play again for the fate of ye soule? (y/n): ");
                string playAgainInput = Console.ReadLine();
                playAgain = (playAgainInput.ToLower() == "y");
            }
            while (playAgain);
        }
    }
}