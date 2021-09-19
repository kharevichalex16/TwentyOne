using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //String userInput = Console.ReadLine();
            //Console.WriteLine(userInput);
            Console.WriteLine("Start");


            while (true)
            {
                List<string> playersNames = GetPlayers();
                List<int> usersScores = new List<int>(playersNames.Count);
                for (int i = 0; i < playersNames.Count; i++)
                {
                    usersScores.Add(0);
                }

                SingleGame(playersNames, usersScores);

                string newGame = Console.ReadLine();
                if (newGame == "y")
                {
                    
                }
                if (newGame == "n")
                {
                    break;
                }
            }

            //for (int i = 0; i < playersNames.Count; i++)
            //{
            //    Console.WriteLine(playersNames[i]);
            //}
            //foreach (string card in deck)
            //{
            //    Console.WriteLine(card);
            //}
            Console.ReadKey();
        }

        public static void SingleGame(List<string> playersNames, List<int> usersScores)
        {
            List<string> deck = GetDeck();
            Dictionary<string, int> priceList = GetPriceList();

            while (true)
            {
                string newCard = Console.ReadLine();


                if (newCard == "y")
                {
                    string currentCard = deck[0];
                    deck.RemoveAt(0);
                    int currentCardPoints = priceList[currentCard];
                    usersScores[0] += currentCardPoints;

                    Console.WriteLine($"Name: {playersNames[0]}, " +
                        $"Card: {currentCard}, " +
                        $"Value: {currentCardPoints}, " +
                        $"Score: {usersScores[0]}");

                    if (usersScores[0] == 21)
                    {
                        Console.WriteLine("Win!!!");
                        break;
                    }
                    if (usersScores[0] > 21)
                    {
                        Console.WriteLine("You los.");
                        break;
                    }
                }
                if (newCard == "n")
                {
                    Console.WriteLine("End game.");
                    break;
                }
            }
        }


        public static List<string> GetPlayers()
        {
            Console.WriteLine("Введи количество игроков");
            int numberPlayers = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Вы выбрали кол-во игроков = {numberPlayers}");

            List<string> playersNames = new List<string>();

            for (int i = 0; i < numberPlayers; i++)
            {
                Console.WriteLine($"Введите имя пользователя {i + 1}");
                playersNames.Add(Console.ReadLine());
            }
            return playersNames;
        }


        public static Dictionary<string, int> GetPriceList() 
        {
            Dictionary<string, int> priceList = new Dictionary<string, int>();
            priceList.Add("6 буба", 6);
            priceList.Add("6 чирва", 6);
            priceList.Add("6 крестя", 6);
            priceList.Add("6 пика", 6);

            priceList.Add("7 буба", 7);
            priceList.Add("7 чирва", 7);
            priceList.Add("7 крестя", 7);
            priceList.Add("7 пика", 7);

            priceList.Add("8 буба", 8);
            priceList.Add("8 чирва", 8);
            priceList.Add("8 крестя", 8);
            priceList.Add("8 пика", 8);

            priceList.Add("9 буба", 9);
            priceList.Add("9 чирва", 9);
            priceList.Add("9 крестя", 9);
            priceList.Add("9 пика", 9);

            priceList.Add("10 буба", 10);
            priceList.Add("10 чирва", 10);
            priceList.Add("10 крестя", 10);
            priceList.Add("10 пика", 10);

            priceList.Add("Валет буба", 2);
            priceList.Add("Валет чирва", 2);
            priceList.Add("Валет крестя", 2);
            priceList.Add("Валет пика", 2);

            priceList.Add("Дама буба", 3);
            priceList.Add("Дама чирва", 3);
            priceList.Add("Дама крестя", 3);
            priceList.Add("Дама пика", 3);

            priceList.Add("Король буба", 4);
            priceList.Add("Король чирва", 4);
            priceList.Add("Король крестя", 4);
            priceList.Add("Король пика", 4);

            priceList.Add("Туз буба", 11);
            priceList.Add("Туз чирва", 11);
            priceList.Add("Туз крестя", 11);
            priceList.Add("Туз пика", 11);

            return priceList;
        }


        public static List<string> GetDeck()
        {
            Dictionary<string, int> priceList = GetPriceList();
            List<string> deck = new List<string>(priceList.Keys);

             Random random = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                String value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }

            return deck;
        }
    }
}
