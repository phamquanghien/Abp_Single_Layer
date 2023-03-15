using TodoApp.Entities;
using TodoApp.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Services;

public class StudentAppService : ApplicationService
{
    private readonly IRepository<Student, Guid> _studentRepository;
    
    public StudentAppService(IRepository<Student, Guid> studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    // TODO: Implement the methods here...
    public async Task<List<StudentDto>> GetListAsync()
    {
        var items = await _studentRepository.GetListAsync();
        return items
            .Select(item => new StudentDto
            {
                Id = item.Id,
                FullName = item.FullName,
                Address = item.Address
            }).ToList();
    }
    public async Task<StudentDto> CreateAsync(string fname, string address)
    {
        var student = await _studentRepository.InsertAsync(
            new Student {
                FullName = fname,
                Address = address
                }
        );

        return new StudentDto
        {
            Id = student.Id,
            FullName = student.FullName,
            Address = student.Address
        };
    }
    public async Task DeleteAsync(Guid id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}