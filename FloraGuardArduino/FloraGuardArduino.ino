#include <ESP8266WiFi.h>

// Fonksiyon bildirimi
void pompalarıAc(bool manuelMi);
void pompalarıKapat();

#define IN1 D5
#define IN2 D6
#define IN3 D8
#define IN4 D7
#define SOIL_PIN A0

// Zamanlayıcılar
unsigned long sonOlcumZamani = 0;
unsigned long sonGosterimZamani = 0;

const unsigned long sulamaKontrolAraligi = 30000; // ⏱ 30 saniye
const unsigned long nemGosterimAraligi = 1000;    // 🖥 1 saniye

bool pompaAcik = false;
bool manuelMod = false;
bool otomatikSulamaAktif = true;
unsigned long pompaAcilisZamani = 0;
unsigned long pompaSuresi = 0;

int nemDegeri = 0;

void setup() {
  Serial.begin(9600);

  pinMode(IN1, OUTPUT);
  pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT);
  pinMode(IN4, OUTPUT);

  pompalarıKapat();
  Serial.println("🌱 FloraGuard Başladı - Anlık Nem Gösterimi + 30sn Otomatik Kontrol");
}

void loop() {
  // 🖐 Manuel komutlar
  if (Serial.available()) {
    char komut = Serial.read();

    if (komut == '1') {
      manuelMod = true;
      otomatikSulamaAktif = false;
      pompalarıAc(true); 
      Serial.println("🖐 MANUEL: Pompa açıldı. Otomatik durduruldu.");
    }
    else if (komut == '0') {
      manuelMod = false;
      otomatikSulamaAktif = false;
      pompalarıKapat();
      Serial.println("🖐 MANUEL: Pompa kapatıldı. Otomatik durduruldu.");
    }
    else if (komut == '2') {
      otomatikSulamaAktif = true;
      manuelMod = false;
      Serial.println("🔄 Otomatik sulama tekrar aktif edildi.");
    }
    else if (komut == '3') {
      manuelMod = true;
      otomatikSulamaAktif = false;

      Serial.println("🧪 KARISIM: 2gr ilaç + 500gr su → Başlatılıyor...");

      // İlaç pompası (OUT1 & OUT2): 1 saniye çalış
      digitalWrite(IN1, HIGH);
      digitalWrite(IN2, LOW);
      delay(1000);
      digitalWrite(IN1, LOW);
      digitalWrite(IN2, LOW);
      Serial.println("✅ İlaç eklendi.");

      // Su pompası (OUT3 & OUT4): 3 saniye çalış
      digitalWrite(IN3, HIGH);
      digitalWrite(IN4, LOW);
      delay(3000);
      digitalWrite(IN3, LOW);
      digitalWrite(IN4, LOW);
      Serial.println("✅ Su eklendi.");

      Serial.println("🧪 Karışım işlemi tamamlandı.");
      otomatikSulamaAktif = true;
      manuelMod = false;
      Serial.println("🔄 Otomatik sulama tekrar aktif hale getirildi.");
    }
  }

  if (manuelMod) return;

  // 🖥 Her 1 saniyede bir nem bilgisini göster
  if (millis() - sonGosterimZamani >= nemGosterimAraligi) {
    sonGosterimZamani = millis();
    nemDegeri = analogRead(SOIL_PIN);
    Serial.print("NEM: ");
    Serial.println(nemDegeri);
  }

  // ⏱ Her 30 saniyede bir otomatik sulama yapılır
  if (otomatikSulamaAktif && millis() - sonOlcumZamani >= sulamaKontrolAraligi) {
    sonOlcumZamani = millis();

    Serial.print("💧 Kontrol - NEM: ");
    Serial.print(nemDegeri);
    Serial.print(" — Durum: ");

    if (nemDegeri > 500) {
      Serial.println("Çok Kuru → 4 sn sadece su sulama");
      pompaSuresi = 4000;
      pompalarıAc(false); // OTOMATİK → Sadece su
      pompaAcilisZamani = millis();
      pompaAcik = true;
    }
    else if (nemDegeri > 300 && nemDegeri <= 500) {
      Serial.println("Orta Kuru → 2 sn sadece su sulama");
      pompaSuresi = 2000;
      pompalarıAc(false); // OTOMATİK → Sadece su
      pompaAcilisZamani = millis();
      pompaAcik = true;
    }
    else {
      Serial.println("Nemli → Sulama yapılmadı");
      pompalarıKapat();
      pompaAcik = false;
    }
  }

  // ⏲ Pompa süresi dolduysa kapat
  if (pompaAcik && millis() - pompaAcilisZamani >= pompaSuresi) {
    pompalarıKapat();
    Serial.println("⏹ Otomatik: Sulama süresi bitti → Pompa kapatıldı");
    pompaAcik = false;
  }
}

// 🧠 Manuel veya otomatik moda göre pompaları aç
void pompalarıAc(bool manuelMi) {
  if (manuelMi) {
    // MANUEL → ilaç ve su pompaları çalışır
    digitalWrite(IN1, HIGH); // ilaç
    digitalWrite(IN2, LOW);
    digitalWrite(IN3, HIGH); // su
    digitalWrite(IN4, LOW);
  } else {
    // OTOMATİK → sadece su pompası
    digitalWrite(IN1, LOW); // ilaç kapalı
    digitalWrite(IN2, LOW);
    digitalWrite(IN3, HIGH); // su
    digitalWrite(IN4, LOW);
  }
}

// 🔌 Tüm pompaları kapat
void pompalarıKapat() {
  digitalWrite(IN1, LOW);
  digitalWrite(IN2, LOW);
  digitalWrite(IN3, LOW);
  digitalWrite(IN4, LOW);

}