using System;


namespace Goods
{
    class Program
    {
        static void Main(string[] args)
        {
            Tyre tyre = new Tyre(1,"Michelin",16, 205,55,true);
            Tyre tyre2 = new Tyre(2, "KamaEuro", 15, 210, 60, false);
            JsonRepository<Tyre> tyreRepository = new JsonRepository<Tyre>();

            tyreRepository.GoodIsAdded += (message => Console.WriteLine(DateTime.Now +"  "+ message));
            tyreRepository.GoodIsNotAdded += (message => Console.WriteLine(DateTime.Now+message));

            tyreRepository.AddItem(tyre);
            tyreRepository.AddItem(tyre2);

            Console.ReadLine();
        }
       
    }
}
