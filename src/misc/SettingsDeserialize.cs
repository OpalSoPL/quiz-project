using System.Collections.Generic;

public class SettingsDeserialize
{
    public uint Version { get; set; }
    public bool Debug { get; set; }
    public string Question_file {get; set; }
    public int  Run_from_question { get; set; } //emergency / debug
}