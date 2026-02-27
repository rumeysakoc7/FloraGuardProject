using StokTakipSistemi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;


namespace FloraGuardProje
{
    public class MudahaleRepository
    {
        public List<MudahaleDTO> GetirTumMudahaleDetaylari()
        {
            List<MudahaleDTO> liste = new List<MudahaleDTO>();

            string query = @"
        SELECT 
            t.TespitID, 
            t.BitkiID, 
            b.Tur, 
            b.Cesit,
            ht.HastalikAdi, 
            ht.IlacTuru, 
            ht.IlacDozaji,
            t.BildirimGonderildi, 
            t.MudahaleEdildi,
            m.MudahaleZamani
        FROM 
            HastalikTespitleri t
        LEFT JOIN Bitki b ON t.BitkiID = b.BitkiID
        LEFT JOIN HastalikTipleri ht ON t.HastalikTipID = ht.HastalikTipID
        LEFT JOIN Mudahaleler m ON t.TespitID = m.TespitID
        ORDER BY t.TespitZamani DESC";

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    conn.Open(); 
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new MudahaleDTO
                            {
                                TespitID = reader.GetInt32(0),
                                BitkiID = reader.GetInt32(1),
                                Tur = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Cesit = reader.IsDBNull(3) ? null : reader.GetString(3),
                                HastalikAdi = reader.IsDBNull(4) ? null : reader.GetString(4),
                                IlacTuru = reader.IsDBNull(5) ? null : reader.GetString(5),
                                IlacDozaji = reader.IsDBNull(6) ? null : reader.GetString(6),
                                BildirimGonderildi = reader.IsDBNull(7) ? (bool?)null : reader.GetBoolean(7),
                                MudahaleEdildi = reader.IsDBNull(8) ? (bool?)null : reader.GetBoolean(8),
                                MudahaleZamani = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Müdahale detayları listelenirken hata oluştu.");
            }

            return liste;
        }


        public void GuncelleMudahaleDurumu(int tespitID)
        {
            string query = "UPDATE HastalikTespitleri SET MudahaleEdildi = 1 WHERE TespitID = @TespitID";

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                {
                    SqlBaglanti.Instance.OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TespitID", tespitID);
                        cmd.ExecuteNonQuery();
                    }
                    SqlBaglanti.Instance.CloseConnection(); 
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"TespitID={tespitID} için müdahale durumu güncellenirken hata oluştu.");
            }
        }


        public void MudahaleEkle(int bitkiID, int tespitID, DateTime zaman)
        {
            string query = "INSERT INTO Mudahaleler (BitkiID, TespitID, MudahaleZamani) VALUES (@BitkiID, @TespitID, @Zaman)";

            try
            {
                using (SqlConnection conn = SqlBaglanti.Instance.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BitkiID", bitkiID);
                    cmd.Parameters.AddWithValue("@TespitID", tespitID);
                    cmd.Parameters.AddWithValue("@Zaman", zaman);

                    SqlBaglanti.Instance.OpenConnection();
                    cmd.ExecuteNonQuery();
                    SqlBaglanti.Instance.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"BitkiID={bitkiID}, TespitID={tespitID} için müdahale eklenirken hata oluştu.");
            }
        }
    }
}
