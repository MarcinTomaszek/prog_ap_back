using ApplicationCore.Commons.Functions;
using BackendLab01;

namespace WebApplication1.Properties.DTO;

public class QuizItemDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string>Options;

    private QuizItemDto()
    {
        
    }
    public static QuizItemDto of(QuizItem quiz)
    {
        
        var allOptions = quiz.IncorrectAnswers;
        allOptions.Add(quiz.CorrectAnswer);
        allOptions.Shuffle();
        return new QuizItemDto() { Id = quiz.Id, Question = quiz.Question, Options = allOptions };
    }
    

}