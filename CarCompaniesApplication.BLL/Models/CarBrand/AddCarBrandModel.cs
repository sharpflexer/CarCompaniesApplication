namespace CarCompaniesApplication.BLL.Models.CarBrand;

public class AddCarBrandModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CompanyId { get; set; }
}
