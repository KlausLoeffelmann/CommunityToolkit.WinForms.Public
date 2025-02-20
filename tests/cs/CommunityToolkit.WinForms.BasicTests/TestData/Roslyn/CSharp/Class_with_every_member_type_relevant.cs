using System;

// https://t.ly/Fubar
namespace Fubar;

public class MyClass
{
    private readonly DateTime _startDate;

    public event EventHandler? MyEvent;

    public MyClass(DateTime startDate, DateTime endDate)
        => (_startDate, EndDate) = startDate <= endDate ? (startDate, endDate)
            : throw new ArgumentException("End date must be after start date.");

    public DateTime EndDate { get; }

    public int DaysInRange => (EndDate - _startDate).Days + 1;

    public DateTime this[int index]
        => index >= 0 && index < (EndDate - _startDate).Days + 1
            ? _startDate.AddDays(index)
            : throw new IndexOutOfRangeException();

    public void DoSomething() => MyEvent?.Invoke(this, EventArgs.Empty);

    public class NestedClass
    {
        public required string Name { get; init; }
    }
}
