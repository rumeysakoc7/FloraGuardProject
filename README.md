# FloraGuard 

FloraGuard, bitki sağlığını izleyen ve otomatik/manuel sulama yapan akıllı bir bitki takip sistemidir.

Proje **C#, Arduino ve Yapay Zeka** teknolojileri kullanılarak geliştirilmiştir.

Projede kullanılan bitki hastalığı tespit modeli tarafımdan eğitilmiş ve ONNX formatına dönüştürülerek uygulamaya entegre edilmiştir.

Sistem, toprak nemini ölçer, sulamayı kontrol eder, bitki hastalıklarını tespit eder ve kullanıcıya bildirim gönderir.

---

##  Özellikler

###  Bitki Takibi

- Toprak nem sensörü ile nem ölçümü  
- Gerçek zamanlı nem takibi  
- Nem verilerinin veritabanına kaydedilmesi  
- Nem verilerinden rapor oluşturma  
- Grafik ile nem verisi gösterimi  

###  Sulama Sistemi

- Otomatik sulama sistemi  
- Manuel sulama kontrolü  
- Pompa açma / kapama kontrolü  
- Seri port üzerinden Arduino kontrolü  

###  Yapay Zeka Özellikleri

####  Bitki Hastalığı Tespiti

- Bitki yapraklarının fotoğrafı kullanılarak hastalık tespiti yapılır  
- Yapay zeka modeli **tarafımdan eğitilmiştir**  
- Dataset kullanılarak model eğitimi yapılmıştır  
- Eğitilen model ONNX formatına dönüştürülmüştür  
- C# uygulamasına entegre edilmiştir  
- Model doğruluk oranı yaklaşık **%65 - %70** seviyesindedir  
- Hastalık sonucu **mail olarak kullanıcıya gönderilir**  
- İlaçlama işlemi **manuel olarak yapılmaktadır**

####  Yapay Zeka Bitki Asistanı

- Yapay zekaya bitkiler hakkında soru sorulabilir  
- Hastalıklar hakkında bilgi alınabilir  
- Bitki bakımı hakkında öneriler alınabilir  

---

##  Kullanılan Teknolojiler

- C# (.NET Windows Forms)  
- Arduino (ESP8266)  
- Serial Port Communication  
- Yapay Zeka (ONNX Model)  
- SQL Server  
- Grafik Raporlama  

---

##  Donanım Bileşenleri

- ESP8266 Mikrodenetleyici  
- Toprak Nem Sensörü  
- Su Pompası  
- Röle Modülü  
- Güç Kaynağı  
- Sulama Sistemi  

Donanım bileşenleri Arduino kodları ile kontrol edilmekte ve C# uygulaması ile haberleşmektedir.

---

##  Proje Yapısı

- **FloraGuardProje** → C# masaüstü uygulaması  
- **FloraGuardArduino** → Arduino kodları  
- **Dataset** → Yapay zeka veri seti  
- **Screenshots** → Uygulama ekran görüntüleri  
- **script.sql** → Veritabanı scripti  

---

##  Kurulum

1. Projeyi indirin

```
git clone https://github.com/rumeysakoc7/FloraGuardProject.git
```
2. Visual Studio ile açın

3. Arduino kodunu yükleyin

4. COM Port seçerek çalıştırın

---
---
---

##  Ekran Görüntüleri

Uygulama ekran görüntülerini görmek için aşağıdaki bağlantılara tıklayabilirsiniz:

-  Giriş Sayfası → [Görüntüle](Screenshots/giris.png)
-  Ana Menü → [Görüntüle](Screenshots/anamenu.png)
-  Sensör Verileri → [Görüntüle](Screenshots/sensor.png)
-  Hastalık Tespiti → [Görüntüle](Screenshots/hastalik.png)

---

## 🔧 Donanım Görselleri

- Sulama Sistemi → [Görüntüle](Screenshots/sistem.jpg)
- Bitki Kurulumu → [Görüntüle](Screenshots/Bitki.jpg)
