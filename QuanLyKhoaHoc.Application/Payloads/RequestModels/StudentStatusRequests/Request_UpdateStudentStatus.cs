namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentStatusRequests
{
    public class Request_UpdateStudentStatus
    {
        public int Id { get; set; }
        public string StudentStatusName { get; set; } = string.Empty;
    }
}
