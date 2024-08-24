using Sardor.TelegramBot;
using Sardor.TelegramBot.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var botclient = new BotClient("7240882379:AAGNVUaJcApUqh-qKU0SS8o_zwA_g69X7Wk");

        await botclient.StartListeningAsync(Hand);
    }

    public static async Task Hand(BotClient botClient , Update update)
    {
        if(update.message is not null)
        {
            await botClient.SendPhotoAsync("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJ0MD9aBDZBIN754j3pDc9y14onip9MrvaZA&s",update.message.chat.id.ToString(),"Qaleslar endi");
        }
    }

}