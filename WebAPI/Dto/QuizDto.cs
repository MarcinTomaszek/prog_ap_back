using BackendLab01;

namespace WebAPI.DTO;

public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public List<QuizItemDto> Items { get; set; }

    private QuizDto()
    {
        
    }

    public static QuizDto of(Quiz quiz)
    {
        List<QuizItemDto>  quizItemDtoList = new List<QuizItemDto>();
        foreach (var q in quiz.Items)
        {
            quizItemDtoList.Add(QuizItemDto.of(q));
        }
        return new QuizDto() { Id = quiz.Id, Title = quiz.Title, Items = quizItemDtoList };
        
    }

}