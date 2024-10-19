namespace atwork_CRUD_backend_Application.Exceptions
{
    public sealed class ValidationException : ApplicationException
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary) 
            : base ("Validation Failure", string.Join(Environment.NewLine, errorsDictionary.Select(x => x.Key + " : " + string.Join(" , ", x.Value)).ToArray())) 
        {
            ErrorsDictionary = errorsDictionary;
        }
    }
}
