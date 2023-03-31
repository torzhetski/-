using static System.Console;
using System.Collections.Generic;
using zadanie_1;

class Program
{
    static void Main()
    {  
        CBookCard book1 = new CBookCard("имя1","заголовок1",2001,501, "351.821,621.753.3","тираж1");
        CBookCard book2 = new CBookCard("имя2", "заголовок2", 2002, 502, "352.822,622.753.3", "тираж2");
        WriteLine(book1);WriteLine(book2);
        ReadKey();
        Clear();
        CBookCard book3 = new CBookCard("имя3", "заголовок3", 2003, 503, "352.823,623.753.3", "тираж3");
        CBookCard book4 = new CBookCard("имя4", "заголовок4", 2004, 504, "352.824,624.753.3", "тираж4");

        CBookCard[] cBookCards = new CBookCard[] { book4, book1, book2, book3, book1 };
        
        WriteLine("Массив книг до сортировки: ");
        foreach (var item in cBookCards)
        {
            WriteLine(item);
        }
        Array.Sort(cBookCards);
        WriteLine("Массив книг после сортировки: ");
        foreach (var item in cBookCards)
        {
            WriteLine(item);
        }
        //CBookCard.Sorting(cBookCards);

    }


}