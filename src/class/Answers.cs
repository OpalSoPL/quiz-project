public static class Answers
{
    public static bool CheckAnswer (EAnswerField answer, int number)
    {
        return GetCorrectAnswer(number).Equals(answer);
    }

    public static EAnswerField GetCorrectAnswer (int number)
    {
        return Quiz.Questions[number].CorrectAnswer;
    }

    public static string GetAnswerDescription (int number, EAnswerField answer)
    {
        return Quiz.Questions[number].Answers[answer];
    }

    public static bool isLastQuestion(int number)
    {
        return number == Quiz.Questions.Count-1;
    }
}