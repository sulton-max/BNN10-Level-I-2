namespace N40_C.Models;

public class Email
{
    // Planner - sender va receiver Id si bo'lishi shart
    // Newsletter - sender va reciever Id si bo'lishi shartmas

    // public Guid? SenderUserid { get; set; }
    // public Guid? ReceiverUserid { get; set; }
    public string SenderEmailAddress { get; set; }
    public string ReceiverEmailAddress { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public Email(string senderEmailAddress, string receiverEmailAddress, string subject, string body)
    {
        SenderEmailAddress = senderEmailAddress;
        ReceiverEmailAddress = receiverEmailAddress;
        Subject = subject;
        Body = body;
    }
}