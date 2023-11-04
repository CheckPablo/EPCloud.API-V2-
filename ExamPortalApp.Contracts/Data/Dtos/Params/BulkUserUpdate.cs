namespace ExamPortalApp.Contracts.Data.Dtos.Params
{
    public class BulkUserUpdate
    {
        public List<int> ApprovedUserIds { get; set; } = new List<int>();
        public List<int> ActiveUserIds { get; set; } = new List<int>();
        public List<int> AdminUserIds { get; set; } = new List<int>();
        public List<int> UserIds { get; set; } = new List<int>();
    }
}
