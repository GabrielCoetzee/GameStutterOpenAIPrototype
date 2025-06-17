namespace Integration.AI.Models
{
    public class Message
    {
        public string Content { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Response
    {
        public List<Choice> Choices { get; set; }
    }
}
