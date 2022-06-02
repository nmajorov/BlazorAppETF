namespace BlazorAppETF.Services;

/// <summary>
/// Internal Exception if user not found in database
/// </summary>
[Serializable]
public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base() { }
    public UserNotFoundException(string message) : base(message) { }
    public UserNotFoundException(string message, Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client.
    protected UserNotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}