using Godot;

public partial class Autoload : Node
{
    [Signal]
    public delegate void LoadedEventHandler();

    public override async void _EnterTree()
    {
        SettingsDeserialize settings = await QuizGame.Helpers.Json.LoadFromFile<SettingsDeserialize>(
            (!OS.HasFeature("editor") ? OS.GetExecutablePath().GetBaseDir() : "res:/"
                )+ "/appSettings.json"
            );

        //generate default settings file if currently is missing
        if (settings is null && !OS.HasFeature("editor"))
        {
            SettingsDeserialize settingsDefault = new()
            {
                Version = 1,
                Question_file = "path/to/question/file.json",
                Run_from_question = -1
            };

            _ = QuizGame.Helpers.Json.SaveToFile(
                    settingsDefault,
                    $"{OS.GetExecutablePath().GetBaseDir()}/appSettings.json",
                    true
                );

            OS.Alert("Settings file not found\nNew file has been generated. Please configure it", "Settings file not found");
            GetTree().Quit();
        }
        else if (settings is null && OS.HasFeature("editor"))
        {
            OS.Alert("Settings file not found", "Settings file not found");
            GD.PrintErr((!OS.HasFeature("editor") ? OS.GetExecutablePath().GetBaseDir() : "res:/")+ "/appSettings.json");
            GetTree().Quit();
        }

        Global.Debug = settings.Debug;
        Global.QuestionFile = settings.Question_file;
        Global.GoToQuestion = settings.Run_from_question;

        QuestionsDeserialize QuestionFile = await QuizGame.Helpers.Json.LoadFromFile<QuestionsDeserialize>(Global.QuestionFile);

        Quiz.ClearQuestions();
        foreach (var item in QuestionFile.Data)
        {
            Quiz.Questions.Add(item.Value);
        }

        EmitSignal(nameof(Loaded));

    }
}