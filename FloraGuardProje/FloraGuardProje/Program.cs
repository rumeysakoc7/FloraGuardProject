using FloraGuardProje;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var sqlBaglanti = SqlBaglanti.Instance;

            var sinkOptions = new MSSqlServerSinkOptions
            {
                TableName = "Loglar",             
                AutoCreateSqlTable = true          
            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.MSSqlServer(
                    connectionString: sqlBaglanti.GetConnection().ConnectionString,
                    sinkOptions: sinkOptions
                )
                .CreateLogger();

            try
            {
                ApplicationConfiguration.Initialize();

                Log.Information("Uygulama başlatıldı.");
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Uygulama başlatılırken hata oluştu!");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
