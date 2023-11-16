using TARpe22ShopVaitmaa.Core.Dto.WeatherDtos;

namespace TARpe22ShopVaitmaa.ApplicationServices.Services
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}