using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Stage
    {
        protected uint dueTime;
        protected uint finance;
        protected List<Worker> team = new List<Worker>();

        public Stage(uint dueTime, uint finance, uint number, bool salary)
        {
            this.dueTime = dueTime;
            this.finance = finance;
            if (salary)
                for (int i = 0; i < number; i++)
                {
                    WriteLine($"Введите зарплату {i + 1}-го человека");
                    string helper = ReadLine(); Worker worker = new Worker();
                    if (uint.TryParse(helper, out var result))
                    {
                        worker.Salary = result;
                        team.Add(worker);
                    }
                    else
                    {
                        Console.WriteLine("Введите допустимое значение");
                        i--;
                    }
                }
            else
                team = Worker.SetTeam(number);
        }
        public Stage(uint dueTime, uint finance, uint number) : this(dueTime, finance, number, false) { }

        public uint DueTime
        {
            get { return dueTime; }
            set { dueTime = value; }
        }

        public uint Team
        {
            get
            {
                int i = 0;
                do
                {
                    i++;
                    return team[i].Salary;
                }
                while (i < team.Count());
            }
            set
            {
                for (int i = 0; i < team.Count(); i++)
                {
                    WriteLine($"Введите зарплату {i + 1}-го человека");
                    string helper = ReadLine();
                    if (uint.TryParse(helper, out var result))
                        team[i].Salary = result;
                    else
                    {
                        Console.WriteLine("Введите допустимое значение");
                        i--;
                    }
                }


            }
        }

        public uint Finance
        {
            get { return finance; }
            set { finance = value; }
        }

        public uint ExpensesForProject(List<Stage> project)
        {
            uint sum = 0;
            foreach (var item in project) 
                sum += ExpensesForStsge(item);
            return sum;
        }

        public uint ExpensesForStsge(Stage stage) 
        {
            uint sum=stage.finance;
            for(int i = 0; i < stage.team.Count();i++) 
                sum += team[i].Salary;
            return sum;
        }

        public override string ToString()
        {
            for (int i = 0; i < team.Count(); i++)
                WriteLine($"зарплата {i + 1} - го работника: {team[i].Salary}");
            return $"dueTime: {dueTime}\nfinance: {finance}";
        }

    }

    public class Analizing : Stage
    {
        public Analizing(uint dueTime, uint finance, uint number, bool salary) : base(dueTime, finance, number, salary) { }
        public Analizing(uint dueTime, uint finance, uint number) : base(dueTime, finance, number) { }

    }

    public class Projecting : Stage
    {
        public Projecting(uint dueTime, uint finance, uint number, bool salary) : base(dueTime, finance, number, salary) { }
        public Projecting(uint dueTime, uint finance, uint number) : base(dueTime, finance, number) { }

    }

    public class Coding : Stage
    {
        public Coding(uint dueTime, uint finance, uint number, bool salary) : base(dueTime, finance, number, salary) { }
        public Coding(uint dueTime, uint finance, uint number) : base(dueTime, finance, number) { }

    }

    public class Testing : Stage
    {
        private int numberOfBugs;
        public int NumberOfBugs
        {
            get { return numberOfBugs; }
            set { numberOfBugs = value; }
        }
        public Testing(uint dueTime, uint finance, uint number, bool salary) : base(dueTime, finance, number, salary) { }
        public Testing(uint dueTime, uint finance, uint number) : base(dueTime, finance, number) { }

    }

    public class Expluatation : Stage
    {
        private DateTime supportPeriod;
        public DateTime SupportPeriod
        {
            get { return supportPeriod; }
            set {; }
        }

        public Expluatation(uint dueTime, uint finance, uint number, bool salary, int year) : base(dueTime, finance, number, salary)
        {
            supportPeriod = new DateTime(year, 1, 1);
        }
        public Expluatation(uint dueTime, uint finance, uint number) : base(dueTime, finance, number) { }

    }

    public class Worker
    {
        public uint Salary { get; set; }
        public static List<Worker> SetTeam(uint number)
        {
            List<Worker> team = new List<Worker>((int)number);
            Random rand = new Random();
            for (int i = 0; i < number; i++)
            {
                Worker worker = new Worker();
                worker.Salary = (uint)rand.Next(1000, 10000);
                team.Add(worker);
            }
            return team;
        }
    }
}