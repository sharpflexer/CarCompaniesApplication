using AutoMapper;
using CarCompaniesApplication.BLL.Interfaces;
using CarCompaniesApplication.BLL.Models.CarCompany;
using CarCompaniesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCompaniesApplication.BLL.Services;

/// <summary>
/// Сервис для работы с компаниями-производителями.
/// </summary>
public class CarCompaniesService : ICarCompaniesService
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    private readonly DbContext _dbContext;

    /// <summary>
    /// Набор компаний-производителей.
    /// </summary>
    private readonly DbSet<CarCompany> _carCompanies;

    /// <summary>
    /// Маппер.
    /// </summary>
    private readonly IMapper _mapper;

    public CarCompaniesService(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _carCompanies = dbContext.Set<CarCompany>() ?? throw new ArgumentNullException(nameof(_carCompanies));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ResultCarCompanyModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var companies = await _carCompanies.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ResultCarCompanyModel>>(companies);
    }

    /// <inheritdoc/>
    public async Task AddCarCompanyAsync(AddCarCompanyModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CarCompany>(model);
        entity.Id = Guid.NewGuid();

        await _carCompanies.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RemoveCarCompanyAsync(Guid companyId, CancellationToken cancellationToken)
    {
        var company = await _carCompanies.FirstOrDefaultAsync(c => c.Id == companyId, cancellationToken);

        if (company == null)
            return;

        _carCompanies.Remove(company);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
