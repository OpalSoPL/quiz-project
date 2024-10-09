using System.Collections.Generic;

public struct Answer
{
    public string Description { get; set; }
    public EAnswerField CorrectAnswer { get; set; }
    public Dictionary<EAnswerField,string> Answers { get; set; }
}