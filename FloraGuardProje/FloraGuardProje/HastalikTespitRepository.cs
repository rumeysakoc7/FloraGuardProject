using StokTakipSistemi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloraGuardProje
{
    public class HastalikTespitRepository
    {
        private SqlConnection baglanti;

        public HastalikTespitRepository()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
        }

        public int GetBitkiIDFromSensor()
        {
            try
            {
                SqlBaglanti.Instance.OpenConnection();

                string query = "SELECT TOP 1 BitkiID FROM SensorVerileri ORDER BY OlcumZamani DESC";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitki ID alınırken hata oluştu:\n" + ex.Message);
                return -1;
            }
        }

        public int GetHastalikTipID(string hastalikAdi)
        {
            try
            {
                string query = "SELECT HastalikTipID FROM HastalikTipleri WHERE HastalikAdi = @adi";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@adi", hastalikAdi);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hastalık Tip ID alınırken hata oluştu:\n" + ex.Message);
                return -1;
            }
        }

        public void Kaydet(HastalikTespitics tespit)
        {
            try
            {
                string query = @"INSERT INTO HastalikTespitleri 
                         (BitkiID, HastalikTipID, TespitZamani, GuvenOrani, BildirimGonderildi, MudahaleEdildi)
                         VALUES (@BitkiID, @HastalikTipID, @TespitZamani, @GuvenOrani, @BildirimGonderildi, @MudahaleEdildi)";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@BitkiID", tespit.BitkiID);
                    cmd.Parameters.AddWithValue("@HastalikTipID", tespit.HastalikTipID);
                    cmd.Parameters.AddWithValue("@TespitZamani", tespit.TespitZamani);
                    cmd.Parameters.AddWithValue("@GuvenOrani", tespit.GuvenOrani);
                    cmd.Parameters.AddWithValue("@BildirimGonderildi", tespit.BildirimGonderildi.HasValue ? tespit.BildirimGonderildi.Value : false);
                    cmd.Parameters.AddWithValue("@MudahaleEdildi", tespit.MudahaleEdildi.HasValue ? tespit.MudahaleEdildi.Value : false);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hastalık kaydı yapılırken hata oluştu:\n" + ex.Message);
            }
        }



        public bool KayitZatenVarVeMudahaleBekliyor(int bitkiID, int hastalikTipID)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM HastalikTespitleri
                             WHERE BitkiID = @bitkiID AND HastalikTipID = @hastalikTipID AND MudahaleEdildi = 0";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@bitkiID", bitkiID);
                    cmd.Parameters.AddWithValue("@hastalikTipID", hastalikTipID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt kontrolü yapılırken hata oluştu:\n" + ex.Message);
                return true; 
            }


        }


        public void SendEmailToYoneticilerFromSensorVerisi(string hastalikAdi)
        {
           
            string[] desteklenenHastaliklar = {
        "Domates - Erken Yanıklık",
        "Domates - Geç Yanıklık",
        "Domates - Sağlıklı"
    };

            if (!desteklenenHastaliklar.Contains(hastalikAdi))
            {
                
                return;
            }

            try
            {
                SqlBaglanti.Instance.OpenConnection();
                SqlConnection conn = SqlBaglanti.Instance.GetConnection();

                
                int bitkiID = -1;
                string bitkiQuery = "SELECT TOP 1 BitkiID FROM SensorVerileri ORDER BY OlcumZamani DESC";
                using (SqlCommand cmd = new SqlCommand(bitkiQuery, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null) bitkiID = Convert.ToInt32(result);
                }

                string bitkiCesit = "(Bilinmiyor)";
                using (SqlCommand cmd = new SqlCommand("SELECT Cesit FROM Bitki WHERE BitkiID = @BitkiID", conn))
                {
                    cmd.Parameters.AddWithValue("@BitkiID", bitkiID);
                    object result = cmd.ExecuteScalar();
                    if (result != null) bitkiCesit = result.ToString();
                }

                int hastalikTipID = -1;
                using (SqlCommand cmd = new SqlCommand("SELECT HastalikTipID FROM HastalikTipleri WHERE HastalikAdi = @adi", conn))
                {
                    cmd.Parameters.AddWithValue("@adi", hastalikAdi);
                    object result = cmd.ExecuteScalar();
                    if (result != null) hastalikTipID = Convert.ToInt32(result);
                }

                string hastalikAdiGercek = hastalikAdi;
                if (hastalikTipID != -1)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HastalikAdi FROM HastalikTipleri WHERE HastalikTipID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", hastalikTipID);
                        object result = cmd.ExecuteScalar();
                        if (result != null) hastalikAdiGercek = result.ToString();
                    }
                }

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("floraguard1@gmail.com");
                mail.Subject = "Yeni Bitki Hastalığı Tespiti";
                mail.Body = $"Bitki: {bitkiCesit}\n\n" +
                            $"Tahmin edilen hastalık: {hastalikAdiGercek}\n\n" +
                            "Lütfen gerekli incelemeyi ve müdahaleyi yapınız.\n\n- FloraGuard Sistemi";

                using (SqlCommand cmd = new SqlCommand("SELECT Email FROM Kullanicilar WHERE KullaniciTipi = 'Yönetici'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["Email"].ToString();
                            mail.To.Add(email);
                        }
                    }
                }

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("floraguard1@gmail.com", "frqyqgecqeqrjuno");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("Yöneticilere hastalık bildirimi maili gönderildi.");


                string updateQuery = @"UPDATE HastalikTespitleri 
                               SET BildirimGonderildi = 1 
                               WHERE BitkiID = @bitkiID 
                                 AND HastalikTipID = @hastalikTipID 
                                 AND CAST(TespitZamani AS DATE) = CAST(GETDATE() AS DATE)";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@bitkiID", bitkiID);
                    updateCmd.Parameters.AddWithValue("@hastalikTipID", hastalikTipID);
                    updateCmd.ExecuteNonQuery();
                }

                SqlBaglanti.Instance.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderim hatası: " + ex.Message);
            }
        }

    }
}
