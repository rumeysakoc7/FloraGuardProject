using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Serilog;

public class ChatGPTClient
{
    private readonly string apiKey = "YOUR_API_KEY_HERE";

    public async Task<string> GetChatGPTResponse(string prompt)
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = "Sen sadece bitki hastalıklarını analiz eden bir yardımcı botsun. Her mesajda sadece verilen yeni metne göre yanıt ver." },
                new { role = "user", content = prompt }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();



            dynamic result = JsonConvert.DeserializeObject(responseJson);

            if (result == null || result.choices == null || result.choices.Count == 0)
            {
                return "ChatGPT yanıtı boş veya hatalı. API Key geçerli mi? Hata oluşmuş olabilir.";
            }

            return result.choices[0].message.content.ToString();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "ChatGPT yanıtı çözümleme sırasında bir hata oluştu. JSON parse işlemi başarısız.");
            return $"Hata oluştu: {ex.Message}";
        }

    }
}