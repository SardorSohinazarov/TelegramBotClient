using Sardor.TelegramBot.Models;
using System.Text;
using System.Text.Json;

namespace Sardor.TelegramBot
{
    public class BotClient
    {
        private int offset = 0;
        public string Token { get; set; }

        public BotClient(string token)
        {
            Token = token;
        }

        public async Task StartListeningAsync(Func<BotClient, Update, Task> func)
        {
            //while getUpdate
            //mobodo update console
            //keyinchalik method



            while (true)
            {
                var result = await GetUpdatesAsync(Token, offset);

                if (!result.ok)
                {
                    Console.WriteLine("Error !!!!!!!!!!!!!!!!!!!");
                }

                if (result.result == null || result.result.Count == 0)
                {
                    Console.WriteLine("Updatelar yo'q !!!!!!!!!!");
                }

                if (result.result.Count > 0)
                    offset = result.result[result.result.Count - 1].update_id + 1;

                foreach (var item in result.result)
                {
                    await func(this, item);
                }
            }
        }

        static async Task<Root> GetUpdatesAsync(string token, int offset)
        {
            var getUpdatesUrl = $"https://api.telegram.org/bot{token}/getUpdates";

            var client = new HttpClient();
            var response = await client.PostAsync(
                requestUri: getUpdatesUrl,
                content: new StringContent(
                    content: JsonSerializer.Serialize(
                        new
                        {
                            offset,
                            limit = 100,
                        }),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json"));

            var result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Root>(result);

            Console.WriteLine(result);
        }

    }
}
