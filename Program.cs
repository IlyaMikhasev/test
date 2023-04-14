using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace test
{
    enum yearMonth
    {
        январь,
        февраль,
        март,
        апрель,
        май,
        июнь,
        июль,
        август,
        сентябрь,
        октябрь,
        ноябрь,
        декабрь
    }
    class MetersData
    {
        public void addDateHW(int hotwater) {
            _hot.Add(hotwater);
        }
        public void addDateCW(int coldwater)
        {
            _cold.Add(coldwater);
        }

        public List<int> _hot = new List<int>();
        public List<int> _cold = new List<int>();
        public List<int> _res= new List<int>();
    }
    internal class Program
    {
        static void ResultYear() {
            MetersData metersData = new MetersData();
            int hotwater ,coldwater,htmp=9999999,ctmp=9999999;
            bool correctInputhot = true;
            bool correctInputcold = true;
            yearMonth month = yearMonth.январь;
            ConsoleKey key;
            for (int i = 0; i < 12; i++)
            {
                do
                {
                    try
                    {                        
                        Console.WriteLine($"Введите показания холодной воды за {month}");
                        coldwater = int.Parse(Console.ReadLine());
                        if (coldwater < ctmp || coldwater > 99999999)
                        {
                            correctInputcold = false;
                        }
                        else
                        {
                            correctInputcold = true;
                            metersData.addDateCW(coldwater);
                        }
                        Console.WriteLine($"Введите показания горячей воды за {month}");
                        hotwater = int.Parse(Console.ReadLine());
                        if (hotwater < htmp || hotwater > 99999999)
                        {

                            correctInputhot = false;
                        }
                        else
                        {
                            correctInputhot = true;
                            metersData.addDateHW(hotwater);
                        }
                        Console.WriteLine("для завершения записи нажмите [Q]");  
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Неверный ввод данных");
                    }

                } while (!correctInputcold && !correctInputhot);
                month += 1;
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q)
                    break;
                Console.Clear();
            }
            month = yearMonth.январь;
            DateTime time = DateTime.Now;   
            var streamwriter = new StreamWriter($"file"+time.ToString("MM.dd")+".txt");
            for (int i = 0; i < metersData._hot.Count; i++)
            {
                Console.WriteLine($"{month}\tгорячая  вода\t{metersData._hot[i]}");
                streamwriter.WriteLine($"{month}\tгорячая  вода\t{metersData._hot[i]}");
                Console.WriteLine($"{month}\tхолодная вода\t{metersData._cold[i]}");
                streamwriter.WriteLine($"{month}\tхолодная вода\t{metersData._cold[i]}");
                month += 1;
            }
            streamwriter.Close();
        }
       
        static void Main(string[] args)
        {
            ResultYear();
           
        }
    }
}
