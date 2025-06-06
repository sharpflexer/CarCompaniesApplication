namespace CarCompaniesApplication.BLL.Models.CarBrand;

public class ResultCarBrandModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CompanyId { get; set; }
}
