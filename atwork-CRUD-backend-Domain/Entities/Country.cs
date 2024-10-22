namespace atwork_CRUD_backend_Domain.Entities
{
    public class Country
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
    }
}
