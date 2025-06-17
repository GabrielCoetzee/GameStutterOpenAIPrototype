namespace Integration.AI.Services
{
    public class ChatSession
    {
        private readonly List<object> _messages;

        public ChatSession()
        {
            _messages = new List<object>
            {
                new
                {
                    role = "system",
                    content = "Your task is to provide stuttering fixes for video games delimited by triple backticks. " +
                        "For in-game settings, keep only those in mind that has a minimal impact on visual fidelity as some video games still have stuttering issues even when video settings are set all the way down." +
                        "Please provide info in the order of the numbered format below and be as thorough as possible. Always list all the points even if you have no info on that point" +
                        "but if you can't find or don't have any info related to any of the numbered points, then please say so outright for the relevant point(s)." +
                        "1) In-Game Settings" +
                        "2) Fixes on Reddit" +
                        "3) File modifications" +
                        "4) Mods"
                }
            };
        }

        public void AddMessage(string role, string content)
        {
            _messages.Add(new { role, content });
        }

        public IEnumerable<object> GetMessages() => _messages.ToArray();
    }
}
