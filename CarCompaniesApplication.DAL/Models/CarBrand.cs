namespace CarCompaniesApplication.DAL.Models;

/// <summary>
/// Марка автомобиля.
/// </summary>
public class CarBrand
{
    /// <summary>
    /// Идентификатор марки.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название марки.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Описание марки.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Компания-производитель.
    /// </summary>
    public required CarCompany Company { get; set; }
}
