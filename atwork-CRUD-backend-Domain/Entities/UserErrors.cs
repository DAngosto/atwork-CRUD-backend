namespace atwork_CRUD_backend_Domain.Entities
{
    public static class UserErrors
    {
        public static string InvalidUsernameOrPassword() => $"Invalid username or password was provided";
        public static string UserCreationUnavailable() => $"System could not create provided user";
    }
}
