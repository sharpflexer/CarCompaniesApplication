namespace CarCompaniesApplication.API.Models.CarBrand;

/// <summary>
/// Модель запроса на получение марки автомобиля.
/// </summary>
public class ResultCarBrandDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CompanyId { get; set; }
}