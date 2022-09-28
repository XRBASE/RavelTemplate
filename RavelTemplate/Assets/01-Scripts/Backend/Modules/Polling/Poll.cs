using System;
using System.Collections.Generic;

[Serializable]
public class Poll
{
    //called when poll is changed locally, triggers networking in dataservices.
    public static Action<Poll> onPollChangedLocal;
    
    public string id;
    public string question;
    public List<string> answers;
    public List<Result> results;
    
    public bool pollingOpen;
    public string ownerUUID;

    /// <summary>
    /// Serializable data of user awnsers on poll
    /// </summary>
    [Serializable]
    public class Result
    {
        public string userSesionId;
        public int choice;
        
        public Result(string userSesionId, int choice)
        {
            this.userSesionId = userSesionId;
            this.choice = choice;
        }
    }
}
