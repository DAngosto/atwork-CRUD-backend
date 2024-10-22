namespace atwork_CRUD_backend_Application.DTOs.Dashboard
{
    public class DashboardDataDto
    {
        public required int NumberOfEmployees { get; set; }
        public required double WellnessScoreAverage { get; set; }
        public required double ProductivityScoreAverage { get; set; }
    }
}
