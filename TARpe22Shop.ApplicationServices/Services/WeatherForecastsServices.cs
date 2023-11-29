using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Dto.WeatherDtos;

namespace TARpe22ShopVaitmaa.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            //City Name = "Tallinn, EE" Location = "EUR|EE|EN001|TALLINN" Country = "Estonia"

            string apikey = "UoJSCG3lbTnHIA9VEMQbeILRapsOWdQx";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=UoJSCG3lbTnHIA9VEMQbeILRapsOWdQx&metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = new JavaScriptSerializer().Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;
                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                //dto.Date = dto.DailyForecastsDay;
                //dto.EpochDate = dto.DailyForecastsEpochDate;
                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;
            }

            return dto;
        }
    }
}
