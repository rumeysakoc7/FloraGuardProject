using StokTakipSistemi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Serilog;

namespace FloraGuardProje
{
    public partial class Loglar : Form
    {
        public Loglar()
        {
            InitializeComponent();
        }

        private void Loglar_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerbaslangic.Value = DateTime.Today.AddDays(-7);
                dateTimePickerbitis.Value = DateTime.Today;

                dateTimePickerbaslangic.ValueChanged += dateTimePickerbaslangic_ValueChanged;
                dateTimePickerbitis.ValueChanged += dateTimePickerbitis_ValueChanged;

                LoglariYukle();

                dataGridViewloglar.AllowUserToAddRows = false;
                dataGridViewloglar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                Log.Information("Loglar formu yüklendi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Loglar_Load sırasında hata oluştu.");
                MessageBox.Show("Form yüklenirken hata oluştu:\n" + ex.Message);
            }
        }

        private void dateTimePickerbaslangic_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoglariYukle();
                Log.Information("Başlangıç tarihi değiştirildi: {Baslangic}", dateTimePickerbaslangic.Value);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Başlangıç tarihi değiştirilirken hata oluştu.");
                MessageBox.Show("Başlangıç tarihi değiştirilirken hata oluştu:\n" + ex.Message);
            }
        }

        private void dateTimePickerbitis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoglariYukle();
                Log.Information("Bitiş tarihi değiştirildi: {Bitis}", dateTimePickerbitis.Value);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bitiş tarihi değiştirilirken hata oluştu.");
                MessageBox.Show("Bitiş tarihi değiştirilirken hata oluştu:\n" + ex.Message);
            }
        }

        private void LoglariYukle()
        {
            try
            {
                DateTime baslangic = dateTimePickerbaslangic.Value.Date;
                DateTime bitis = dateTimePickerbitis.Value.Date.AddDays(1).AddSeconds(-1);

                if (baslangic > bitis)
                {
                    MessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz.");
                    Log.Warning("Geçersiz tarih aralığı: Başlangıç > Bitiş");
                    return;
                }

                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string query = @"
                        SELECT 
                            Id,
                            Message,
                            Level,
                            TimeStamp,
                            Exception
                        FROM Loglar
                        WHERE TimeStamp BETWEEN @baslangic AND @bitis
                        ORDER BY TimeStamp DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@baslangic", baslangic);
                        cmd.Parameters.AddWithValue("@bitis", bitis);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridViewloglar.DataSource = dt;

                            Log.Information("Loglar {RowCount} kayıtla başarıyla yüklendi.", dt.Rows.Count);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Logları yüklerken hata oluştu.");
                MessageBox.Show("Loglar yüklenirken hata oluştu:\n" + ex.Message);
            }
        }
    }
}
