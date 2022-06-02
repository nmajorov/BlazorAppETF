namespace BlazorAppETF.Services;

/// <summary>
/// Internal Exception if user name already exist in database
/// </summary>
[Serializable]
public class UserExistException : Exception
{
    public UserExistException() : base() { }
    public UserExistException(string message) : base(message) { }
    public UserExistException(string message, Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client.
    protected UserExistException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}