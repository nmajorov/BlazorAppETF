namespace BlazorAppETF.Services;

/// <summary>
/// Internal Exception if user name and password not matching with record
/// </summary>
[Serializable]
public class LoginFailException : Exception
{
    public LoginFailException() : base() { }
    public LoginFailException(string message) : base(message) { }
    public LoginFailException(string message, Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client.
    protected LoginFailException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}