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
            Console.WriteLine("Koniec");
        }
    }
}
