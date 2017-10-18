using System;
using System.Collections.Generic;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
			Deck myDeck = new Deck();
            myDeck.ShowDeck();
			myDeck.Deal();
            myDeck.Deal();
            myDeck.Deal();
            myDeck.ShuffleCards();
            Console.WriteLine(myDeck.Cards.Count);

            Player myPlayer = new Player("lola");
            Console.WriteLine(myPlayer.Name);
            myPlayer.Draw(myDeck);
            myPlayer.Draw(myDeck);
            myPlayer.Draw(myDeck);
            myPlayer.ShowHand();
            Console.WriteLine("Hand: {0}", myPlayer.Hand.Count);
            myPlayer.Discard(0);
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
            public Deck(){
                Cards = new List<Card>();
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
            }

            public void ShuffleCards(){
                Random rand = new Random();
                for (int idx = 0; idx < Cards.Count - 1; idx++) {
                    int randIdx = rand.Next(idx + 1, Cards.Count - 1);
                    Card tempCard = Cards[idx];
                    Cards[idx] = Cards[randIdx];
                    Cards[randIdx] = tempCard;
                }
            }

            public Card Deal(){
                this.ShuffleCards();
                Card dealtCard;
                dealtCard = this.Cards[this.Cards.Count - 1];
                this.Cards.RemoveAt(Cards.Count - 1);
                Console.WriteLine("++++++++++++++++++++++++ Dealer dealt you this card: ");
                dealtCard.ShowCard();
                return dealtCard;
            }

            public void ShowDeck(){
                foreach (Card card in Cards){
                    card.ShowCard();
                }
            }
        }

        class Player
        {
            public string Name { set; get; }

            public List<Card> Hand { set; get; }

            public Player(string name){
                Name = name;
                this.Hand = new List<Card>();
            }

            public Card Draw(Deck deck) {
                Card cardToDraw = deck.Deal();
                this.Hand.Add(cardToDraw);
                Console.WriteLine("+++++++++++++++++++++++ I draw this card: ");
                cardToDraw.ShowCard();
                return cardToDraw;
            }

            public Card Discard(int idx) {
                Console.WriteLine("+++++++++++++++++++++ I discarded this card: ");
                try {
                    Hand[idx].ShowCard();
                    Card cardToDiscard = Hand[idx];
                    Hand.RemoveAt(idx);
                    return cardToDiscard; 
                }
                catch (System.ArgumentOutOfRangeException) {
                    Console.WriteLine("++++++++++++++++++++ I am too stupid to know how many cards I have.");
                    return null;
                }
            }
            public void ShowHand() {
                Console.WriteLine("****************************** this is my Hand: ");
                foreach (Card card in this.Hand) {
                    card.ShowCard();
                }
            }
        }
    }
}
