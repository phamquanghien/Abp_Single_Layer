using Volo.Abp.Domain.Entities;

namespace TodoApp.Entities;

public class Student : BasicAggregateRoot<Guid>
{
    public string FullName { get; set; }
    public string Address { get; set; }
}