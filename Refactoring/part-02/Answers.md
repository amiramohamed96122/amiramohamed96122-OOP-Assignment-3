# Part 02 — answers

---
## Reports

- What was the problem?

The three report exporters had the same export workflow: loading the data, validating it, formatting it,
and saving the file. This caused duplicated code in CsvReportExporter, JsonReportExporter, and TextReportExporter.

- What did you change?

I created an abstract `ReportExporter` class that contains the common export steps and their order. 
The `Export()` method performs Load, Validate, Format, and Save. The specific exporters only implement their own `Format()` method.

- Why did you choose that approach?

I chose the Template Method pattern with an abstract class because the three exporters share the same workflow and implementation.
The abstract class allows the common code and the order of the steps to be written once, while each exporter can provide its own formatting.

An interface would define the contract but would not be as suitable for sharing the common implementation and workflow.

------------------------------------------------------------------------

## Enrollment

- What was the problem?

The Program.cs file was responsible for creating four services and calling them one by one in the correct order.
This made the caller dependent on the internal details of the enrollment process.

- What did you change?

I introduced an `EnrollmentFacade` that provides one simple method for enrolling a student. 
The facade creates and coordinates the PaymentGateway, SeatInventory, InvoiceGenerator,
and EmailService and calls them in the required order.

- What problem does the Facade solve?

The Facade hides the complexity of the enrollment process behind a simple interface.
Program.cs no longer needs to know about the four services, how they are created, 
or the order in which they must be called.
