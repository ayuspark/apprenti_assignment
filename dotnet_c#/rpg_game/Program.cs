using System;
using System.Collections.Generic;

namespace rpg_game
{
    class Human
    {
        public string Name { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }

        public Human() { }

        public Human(string name, int intelligence = 3, int strength = 3, int health = 100, int dexterity = 3)
        {
            Name = name;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Strength = strength;
            Health = health;
        }

        public void Attack(Human human)
        {
            human.Health -= Strength * 5;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"name: {this.Name}");
            Console.WriteLine($"health: {this.Health}");
            Console.WriteLine($"intelli: {this.Intelligence}");
            Console.WriteLine($"dext: {this.Dexterity}");
            Console.WriteLine($"strength: {Strength}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
        }
    }

    class Wizard : Human
    {
        //TODO: how do you inherit constructor
        public Wizard(string name, int intelligence = 25, int strength = 3, int health = 50, int dexterity = 3)
        {
            Name = name;
            Intelligence = intelligence;
            Strength = strength;
            Health = health;
            Dexterity = dexterity;
        }

        public void Heal()
        {
            this.Intelligence += 10;
            Console.WriteLine($"********** Wizard {this.Name} is healing!");
        }

        public void Fireball(Human obj)
        {
            Random randInt = new Random();
            int attack = randInt.Next(20, 51);
            obj.Health -= attack;
            Console.WriteLine($"********** a fireball attacked {obj.Name}, health: {obj.Health}, dropped {attack}!");
        }
    }


    class KungfuPerson : Human
    {
        private static List<KungfuPerson> kungfuPersonList = new List<KungfuPerson>();
        public KungfuPerson(string name, int intelligence = 25, int strength = 3, int health = 50, int dexterity = 175)
        {
            Name = name;
            Intelligence = intelligence;
            Strength = strength;
            Health = health;
            Dexterity = dexterity;
            kungfuPersonList.Add(this);
        }

        public void Steal(Human obj)
        {
            this.Attack(obj);
            this.Health += 10;
            Console.WriteLine($"************ KungfuPerson {Name} attack {obj.Name}!");
        }

        public void GetAway()
        {
            this.Health -= 15;
            Console.WriteLine("************* KungfuPerson ran away.");
        }

        public static int HowMany()
        {
            int count = KungfuPerson.kungfuPersonList.Count;
            Console.WriteLine($"************* {count} kungfuPersons here.");
            return count;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Wizard myWizard = new Wizard("bojack");
            Human myHuman = new Human("lola");
            KungfuPerson myKungfu = new KungfuPerson("pb");

            myHuman.ShowStatus();
            myWizard.Fireball(myHuman);
            myHuman.ShowStatus();

            myKungfu.ShowStatus();
            myKungfu.GetAway();
            myKungfu.ShowStatus();

            KungfuPerson.HowMany();
        }
    }
}