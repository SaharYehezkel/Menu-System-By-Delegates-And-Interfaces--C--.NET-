using System;

namespace Ex04.Menus.Test
{
    public class ShowDateTime
    {
        public static void ShowDate()
        {
            Console.WriteLine("Date: {0}", DateTime.Now.ToShortDateString());
        }

        public static void ShowTime() 
        {
            Console.WriteLine("Time: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}
