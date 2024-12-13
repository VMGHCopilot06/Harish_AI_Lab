public interface INumber
{
    object Value { get; set; }
}

public class Number : INumber
{
    public object Value { get; set; }
}

//Refactored code
public interface INumber<T>
{
    T Value { get; set; }
}

public class Number<T> : INumber<T> // Utilize generics to avoid boxing
{
    public T Value { get; set; }
}