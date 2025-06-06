using AutoMapper;
using CarCompaniesApplication.API.Models.CarBrand;
using CarCompaniesApplication.BLL.Interfaces;
using CarCompaniesApplication.BLL.Models.CarBrand;
using Microsoft.AspNetCore.Mvc;

namespace CarCompaniesApplication.API.Controllers;

/// <summary>
/// Контроллер для управления марками автомобилей.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarBrandsController : ControllerBase
{
    private readonly ICarBrandsService _carBrandsService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CarBrandsController"/>.
    /// </summary>
    public CarBrandsController(ICarBrandsService carBrandsService, IMapper mapper)
    {
        _carBrandsService = carBrandsService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает список марок автомобилей по идентификатору компании.
    /// </summary>
    /// <param name="companyId">Идентификатор компании.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список марок автомобилей.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ResultCarBrandDto>>> GetBrandsByCompanyId([FromQuery] Guid companyId, CancellationToken cancellationToken)
    {
        if (companyId == Guid.Empty)
            return BadRequest("ID компании обязателен");

        var bllModels = await _carBrandsService.GetBrandsByCompanyId(companyId, cancellationToken);
        var dtos = _mapper.Map<IEnumerable<ResultCarBrandDto>>(bllModels);

        return Ok(dtos);
    }

    /// <summary>
    /// Добавляет новую марку автомобиля.
    /// </summary>
    /// <param name="dto">Данные марки автомобиля.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpPost("[action]")]
    public async Task<IActionResult> AddCompanyBrand([FromBody] AddCarBrandDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<AddCarBrandModel>(dto);
        await _carBrandsService.AddCarBrand(model, cancellationToken);

        return Ok();
    }

    /// <summary>
    /// Удаляет марку автомобиля по идентификатору.
    /// </summary>
    /// <param name="brandId">Идентификатор марки автомобиля.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("[action]/{brandId}")]
    public async Task<IActionResult> RemoveCompanyBrand(Guid brandId, CancellationToken cancellationToken)
    {
        if (brandId == Guid.Empty)
            return BadRequest("ID бренда обязателен");

        await _carBrandsService.RemoveCarBrand(brandId, cancellationToken);

        return Ok();
    }
}
