namespace EmailChatProject.Entities
{
    public class Message
    {

        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string SenderName { get; set; }
        public string ReceiverMail { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool Isread { get; set; }
        public DateTime SendDate { get; set; }
        public bool SenderDeleted { get; set; }
        public bool ReceiverDeleted { get; set; }

    }
}
