using CarCompaniesApplication.BLL.Models.CarCompany;

namespace CarCompaniesApplication.BLL.Interfaces;

/// <summary>
/// Контракт для сервиса компаний-производителей.
/// </summary>
public interface ICarCompaniesService
{
    /// <summary>
    /// Получить всех производителей.
    /// </summary>
    public Task<IEnumerable<ResultCarCompanyModel>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Добавить нового производителя автомобилей.
    /// </summary>
    /// <param name="company">Новый производитель.</param>
    public Task AddCarCompanyAsync(AddCarCompanyModel company, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить производителя автомобилей.
    /// </summary>
    /// <param name="companyId">Идентификатор производителя.</param>
    public Task RemoveCarCompanyAsync(Guid companyId, CancellationToken cancellationToken);
}
