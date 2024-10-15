namespace TM.Domain.Exceptions;

[Serializable]
public class DataNotFoundException : Exception
{
    public DataNotFoundException() : base() { }
    public DataNotFoundException(string message) : base(message) { }
    public DataNotFoundException(string message, Exception innerException) : base(message,innerException) { }
}