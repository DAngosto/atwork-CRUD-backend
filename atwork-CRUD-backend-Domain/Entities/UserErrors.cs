namespace atwork_CRUD_backend_Domain.Entities
{
    public static class UserErrors
    {
        public static string InvalidUsernameOrPassword() => $"Invalid username or password was provided";
        public static string UserCreationUnavailable() => $"System could not create provided user";
        public static string NotFoundById(Guid id) => $"The user with the Id = '{id}' was not found";
    }
}
