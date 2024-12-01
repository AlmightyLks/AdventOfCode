namespace Shared;

public interface IDay
{
    int Day { get; }
    IEnumerable<object> Execute();
}
