using System;

public class UserAlreadyRegistered : Exception 
{
     public UserAlreadyRegistered(string message) : base(message)
     {}
}