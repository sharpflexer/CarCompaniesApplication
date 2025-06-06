namespace CarCompaniesApplication.API.Models.CarCompany
{
    public class ResultCarCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Site { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
