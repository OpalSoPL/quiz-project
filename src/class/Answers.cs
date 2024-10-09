public static class Answers
{
    public static bool CheckAnswer (EAnswerField answer, int number)
    {
        return getCorrectAnswer(number).Equals(answer);
    }

    public static EAnswerField getCorrectAnswer (int number)
    {
        return Quiz.Questions[number].CorrectAnswer;
    }
}