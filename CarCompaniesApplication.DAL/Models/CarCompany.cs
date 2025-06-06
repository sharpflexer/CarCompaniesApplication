namespace CarCompaniesApplication.DAL.Models;

/// <summary>
/// Компания-производитель автомобилей.
/// </summary>
public class CarCompany
{
    /// <summary>
    /// Идентификатор компании.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название компании.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Сайт компании.
    /// </summary>
    public required string Site { get; set; }

    /// <summary>
    /// Описание компании.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Марки автомобилей компании.
    /// </summary>
    public required IEnumerable<CarBrand> Brands { get; set; }
}
