using AutoMapper;
using CarCompaniesApplication.API.Models.CarCompany;
using CarCompaniesApplication.BLL.Interfaces;
using CarCompaniesApplication.BLL.Models.CarCompany;
using Microsoft.AspNetCore.Mvc;

namespace CarCompaniesApplication.API.Controllers;

/// <summary>
/// Контроллер для управления компаниями-производителями.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarCompaniesController : ControllerBase
{
    private readonly ICarCompaniesService _carCompaniesService;
    private readonly IMapper _mapper;

    public CarCompaniesController(ICarCompaniesService carCompaniesService, IMapper mapper)
    {
        _carCompaniesService = carCompaniesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получает список всех компаний-производителей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список компаний в виде DTO.</returns>
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ResultCarCompanyDto>>> GetCarCompaniesAsync(CancellationToken cancellationToken)
    {
        var companies = await _carCompaniesService.GetAllAsync(cancellationToken);
        var result = _mapper.Map<IEnumerable<ResultCarCompanyDto>>(companies);

        return Ok(result);
    }

    /// <summary>
    /// Добавляет новую компанию-производителя.
    /// </summary>
    /// <param name="dto">DTO для добавления новой компании.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат выполнения запроса.</returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> AddCarCompany([FromBody] AddCarCompanyDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var model = _mapper.Map<AddCarCompanyModel>(dto);
            await _carCompaniesService.AddCarCompanyAsync(model, cancellationToken);

            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "Ошибка при добавлении компании.");
        }
    }

    /// <summary>
    /// Удаляет компанию по идентификатору.
    /// </summary>
    /// <param name="companyId">Идентификатор компании.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат выполнения запроса.</returns>
    [HttpDelete("[action]/{companyId}")]
    public async Task<IActionResult> RemoveCarCompany(Guid companyId, CancellationToken cancellationToken)
    {
        if (companyId == Guid.Empty)
            return BadRequest("ID компании обязателен.");

        try
        {
            await _carCompaniesService.RemoveCarCompanyAsync(companyId, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "Ошибка при удалении компании.");
        }
    }
}
