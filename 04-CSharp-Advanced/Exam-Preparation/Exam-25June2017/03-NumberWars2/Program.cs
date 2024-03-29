﻿using System;
using System.Collections.Generic;
using System.Linq;

class NumberWars
{
    static void Main()
    {
        var firstAllCards = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        var secondAllCards = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        int turnsCounter = 0;
        bool gameOver = false;

        while (!gameOver && turnsCounter < 1000000 && firstAllCards.Count != 0 && secondAllCards.Count != 0)
        {
            turnsCounter++;

            var firstPlayerCard = firstAllCards.Dequeue();
            var secondPlayerCard = secondAllCards.Dequeue();

            int firstValue = GetNumberValue(firstPlayerCard);
            int secondValue = GetNumberValue(secondPlayerCard);

            if (firstValue > secondValue)
            {
                firstAllCards.Enqueue(firstPlayerCard);
                firstAllCards.Enqueue(secondPlayerCard);
            }
            else if (secondValue > firstValue)
            {
                secondAllCards.Enqueue(secondPlayerCard);
                secondAllCards.Enqueue(firstPlayerCard);
            }
            else
            {
                var winnersHand = new List<string> { firstPlayerCard, secondPlayerCard };

                while (!gameOver)
                {
                    if (firstAllCards.Count < 3 || secondAllCards.Count < 3)
                    {
                        gameOver = true;
                        break;
                    }

                    int firstSum = 0;
                    int secondSum = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        firstSum += GetCharValue(firstAllCards.Peek());
                        secondSum += GetCharValue(secondAllCards.Peek());

                        winnersHand.Add(firstAllCards.Dequeue());
                        winnersHand.Add(secondAllCards.Dequeue());
                    }

                    if (firstSum > secondSum)
                    {
                        foreach (var card in winnersHand.OrderByDescending(x => GetNumberValue(x)).ThenByDescending(x => GetCharValue(x)))
                        {
                            firstAllCards.Enqueue(card);
                        }
                        break;
                    }
                    else if (secondSum > firstSum)
                    {
                        foreach (var card in winnersHand.OrderByDescending(x => GetNumberValue(x)).ThenByDescending(x => GetCharValue(x)))
                        {
                            secondAllCards.Enqueue(card);
                        }
                        break;
                    }
                }
            }
        }

        string winner = GetWinner(firstAllCards, secondAllCards);
        Console.WriteLine($"{winner} after {turnsCounter} turns");
    }

    private static int GetCharValue(string v)
    {
        return v.Last();
    }

    private static int GetNumberValue(string firstPlayerCard)
    {
        return int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
    }

    private static string GetWinner(Queue<string> firstAllCards, Queue<string> secondAllCards)
    {
        if (firstAllCards.Count > secondAllCards.Count)
            return "First player wins";
        if (secondAllCards.Count > firstAllCards.Count)
            return "Second player wins";
        else
            return "Draw";
    }
}