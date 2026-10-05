namespace RefactoringLab.Part02.Enrollment;
public class EnrollmentFacade
{
    private readonly PaymentGateway _paymentGateway;
    private readonly SeatInventory _seatInventory;
    private readonly InvoiceGenerator _invoiceGenerator;
    private readonly EmailService _emailService;

    public EnrollmentFacade()
    {
        _paymentGateway = new PaymentGateway();
        _seatInventory = new SeatInventory();
        _invoiceGenerator = new InvoiceGenerator();
        _emailService = new EmailService();
    }

    public void Enroll(  string studentId,string courseId,  decimal amount)
    {
        // 1. Charge the student
        _paymentGateway.Charge(studentId, amount);

        // 2. Reserve a seat
        _seatInventory.Reserve(courseId, studentId);

        // 3. Create invoice
        var invoiceId = _invoiceGenerator.Create(studentId, amount);

        // 4. Send email
        _emailService.Send( studentId, "Enrollment Confirmed", $"Your invoice is {invoiceId}  for {courseId} ");
    }
}