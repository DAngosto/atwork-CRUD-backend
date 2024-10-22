namespace atwork_CRUD_backend_Domain.Entities
{
    public static class EmployeeErrors
    {
        public static string NotFoundById(Guid id) => $"The employee with the Id = '{id}' was not found";
        public static string EmployeeCreationUnavailable() => $"System could not create provided employee";
    }
}
