using RefactoringLab;

var shipping = new ShippingCostCalculator(
    new IShippingCarrier[]
    {
        new AramexCarrier(),
        new FedExCarrier(),
        new DhlCarrier(),
        new UpsCarrier()
    });

Console.WriteLine($"Aramex 2kg  {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg   {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"DHL 2kg     {shipping.Calculate("DHL", 2)}");
Console.WriteLine($"UPS 2kg     {shipping.Calculate("UPS", 2)}");

Console.WriteLine();

var processor = new OrderProcessor(
    new SqlOrderRepository(),
    new SmtpEmailSender());

processor.Process(1001, "customer@example.com");

Console.WriteLine();

var scheduledTime = DateTime.Today.AddHours(18);

// Email - urgent + scheduled
new Notification(
    new EmailNotificationChannel(),
    urgent: true,
    scheduledAt: scheduledTime)
    .Send(
        "customer@example.com",
        "Your order ships tomorrow");

// SMS - urgent
new Notification(
    new SmsNotificationChannel(),
    urgent: true)
    .Send(
        "+201000000000",
        "OTP 4821");

// Push - scheduled + urgent
new Notification(
    new WhatsappNotificationChannel(),
    urgent: true,
    scheduledAt: scheduledTime)
    .Send(
        "customer@example.com",
        "Your order ships tomorrow");
