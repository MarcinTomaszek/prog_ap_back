using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class QuizList : PageModel
{
    private readonly IQuizAdminService _quizAdminService;

    public QuizList(IQuizAdminService quizAdminService)
    {
        _quizAdminService = quizAdminService;
    }

    public  List<BackendLab01.Quiz> quizList { get; set; }

    public void OnGet()
    {
        quizList = _quizAdminService.FindAllQuizzes();
    }
}