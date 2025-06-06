using AutoMapper;
using CarCompaniesApplication.BLL.Interfaces;
using CarCompaniesApplication.BLL.Models.CarBrand;
using CarCompaniesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCompaniesApplication.BLL.Services;

/// <summary>
/// Сервис для работы с марками автомобилей.
/// </summary>
public class CarBrandsService : ICarBrandsService
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    private readonly DbContext _dbContext;

    /// <summary>
    /// Набор данных марок автомобилей.
    /// </summary>
    private readonly DbSet<CarBrand> _carBrands;

    /// <summary>
    /// Маппер.
    /// </summary>
    private readonly IMapper _mapper;

    public CarBrandsService(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _carBrands = dbContext.Set<CarBrand>() ?? throw new ArgumentNullException(nameof(_carBrands));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ResultCarBrandModel>> GetBrandsByCompanyId(Guid companyId, CancellationToken cancellationToken)
    {
        var brands = await _carBrands
            .Include(b => b.Company)
            .Where(b => b.Company.Id == companyId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ResultCarBrandModel>>(brands);
    }

    /// <inheritdoc/>
    public async Task AddCarBrand(AddCarBrandModel model, CancellationToken cancellationToken)
    {
        var company = await _dbContext.Set<CarCompany>()
            .FirstOrDefaultAsync(c => c.Id == model.CompanyId, cancellationToken);

        if (company == null)
            throw new InvalidOperationException("Компания не найдена");

        var entity = _mapper.Map<CarBrand>(model);
        entity.Id = Guid.NewGuid();
        entity.Company = company;

        await _carBrands.AddAsync(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RemoveCarBrand(Guid brandId, CancellationToken cancellationToken)
    {
        var carBrand = await _dbContext.Set<CarBrand>()
            .FirstOrDefaultAsync(b => b.Id == brandId, cancellationToken);

        if (carBrand == null)
            return;

        _carBrands.Remove(carBrand);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
