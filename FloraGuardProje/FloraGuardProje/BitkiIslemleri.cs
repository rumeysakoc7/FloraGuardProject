using StokTakipSistemi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class BitkiRepository
    {
        public List<Bitki> GetirTumBitkiler()
        {
            List<Bitki> bitkiler = new List<Bitki>();

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = "SELECT * FROM Bitki";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlBaglanti.Instance.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bitki bitki = new Bitki
                        {
                            BitkiID = Convert.ToInt32(reader["BitkiID"]),
                            Tur = reader["Tur"].ToString(),
                            Cesit = reader["Cesit"].ToString(),
                            EkimTarihi = Convert.ToDateTime(reader["EkimTarihi"]),
                            Aciklama = reader["Aciklama"].ToString(),
                            OptimumSicaklik = Convert.ToInt32(reader["OptimumSicaklik"]),
                            OptimumNem = Convert.ToInt32(reader["OptimumNem"]),
                            EklemeTarihi = Convert.ToDateTime(reader["EklemeTarihi"]),
                            GuncellemeTarihi = reader["GuncellemeTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["GuncellemeTarihi"]) : (DateTime?)null
                        };

                        bitkiler.Add(bitki);
                    }

                    reader.Close();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitkiler listelenirken hata oluştu: " + ex.Message);
            }

            return bitkiler;
        }
        public void Ekle(Bitki bitki)
        {
            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = @"INSERT INTO Bitki (Tur, Cesit, EkimTarihi, Aciklama,  OptimumSicaklik, OptimumNem, EklemeTarihi)
                                 VALUES (@Tur, @Cesit, @EkimTarihi, @Aciklama,  @OptimumSicaklik, @OptimumNem, @EklemeTarihi)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Tur", bitki.Tur);
                    cmd.Parameters.AddWithValue("@Cesit", bitki.Cesit);
                    cmd.Parameters.AddWithValue("@EkimTarihi", bitki.EkimTarihi);
                    cmd.Parameters.AddWithValue("@Aciklama", (object)bitki.Aciklama ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OptimumSicaklik", bitki.OptimumSicaklik);
                    cmd.Parameters.AddWithValue("@OptimumNem", bitki.OptimumNem);
                    cmd.Parameters.AddWithValue("@EklemeTarihi", bitki.EklemeTarihi);

                    SqlBaglanti.Instance.OpenConnection();
                    cmd.ExecuteNonQuery();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitki eklenirken hata oluştu: " + ex.Message);
            }
        }

        public bool Guncelle(Bitki bitki)
        {
            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string kontrolQuery = "SELECT * FROM Bitki WHERE BitkiID = @BitkiID";
                    SqlCommand kontrolCmd = new SqlCommand(kontrolQuery, conn);
                    kontrolCmd.Parameters.AddWithValue("@BitkiID", bitki.BitkiID);

                    SqlBaglanti.Instance.OpenConnection();
                    SqlDataReader reader = kontrolCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (
                            reader["Tur"].ToString() == bitki.Tur &&
                            reader["Cesit"].ToString() == bitki.Cesit &&
                            Convert.ToDateTime(reader["EkimTarihi"]) == bitki.EkimTarihi &&
                            reader["Aciklama"].ToString() == (bitki.Aciklama ?? "") &&
                            Convert.ToInt32(reader["OptimumSicaklik"]) == bitki.OptimumSicaklik &&
                            Convert.ToInt32(reader["OptimumNem"]) == bitki.OptimumNem
                        )
                        {
                            reader.Close();
                            SqlBaglanti.Instance.CloseConnection();
                            MessageBox.Show("Herhangi bir değişiklik yapılmadı.");
                            return false;
                        }
                    }
                    reader.Close();

                    string query = @"UPDATE Bitki SET 
                                 Tur = @Tur,
                                 Cesit = @Cesit,
                                 EkimTarihi = @EkimTarihi,
                                 Aciklama = @Aciklama,
                                 OptimumSicaklik = @OptimumSicaklik,
                                 OptimumNem = @OptimumNem,
                                 GuncellemeTarihi = @GuncellemeTarihi
                                 WHERE BitkiID = @BitkiID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Tur", bitki.Tur);
                    cmd.Parameters.AddWithValue("@Cesit", bitki.Cesit);
                    cmd.Parameters.AddWithValue("@EkimTarihi", bitki.EkimTarihi);
                    cmd.Parameters.AddWithValue("@Aciklama", (object)bitki.Aciklama ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OptimumSicaklik", bitki.OptimumSicaklik);
                    cmd.Parameters.AddWithValue("@OptimumNem", bitki.OptimumNem);
                    cmd.Parameters.AddWithValue("@GuncellemeTarihi", DateTime.Now);
                    cmd.Parameters.AddWithValue("@BitkiID", bitki.BitkiID);

                    cmd.ExecuteNonQuery();
                    SqlBaglanti.Instance.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitki güncellenirken hata oluştu: " + ex.Message);
                return false;
            }
        }


        public void Sil(int bitkiID)
        {
            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = "DELETE FROM Bitki WHERE BitkiID = @BitkiID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BitkiID", bitkiID);

                    SqlBaglanti.Instance.OpenConnection();
                    cmd.ExecuteNonQuery();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitki silinirken hata oluştu: " + ex.Message);
            }
        }

        public List<Bitki> GetirBitkiSecenekleri()
        {
            List<Bitki> bitkiler = new List<Bitki>();

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    string query = "SELECT BitkiID, Cesit FROM Bitki";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlBaglanti.Instance.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bitkiler.Add(new Bitki
                        {
                            BitkiID = Convert.ToInt32(reader["BitkiID"]),
                            Cesit = reader["Cesit"].ToString()
                        });
                    }

                    reader.Close();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitki listesi alınırken hata oluştu: " + ex.Message);
            }

            return bitkiler;
        }

    }
}
