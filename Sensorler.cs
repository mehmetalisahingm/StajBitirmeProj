using System;

namespace HomeAssis
{
    public class Sensorler
    {
        
        public int temp;
        public int nem;
        public int kapi;
        public int duman;

      
        //public int GetTemperature()
        //{
        //    return temp;
        //}
        //public void SetTemperature(int value)
        //{
        //    temp = value;
        //}

        
        //public int GetHumidity()
        //{
        //    return nem;
        //}
        //public void SetHumidity(int value)
        //{
        //    nem = value;
        //}

        
        //public int GetDoor()
        //{
        //    return kapi;
        //}
        //public void SetDoor(int value)
        //{
        //    kapi = value;
        //}

       
        //public int GetSmoke()
        //{
        //    return duman;
        //}
        //public void SetSmoke(int value)
        //{
        //    duman = value;
        //}

      
        public void ReadTemperature()
        {
          
            Random rnd = new Random();
            temp = rnd.Next(20, 40); 
            Console.WriteLine($"Temperature read: {temp}°C");
        }

        public void ReadHumidity()
        {
            Random rnd = new Random();
            nem = rnd.Next(30, 90);
            Console.WriteLine($"Humidity read: {nem}%");
            if (nem > 85)
            {
                Console.WriteLine("aşırı nemli");
            }
            else 
            {
                Console.WriteLine( "nem düzeyi normal");
            }

        }

        public void ReadDoor()
        {
            Random rnd = new Random();
            kapi = rnd.Next(0, 2); 
            Console.WriteLine($"Door status read: {(kapi == 0 ? "Closed" : "Open")}");
        }

        public void ReadSmoke()
        {
            Random rnd = new Random();
            duman = rnd.Next(0,100); 
            if (duman >5)
            {
                Console.WriteLine( "duman tespit edilmedi");
            }
            else
            {
                Console.WriteLine( "duman tespit edildi");
            }

        }
    }
}
