

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

//            MessageBox.Show("Sensörler çalýþmaya baþladý, veriler veritabanýna yazýlýyor.");
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
//                MessageBox.Show("Veri yüklenirken hata: " + ex.Message);
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
//                form.Text = "Eþik Seçimi";

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

//            string[] options = { "Sýcaklýk", "Nem", "Duman"};

//            string selected = ShowSelectionDialog(options);
//            if (string.IsNullOrEmpty(selected))
//                return; 

//            string input = Microsoft.VisualBasic.Interaction.InputBox(
//                $"Yeni {selected} eþik deðerini girin:", "Eþik Deðeri Güncelleme", "0");

//            if (int.TryParse(input, out int newThreshold))
//            {

//                switch (selected)
//                {
//                    case "Sýcaklýk":
//                        sensor.tempesik = newThreshold;
//                        break;
//                    case "Nem":
//                        sensor.nemesik = newThreshold;
//                        break;
//                    case "Duman":
//                        sensor.dumanesik = newThreshold;
//                        break;

//                }

//                MessageBox.Show($"{selected} eþik deðeri {newThreshold} olarak güncellendi.");
//            }
//            else
//            {
//                MessageBox.Show("Geçerli bir sayý girmediniz.");
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

            MessageBox.Show("Sensörler çalýþmaya baþladý, veriler veritabanýna yazýlýyor.");
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
                MessageBox.Show("Veri yüklenirken hata: " + ex.Message);
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

                // Öncelikle tüm hücreleri varsayýlan renge döndür
                row.Cells["Temp"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Temp"].Style.ForeColor = System.Drawing.Color.Black;

                row.Cells["Humidity"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Humidity"].Style.ForeColor = System.Drawing.Color.Black;

                row.Cells["Smoke"].Style.BackColor = System.Drawing.Color.White;
                row.Cells["Smoke"].Style.ForeColor = System.Drawing.Color.Black;

                // Eþiklere göre renklendir
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
                form.Text = "Eþik Seçimi";

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
                $"Yeni {selected} eþik deðerini girin:", "Eþik Deðeri Güncelleme", "0");

            if (int.TryParse(input, out int newThreshold))
            {
                // Sensör sýnýfýndaki eþik deðeri güncelle
                sensor.UpdateThreshold(selected, newThreshold);

                MessageBox.Show($"{selected} eþik deðeri {newThreshold} olarak güncellendi.");
            }
            else
            {
                MessageBox.Show("Geçerli bir sayý girmediniz.");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            // Kullanýcýdan yeni sensör sütun adýný al (örnek: "Pressure", "Light", vb.)
            string newSensorColumn = Microsoft.VisualBasic.Interaction.InputBox(
                "Veri tabanýna eklenecek yeni sensör sütun adýný girin:",
                "Yeni Sensör Ekle",
                "YeniSensor");

            if (string.IsNullOrWhiteSpace(newSensorColumn))
            {
                MessageBox.Show("Geçerli bir sensör adý girmediniz.");
                return;
            }

            // Sütun adý için basit kontrol (yalnýzca harf ve rakam)
            if (!System.Text.RegularExpressions.Regex.IsMatch(newSensorColumn, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Sütun adý sadece harf, rakam veya alt çizgi içermelidir.");
                return;
            }

            // SQLite baðlantý dizesi
            string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                // Sütun eklemek için ALTER TABLE sorgusu
                // Burada sütun tipi INTEGER olarak varsayýldý, ihtiyacýnýza göre deðiþtirin
                string sql = $"ALTER TABLE Sensors ADD COLUMN [{newSensorColumn}] INTEGER DEFAULT 0";

                using var cmd = new SQLiteCommand(sql, conn);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"'{newSensorColumn}' sensör sütunu baþarýyla eklendi.");
                }
                catch (SQLiteException ex)
                {
                    // Eðer sütun zaten varsa hata döner, burada yakalanýyor
                    if (ex.Message.Contains("duplicate column name"))
                    {
                        MessageBox.Show($"'{newSensorColumn}' sütunu zaten mevcut.");
                    }
                    else
                    {
                        MessageBox.Show("Sütun eklenirken hata: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabaný baðlantýsýnda hata: " + ex.Message);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string sensorToDelete = Microsoft.VisualBasic.Interaction.InputBox(
                "Silmek istediðiniz sensör sütun adýný girin:",
                "Sensör Sil",
                "SütunAdý");

            if (string.IsNullOrWhiteSpace(sensorToDelete))
            {
                MessageBox.Show("Geçerli bir sütun adý girmediniz.");
                return;
            }

            string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                // Mevcut sütunlarý al
                var columns = new List<string>();
                using (var cmd = new SQLiteCommand("PRAGMA table_info(Sensors);", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(1));
                    }
                }

                // Sütunun varlýðýný kontrol et
                if (!columns.Any(c => c.Equals(sensorToDelete, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"'{sensorToDelete}' adlý sütun tablo içinde bulunamadý.");
                    return;
                }

                // Silmek istediðimiz sütun haricindeki sütunlar
                var remainingColumns = columns.Where(c => !c.Equals(sensorToDelete, StringComparison.OrdinalIgnoreCase)).ToList();

                if (remainingColumns.Count == 0)
                {
                    MessageBox.Show("Tabloda en az bir sütun olmalýdýr. Silme iþlemi iptal edildi.");
                    return;
                }

                // Yeni tabloyu oluþtur, veri taþý, eski tabloyu sil, tabloyu yeniden adlandýr
                using (var tran = conn.BeginTransaction())
                {
                    // Yeni tablo oluþtur
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

                    // Yeni tabloyu yeniden adlandýr
                    using (var cmdRename = new SQLiteCommand("ALTER TABLE Sensors_new RENAME TO Sensors;", conn, tran))
                    {
                        cmdRename.ExecuteNonQuery();
                    }

                    tran.Commit();
                }

                MessageBox.Show($"'{sensorToDelete}' sütunu baþarýyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sütun silinirken hata oluþtu: " + ex.Message);
            }
        }


        private void btn4_Click(object sender, EventArgs e)
        {
            string oldName = Microsoft.VisualBasic.Interaction.InputBox(
                "Deðiþtirmek istediðiniz sensör sütun adýný girin:",
                "Sensör Düzenle",
                "EskiSutunAdý");

            if (string.IsNullOrWhiteSpace(oldName))
            {
                MessageBox.Show("Geçerli bir eski sütun adý girmediniz.");
                return;
            }

            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                $"'{oldName}' sütununun yeni adýný girin:",
                "Sensör Düzenle",
                "YeniSutunAdý");

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Geçerli bir yeni sütun adý girmediniz.");
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

                MessageBox.Show($"'{oldName}' sütunu '{newName}' olarak baþarýyla deðiþtirildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sütun adý deðiþtirilirken hata: " + ex.Message);
            }
        }

    }
}

