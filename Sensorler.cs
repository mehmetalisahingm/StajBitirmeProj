//using System;
//using System.Threading;

//namespace HomeAssis
//{
//    public class Sensorler
//    {
//        public int temp;
//        public int nem;
//        public int kapi;
//        public int duman;

//        public void ReadTemperature()
//        {
//            Random rnd = new Random();
//            temp = rnd.Next(20, 40);
//            Console.WriteLine($"Temperature read: {temp}°C");
//        }

//        public void ReadHumidity()
//        {
//            Random rnd = new Random();
//            nem = rnd.Next(30, 90);
//            Console.WriteLine($"Humidity read: {nem}%");
//            if (nem > 85)
//            {
//                Console.WriteLine("aşırı nemli");
//            }
//            else
//            {
//                Console.WriteLine("nem düzeyi normal");
//            }
//        }

//        public void ReadDoor()
//        {
//            Random rnd = new Random();
//            kapi = rnd.Next(0, 2);
//            Console.WriteLine($"Door status read: {(kapi == 0 ? "Closed" : "Open")}");
//        }

//        public void ReadSmoke()
//        {
//            Random rnd = new Random();
//            duman = rnd.Next(0, 100);
//            if (duman > 5)
//            {
//                Console.WriteLine("duman tespit edilmedi");
//            }
//            else
//            {
//                Console.WriteLine("duman tespit edildi");
//            }
//        }
//    }


//}
using System;
using System.Threading;

namespace HomeAssis
{
    public class Sensorler
    {
        public int temp;
        public int nem;
        public int kapi;
        public int duman;

        private Random rnd = new Random();

        public void ReadTemperature()
        {
            temp = rnd.Next(20, 40);
            Console.WriteLine($"Temperature read: {temp}°C");
        }

        public void ReadHumidity()
        {
            nem = rnd.Next(30, 90);
            Console.WriteLine($"Humidity read: {nem}%");
            if (nem > 85)
                Console.WriteLine("Aşırı nemli");
            else
                Console.WriteLine("Nem düzeyi normal");
        }

        public void ReadDoor()
        {
            kapi = rnd.Next(0, 2);
            Console.WriteLine($"Door status read: {(kapi == 0 ? "Closed" : "Open")}");
        }

        public void ReadSmoke()
        {
            duman = rnd.Next(0, 100);
            if (duman > 5)
                Console.WriteLine("Duman tespit edilmedi");
            else
                Console.WriteLine("Duman tespit edildi");
        }

        public void StartSensors()
        {
            new Thread(() =>
            {
                while (true)
                {
                    ReadTemperature();
                    Thread.Sleep(30000); // 30 saniye bekle
                }
            })
            { IsBackground = true }.Start();

            new Thread(() =>
            {
                while (true)
                {
                    ReadHumidity();
                    Thread.Sleep(30000);
                }
            })
            { IsBackground = true }.Start();

            new Thread(() =>
            {
                while (true)
                {
                    ReadDoor();
                    Thread.Sleep(30000);
                }
            })
            { IsBackground = true }.Start();

            new Thread(() =>
            {
                while (true)
                {
                    ReadSmoke();
                    Thread.Sleep(30000);
                }
            })
            { IsBackground = true }.Start();
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Sensorler sens = new Sensorler();
    //        sens.StartSensors();

    //        Console.WriteLine("Sensörler çalışıyor. Çıkmak için bir tuşa basın...");
    //        Console.ReadKey();
    //    }
    //}
}


//using System;
//using System.Runtime.CompilerServices;
//using System.Threading;

//namespace HomeAssis
//{
//    public class Sensorler
//    {
//        public int temp;
//        public int nem;
//        public int kapi;
//        public int duman;
//        public int tempesik = 38;
//        public int nemesik = 85;
//        public int dumanesik =5;

//        private Random rnd = new Random();

//        public void ReadTemperature()
//        {
//            temp = rnd.Next(20, 40);
//            Console.WriteLine($"Temperature read: {temp}°C");
//        }

//        public void ReadHumidity()
//        {
//            nem = rnd.Next(30, 90);
//            Console.WriteLine($"Humidity read: {nem}%");
//            if (nem > nemesik)
//                Console.WriteLine("Aşırı nemli");
//            else
//                Console.WriteLine("Nem düzeyi normal");
//        }

//        public void ReadDoor()
//        {
//            kapi = rnd.Next(0, 2);
//            Console.WriteLine($"Door status read: {(kapi == 0 ? "Closed" : "Open")}");
//        }

//        public void ReadSmoke()
//        {
//            duman = rnd.Next(0, 100);
//            Console.WriteLine($"duman yüzdesi {duman}"); 
                
//            if (duman > dumanesik)
//                Console.WriteLine("Duman tespit edilmedi");
//            else
//                Console.WriteLine("Duman tespit edildi");
//        }

//        public void StartSensors()
//        {
//            new Thread(() =>
//            {
//                while (true)
//                {
//                    ReadTemperature();
//                    Thread.Sleep(5000); 
//                }
//            })
//            { IsBackground = true }.Start();

//            new Thread(() =>
//            {
//                while (true)
//                {
//                    ReadHumidity();
//                    Thread.Sleep(5000);
//                }
//            })
//            { IsBackground = true }.Start();

//            new Thread(() =>
//            {
//                while (true)
//                {
//                    ReadDoor();
//                    Thread.Sleep(5000);
//                }
//            })
//            { IsBackground = true }.Start();

//            new Thread(() =>
//            {
//                while (true)
//                {
//                    ReadSmoke();
//                    Thread.Sleep(5000);
//                }
//            })
//            { IsBackground = true }.Start();
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Sensorler sens = new Sensorler();
//            sens.StartSensors();

//            Console.WriteLine("Sensörler çalışıyor. Çıkmak için bir tuşa basın...");
//            Console.ReadKey();
//        }
//    }
//}
