using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using AForge.Video;
using AForge.Video.DirectShow;
using Serilog;

namespace FloraGuardProje
{
    public partial class HastalikTespitleri : Form
    {
        InferenceSession session;
        string[] classNames;
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        Bitmap currentFrame;
        private bool kameraAcildi = false;


        public HastalikTespitleri()
        {
            InitializeComponent();

            session = new InferenceSession("bitki_hastalik_modeli.onnx");

            classNames = new string[]
            {
            "Tomato_Bacterial_spot",
            "Tomato_Early_blight",
            "Tomato_Late_blight",
            "Tomato_Leaf_Mold",
            "Tomato_Septoria_leaf_spot",
            "Tomato_Spider_mites_Two_spotted_spider_mite",
            "Tomato_Target_Spot",
            "Tomato_Tomato_YellowLeaf__Curl_Virus",
            "Tomato_Tomato_mosaic_virus",
            "Tomato_healthy"
            };

        }

        private Dictionary<string, string> hastalikCevirisi = new Dictionary<string, string>
{
    { "Tomato_Bacterial_spot", "Domates - Bakteriyel Leke" },
    { "Tomato_Early_blight", "Domates - Erken Yanıklık" },
    { "Tomato_Late_blight", "Domates - Geç Yanıklık" },
    { "Tomato_Leaf_Mold", "Domates - Yaprak Küfü" },
    { "Tomato_Septoria_leaf_spot", "Domates - Septoria Yaprak Lekesi" },
    { "Tomato_Spider_mites_Two_spotted_spider_mite", "Domates - İki Noktalı Kırmızı Örümcek" },
    { "Tomato_Target_Spot", "Domates - Hedef Leke" },
    { "Tomato_Tomato_YellowLeaf__Curl_Virus", "Domates - Sarı Yaprak Kıvırcıklık Virüsü" },
    { "Tomato_Tomato_mosaic_virus", "Domates - Mozaik Virüsü" },
    { "Tomato_healthy", "Domates - Sağlıklı" }
};

        private async void btnAnalizEt_Click(object sender, EventArgs e)
        {
            string prompt = $"Aşağıdaki belirtilere göre, sadece bu yeni giriş üzerinden analiz yap:\n" +
                $"\"{txtAnalizGirdi.Text}\"\n\n" +
                "Bu belirtilere göre lütfen sadece aşağıdaki 3 başlığı yaz:\n" +
                "- Belirtiler: (madde madde yaz)\n- Nedenler: (madde madde yaz)\n- Çözümler: (madde madde yaz)\n" +
                "Başka açıklama yapma, her başlık altında 2-3 madde olacak şekilde sade ve kısa cümlelerle yaz.";


            try
            {
                ChatGPTClient client = new ChatGPTClient();
                string cevap = await client.GetChatGPTResponse(prompt);

                string[] bolumler = cevap.Split(new[] { "Belirtiler:", "Nedenler:", "Çözümler:" }, StringSplitOptions.None);

                if (bolumler.Length >= 4)
                {
                    txtBelirtiler.Text = bolumler[1].Trim();
                    txtNedenler.Text = bolumler[2].Trim();
                    txtCozumler.Text = bolumler[3].Trim();
                }
                else
                {
                    MessageBox.Show("Yanıt düzgün ayrıştırılamadı:\n\n" + cevap);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("ChatGPT sunucusuna bağlanılamadı. Lütfen internet bağlantınızı kontrol edin.\n\nHata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonhastaliktani_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxgoruntu.Image == null)
                {
                    MessageBox.Show("Lütfen bir resim seçin.");
                    return;
                }

                Bitmap resized = new Bitmap(pictureBoxgoruntu.Image, new System.Drawing.Size(224, 224));
                float[] imageData = BitmapToFloatArray(resized);

                var inputTensor = new DenseTensor<float>(imageData, new[] { 1, 224, 224, 3 });
                var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_layer", inputTensor)
        };

                using var results = session.Run(inputs);
                var output = results.First().AsEnumerable<float>().ToArray();

                int maxIndex = Array.IndexOf(output, output.Max());
                string prediction = classNames[maxIndex];
                string predictionTr = hastalikCevirisi.ContainsKey(prediction) ? hastalikCevirisi[prediction] : prediction;
                float confidence = output.Max() * 100;

                textBoxhastalikAdi.Text = $"{predictionTr}";
                textBoxguvenOrani.Text = $"{confidence:F2}";
                Log.Information("Görsel analiz edildi. Tahmin: {Prediction}, Güven: {Confidence:F2}", predictionTr, confidence);

                TahminSonucunuKaydet();

                string[] desteklenenHastaliklar = {
            "Domates - Erken Yanıklık",
            "Domates - Geç Yanıklık",
            "Domates - Sağlıklı"
        };

                if (desteklenenHastaliklar.Contains(predictionTr))
                {
                    new HastalikTespitRepository().SendEmailToYoneticilerFromSensorVerisi(predictionTr);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Görsel analizinde hata oluştu.");
                MessageBox.Show("Analiz sırasında bir hata oluştu:\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Resimler|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxgoruntu.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görsel yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private float[] BitmapToFloatArray(Bitmap bmp)
        {
            try
            {
                float[] result = new float[224 * 224 * 3];
                int i = 0;

                for (int y = 0; y < 224; y++)
                {
                    for (int x = 0; x < 224; x++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        result[i++] = pixel.R / 255f;
                        result[i++] = pixel.G / 255f;
                        result[i++] = pixel.B / 255f;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim işlenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; 
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                currentFrame = (Bitmap)eventArgs.Frame.Clone();
                pictureBoxgoruntu.Image = (Bitmap)currentFrame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yeni kare alınırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonkamerabaslat_Click(object sender, EventArgs e)
        {
            try
            {
                kameraAcildi = true;

                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("Kamera bulunamadı!");
                    Log.Warning("Kamera bulunamadı.");
                    return;
                }

                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                videoSource.Start();
                Log.Information("Kamera başlatıldı.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kamera başlatılırken hata oluştu.");
                MessageBox.Show("Kamera başlatılırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HastalikTespitleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kamera kapatılırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


     

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Canlı analiz et butonu

                if (!kameraAcildi)
                {
                    MessageBox.Show("Lütfen önce kamerayı başlatın.");
                    return;
                }


                if (currentFrame == null)
                {
                    MessageBox.Show("Canlı görüntü alınamadı.");
                    return;
                }

                Bitmap resized = new Bitmap(currentFrame, new System.Drawing.Size(224, 224));
                float[] imageData = BitmapToFloatArray(resized);

                var inputTensor = new DenseTensor<float>(imageData, new[] { 1, 224, 224, 3 });

                var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_layer", inputTensor)
        };

                using var results = session.Run(inputs);
                var output = results.First().AsEnumerable<float>().ToArray();

                int maxIndex = Array.IndexOf(output, output.Max());
                string prediction = classNames[maxIndex];
                string predictionTr = hastalikCevirisi.ContainsKey(prediction) ? hastalikCevirisi[prediction] : prediction;
                float confidence = output.Max() * 100;

                textBoxhastalikAdi.Text = $"{predictionTr}";
                textBoxguvenOrani.Text = $"{confidence:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Canlı analiz sırasında bir hata oluştu:\n\n" + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonkapat_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                }

                pictureBoxgoruntu.Image = null;
                pictureBoxgoruntu.Invalidate();
                textBoxhastalikAdi.Clear();
                textBoxguvenOrani.Clear();

                kameraAcildi = false;
                currentFrame = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kapatma işlemi sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TahminSonucunuKaydet()
        {
            try
            {
                string hastalikAdi = textBoxhastalikAdi.Text.Trim();
                float.TryParse(textBoxguvenOrani.Text.Trim(), out float guvenOrani);

                if (string.IsNullOrWhiteSpace(hastalikAdi) || guvenOrani == 0)
                    return;

                string[] desteklenenHastaliklar = {
            "Domates - Erken Yanıklık",
            "Domates - Geç Yanıklık",
            "Domates - Sağlıklı"
        };

                if (!desteklenenHastaliklar.Contains(hastalikAdi))
                {
                    return;
                }

                var repo = new HastalikTespitRepository();

                int bitkiID = repo.GetBitkiIDFromSensor();
                if (bitkiID == -1)
                {
                    MessageBox.Show("SensorVerileri tablosunda BitkiID bulunamadı.");
                    return;
                }

                int hastalikTipID = repo.GetHastalikTipID(hastalikAdi);
                if (hastalikTipID == -1)
                {
                    MessageBox.Show("Hastalık tipi bulunamadı. Önce HastalikTipleri tablosuna ekleyin.");
                    return;
                }

                if (repo.KayitZatenVarVeMudahaleBekliyor(bitkiID, hastalikTipID))
                {
                    MessageBox.Show("Bu hastalık zaten daha önce tespit edildi ve henüz müdahale edilmedi. Yeni kayıt yapılmadı.");
                    return;
                }

                bool mudahaleEdildiMi = hastalikAdi == "Domates - Sağlıklı";

                HastalikTespitics tespit = new HastalikTespitics
                {
                    BitkiID = bitkiID,
                    HastalikTipID = hastalikTipID,
                    TespitZamani = DateTime.Now,
                    GuvenOrani = guvenOrani,
                    MudahaleEdildi = mudahaleEdildiMi,
                    BildirimGonderildi = false
                };

                repo.Kaydet(tespit);
                Log.Information("Tahmin sonucu kaydedildi. Hastalık: {Hastalik}, BitkiID: {BitkiID}", hastalikAdi, bitkiID);
                MessageBox.Show("✅ Tahmin sonucu başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Tahmin sonucu kaydı sırasında hata.");
                MessageBox.Show("Tahmin sonucu kaydedilirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonmudahalegecis_Click(object sender, EventArgs e)
        {
            try
            {
                Mudahaleler frm = new Mudahaleler();
                frm.Show();
                Log.Information("Müdahaleler sayfasına geçildi.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Müdahale sayfası açılırken hata oluştu.");
                MessageBox.Show("Müdahale ekranı açılırken hata oluştu:\n" + ex.Message);
            }

        }
    }
}
