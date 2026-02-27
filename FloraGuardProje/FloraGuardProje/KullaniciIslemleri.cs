using StokTakipSistemi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraGuardProje
{
    public class KullaniciIslemleri
    {
        private SqlConnection baglanti;

        public KullaniciIslemleri()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
        }

        public Kullanici GirisYap(string kullaniciAdi, string sifre)
        {
            using (var baglanti = SqlBaglanti.Instance.GetConnection())
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @kadi AND Sifre = @sifre";
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        using (SqlDataReader reader = komut.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Kullanici
                                {
                                    KullaniciID = (int)reader["KullaniciID"],
                                    KullaniciAdi = reader["KullaniciAdi"].ToString(),
                                    Sifre = reader["Sifre"]?.ToString(),
                                    Email = reader["Email"]?.ToString(),
                                    EklenmeTarihi = reader["EklenmeTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["EklenmeTarihi"]) : DateTime.MinValue,
                                    KullaniciTipi = reader["KullaniciTipi"]?.ToString(),
                                    Ad = reader["Adi"]?.ToString(),
                                    Soyad = reader["Soyadi"]?.ToString()
                                };
                            }
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Girişte hata oluştu: " + ex.Message, ex);
                }
            }
        }

        public bool KayitOl(Kullanici kullanici)
        {
            try
            {
                baglanti.Open();
                string query = @"INSERT INTO Kullanicilar 
                            (KullaniciAdi, Sifre, Email, EklenmeTarihi, KullaniciTipi, Adi, Soyadi) 
                            VALUES (@kadi, @sifre, @email, @ekleme, @tur, @ad, @soyad)";
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@kadi", kullanici.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", kullanici.Sifre);
                cmd.Parameters.AddWithValue("@email", kullanici.Email);
                cmd.Parameters.AddWithValue("@ekleme", kullanici.EklenmeTarihi);
                cmd.Parameters.AddWithValue("@tur", kullanici.KullaniciTipi);
                cmd.Parameters.AddWithValue("@ad", kullanici.Ad);
                cmd.Parameters.AddWithValue("@soyad", kullanici.Soyad);

                int sonuc = cmd.ExecuteNonQuery();
                return sonuc > 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool SifreGuncelle(string email, string yeniSifre)
        {
            try
            {
                baglanti.Open();
                string query = "UPDATE Kullanicilar SET Sifre = @sifre WHERE Email = @eposta";
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@sifre", yeniSifre);
                cmd.Parameters.AddWithValue("@eposta", email);

                int sonuc = cmd.ExecuteNonQuery();
                return sonuc > 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KullaniciVarMi(string email)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Kullanicilar WHERE Email = @email", baglanti);
                cmd.Parameters.AddWithValue("@email", email);

                int sayi = (int)cmd.ExecuteScalar();
                return sayi > 0;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Kullanici> KullanicilariGetir()
        {
            var liste = new List<Kullanici>();
            try
            {
                baglanti.Open();
                string query = "SELECT * FROM Kullanicilar";
                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Kullanici
                        {
                            KullaniciID = (int)reader["KullaniciID"],
                            KullaniciAdi = reader["KullaniciAdi"].ToString(),
                            Sifre = reader["Sifre"].ToString(),
                            Email = reader["Email"].ToString(),
                            EklenmeTarihi = Convert.ToDateTime(reader["EklenmeTarihi"]),
                            KullaniciTipi = reader["KullaniciTipi"].ToString(),
                            Ad = reader["Adi"]?.ToString(),
                            Soyad = reader["Soyadi"]?.ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı listelenirken hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            return liste;
        }

        public bool KullaniciEkle(Kullanici kullanici)
        {
            try
            {
                baglanti.Open();
                string query = @"INSERT INTO Kullanicilar 
                            (KullaniciAdi, Sifre, Email, EklenmeTarihi, KullaniciTipi, Adi, Soyadi)
                            VALUES (@kadi, @sifre, @email, @tarih, @tip, @ad, @soyad)";
                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@kadi", kullanici.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", kullanici.Sifre);
                    cmd.Parameters.AddWithValue("@email", kullanici.Email);
                    cmd.Parameters.AddWithValue("@tarih", kullanici.EklenmeTarihi);
                    cmd.Parameters.AddWithValue("@tip", kullanici.KullaniciTipi);
                    cmd.Parameters.AddWithValue("@ad", kullanici.Ad);
                    cmd.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KullaniciGuncelle(Kullanici kullanici)
        {
            try
            {
                baglanti.Open();
                string query = @"UPDATE Kullanicilar SET 
                            KullaniciAdi = @kadi, 
                            Sifre = @sifre, 
                            Email = @email, 
                            KullaniciTipi = @tip,
                            Adi = @ad,
                            Soyadi = @soyad
                            WHERE KullaniciID = @id";
                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@kadi", kullanici.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", kullanici.Sifre);
                    cmd.Parameters.AddWithValue("@email", kullanici.Email);
                    cmd.Parameters.AddWithValue("@tip", kullanici.KullaniciTipi);
                    cmd.Parameters.AddWithValue("@ad", kullanici.Ad);
                    cmd.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                    cmd.Parameters.AddWithValue("@id", kullanici.KullaniciID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KullaniciSil(int kullaniciId)
        {
            try
            {
                baglanti.Open();
                string query = "DELETE FROM Kullanicilar WHERE KullaniciID = @id";
                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@id", kullaniciId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }
    }

}
