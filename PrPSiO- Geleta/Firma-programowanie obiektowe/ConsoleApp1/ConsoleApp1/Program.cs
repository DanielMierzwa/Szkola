

using ConsoleApp1;

public class MainClass()
{
    static double Porownaj(Firma f, Firma g)
    {
        if (f.wartosc > g.wartosc)
        {
            return f.wartosc;
        }
        return g.wartosc;
    }
}