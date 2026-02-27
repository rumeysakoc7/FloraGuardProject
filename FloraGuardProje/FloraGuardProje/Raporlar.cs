using StokTakipSistemi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Serilog;

namespace FloraGuardProje
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime baslangic = dateTimePickerbaslangic.Value.Date;
                DateTime bitis = dateTimePickerbitis.Value.Date.AddDays(1).AddSeconds(-1);
                DateTime raporZamani = DateTime.Now;
                int aktifKullaniciID = KullaniciSession.AktifKullanici.KullaniciID;
                int raporID;

                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    conn.Open();

                    string insertRaporQuery = @"INSERT INTO Raporlar 
                        (RaporOlusturmaZamani, BaslangicTarihi, BitisTarihi, OlusturanKullaniciID)
                        VALUES (@zaman, @baslangic, @bitis, @kullaniciID);
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmdInsert = new SqlCommand(insertRaporQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@zaman", raporZamani);
                        cmdInsert.Parameters.AddWithValue("@baslangic", baslangic);
                        cmdInsert.Parameters.AddWithValue("@bitis", bitis);
                        cmdInsert.Parameters.AddWithValue("@kullaniciID", aktifKullaniciID);
                        raporID = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }

                    string selectQuery = @"SELECT 
                        sv.OlcumZamani AS Tarih,
                        b.Tur + ' - ' + b.Cesit AS BitkiAdi,
                        sv.ToprakNemi,
                        ht.HastalikAdi,
                        ht.IlacTuru,
                        t.GuvenOrani,
                        CASE 
                            WHEN t.MudahaleEdildi = 1 THEN 'Evet'
                            WHEN t.MudahaleEdildi = 0 THEN 'Hayır'
                            ELSE 'Yok'
                        END AS MudahaleDurumu
                    FROM SensorVerileri sv
                    INNER JOIN Bitki b ON sv.BitkiID = b.BitkiID
                    LEFT JOIN HastalikTespitleri t ON t.BitkiID = sv.BitkiID 
                        AND CAST(t.TespitZamani AS DATE) = CAST(sv.OlcumZamani AS DATE)
                    LEFT JOIN HastalikTipleri ht ON t.HastalikTipID = ht.HastalikTipID
                    WHERE sv.OlcumZamani BETWEEN @baslangic AND @bitis
                    ORDER BY sv.OlcumZamani DESC;";

                    using (SqlCommand cmdSelect = new SqlCommand(selectQuery, conn))
                    {
                        cmdSelect.Parameters.AddWithValue("@baslangic", baslangic);
                        cmdSelect.Parameters.AddWithValue("@bitis", bitis);

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = cmdSelect.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string insertDetail = @"INSERT INTO RaporDetaylari
                                (RaporID, Tarih, BitkiAdi, ToprakNemi, HastalikAdi, IlacTuru, GuvenOrani, MudahaleDurumu)
                                VALUES (@raporID, @tarih, @bitkiAdi, @nem, @hastalik, @ilac, @guven, @mudahale)";

                            using (SqlCommand cmdDetail = new SqlCommand(insertDetail, conn))
                            {
                                cmdDetail.Parameters.AddWithValue("@raporID", raporID);
                                cmdDetail.Parameters.AddWithValue("@tarih", row["Tarih"]);
                                cmdDetail.Parameters.AddWithValue("@bitkiAdi", row["BitkiAdi"]);
                                cmdDetail.Parameters.AddWithValue("@nem", row["ToprakNemi"]);
                                cmdDetail.Parameters.AddWithValue("@hastalik", row["HastalikAdi"] ?? DBNull.Value);
                                cmdDetail.Parameters.AddWithValue("@ilac", row["IlacTuru"] ?? DBNull.Value);
                                cmdDetail.Parameters.AddWithValue("@guven", row["GuvenOrani"] ?? DBNull.Value);
                                cmdDetail.Parameters.AddWithValue("@mudahale", row["MudahaleDurumu"]);
                                cmdDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    conn.Close();
                }

                MessageBox.Show("✅ Rapor başarıyla oluşturuldu.");
                Log.Information("Rapor başarıyla oluşturuldu. RaporID={RaporID}", raporID);
                RaporBasliklariniYukle();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Rapor oluşturulurken hata oluştu.");
                MessageBox.Show("❌ Hata oluştu:\n" + ex.Message);
            }
        }

        private void RaporBasliklariniYukle()
        {
            try
            {
                dataGridViewrapor.Rows.Clear();
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        r.RaporID, r.RaporOlusturmaZamani, r.BaslangicTarihi, r.BitisTarihi, k.KullaniciAdi
                        FROM Raporlar r
                        JOIN Kullanicilar k ON r.OlusturanKullaniciID = k.KullaniciID
                        ORDER BY r.RaporOlusturmaZamani DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rowIndex = dataGridViewrapor.Rows.Add();
                            DataGridViewRow row = dataGridViewrapor.Rows[rowIndex];

                            row.Cells["RaporID"].Value = reader["RaporID"];
                            row.Cells["RaporOlusturmaZamani"].Value = Convert.ToDateTime(reader["RaporOlusturmaZamani"]).ToString("g");
                            row.Cells["BaslangicTarihi"].Value = Convert.ToDateTime(reader["BaslangicTarihi"]).ToString("d");
                            row.Cells["BitisTarihi"].Value = Convert.ToDateTime(reader["BitisTarihi"]).ToString("d");
                            row.Cells["KullaniciAdi"].Value = reader["KullaniciAdi"].ToString();
                        }
                    }
                }
                Log.Information("Rapor başlıkları başarıyla yüklendi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Rapor başlıkları yüklenirken hata oluştu.");
                MessageBox.Show("Rapor başlıkları yüklenirken hata:\n" + ex.Message);
            }
        }

        private void dataGridViewrapor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int secilenRaporID = Convert.ToInt32(dataGridViewrapor.Rows[e.RowIndex].Cells["RaporID"].Value);

                    if (dataGridViewrapor.Rows.Count > e.RowIndex + 1 &&
                        dataGridViewrapor.Rows[e.RowIndex + 1].Tag?.ToString() == "detay")
                    {
                        while (dataGridViewrapor.Rows.Count > e.RowIndex + 1 &&
                               dataGridViewrapor.Rows[e.RowIndex + 1].Tag?.ToString() == "detay")
                        {
                            dataGridViewrapor.Rows.RemoveAt(e.RowIndex + 1);
                        }
                        return;
                    }

                    DataTable detaylar = new DataTable();
                    using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                    {
                        conn.Open();
                        string query = @"SELECT Tarih, BitkiAdi, ToprakNemi, HastalikAdi, IlacTuru, GuvenOrani, MudahaleDurumu
                                 FROM RaporDetaylari
                                 WHERE RaporID = @raporID
                                 ORDER BY Tarih DESC";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@raporID", secilenRaporID);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(detaylar);
                        }
                    }

                    if (dataGridViewrapor.ColumnCount < 7)
                    {
                        MessageBox.Show("DataGridView'de 7 sütun tanımlı değil, detaylar eklenemiyor.");
                        return;
                    }

                    int insertIndex = e.RowIndex + 1;
                    foreach (DataRow row in detaylar.Rows)
                    {
                        DataGridViewRow detaySatiri = new DataGridViewRow();
                        detaySatiri.CreateCells(dataGridViewrapor);

                        detaySatiri.DefaultCellStyle.BackColor = Color.LightGray;
                        detaySatiri.DefaultCellStyle.Font = new Font(dataGridViewrapor.Font, FontStyle.Italic);
                        detaySatiri.Tag = "detay";

                        detaySatiri.Cells[0].Value = "➤ " + Convert.ToDateTime(row["Tarih"]).ToString("dd.MM.yyyy HH:mm");
                        detaySatiri.Cells[1].Value = row["BitkiAdi"];
                        detaySatiri.Cells[2].Value = row["ToprakNemi"];
                        detaySatiri.Cells[3].Value = row["HastalikAdi"] != DBNull.Value ? row["HastalikAdi"].ToString() : "-";
                        detaySatiri.Cells[4].Value = row["IlacTuru"] != DBNull.Value ? row["IlacTuru"].ToString() : "-";
                        detaySatiri.Cells[5].Value = row["GuvenOrani"] != DBNull.Value ? row["GuvenOrani"].ToString() : "-";
                        detaySatiri.Cells[6].Value = row["MudahaleDurumu"];

                        dataGridViewrapor.Rows.Insert(insertIndex++, detaySatiri);
                    }

                    Log.Information("RaporID {RaporID} için detaylar başarıyla yüklendi.", secilenRaporID);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Detaylar yüklenirken hata oluştu.");
                    MessageBox.Show("Detaylar yüklenirken hata:\n" + ex.Message);
                }
            }
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewrapor.Columns.Clear();
                dataGridViewrapor.Columns.Add("RaporID", "Rapor ID");
                dataGridViewrapor.Columns.Add("RaporOlusturmaZamani", "Rapor Oluşturma");
                dataGridViewrapor.Columns.Add("BaslangicTarihi", "Başlangıç Tarihi");
                dataGridViewrapor.Columns.Add("BitisTarihi", "Bitiş Tarihi");
                dataGridViewrapor.Columns.Add("KullaniciAdi", "Kullanıcı Adı");
                dataGridViewrapor.Columns.Add("Dummy1", "");
                dataGridViewrapor.Columns.Add("Dummy2", "");

                dataGridViewrapor.AllowUserToAddRows = false;
                dataGridViewrapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                RaporBasliklariniYukle();

                Log.Information("Raporlar formu yüklendi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Raporlar_Load sırasında hata oluştu.");
                MessageBox.Show("Form yüklenirken hata:\n" + ex.Message);
            }
        }
    }
}
