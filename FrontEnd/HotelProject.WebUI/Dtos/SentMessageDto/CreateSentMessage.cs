namespace HotelProject.WebUI.Dtos.SentMessageDto
{
    public class CreateSentMessage
    {
        public string RecieverName { get; set; }
        public string RecieverMail { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
