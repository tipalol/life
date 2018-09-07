using System;
using System.Collections.Generic;
using System.IO;
// <copyright file="Game.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Sorokin Dmitrii</author>
// <date>08/30/2018 12:10:53 AM </date>
// <summary>Game main class, realize game logic</summary>
namespace Life
{
    public class Game
    {
        public static int mode;
        private int year = 2000;
        static int startCountOfPersons = 100;
        private List<Person> persons = new List<Person>();
        private bool life = true;

        private string GenerateName(int len)
        {
            Random r = new Random(SecureRandom.Next());
            string[] consonants = { "б", "в", "г", "д", "ж", "з", "к", "л", "м", "н", "п", "р", "с", "т", "й", "х", "ш" };
            string[] vowels = { "а", "е", "и", "о", "у", "э", "я" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
        private void AddRandomPerson()
        {
            Random random = new Random(SecureRandom.Next());
            persons.Add(new Person(GenerateName(random.Next(4, 6)), random.Next(16, 46), random.Next(1000, 100000)));
        }
        public void SaveGame()
        {
            StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "/saves/save");
            streamWriter.WriteLine(persons.Count);
            for (int i = 0; i < persons.Count; i++)
            {
                streamWriter.WriteLine(persons[i].getName());
                streamWriter.WriteLine(persons[i].getAge());
                streamWriter.WriteLine(persons[i].getMoney());
                streamWriter.WriteLine(persons[i].getAlive());
            }
            streamWriter.Close();
        }
        public void LoadGame()
        {
            StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "/saves/save");
            Game.mode = Convert.ToInt32(streamReader.ReadLine());
            for (int i = 0; i < Game.mode; i++)
            {
                persons.Add(new Person(streamReader.ReadLine(),
                                       Convert.ToInt32(streamReader.ReadLine()),
                                       Convert.ToInt32(streamReader.ReadLine()),
                                       Convert.ToBoolean(streamReader.ReadLine())));
            }
            streamReader.Close();
        }
        private void Tick()
        {

            int deaths = 0;
            int newCommers = 0;
            for (int i = 1; i < persons.Count-1; i++)
            {
                Random _random = new Random(SecureRandom.Next());
                if (persons[i].isAlive())
                {
                    switch (_random.Next(0, 1000))
                    {
                        case 0:
                            new Event(0, persons[i].getName() + " умирает :(").print();
                            persons[i].Kill();
                            persons.Remove(persons[i]);
                            deaths++;
                            break;
                        case 1:
                            AddRandomPerson();
                            new Event(2, persons[persons.Count - 1].getName() + " приезжает в город :)").print();
                            newCommers++;
                            break;
                        case 2:
                            int indexA = _random.Next(1, persons.Count);
                            int indexB = _random.Next(1, persons.Count);

                            if (!persons[indexA].isMeet(indexA))
                            {
                                persons[indexA].AddMeeting(indexB, persons[indexB]);
                                persons[indexB].AddMeeting(indexA, persons[indexA]);
                                new Event(3, persons[indexA].getName() + " знакомится с " + persons[indexB].getName()).print();
                            }

                            break;
                    }
                    persons[i].Tick();
                }
                else { persons.Remove(persons[i]); deaths++; new Event(0, persons[i].getName() + " умирает :(").print(); }
            }
            Random random = new Random(SecureRandom.Next());
            for (int i = 0; i < random.Next(0, 100); i++)
            {
                AddRandomPerson();
                new Event(2, persons[persons.Count - 1].getName() + " приезжает в город :)").print();
                newCommers++;
            }
            Console.WriteLine("Год " + year);
            Console.WriteLine("Население: " + persons.Count);
            Console.WriteLine("Умерло: " + deaths);
            Console.WriteLine("Приехало: " + newCommers);
            year++;
        }
        public Game(int mode)
        {
            Game.mode = mode;
            switch (Game.mode)
            {
                case 1:
                    int a = Convert.ToInt32(startCountOfPersons / 500);
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j <= 500; j++)
                        {
                            AddRandomPerson();
                            //persons[j].debugInfo();
                        }
                    }
                    SaveGame();
                    Tick();
                    string input;
                    while (life)
                    {
                        input = Console.ReadLine();
                        if (input == "exit") { break; }
                        Tick();
                    }

                    break;
                case 2:
                    LoadGame();
                    for (int i = 0; i <= startCountOfPersons; i++)
                    {
                        //persons[i].debugInfo();
                    }
                    break;
            }
        }
    }
}
