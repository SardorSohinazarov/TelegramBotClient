namespace Sardor.TelegramBot.Models
{
    public class Chat
    {
        public object id { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public string type { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
    }

    public class From
    {
        public object id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public string language_code { get; set; }
        public string last_name { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }
        public From from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }

    public class OldChatMember
    {
        public User user { get; set; }
        public string status { get; set; }
    }

    public class Photo
    {
        public string file_id { get; set; }
        public string file_unique_id { get; set; }
        public int file_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Update
    {
        public int update_id { get; set; }
        public Message message { get; set; }
    }

    public class Root
    {
        public bool ok { get; set; }
        public List<Update> result { get; set; }
    }

    public class User
    {
        public long id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
    }
}
