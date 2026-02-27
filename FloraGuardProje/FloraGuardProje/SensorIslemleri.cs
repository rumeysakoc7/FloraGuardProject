using StokTakipSistemi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class SensorIslemleri
    {
        public void Ekle(SensorVeri veri)
        {
            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = "INSERT INTO SensorVerileri (BitkiID, ToprakNemi, OlcumZamani) VALUES (@BitkiID, @ToprakNemi, @OlcumZamani)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@BitkiID", veri.BitkiID);
                    cmd.Parameters.AddWithValue("@ToprakNemi", veri.ToprakNemi);
                    cmd.Parameters.AddWithValue("@OlcumZamani", veri.OlcumZamani);

                    SqlBaglanti.Instance.OpenConnection();
                    cmd.ExecuteNonQuery();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sensor verisi eklenirken hata oluştu: " + ex.Message);
            }
         }


        public List<SensorVeri> GetirSensorVerileri(int bitkiID)
        {
            List<SensorVeri> veriler = new List<SensorVeri>();

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = "SELECT * FROM SensorVerileri WHERE BitkiID = @BitkiID ORDER BY OlcumZamani ASC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BitkiID", bitkiID);

                    SqlBaglanti.Instance.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        veriler.Add(new SensorVeri
                        {
                            SensorVeriID = Convert.ToInt32(reader["SensorVeriID"]),
                            BitkiID = Convert.ToInt32(reader["BitkiID"]),
                            ToprakNemi = Convert.ToInt32(reader["ToprakNemi"]),
                            OlcumZamani = Convert.ToDateTime(reader["OlcumZamani"])
                        });
                    }

                    reader.Close();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken hata oluştu: " + ex.Message);
            }

            return veriler;
        }

        public List<SensorVeri> GetirSensorVerileriTarihle(int bitkiID, DateTime baslangic, DateTime bitis)
        {
            List<SensorVeri> veriler = new List<SensorVeri>();

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = @"SELECT * FROM SensorVerileri 
                             WHERE BitkiID = @BitkiID 
                             AND OlcumZamani BETWEEN @Baslangic AND @Bitis
                             ORDER BY OlcumZamani ASC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BitkiID", bitkiID);
                    cmd.Parameters.AddWithValue("@Baslangic", baslangic);
                    cmd.Parameters.AddWithValue("@Bitis", bitis);

                    SqlBaglanti.Instance.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        veriler.Add(new SensorVeri
                        {
                            SensorVeriID = Convert.ToInt32(reader["SensorVeriID"]),
                            BitkiID = Convert.ToInt32(reader["BitkiID"]),
                            ToprakNemi = Convert.ToInt32(reader["ToprakNemi"]),
                            OlcumZamani = Convert.ToDateTime(reader["OlcumZamani"])
                        });
                    }

                    reader.Close();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarihli veriler alınırken hata oluştu: " + ex.Message);
            }

            return veriler;
        }

        public List<SensorVeri> GetirSensorVerileriByBitkiID(int bitkiID)
        {
            List<SensorVeri> veriler = new List<SensorVeri>();

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = "SELECT * FROM SensorVerileri WHERE BitkiID = @BitkiID ORDER BY OlcumZamani DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BitkiID", bitkiID);

                    SqlBaglanti.Instance.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        veriler.Add(new SensorVeri
                        {
                            SensorVeriID = Convert.ToInt32(reader["SensorVeriID"]),
                            BitkiID = Convert.ToInt32(reader["BitkiID"]),
                            ToprakNemi = Convert.ToInt32(reader["ToprakNemi"]),
                            OlcumZamani = Convert.ToDateTime(reader["OlcumZamani"])
                        });
                    }

                    reader.Close();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sensor verileri alınırken hata oluştu: " + ex.Message);
            }

            return veriler;
        }



    }

}
