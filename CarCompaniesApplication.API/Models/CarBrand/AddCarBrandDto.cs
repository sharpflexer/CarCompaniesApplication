namespace CarCompaniesApplication.API.Models.CarBrand;

/// <summary>
/// Модель запроса на добавление марки автомобиля.
/// </summary>
public class AddCarBrandDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CompanyId { get; set; }
}
