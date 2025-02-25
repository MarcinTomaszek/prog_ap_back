using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            var quiz_admin = provider.GetService<IQuizAdminService>();
            quiz_admin.AddQuizItem(points: 1, correctAnswer: "A", incorrectAnswers: new List<string>(){"B", "C", "D"},question: "Pierwsza litera alfabetu?");
            quiz_admin.AddQuizItem(points: 1, correctAnswer: "B", incorrectAnswers: new List<string>(){"A", "C", "E"},question: "Druga litera alfabetu?" );
            quiz_admin.AddQuizItem(points: 1, correctAnswer: "C", incorrectAnswers: new List<string>(){"A", "B", "F"},question: "Trzecia litera alfabetu?");

            var quiz = quiz_admin.AddQuiz("Litery alfabetu", quiz_admin.FindAllQuizItems());
        }
    }
}