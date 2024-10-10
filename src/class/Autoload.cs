using Godot;

public partial class Autoload : Node
{
    [Signal]
    public delegate void LoadedEventHandler();

    public override async void _EnterTree()
    {
        SettingsDeserialize settings = await QuizGame.Helpers.Json.LoadToFile<SettingsDeserialize>(
            !OS.IsDebugBuild() ? OS.GetExecutablePath() : "res://"
            + "settings.json",
            OS.IsDebugBuild()
            );

        Global.Debug = settings.Debug;
        Global.QuestionFile = settings.Question_file;
        Global.GoToQuestion = settings.Run_from_question;

        QuestionsDeserialize QuestionFile = await QuizGame.Helpers.Json.LoadToFile<QuestionsDeserialize>(Global.QuestionFile);

        Quiz.ClearQuestions();
        foreach (var item in QuestionFile.Data)
        {
            Quiz.Questions.Add(item.Value);
        }

        EmitSignal(nameof(Loaded));

    }
}