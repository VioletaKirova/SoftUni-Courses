using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_NumberWars
{
    // 30/100

    class Program
    {
        static void Main(string[] args)
        {
            string[] cardArrayOne = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            string[] cardArrayTwo = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            Queue<string> firstPlayerDeck = new Queue<string>(cardArrayOne);
            Queue<string> secondPlayerDeck = new Queue<string>(cardArrayTwo);

            List<string> currentCards = new List<string>();

            int turns = 0;

            bool gameOver = false;

            while (!gameOver && firstPlayerDeck.Any() && secondPlayerDeck.Any() && turns < 1000000)
            {
                if (gameOver)
                {
                    if (firstPlayerDeck.Count > secondPlayerDeck.Count)
                    {
                        foreach (var card in currentCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ThenBy(x => x.Last()))
                        {
                            firstPlayerDeck.Enqueue(card);
                        }
                    }
                    else
                    {
                        foreach (var card in currentCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ThenBy(x => x.Last()))
                        {
                            secondPlayerDeck.Enqueue(card);
                        }
                    }
                }

                string firstPlayerCard = firstPlayerDeck.Dequeue();
                string secondPlayerCard = secondPlayerDeck.Dequeue();

                int firstPlayerCardValue = int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
                int secondPlayerCardValue = int.Parse(secondPlayerCard.Substring(0, secondPlayerCard.Length - 1));

                if (firstPlayerCardValue != secondPlayerCardValue)
                {
                    if (firstPlayerCardValue > secondPlayerCardValue)
                    {
                        firstPlayerDeck.Enqueue(firstPlayerCard);
                        firstPlayerDeck.Enqueue(secondPlayerCard);
                        turns++;
                        continue;
                    }
                    else
                    {
                        secondPlayerDeck.Enqueue(secondPlayerCard);
                        secondPlayerDeck.Enqueue(firstPlayerCard);
                        turns++;
                        continue;
                    }
                }

                currentCards = new List<string>();

                currentCards.Add(firstPlayerCard);
                currentCards.Add(secondPlayerCard);

                while (true)
                {
                    if (firstPlayerDeck.Count > 3 && secondPlayerDeck.Count > 3)
                    {
                        string fpCardOne = firstPlayerDeck.Dequeue();
                        string fpCardTwo = firstPlayerDeck.Dequeue();
                        string fpCardThree = firstPlayerDeck.Dequeue();

                        string spCardOne = secondPlayerDeck.Dequeue();
                        string spCardTwo = secondPlayerDeck.Dequeue();
                        string spCardThree = secondPlayerDeck.Dequeue();

                        AddCardsInList(currentCards, fpCardOne, fpCardTwo, fpCardThree, spCardOne, spCardTwo, spCardThree);

                        int fpCardsValue = GetCardsValue(fpCardOne, fpCardTwo, fpCardThree);
                        int spCardsValue = GetCardsValue(spCardOne, spCardTwo, spCardThree);

                        if (fpCardsValue != spCardsValue)
                        {                            
                            currentCards = currentCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1))).ThenBy(x => x.Last()).ToList();

                            if (fpCardsValue > spCardsValue)
                            {
                                for (int i = 0; i < currentCards.Count; i++)
                                {
                                    firstPlayerDeck.Enqueue(currentCards[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < currentCards.Count; i++)
                                {
                                    secondPlayerDeck.Enqueue(currentCards[i]);
                                }
                            }

                            turns++;
                            currentCards.Clear();
                        }
                    }
                    else
                    {
                        turns++;
                        gameOver = true;
                        break;
                    }             
                }
            }

            if (turns == 0)
            {
                turns++;
            }

            if (firstPlayerDeck.Any() && secondPlayerDeck.Any())
            {
                if (firstPlayerDeck.Count > secondPlayerDeck.Count)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                }
                else if (firstPlayerDeck.Count < secondPlayerDeck.Count)
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {turns} turns");
                }
            }
            else if (!firstPlayerDeck.Any() && !secondPlayerDeck.Any())
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (firstPlayerDeck.Any() && !secondPlayerDeck.Any())
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (!firstPlayerDeck.Any() && secondPlayerDeck.Any())
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }

        private static void AddCardsInList(List<string> currentCards, string fpCardOne, string fpCardTwo, string fpCardThree, string spCardOne, string spCardTwo, string spCardThree)
        {
            currentCards.Add(fpCardOne);
            currentCards.Add(fpCardTwo);
            currentCards.Add(fpCardThree);
            currentCards.Add(spCardOne);
            currentCards.Add(spCardTwo);
            currentCards.Add(spCardThree);
        }

        private static int GetCardsValue(string cardOne, string cardTwo, string cardThree)
        {
            int value = (cardOne[cardOne.Length - 1] - 'a' + 1) +
                (cardTwo[cardTwo.Length - 1] - 'a' + 1) +
                (cardThree[cardThree.Length - 1] - 'a' + 1);

            return value;
        }
    }
}
