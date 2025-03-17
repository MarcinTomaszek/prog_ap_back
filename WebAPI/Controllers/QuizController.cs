using BackendLab01;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/v1/quizzes")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizUserService _service;
        
        public QuizController(IQuizUserService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
           return  _service.FindAllQuizzes().Select(u=>QuizDto.of(u));
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {

            if (_service.FindQuizById(id) is null)
                return NotFound();
            return Ok(QuizDto.of(_service.FindQuizById(id)));
        } 
        
        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public IActionResult SaveAnswer(int quizId, int itemId, [FromBody] QuizItemAnswerDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid request body");
            }

            _service.SaveUserAnswerForQuiz(quizId, itemId, dto.UserId, dto.Answer);
    
            return Ok("Answer saved successfully");
        }
        
        [HttpGet]
        [Route("{quizId}/users/{userId}/result")]
        public ActionResult<QuizResultDto> GetQuizResultForUser(int quizId, int userId)
        {
            int correctAnswers = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);

            var resultDto = new QuizResultDto(quizId, userId, correctAnswers);

            return Ok(resultDto);
        }
    }
}
