
# Part 01 — answers

---

## ShippingCostCalculator

* What was the problem?

The calculator used a switch statement with hard-coded carriers.
Adding a new carrier required modifying the existing `ShippingCostCalculator` class, 
which violated the Open/Closed Principle.

* What did you change?

I created an `IShippingCarrier` abstraction and a separate class for each carrier.
`ShippingCostCalculator` now receives the carriers and selects the required one
without knowing the concrete carrier implementations.

---

## OrderProcessor

* What was the problem?

`OrderProcessor` created `SqlOrderRepository` and `SmtpEmailSender` directly.
This made it tightly coupled to concrete classes and made the class harder to 
change or test.

* What did you change?

I introduced `IOrderRepository` and `IEmailSender` interfaces and injected them 
into `OrderProcessor` through its constructor. The processor now depends on 
abstractions instead of concrete implementations.

---

## Notifications

* What was the problem?

The notification design used inheritance for every combination of channel, urgency, and scheduling. This could create many classes such as urgent email, urgent SMS, and urgent scheduled email.

* What did you change?

I replaced the inheritance combinations with composition. `Notification` receives an `INotificationChannel` and options for urgency and scheduling. Email, SMS, and Push can now be combined with these options without creating a separate class for every combination.

---

## Proof

* New carrier file(s):

`UpsCarrier` (or the carrier implementation added for the lab).

* New notification channel file(s):

`wattsapNotificationChannel`.

* Existing classes left unchanged? (yes/no):

No. The original classes that violated the required design were refactored, while the existing behavior and output were preserved.
