namespace WebAPI.DTO;

public class QuizResultDto
{
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int CorrectAnswersCount { get; set; }

    public QuizResultDto(int quizId, int userId, int correctAnswersCount)
    {
        QuizId = quizId;
        UserId = userId;
        CorrectAnswersCount = correctAnswersCount;
    }
}