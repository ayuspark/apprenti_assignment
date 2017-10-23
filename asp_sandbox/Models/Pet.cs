using System;
using System.Diagnostics.Contracts;

namespace asp_sandbox
{
    public class Pet
    {
        //public string Name { get; private set; }
        public int Happiness { get; set; }
        public int Fullness { get; set; }
        public int Energy { get; set; }
        public int Meal { get; set; }
        public string output { get; set; }
        private Random rand { get; set; }

        public Pet()
        {
            //Name = name;
            Happiness = 5;
            Fullness = 5;
            Energy = 5;
            Meal = 7;
            rand = new Random();
        }

        public Pet Feed()
        {
            Contract.Ensures(Contract.Result<Pet>() != null);
            if (Meal > 0)
            {
                int possibility = rand.Next(1, 5);
                if (possibility / 4.00 > 1 / 4.00)
                {
                    Meal--;
                    Fullness += rand.Next(5, 11);
                    output = $"You feed it a meal, {Meal} left.\nIt's {Fullness} full.";
                } else
                {
                    Meal--;
                    output = $"You feed it a meal, {Meal} left.\nBut it ain't like it.";
                }
            } else
            {
                output = "You have no meals to feed it.";
            }
            return this;
        }

        public Pet Play()
        {
            if (Energy >= 5)
            {
                if (rand.Next(1, 5) / 4.00 >= 1 / 4.00)
                {
                    Energy -= 5;
                    Happiness += rand.Next(5, 11);
                    output = $"Played with it. It has {Energy} energy left and {Happiness} happiness.";
                } else
                {
                    Energy -= 5;
                    output = $"Played with it. It has {Energy} energy left but it ain't like it.";
                }
            } else
            {
                output = $"It does not have enough energy to play. Energy left: {Energy}.";
            }
            return this;
        }

        public Pet Work()
        {
            if (Energy > 5)
            {
                Meal += rand.Next(1, 4);
                Energy -= 5;
                output = $"Worked. Now energy left: {Energy}, Meal: {Meal}";
            } else
            {
                output = $"Not enough energy to work. Energy left: {Energy}.";
            }
            return this;
        }

        public Pet Sleep()
        {
            Energy += 15;
            output = $"Slept. Now Energy: {Energy}, Happiness: {Happiness}, Fullness: {Fullness}.";
            return this;
        }
    }
}
