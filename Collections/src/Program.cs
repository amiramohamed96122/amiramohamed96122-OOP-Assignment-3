using src;

Console.WriteLine(
    $"\"01012345678\" IsValidEgyptianPhone: {"01012345678".IsValidEgyptianPhone()}"
);

Console.WriteLine(
    $"\"+201512345678\" IsValidEgyptianPhone: {"+201512345678".IsValidEgyptianPhone()}"
);

Console.WriteLine(
    $"\"01312345678\" IsValidEgyptianPhone: {"01312345678".IsValidEgyptianPhone()}"
);

Console.WriteLine(
    $"\"0101234567\" IsValidEgyptianPhone: {"0101234567".IsValidEgyptianPhone()}"
);

Console.WriteLine(
    $"\"0101234567a\" IsValidEgyptianPhone: {"0101234567a".IsValidEgyptianPhone()}"
);

Console.WriteLine(
    $"\"29901011234567\" IsValidEgyptianNationalId: {"29901011234567".IsValidEgyptianNationalId()}"
);

Console.WriteLine(
    $"\"19901011234567\" IsValidEgyptianNationalId: {"19901011234567".IsValidEgyptianNationalId()}"
);

Console.WriteLine(
    $"\"2990101123456\" IsValidEgyptianNationalId: {"2990101123456".IsValidEgyptianNationalId()}"
);
