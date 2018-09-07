using System;

namespace EbaloNanol
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
