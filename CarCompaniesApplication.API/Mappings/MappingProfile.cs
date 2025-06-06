using AutoMapper;
using CarCompaniesApplication.API.Models.CarBrand;
using CarCompaniesApplication.API.Models.CarCompany;
using CarCompaniesApplication.BLL.Models.CarBrand;
using CarCompaniesApplication.BLL.Models.CarCompany;
using CarCompaniesApplication.DAL.Models;

namespace CarCompaniesApplication.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        UseCarBrandMappings();
        UseCarCompanyMappings();
    }

    private void UseCarBrandMappings()
    {
        CreateMap<AddCarBrandDto, AddCarBrandModel>();
        CreateMap<ResultCarBrandModel, ResultCarBrandDto>().ReverseMap();

        CreateMap<AddCarBrandModel, CarBrand>()
            .ForMember(dest => dest.Company, opt => opt.Ignore());

        CreateMap<CarBrand, ResultCarBrandModel>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));

        CreateMap<ResultCarBrandModel, CarBrand>()
            .ForMember(dest => dest.Company, opt => opt.Ignore());
    }

    private void UseCarCompanyMappings()
    {
        CreateMap<AddCarCompanyDto, AddCarCompanyModel>();
        CreateMap<ResultCarCompanyModel, ResultCarCompanyDto>().ReverseMap();

        CreateMap<AddCarCompanyModel, CarCompany>();
        CreateMap<CarCompany, ResultCarCompanyModel>();
    }
}
