using System.Text;
using System.Text.Json;

namespace Sardor.TelegramBot
{
    public static class BotClientExtensions
    {
        public static async Task SendTextAsync(this BotClient botClient, string text, string chatId)
        {
            string token = botClient.Token;

            var sendMessageUrl = $"https://api.telegram.org/bot{token}/sendMessage";

            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(new
            {
                chat_id = chatId,
                text,
            }), Encoding.UTF8, "application/json");

            await client.PostAsync(sendMessageUrl, content);
        }

        public static async Task SendPhotoAsync(this BotClient botClient, string photoUrl, string chatId, string caption = null)
        {
            string token = botClient.Token;

            var sendPhotoUrl = $"https://api.telegram.org/bot{token}/sendPhoto";

            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(new
            {
                chat_id = chatId,
                photo = photoUrl,
                caption = caption is null ? "" : caption,
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(sendPhotoUrl, content);
        }
    }
}
