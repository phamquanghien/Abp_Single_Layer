using TodoApp.Services;
using TodoApp.Services.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TodoApp.Pages;

public class StudentModel : AbpPageModel
{
    public List<StudentDto> Students { get; set; }

    private readonly StudentAppService _studentAppService;

    public StudentModel(StudentAppService studentAppService)
    {
        _studentAppService = studentAppService;
    }
    
    public async Task OnGetAsync()
    {
        Students = await _studentAppService.GetListAsync();
    }
}