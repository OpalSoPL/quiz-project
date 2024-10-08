public static class Answer
{
    public static bool CheckAnswer (EAnswerField answer, uint number)
    {
        return getCorrectAnswer(number).Equals(answer);
    }

    public static EAnswerField getCorrectAnswer (uint number)
    {
        return Quiz.Questions[number].correctAnswer;
    }
}