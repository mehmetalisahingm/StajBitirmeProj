namespace HomeAssis
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());




            Sensorler sensorler = new Sensorler();

            Thread t1 = new Thread(sensorler.ReadTemperature);
            Thread t2 = new Thread(sensorler.ReadHumidity);
            Thread t3 = new Thread(sensorler.ReadDoor);
            Thread t4 = new Thread(sensorler.ReadSmoke);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            // Threadlerin bitmesini bekle
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            Console.WriteLine("Tüm sensörler okundu.");


        }
    }
}
