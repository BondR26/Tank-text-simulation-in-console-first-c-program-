using System;
using LibraryTanks;
using System.Collections.Generic;
using System.ComponentModel;

class Colission
{
    private List<Tank> OneSide;
    private List<Tank> SecondSide;

    public Colission(ref List<Tank> os, ref List<Tank> ss)
    {
        OneSide = os;
        SecondSide = ss;
    }
    public void Fight()
    {
        int count = 0;
        bool flag = false;

        while (true)
        {
            flag = false;

            //Console.Clear();

            

            Console.WriteLine(OneSide[count].ToString() + "\nVS\n");
            Console.WriteLine(SecondSide[count].ToString());


            while (flag != true)
            {
                Console.WriteLine(OneSide[count] * SecondSide[count]);
                Console.WriteLine(SecondSide[count] * OneSide[count]);


                if (OneSide[count].Attack() <= 0 || OneSide[count].Defense() <= 0)
                {
                    Console.WriteLine(OneSide[count].Name_Model() + " have fallen\n");
                    OneSide.RemoveAt(count);
                    flag = true;
                }
                else if (SecondSide[count].Attack() <= 0 || SecondSide[count].Defense() <= 0)
                {
                    Console.WriteLine(SecondSide[count].Name_Model() + " have fallen\n");
                    SecondSide.RemoveAt(count);
                    flag = true;
                }
            }

         

            if(OneSide.Count <= 0)
            {
                Console.WriteLine("Team " + SecondSide[count].Name_Model() + " won\n");
                break;
            }
            else if(SecondSide.Count <= 0)
            {
                Console.WriteLine("Team " + OneSide[count].Name_Model() + " won\n");
                break;
            }

        }
    }

}

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Tank> Germans = new List<Tank>{new Panther("Klaus", new Random().Next(0, 10)), new Panther("Otto", new Random().Next(0, 10)) , new Panther("Vilgelm", new Random().Next(0, 10)),
            new Panther("Till", new Random().Next(0, 10)) ,new Panther("Rudolf", new Random().Next(0, 10)) };

            List<Tank> Russians = new List<Tank>{new T34("Sergey", new Random().Next(5, 12)), new T34("Petro", new Random().Next(5, 12)) , new T34("Ivan", new Random().Next(5, 12)) ,
            new T34("Roman", new Random().Next(5, 12)),new T34("Nikolay", new Random().Next(5, 12))};

            Colission cl = new Colission(ref Germans, ref Russians);

            cl.Fight();

        }
    }
}
