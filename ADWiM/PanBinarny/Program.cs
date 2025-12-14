using PanBinarny.Models;
namespace PanBinarny
{
    internal class Program
    {
        static double LPGCost = 2.59f;
        static double Pb95Cost = 5.89f;
        static CarState car;

        static CarState carWeird;
        static void Main(string[] args)
        {
            car = new CarState();
            carWeird = new CarState();

            while (car.Drive()&&carWeird.Drive(true))
            {

            }
            bool flag = true;
            string inp = "";
            while (flag)
            {
                inp = Console.ReadLine();
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
                        double gasoline =  (double)car.Fuel.TankedLitersPb95 * Pb95Cost;
                        double lpg = (double)car.Fuel.TankedLitersLPG * LPGCost +3000;

                        double onlyGasoline = (double)carWeird.Fuel.TankedLitersPb95 * Pb95Cost;
                        onlyGasoline = Math.Round(onlyGasoline, 2, MidpointRounding.ToEven);
                        lpg = Math.Round(lpg, 2, MidpointRounding.ToEven);
                        gasoline = Math.Round(gasoline, 2, MidpointRounding.ToEven);

                        Console.WriteLine("5.Koszt eksploatacji:" + (lpg+gasoline).ToString() + "zł");
                        Console.WriteLine("lpg:" + (lpg -3000).ToString() + "zł");
                        Console.WriteLine("koszt instalacji: 3000zł");
                        Console.WriteLine("pb95:" + (gasoline).ToString() + "zł");
                        Console.WriteLine("Na trybie tylko benzyna:" + (onlyGasoline).ToString() + "zł");
                        break;
                    default: flag = false; break;
                }
            }

            if (!int.TryParse(inp, out int x))

            {
                Console.WriteLine("Wprowadzona wartość nie jest liczbą całkowitą ");
            }
            else
            {
                Console.WriteLine("Nie ma takiego zadania  ");
            }



        }
    }

}//xd
