using ClassLibrary;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Expluatation stage = new Expluatation(0,0,2,false,2030);
        WriteLine(stage.SupportPeriod);
        WriteLine(stage);
    }
}
