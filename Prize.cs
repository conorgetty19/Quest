using System;

namespace Quest
{
    public class Prize
    {
        private string _text;

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer hero)
        {
            int awesomeCount = hero.Awesomeness;
            if (awesomeCount > 0)
            {
                while (awesomeCount > 0)
                {
                    Console.Write($"A prize for you, {hero.Name}: ");
                    Console.WriteLine(_text);
                    awesomeCount--;
                }
            }
            else
            {
                Console.WriteLine("You get no maidens.");
            }
        }
    }
}