using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Models;
namespace BackendLab01.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}