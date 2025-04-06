using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppVirtualAssistant
{
    public class GptClient
    {
        private readonly string apiKey;
        private readonly HttpClient http;

        public GptClient(string apiKey)
        {
            this.apiKey = apiKey;
            this.http = new HttpClient();
            this.http.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        public async Task<string> EnviarPreguntaAsync(string mensaje)
        {
            var request = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
            new { role = "user", content = mensaje }
        }
            };

            var response = await http.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            );

            var json = await response.Content.ReadAsStringAsync();

            try
            {
                using var doc = JsonDocument.Parse(json);

                // ✅ Si contiene error
                if (doc.RootElement.TryGetProperty("error", out var error))
                {
                    string msg = error.GetProperty("message").GetString();
                    return $"⚠️ OpenAI Error: {msg}";
                }

                // ✅ Si contiene choices
                return doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString()
                    ?.Trim() ?? "🤖 Respuesta vacía.";
            }
            catch (Exception ex)
            {
                return $"⚠️ Error al leer respuesta de OpenAI: {ex.Message}";
            }
        }

    }
}

