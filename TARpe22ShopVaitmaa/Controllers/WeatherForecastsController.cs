using Microsoft.AspNetCore.Mvc;
using TARpe22ShopVaitmaa.ApplicationServices.Services;
using TARpe22ShopVaitmaa.Core.Dto.WeatherDtos;
using TARpe22ShopVaitmaa.Models.Weather;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastsServices;
        public WeatherForecastsController(IWeatherForecastsServices weatherForecastsServices)
        {
            _weatherForecastsServices = weatherForecastsServices;
        }
        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();
            return View(vm);
        }
        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }
            return View();
        }
        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new();
            WeatherViewModel vm = new();

            _weatherForecastsServices.WeatherDetail(dto);

            vm.EffectiveDate = dto.EffectiveDate;
            vm.EffectiveEpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.Category = dto.Category;
            vm.EndDate = dto.EndDate;
            vm.EndEpochDate = dto.EndEpochDate;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Date = dto.DailyForecastsDay;
            vm.EpochDate = dto.DailyForecastsEpochDate;
            
            vm.Temperature.Minimum.Value = dto.TempMinValue;
            vm.Temperature.Minimum.Unit = dto.TempMinUnit;
            vm.Temperature.Minimum.UnitType = dto.TempMinUnitType;
            
            vm.Temperature.Maximum.Value = dto.TempMaxValue;
            vm.Temperature.Maximum.Unit = dto.TempMaxUnit;
            vm.Temperature.Maximum.UnitType = dto.TempMaxUnitType;

            vm.Day.Icon = dto.DayIcon;
            vm.Day.IconPhrase = dto.DayIconPhrase;
            vm.Day.HasPrecipitation = dto.DayHasPrecipitation;
            vm.Day.PrecipitationType = dto.DayPrecipitationType;
            vm.Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;
            
            vm.Night.Icon = dto.NightIcon;
            vm.Night.IconPhrase = dto.NightIconPhrase;
            vm.Night.HasPrecipitation = dto.NightHasPrecipitation;
            vm.Night.PrecipitationType = dto.NightPrecipitationType;
            vm.Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;

            return View(vm);
        }
    }
}
