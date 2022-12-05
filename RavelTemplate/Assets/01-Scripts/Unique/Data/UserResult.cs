using System;

/// <summary>
/// Processed results of the player's answers
/// (is temporary and only applicable to Unique use case)
/// </summary>
public class UserResults
{
    //temporary, just user the amount of e certain answer given to determine some interesting value
    [Flags]
    public enum ResultType {
        None = 0,
        Nee = 1,
        Misschien = 2,
        Ja = 4,
    }
}