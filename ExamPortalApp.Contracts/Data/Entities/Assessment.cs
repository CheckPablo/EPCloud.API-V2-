namespace ExamPortalApp.Contracts.Data.Entities;

public partial class Assessment : EntityBase
{
    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? Score { get; set; }

    public bool? BitAbsent { get; set; }

    public bool BitLangChanged { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Removed { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? TestQuestionId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Test? Test { get; set; }

    public virtual TestQuestion? TestQuestion { get; set; }
}
