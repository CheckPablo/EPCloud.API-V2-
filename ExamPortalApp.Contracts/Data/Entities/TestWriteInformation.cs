using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortalApp.Contracts.Data.Entities;

public  class TestWriteInformation 
{

    public string LOGINGUID { get; set; }
    public int TestSecurityLevel { get; set; }
    public virtual ICollection<RandomOtp> testOtp { get; set; } = new List<RandomOtp>();
}
