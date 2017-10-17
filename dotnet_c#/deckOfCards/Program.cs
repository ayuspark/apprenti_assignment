using System;
using System.Collections.Generic;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>();
            myDeck.CreateDeck();
            myDeck.ShowDeck();
        }

        class Card
        {
            public string StringVal { private set; get; }
            public int Val { private set; get; }
            public string Suit { private set; get; }

            public Card(string stringVal, string suit, int val)
            {
                StringVal = stringVal;
                Suit = suit;
                Val = val;
            }

            public void ShowCard(){
                string output = $"{this.Suit} {this.StringVal}";
                Console.WriteLine($"This card is {output}");
            }
        }

        class Deck
        {
            public List<Card> Cards { set; get; }
            public List<Card> CreateDeck(){
                //List<object> deckOfCards = new List<object>();
                string[] suits = { "spade", "heart", "diamond", "clubs" };
                Dictionary<int, string> stringValDict = new Dictionary<int, string>
                {
                    { 11, "jack"},
                    { 12, "queen"},
                    { 13, "king"},
                };
                foreach (string suit in suits){
                    for (int i = 1; i <= 13; i++){
                        if (i < 11) {
                            Card oneCard = new Card(stringVal: i.ToString(), suit: suit, val: i);
                            Cards.Add(oneCard);
                        }
                        else {
                            Card oneCard = new Card(stringVal: stringValDict[i], suit: suit, val: i);
                            Cards.Add(oneCard);
                        }
                    }
                }
                return Cards;
            }

            public void ShowDeck(){
                foreach (Card card in Cards){
                    card.ShowCard();
                }
            }
        }
    }
}
