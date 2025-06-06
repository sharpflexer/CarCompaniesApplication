using CarCompaniesApplication.BLL.Models.CarBrand;

namespace CarCompaniesApplication.BLL.Interfaces;

/// <summary>
/// Контракт для сервиса брендов.
/// </summary>
public interface ICarBrandsService
{
    /// <summary>
    /// Получить все марки автомобилей заданного производителя.
    /// </summary>
    /// <param name="companyId">Идентификатор производителя.</param>
    public Task<IEnumerable<ResultCarBrandModel>> GetBrandsByCompanyId(Guid companyId, CancellationToken cancellationToken);

    /// <summary>
    /// Добавить новую марку автомобиля.
    /// </summary>
    /// <param name="brand">Марка автомобиля.</param>
    public Task AddCarBrand(AddCarBrandModel brand, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить марку автомобиля.
    /// </summary>
    /// <param name="brandId">Идентификатор марки автомобиля.</param>
    public Task RemoveCarBrand(Guid brandId, CancellationToken cancellationToken);
}
