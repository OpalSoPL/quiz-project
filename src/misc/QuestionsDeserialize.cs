using System.Collections.Generic;

public class QuestionsDeserialize
{
    public uint Version { get; set; }
    public Dictionary<int,Answer> Data { get; set; }
}