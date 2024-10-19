using System.Collections.Generic;
using Godot;

public static class Global
{
    public static bool Debug { get; set; }
    public static string QuestionFile { get; set; }
    public static int GoToQuestion { get; set; }
    public static int CorrectAnswers { get; set; }
    public static SceneTree Tree { get; set; }
}