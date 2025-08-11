using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HomeAssis
{
    public partial class Form1 : Form
    {
        // Veritaban� dosyan�n yolunu buraya yaz
        private string connString = "Data Source=C:\\Users\\Rsa004\\Desktop\\sensors.db;Version=3;";

        public Form1()
        {
            InitializeComponent();
            LoadSensors();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event tetiklendi�inde yap�lacak i�lemler buraya
        }

        private void LoadSensors()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Sensorler"; // veya sensorler tablosu ad� ne ise

                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri �ekme hatas�: " + ex.Message);
            }
        }
    }
}
