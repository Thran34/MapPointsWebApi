namespace MapPointsWebApi;

public class Question
{
    public Question(string text, string[] answers, int correctIndex)
    {
        Text = text;
        Answers = answers;
        CorrectIndex = correctIndex;
    }

    public string Text { get; set; }
    public string[] Answers { get; set; }
    public int CorrectIndex { get; set; }
}