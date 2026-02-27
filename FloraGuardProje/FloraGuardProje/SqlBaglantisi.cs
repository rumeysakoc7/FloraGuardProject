using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public class SqlBaglanti
    {
        private static SqlBaglanti _instance;
        private SqlConnection baglanti;
        private readonly string _connectionString =@"Data Source=.\SQLEXPRESS03;Initial Catalog=FloraGuardDB;Integrated Security=True;TrustServerCertificate=True;";

        private SqlBaglanti()
        {
            try
            {
                baglanti = new SqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı nesnesi oluşturulurken hata oluştu:\n" + ex.Message);
            }
        }

        public static SqlBaglanti Instance
        {
            get
            {
                try
                {
                    if (_instance == null)
                    {
                        _instance = new SqlBaglanti();
                    }
                    return _instance;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SqlBaglanti örneği alınırken hata oluştu:\n" + ex.Message);
                    return null;
                }
            }
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (baglanti == null || baglanti.State == ConnectionState.Closed)
                {
                    baglanti = new SqlConnection(_connectionString);
                }
                return baglanti;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı nesnesi alınırken hata oluştu:\n" + ex.Message);
                return null;
            }
        }

        public void OpenConnection()
        {
            try
            {
                if (baglanti != null && baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı açılırken bir hata oluştu:\n" + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (baglanti != null && baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kapatılırken bir hata oluştu:\n" + ex.Message);
            }
        }
    }
}
