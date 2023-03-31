using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1
{
    internal class CBookCard:IComparable<CBookCard>
    {
        private readonly string author;
        private readonly string header;
        private readonly int yearOfPublish;
        private readonly int numberOfPages;
        private readonly string udk;
        private readonly string circulation;
        private int raiting;
        private string comment;

        public string Author { get; }
        public string Header { get; }
        public int YearOfPublish { get; }
        public int NumberOfPages { get; }
        public string Udk { get; }
        public string Circulation { get; }
        public int Rating
        {
            get { return raiting; }
            set {

                if (raiting > 15 || raiting < 0)
                    WriteLine("Рейтинг должен быть  в диапозоне от 0 до 15");

                else raiting = value;

            }
        }
        public string Comment { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="author"></param>
        /// <param name="header"></param>
        /// <param name="yearOfPublish"></param>
        /// <param name="numberOfPAges"></param>
        /// <param name="udk"></param>
        /// <param name="circulation"></param>
        public CBookCard(string author, string header, int yearOfPublish, int numberOfPAges, string udk, string circulation)
        {
            this.author = author;
            this.header = header;
            this.yearOfPublish = yearOfPublish;
            this.numberOfPages = numberOfPAges;
            this.udk = udk;
            this.circulation = circulation;
        }

        /// <summary>
        /// вывод
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var helper = udk.Split(',', '.', '/', ' ', '-', '_');
            string newudk = string.Empty;
            foreach (var item in helper)
                newudk += item + " ";

            return $"Автор: {author}\n" +
                $"Заголовок: {header}\n" +
                $"Год публикации: {yearOfPublish}\n" +
                $"Число страниц: {numberOfPages}\n" +
                $"УДК: {newudk}\n" +
                $"Тираж: {circulation}\n" +
                $"Рейтинг: {raiting}\n";
        }

        //public static void Sorting(CBookCard[] cBookCards)
        //{
        //    var sortedCBookCards = cBookCards.OrderBy(item => item.yearOfPublish);
        //    foreach (var item in sortedCBookCards)                      
        //        WriteLine(item);
        //}

        public int CompareTo(CBookCard? card)
        {
            if (card is null) throw new ArgumentException("неверное значение");
            else return yearOfPublish.CompareTo(card.yearOfPublish);

        }
    }
}
