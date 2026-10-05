namespace RefactoringLab;
public interface INotificationChannel
{
    void Send( string to,  string message, bool urgent, DateTime? scheduledAt);
}

public class EmailNotificationChannel : INotificationChannel
{
    public void Send(  string to, string message,bool urgent,DateTime? scheduledAt)
    {
        var finalMessage = urgent ? $"[URGENT] {message}" : message;

        if (scheduledAt.HasValue)
        {
            Console.WriteLine( $"[email scheduled {scheduledAt.Value:g}] {to}: {finalMessage}");
        }
        else
        {
            Console.WriteLine($"[email] {to}: {finalMessage}");
        }
    }
}

public class SmsNotificationChannel : INotificationChannel
{
    public void Send(string to, string message, bool urgent, DateTime? scheduledAt)
    {
        var finalMessage = urgent ? $"[URGENT] {message}"  : message;

        if (scheduledAt.HasValue)
        {
            Console.WriteLine( $"[sms scheduled {scheduledAt.Value:g}] {to}: {finalMessage}");
        }
        else
        {
            Console.WriteLine($"[sms] {to}: {finalMessage}");
        }
    }
}

public class WhatsappNotificationChannel : INotificationChannel
{
    public void Send(string to, string message, bool urgent, DateTime? scheduledAt)

    {
        var finalMessage = urgent
            ? $"[URGENT] {message}"
            : message;

        if (scheduledAt.HasValue)
        {
            Console.WriteLine(
                $"[Whatsapp] scheduled {scheduledAt.Value:g}] {to}: {finalMessage}");
        }
        else
        {
            Console.WriteLine($"[Whatsapp] {to}: {finalMessage}");
        }
    }
}

public class Notification
{
    private readonly INotificationChannel _channel;
    private readonly bool _urgent;
    private readonly DateTime? _scheduledAt;

    public Notification(
        INotificationChannel channel,
        bool urgent = false,
        DateTime? scheduledAt = null)
    {
        _channel = channel;
        _urgent = urgent;
        _scheduledAt = scheduledAt;
    }
    public void Send(string to, string message)
    {
        _channel.Send(to, message, _urgent, _scheduledAt);
    }
}


