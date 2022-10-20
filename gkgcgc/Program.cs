using System;
using System.Reflection.Metadata.Ecma335;
using static Ежедневник2snl.Program;

namespace Ежедневник2snl
{
    class Program
    {
        static void Main(string[] args)
        {
            strelka();
        }
        static void desctop(Zametka itemin, ConsoleKeyInfo keyin)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(itemin.Name);
                Console.WriteLine(itemin.Description);
                ConsoleKeyInfo keyB = Console.ReadKey();
                keyin = keyB;
                Console.Clear();
            } while (keyin.Key != ConsoleKey.Escape);
        }
        static int arrow(ConsoleKeyInfo key1, int pos1)
        {
            if (key1.Key == ConsoleKey.DownArrow)
            {
                pos1++;
            }
            if (key1.Key == ConsoleKey.UpArrow)
            {
                pos1--;
            }
            return pos1;
        }
        static DateTime Date(DateTime stdatein, ConsoleKeyInfo keyin)
        {
            if (keyin.Key == ConsoleKey.RightArrow)
            {
                stdatein = stdatein.AddDays(1);
            }
            else if (keyin.Key == ConsoleKey.LeftArrow)
            {
                stdatein = stdatein.AddDays(-1);
            }
            return stdatein;
        }
        static Zametka[] AllNotes()
        {
            Zametka date1zam1 = new Zametka();
            date1zam1.Name = "Поиграть в PUBG";
            date1zam1.pos = 1;
            date1zam1.Description = "Играть на турике 300+ adr и жестко унижать лохов";
            date1zam1.Date = new DateTime(2022, 10, 19);
            Zametka date2zam1 = new Zametka();
            date2zam1.Name = "Сходить в магазин";
            date2zam1.pos = 1;
            date2zam1.Description = "Сходить в магазин и купить себе покушать (например, пельмени)";
            date2zam1.Date = new DateTime(2022, 10, 20);
            Zametka date2zam2 = new Zametka();
            date2zam2.Name = "Поиграть с кошкой";
            date2zam2.pos = 2;
            date2zam2.Description = "Отодвинь все дела и удели время любимому питомцу";
            date2zam2.Date = new DateTime(2022, 10, 20);
            Zametka date3zam1 = new Zametka();
            date3zam1.Name = "Убраться в комнате";
            date3zam1.pos = 1;
            date3zam1.Description = "Раз в неделю надо поддерживать чистоту комнаты";
            date3zam1.Date = new DateTime(2022, 10, 21);
            Zametka date3zam2 = new Zametka();
            date3zam2.Name = "Заняться саморазвитием";
            date3zam2.pos = 2;
            date3zam2.Description = "Заняться полезным и приятным делом - саморазвитием";
            date3zam2.Date = new DateTime(2022, 10, 21);
            Zametka[] zam = new Zametka[] { date1zam1, date2zam1, date2zam2, date3zam1, date3zam2 };
            return zam;
        }
        static void strelka()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            int position = 1;
            DateTime stdate = new DateTime(2022, 10, 19);
            while (key.Key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, 1);
                stdate = Date(stdate, key);
                position = arrow(key, position);
                Console.Clear();
                Console.WriteLine("Выбрана дата " + stdate.ToString("dd.MM.yyyy"));
                Zametka[] notes = AllNotes();
                foreach (Zametka item in notes)
                {
                    if (item.Date == stdate.Date)
                    {
                        Console.WriteLine("  " + item.Name);
                        if (key.Key == ConsoleKey.Enter && item.pos == position)
                        {
                            desctop(item, key);
                            Console.Clear();
                        }
                    }
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                ConsoleKeyInfo keyA = Console.ReadKey();
                key = keyA;
            }
        }
    }
}