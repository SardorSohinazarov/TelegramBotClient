using Sardor.TelegramBot;
using Sardor.TelegramBot.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string token = "{your_telegram_bot_token}";

        var client = new BotClient(token);
        await client.StartListeningAsync(HandleUpdateAsync);

        Console.WriteLine("Eshitishni boshladi");
    }

    public static async Task HandleUpdateAsync(BotClient botClient, Update update)
    {
        if(update.message is not null) 
        {
            if(!string.IsNullOrWhiteSpace(update.message.text)) 
            {
                var text = update.message.text;

                if(text == "/start")
                {
                    await botClient.SendPhotoAsync("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS8u-zRgpXnfWNoKj-fKvbf7iqWl_nRGeZwKw&s", update.message.chat.id.ToString(), "Xush kelibsiz!");
                }
                else if(text == "/kurslar")
                {
                    await botClient.SendTextAsync("Bizda barcha kurslar bor", update.message.chat.id.ToString());
                }
                else 
                {
                    await botClient.SendTextAsync("Bunaqa buyruq topilmadi!", update.message.chat.id.ToString());
                }
            }
        }
    }
}