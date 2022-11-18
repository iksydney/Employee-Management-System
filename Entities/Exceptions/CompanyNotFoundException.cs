namespace CompanyEmployees.Extensions
{
    public sealed class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid companyId)
            : base($"The company with id : {companyId} doesnt exist in the database. ")
        {
        }
    }
}
