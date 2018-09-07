using System;
// <copyright file="Program.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Sorokin Dmitrii</author>
// <date>08/30/2018 12:10:53 AM </date>
// <summary>Program entry point</summary>

namespace Life
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Life v1.0");
            Console.WriteLine("Начать новую игру? (1 - да, 2 - нет - загрузить сохраненную");
            int mode = Convert.ToInt32( Console.ReadLine() );
            Game game = new Game(mode);
        }
    }
}
