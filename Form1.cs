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
        //private string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";
        private string connString = @"Data Source=C:\Users\mehmet\Desktop\sensors.db;Version=3;";

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

            // DataGridView2’ye AlarmMessage sütunu ekle
            if (!dataGridView2.Columns.Contains("AlarmMessage"))
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "AlarmMessage";
                col.HeaderText = "Alarm Mesajı";
                col.ReadOnly = true;
                dataGridView2.Columns.Add(col);
            }

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();

            MessageBox.Show("Sensörler çalışmaya başladı, veriler veritabanına yazılıyor.");
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

                DateTime alarmTime = DateTime.Parse(row.Cells["Date"].Value.ToString());

                string alarmMessage = "";
                if (temp > sensor.tempesik) alarmMessage += $"Sıcaklık alarmı {temp}°C, ";
                if (nem > sensor.nemesik) alarmMessage += $"Nem alarmı {nem}%, ";
                if (duman > sensor.dumanesik) alarmMessage += $"Duman alarmı {duman}%, ";

                if (!string.IsNullOrEmpty(alarmMessage))
                {
                    alarmMessage = alarmMessage.TrimEnd(',', ' ');
                    row.Cells["AlarmMessage"].Value = $"{alarmTime:HH:mm} - {alarmMessage}";
                }
                else
                {
                    row.Cells["AlarmMessage"].Value = "";
                }

                row.Cells["Temp"].Style.BackColor = temp > sensor.tempesik ? System.Drawing.Color.Red : System.Drawing.Color.White;
                row.Cells["Temp"].Style.ForeColor = temp > sensor.tempesik ? System.Drawing.Color.White : System.Drawing.Color.Black;

                row.Cells["Humidity"].Style.BackColor = nem > sensor.nemesik ? System.Drawing.Color.Red : System.Drawing.Color.White;
                row.Cells["Humidity"].Style.ForeColor = nem > sensor.nemesik ? System.Drawing.Color.White : System.Drawing.Color.Black;

                row.Cells["Smoke"].Style.BackColor = duman > sensor.dumanesik ? System.Drawing.Color.Red : System.Drawing.Color.White;
                row.Cells["Smoke"].Style.ForeColor = duman > sensor.dumanesik ? System.Drawing.Color.White : System.Drawing.Color.Black;
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
            string newSensorColumn = Microsoft.VisualBasic.Interaction.InputBox(
                "Veri taban�na eklenecek yeni sens�r s�tun ad�n� girin:",
                "Yeni Sens�r Ekle",
                "YeniSensor");

            if (string.IsNullOrWhiteSpace(newSensorColumn))
            {
                MessageBox.Show("Ge�erli bir sens�r ad� girmediniz.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(newSensorColumn, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("S�tun ad� sadece harf, rakam veya alt �izgi i�ermelidir.");
                return;
            }

            //string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";
            string connString = @"Data Source=C:\Users\mehmet\Desktop\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                string sql = $"ALTER TABLE Sensors ADD COLUMN [{newSensorColumn}] INTEGER DEFAULT 0";

                using var cmd = new SQLiteCommand(sql, conn);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"'{newSensorColumn}' sens�r s�tunu ba�ar�yla eklendi.");
                }
                catch (SQLiteException ex)
                {
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

            //string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";
            string connString = @"Data Source=C:\Users\mehmet\Desktop\sensors.db;Version=3;";

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                var columns = new List<string>();
                using (var cmd = new SQLiteCommand("PRAGMA table_info(Sensors);", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(1));
                    }
                }

                if (!columns.Any(c => c.Equals(sensorToDelete, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"'{sensorToDelete}' adl� s�tun tablo i�inde bulunamad�.");
                    return;
                }

                var remainingColumns = columns.Where(c => !c.Equals(sensorToDelete, StringComparison.OrdinalIgnoreCase)).ToList();

                if (remainingColumns.Count == 0)
                {
                    MessageBox.Show("Tabloda en az bir s�tun olmal�d�r. Silme i�lemi iptal edildi.");
                    return;
                }

                using (var tran = conn.BeginTransaction())
                {

                    string createNewTable = "CREATE TABLE Sensors_new AS SELECT " + string.Join(", ", remainingColumns) + " FROM Sensors;";
                    using (var cmdCreate = new SQLiteCommand(createNewTable, conn, tran))
                    {
                        cmdCreate.ExecuteNonQuery();
                    }

                    using (var cmdDrop = new SQLiteCommand("DROP TABLE Sensors;", conn, tran))
                    {
                        cmdDrop.ExecuteNonQuery();
                    }

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

            //string connString = @"Data Source=C:\Users\Rsa004\source\repos\HomeAssis\sensors.db;Version=3;";
            string connString = @"Data Source=C:\Users\mehmet\Desktop\sensors.db;Version=3;";

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Sensors ve Alarms tablolarındaki tüm veriler silinecek ve ID'ler sıfırlanacak. Devam etmek istiyor musunuz?",
                "Verileri Temizle",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            try
            {
                using var conn = new SQLiteConnection(connString);
                conn.Open();

                using var tran = conn.BeginTransaction();

                new SQLiteCommand("DELETE FROM Sensors;", conn, tran).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM Alarms;", conn, tran).ExecuteNonQuery();

                new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='Sensors';", conn, tran).ExecuteNonQuery();
                new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='Alarms';", conn, tran).ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show("Tüm veriler silindi ve ID'ler sıfırlandı.");

                LoadDataFromDb();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler silinirken hata oluştu: " + ex.Message);
            }
        }


    }
}

