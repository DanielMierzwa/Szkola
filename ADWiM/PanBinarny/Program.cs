using PanBinarny.Models;
namespace PanBinarny
{
    internal class Program
    {
        static float LPGCost = 2.59f;
        static float Pb95Cost = 5.89f;
        static CarState car;
        static void Main(string[] args)
        {
            car=new CarState();

            while (car.Drive())
            {

            }
            bool flag = true;
            string inp="";
            while (flag) 
            {
                inp=Console.ReadLine();
                int z;
                if (!int.TryParse(inp, out z))
                    z = -10;
                switch (z)
                {
                    case 1:
                        Console.WriteLine("1.Tankowano LPG:" + car.Fuel.TankedLPG + " razy");
                        break;
                    case 2:
                        Console.WriteLine("2.Tankowano Pb95:" + car.Fuel.TankedPb95 + " razy");
                        break;
                    case 3:
                        Console.WriteLine("3.Tylko z LPG korzystano łącznie " + car.onlyLPGDays + " dni");
                        break;
                    case 4:
                        Console.WriteLine("4.Pierwszy dzień gdy LPG było poniżej 5,25l:" + car.dayWhenLPGWasBelow525);
                        break;
                    case 5:
                        float result = car.Fuel.TankedLPG * LPGCost + car.Fuel.TankedPb95 * Pb95Cost + 3000;
                        result = (float)Math.Round(result, 2, MidpointRounding.ToEven);
                        Console.WriteLine("5.Koszt eksploatacji:" + result.ToString() + "zł");
                        break;
                    default: flag = false;break;
                }
            }
            
            if(!int.TryParse(inp,out int x)) 
            {
                Console.WriteLine("Wprowadzona wartość nie jest liczbą całkowitą ");
            }
            else
            {
                Console.WriteLine("Nie ma takiego zadania  ");
            }



        }
    }
}
