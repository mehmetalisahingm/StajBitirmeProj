

//using System;
//using System.Data;
//using System.Data.SQLite;
//using System.Timers;
//using System.Windows.Forms;

//namespace HomeAssis
//{
//    public partial class Form1 : Form
//    {
//        private Sensorler sensor;
//        private System.Windows.Forms.Timer timer;
//        private string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

//        public Form1()
//        {
//            InitializeComponent();

//            this.Load += Form1_Load;
//            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
//            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
//        }


//        private void Form1_Load(object sender, EventArgs e)
//        {
//            sensor = new Sensorler();
//            sensor.StartSensors();


//            timer = new System.Windows.Forms.Timer();
//            timer.Interval = 5000;
//            timer.Tick += Timer_Tick;
//            timer.Start();

//            MessageBox.Show("Sens�rler �al��maya ba�lad�, veriler veritaban�na yaz�l�yor.");
//        }

//        private void Timer_Tick(object sender, EventArgs e)
//        {
//            LoadDataFromDb();
//        }

//        private void LoadDataFromDb()
//        {
//            try
//            {
//                using (var conn = new SQLiteConnection(connString))
//                {
//                    conn.Open();

//                    string querySensors = "SELECT * FROM Sensors ORDER BY Date DESC";
//                    using (var adapter = new SQLiteDataAdapter(querySensors, conn))
//                    {
//                        DataTable dtSensors = new DataTable();
//                        adapter.Fill(dtSensors);
//                        dataGridView1.DataSource = dtSensors;
//                    }

//                    string queryAlarms = "SELECT * FROM Alarms ORDER BY Date DESC";
//                    using (var adapterAlarm = new SQLiteDataAdapter(queryAlarms, conn))
//                    {
//                        DataTable dtAlarms = new DataTable();
//                        adapterAlarm.Fill(dtAlarms);
//                        dataGridView2.DataSource = dtAlarms;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Veri y�klenirken hata: " + ex.Message);
//            }
//        }

//        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
//        {
//            foreach (DataGridViewRow row in dataGridView1.Rows)
//            {
//                if (row.IsNewRow) continue;

//                int temp = 0, nem = 0, duman = 0;

//                if (row.Cells["Temp"].Value != DBNull.Value)
//                    int.TryParse(row.Cells["Temp"].Value.ToString(), out temp);
//                if (row.Cells["Humidity"].Value != DBNull.Value)
//                    int.TryParse(row.Cells["Humidity"].Value.ToString(), out nem);
//                if (row.Cells["Smoke"].Value != DBNull.Value)
//                    int.TryParse(row.Cells["Smoke"].Value.ToString(), out duman);


//                row.Cells["Temp"].Style.BackColor = System.Drawing.Color.White;
//                row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.Black;

//                row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.White;
//                row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.Black;

//                row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.White;
//                row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.Black;


//                if (temp > 38)
//                {
//                    row.Cells["Temp"].Style.BackColor = System.Drawing.Color.Red;
//                    row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.White;
//                }
//                if (nem > 85)
//                {
//                    row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.Red;
//                    row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.White;
//                }
//                if (duman > 95)
//                {
//                    row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.Red;
//                    row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.White;
//                }
//            }
//        }


//        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
//        {
//            foreach (DataGridViewRow row in dataGridView2.Rows)
//            {
//                if (row.IsNewRow) continue;

//                int temp = 0, nem = 0, duman = 0;

//                if (row.Cells["Temp"].Value != DBNull.Value)
//                    int.TryParse(row.Cells["Temp"].Value.ToString(), out temp);
//                if (row.Cells["Humidity"].Value != DBNull.Value)
//                    int.TryParse(row.Cells["Humidity"].Value.ToString(), out nem);
//                if (row.Cells["Smoke"].Value != DBNull.Value)
//                    int.TryParse(row.Cells["Smoke"].Value.ToString(), out duman);


//                row.Cells["Temp"].Style.BackColor = System.Drawing.Color.White;
//                row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.Black;

//                row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.White;
//                row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.Black;

//                row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.White;
//                row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.Black;

//                if (temp > 38)
//                {
//                    row.Cells["Temp"].Style.BackColor = System.Drawing.Color.Red;
//                    row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.White;
//                }
//                if (nem > 85)
//                {
//                    row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.Red;
//                    row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.White;
//                }
//                if (duman > 95)
//                {
//                    row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.Red;
//                    row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.White;
//                }
//            }
//        }
//        private string ShowSelectionDialog(string[] options)
//        {
//            using (Form form = new Form())
//            {
//                form.Width = 250;
//                form.Height = 150;
//                form.Text = "E�ik Se�imi";

//                ListBox listBox = new ListBox()
//                {
//                    Dock = DockStyle.Top,
//                    Height = 70
//                };
//                listBox.Items.AddRange(options);
//                form.Controls.Add(listBox);

//                Button okButton = new Button()
//                {
//                    Text = "Tamam",
//                    Dock = DockStyle.Bottom,
//                    DialogResult = DialogResult.OK
//                };
//                form.Controls.Add(okButton);

//                form.AcceptButton = okButton;

//                if (form.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
//                {
//                    return listBox.SelectedItem.ToString();
//                }
//                else
//                {
//                    return null;
//                }
//            }
//        }
//        public void UpdateThreshold(string sensorType, int newValue)
//        {
//            using var conn = new SQLiteConnection(connString);
//            conn.Open();

//            string sql = @"
//        INSERT INTO Thresholds (SensorType, ThresholdValue) VALUES (@sensorType, @value)
//        ON CONFLICT(SensorType) DO UPDATE SET ThresholdValue=excluded.ThresholdValue;
//    ";

//            using var cmd = new SQLiteCommand(sql, conn);
//            cmd.Parameters.AddWithValue("@sensorType", sensorType);
//            cmd.Parameters.AddWithValue("@value", newValue);
//            cmd.ExecuteNonQuery();


//            switch (sensorType)
//            {
//                case "Temp": tempesik = newValue; break;
//                case "Humidity": nemesik = newValue; break;
//                case "Smoke": dumanesik = newValue; break;
//            }
//        }


//        private void btn2_Click(object sender, EventArgs e)
//        {

//            string[] options = { "S�cakl�k", "Nem", "Duman"};

//            string selected = ShowSelectionDialog(options);
//            if (string.IsNullOrEmpty(selected))
//                return; 

//            string input = Microsoft.VisualBasic.Interaction.InputBox(
//                $"Yeni {selected} e�ik de�erini girin:", "E�ik De�eri G�ncelleme", "0");

//            if (int.TryParse(input, out int newThreshold))
//            {

//                switch (selected)
//                {
//                    case "S�cakl�k":
//                        sensor.tempesik = newThreshold;
//                        break;
//                    case "Nem":
//                        sensor.nemesik = newThreshold;
//                        break;
//                    case "Duman":
//                        sensor.dumanesik = newThreshold;
//                        break;

//                }

//                MessageBox.Show($"{selected} e�ik de�eri {newThreshold} olarak g�ncellendi.");
//            }
//            else
//            {
//                MessageBox.Show("Ge�erli bir say� girmediniz.");
//            }
//        }

//    }
//}




using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HomeAssis
{
    public partial class Form1 : Form
    {
        private Sensorler sensor;
        private System.Windows.Forms.Timer timer;
        private string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
            dataGridView2.DataBindingComplete += DataGridView2_DataBindingComplete;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sensor = new Sensorler();
            sensor.StartSensors();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();

            MessageBox.Show("Sens�rler �al��maya ba�lad�, veriler veritaban�na yaz�l�yor.");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadDataFromDb();
        }

        private void LoadDataFromDb()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();

                    string querySensors = "SELECT * FROM Sensors ORDER BY Date DESC";
                    using (var adapter = new SQLiteDataAdapter(querySensors, conn))
                    {
                        DataTable dtSensors = new DataTable();
                        adapter.Fill(dtSensors);
                        dataGridView1.DataSource = dtSensors;
                    }

                    string queryAlarms = "SELECT * FROM Alarms ORDER BY Date DESC";
                    using (var adapterAlarm = new SQLiteDataAdapter(queryAlarms, conn))
                    {
                        DataTable dtAlarms = new DataTable();
                        adapterAlarm.Fill(dtAlarms);
                        dataGridView2.DataSource = dtAlarms;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri y�klenirken hata: " + ex.Message);
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int temp = 0, nem = 0, duman = 0;

                if (row.Cells["Temp"].Value != DBNull.Value)
                    int.TryParse(row.Cells["Temp"].Value.ToString(), out temp);
                if (row.Cells["Humidity"].Value != DBNull.Value)
                    int.TryParse(row.Cells["Humidity"].Value.ToString(), out nem);
                if (row.Cells["Smoke"].Value != DBNull.Value)
                    int.TryParse(row.Cells["Smoke"].Value.ToString(), out duman);

                // �ncelikle t�m h�creleri varsay�lan renge d�nd�r
                row.Cells["Temp"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.Black;

                row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.Black;

                row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.Black;

                // E�iklere g�re renklendir
                if (temp > sensor.tempesik)
                {
                    row.Cells["Temp"].Style.BackColor = System.Drawing.Color.Red;
                    row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.White;
                }
                if (nem > sensor.nemesik)
                {
                    row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.Red;
                    row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.White;
                }
                if (duman > sensor.dumanesik)
                {
                    row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.Red;
                    row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                int temp = 0, nem = 0, duman = 0;

                if (row.Cells["Temp"].Value != DBNull.Value)
                    int.TryParse(row.Cells["Temp"].Value.ToString(), out temp);
                if (row.Cells["Humidity"].Value != DBNull.Value)
                    int.TryParse(row.Cells["Humidity"].Value.ToString(), out nem);
                if (row.Cells["Smoke"].Value != DBNull.Value)
                    int.TryParse(row.Cells["Smoke"].Value.ToString(), out duman);

                row.Cells["Temp"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.Black;

                row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.Black;

                row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.Black;

                if (temp > sensor.tempesik)
                {
                    row.Cells["Temp"].Style.BackColor = System.Drawing.Color.Red;
                    row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.White;
                }
                if (nem > sensor.nemesik)
                {
                    row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.Red;
                    row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.White;
                }
                if (duman > sensor.dumanesik)
                {
                    row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.Red;
                    row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private string ShowSelectionDialog(string[] options)
        {
            using (Form form = new Form())
            {
                form.Width = 250;
                form.Height = 150;
                form.Text = "E�ik Se�imi";

                ListBox listBox = new ListBox()
                {
                    Dock = DockStyle.Top,
                    Height = 70
                };
                listBox.Items.AddRange(options);
                form.Controls.Add(listBox);

                Button okButton = new Button()
                {
                    Text = "Tamam",
                    Dock = DockStyle.Bottom,
                    DialogResult = DialogResult.OK
                };
                form.Controls.Add(okButton);

                form.AcceptButton = okButton;

                if (form.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
                {
                    return listBox.SelectedItem.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string[] options = { "Temp", "Humidity", "Smoke" };

            string selected = ShowSelectionDialog(options);
            if (string.IsNullOrEmpty(selected))
                return;

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Yeni {selected} e�ik de�erini girin:", "E�ik De�eri G�ncelleme", "0");

            if (int.TryParse(input, out int newThreshold))
            {
                // Sens�r s�n�f�ndaki e�ik de�eri g�ncelle
                sensor.UpdateThreshold(selected, newThreshold);

                MessageBox.Show($"{selected} e�ik de�eri {newThreshold} olarak g�ncellendi.");
            }
            else
            {
                MessageBox.Show("Ge�erli bir say� girmediniz.");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            // Kullan�c�dan yeni sens�r s�tun ad�n� al (�rnek: "Pressure", "Light", vb.)
            string newSensorColumn = Microsoft.VisualBasic.Interaction.InputBox(
                "Veri taban�na eklenecek yeni sens�r s�tun ad�n� girin:",
                "Yeni Sens�r Ekle",
                "YeniSensor");

            if (string.IsNullOrWhiteSpace(newSensorColumn))
            {
                MessageBox.Show("Ge�erli bir sens�r ad� girmediniz.");
                return;
            }

            // S�tun ad� i�in basit kontrol (yaln�zca harf ve rakam)
            if (!System.Text.RegularExpressions.Regex.IsMatch(newSensorColumn, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("S�tun ad� sadece harf, rakam veya alt �izgi i�ermelidir.");
                return;
            }

            // SQLite ba�lant� dizesi
            string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                // S�tun eklemek i�in ALTER TABLE sorgusu
                // Burada s�tun tipi INTEGER olarak varsay�ld�, ihtiyac�n�za g�re de�i�tirin
                string sql = $"ALTER TABLE Sensors ADD COLUMN [{newSensorColumn}] INTEGER DEFAULT 0";

                using var cmd = new SQLiteCommand(sql, conn);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"'{newSensorColumn}' sens�r s�tunu ba�ar�yla eklendi.");
                }
                catch (SQLiteException ex)
                {
                    // E�er s�tun zaten varsa hata d�ner, burada yakalan�yor
                    if (ex.Message.Contains("duplicate column name"))
                    {
                        MessageBox.Show($"'{newSensorColumn}' s�tunu zaten mevcut.");
                    }
                    else
                    {
                        MessageBox.Show("S�tun eklenirken hata: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritaban� ba�lant�s�nda hata: " + ex.Message);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string sensorToDelete = Microsoft.VisualBasic.Interaction.InputBox(
                "Silmek istedi�iniz sens�r s�tun ad�n� girin:",
                "Sens�r Sil",
                "S�tunAd�");

            if (string.IsNullOrWhiteSpace(sensorToDelete))
            {
                MessageBox.Show("Ge�erli bir s�tun ad� girmediniz.");
                return;
            }

            string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                // Mevcut s�tunlar� al
                var columns = new List<string>();
                using (var cmd = new SQLiteCommand("PRAGMA table_info(Sensors);", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(1));
                    }
                }

                // S�tunun varl���n� kontrol et
                if (!columns.Any(c => c.Equals(sensorToDelete, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"'{sensorToDelete}' adl� s�tun tablo i�inde bulunamad�.");
                    return;
                }

                // Silmek istedi�imiz s�tun haricindeki s�tunlar
                var remainingColumns = columns.Where(c => !c.Equals(sensorToDelete, StringComparison.OrdinalIgnoreCase)).ToList();

                if (remainingColumns.Count == 0)
                {
                    MessageBox.Show("Tabloda en az bir s�tun olmal�d�r. Silme i�lemi iptal edildi.");
                    return;
                }

                // Yeni tabloyu olu�tur, veri ta��, eski tabloyu sil, tabloyu yeniden adland�r
                using (var tran = conn.BeginTransaction())
                {
                    // Yeni tablo olu�tur
                    string createNewTable = "CREATE TABLE Sensors_new AS SELECT " + string.Join(", ", remainingColumns) + " FROM Sensors;";
                    using (var cmdCreate = new SQLiteCommand(createNewTable, conn, tran))
                    {
                        cmdCreate.ExecuteNonQuery();
                    }

                    // Eski tabloyu sil
                    using (var cmdDrop = new SQLiteCommand("DROP TABLE Sensors;", conn, tran))
                    {
                        cmdDrop.ExecuteNonQuery();
                    }

                    // Yeni tabloyu yeniden adland�r
                    using (var cmdRename = new SQLiteCommand("ALTER TABLE Sensors_new RENAME TO Sensors;", conn, tran))
                    {
                        cmdRename.ExecuteNonQuery();
                    }

                    tran.Commit();
                }

                MessageBox.Show($"'{sensorToDelete}' s�tunu ba�ar�yla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("S�tun silinirken hata olu�tu: " + ex.Message);
            }
        }


        private void btn4_Click(object sender, EventArgs e)
        {
            string oldName = Microsoft.VisualBasic.Interaction.InputBox(
                "De�i�tirmek istedi�iniz sens�r s�tun ad�n� girin:",
                "Sens�r D�zenle",
                "EskiSutunAd�");

            if (string.IsNullOrWhiteSpace(oldName))
            {
                MessageBox.Show("Ge�erli bir eski s�tun ad� girmediniz.");
                return;
            }

            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                $"'{oldName}' s�tununun yeni ad�n� girin:",
                "Sens�r D�zenle",
                "YeniSutunAd�");

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Ge�erli bir yeni s�tun ad� girmediniz.");
                return;
            }

            string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                string sql = $"ALTER TABLE Sensors RENAME COLUMN [{oldName}] TO [{newName}];";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"'{oldName}' s�tunu '{newName}' olarak ba�ar�yla de�i�tirildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("S�tun ad� de�i�tirilirken hata: " + ex.Message);
            }
        }

    }
}

