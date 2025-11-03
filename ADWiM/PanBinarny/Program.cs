using PanBinarny.Models;
namespace PanBinarny
{
    internal class Program
    {
        static CarState car;
        static void Main(string[] args)
        {
            car=new CarState();

            while (car.Drive())
            {

            }
            Console.WriteLine("1.Tankowano LPG:"+car.Fuel.TankedLPG+" razy");
            Console.WriteLine("2.Tankowano Pb95:" + car.Fuel.TankedPb95 + " razy");
            Console.WriteLine("3.Tylko z LPG korzystano łącznie " + car.onlyLPGDays + " dni");
            Console.WriteLine("4.Pierwszy dzień gdy LPG było poniżej 5,25l:" + car.dayWhenLPGWasBelow525);
        }
    }
}
