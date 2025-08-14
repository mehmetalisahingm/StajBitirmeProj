using System;
using System.Data.SQLite;
using System.Threading;

namespace HomeAssis
{
    public class Sensorler
    {
        public int temp;
        public int nem;
        public int kapi;
        public int duman;

        public int tempesik = 38;
        public int nemesik = 85;
        public int dumanesik = 95;

        private Random rnd = new Random();
        private string connString = "Data Source=C:\\Users\\Rsa004\\source\\repos\\HomeAssis\\sensors.db;Version=3;";
        //private string connString = "Data Source=C:\\Users\\mehmet\\Desktop\\sensors.db;Version=3;";

       
        private void SaveToDatabase()
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                string sql = "INSERT INTO Sensors (Temp, Humidity, DoorStatus, Smoke, Date) VALUES (@t, @n, @k, @d, @date)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@t", temp);
                    cmd.Parameters.AddWithValue("@n", nem);
                    cmd.Parameters.AddWithValue("@k", kapi);
                    cmd.Parameters.AddWithValue("@d", duman);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.ExecuteNonQuery();
                }

            
                if (temp > tempesik || nem > nemesik || duman > dumanesik)
                {
                    string sqlAlarm = "INSERT INTO Alarms (Temp, Humidity, DoorStatus, Smoke, Date) VALUES (@t, @n, @k, @d, @date)";
                    using (var cmdAlarm = new SQLiteCommand(sqlAlarm, conn))
                    {
                        cmdAlarm.Parameters.AddWithValue("@t", temp);
                        cmdAlarm.Parameters.AddWithValue("@n", nem);
                        cmdAlarm.Parameters.AddWithValue("@k", kapi);
                        cmdAlarm.Parameters.AddWithValue("@d", duman);
                        cmdAlarm.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmdAlarm.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmdAlarm.ExecuteNonQuery();
                    }
                }
            }
        }

      
        public void LoadThresholds()
        {
            using var conn = new SQLiteConnection(connString);
            conn.Open();

            string createTable = @"
                CREATE TABLE IF NOT EXISTS Thresholds (
                    SensorType TEXT PRIMARY KEY,
                    ThresholdValue INTEGER
                );
            ";
            using (var cmdCreate = new SQLiteCommand(createTable, conn))
            {
                cmdCreate.ExecuteNonQuery();
            }

            string insertDefaults = @"
                INSERT OR IGNORE INTO Thresholds (SensorType, ThresholdValue) VALUES ('Temp', 38);
                INSERT OR IGNORE INTO Thresholds (SensorType, ThresholdValue) VALUES ('Humidity', 85);
                INSERT OR IGNORE INTO Thresholds (SensorType, ThresholdValue) VALUES ('Smoke', 95);
            ";
            using (var cmdDefaults = new SQLiteCommand(insertDefaults, conn))
            {
                cmdDefaults.ExecuteNonQuery();
            }

            string query = "SELECT SensorType, ThresholdValue FROM Thresholds";
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string type = reader.GetString(0);
                int value = reader.GetInt32(1);

                switch (type)
                {
                    case "Temp":
                        tempesik = value;
                        break;
                    case "Humidity":
                        nemesik = value;
                        break;
                    case "Smoke":
                        dumanesik = value;
                        break;
                }
            }
        }

        public void UpdateThreshold(string sensorType, int newValue)
        {
            using var conn = new SQLiteConnection(connString);
            conn.Open();

            string sql = @"
                INSERT INTO Thresholds (SensorType, ThresholdValue) VALUES (@sensorType, @value)
                ON CONFLICT(SensorType) DO UPDATE SET ThresholdValue=excluded.ThresholdValue;
            ";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sensorType", sensorType);
            cmd.Parameters.AddWithValue("@value", newValue);
            cmd.ExecuteNonQuery();

            switch (sensorType)
            {
                case "Temp": tempesik = newValue; break;
                case "Humidity": nemesik = newValue; break;
                case "Smoke": dumanesik = newValue; break;
            }
        }

    
        private void ReadTemperature() => temp = rnd.Next(20, 40);
        private void ReadHumidity() => nem = rnd.Next(30, 90);
        private void ReadDoor() => kapi = rnd.Next(0, 2);
        private void ReadSmoke() => duman = rnd.Next(0, 100);

     
        public void StartSensors()
        {
            LoadThresholds();

            new Thread(() =>
            {
                while (true)
                {
                    ReadTemperature();
                    ReadHumidity();
                    ReadDoor();
                    ReadSmoke();
                    SaveToDatabase();
                    Thread.Sleep(5000);
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
