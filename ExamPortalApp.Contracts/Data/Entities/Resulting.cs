using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Entities;

public  class Resulting 
{
    public int? Id { get; set; }
    public int? TestId { get; set; }

    public int? StudentID { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public string? Grade { get; set; }

    public string? Subject { get; set; }

    public string? TestName { get; set; }

    //public string? UserEmailAddress { get; set; }
    [NotMapped]
    public string? FileName { get; set; }
    [NotMapped]

    public byte[]? Answer { get; set; }
    public string? TestCompleted { get; set; }
    public string? AnswerScript { get; set; }

    public int? DocumentId { get; set; }
    public int? RegionId { get; set; }
}
