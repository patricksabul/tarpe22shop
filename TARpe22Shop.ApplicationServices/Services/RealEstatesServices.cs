using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;

namespace TARpe22ShopVaitmaa.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        public RealEstatesServices
            (
            TARpe22ShopVaitmaaContext context
            )
        {
            _context = context;
        }
        public async Task<RealEstate> GetAsync(Guid id)
        {
            //var result = await _context.RealEstates
            //    .FirstOrDefaultAsync(x => x.Id == id);
            return null;
        }
        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            var realEstateProps = typeof(RealEstate).GetProperties();
            var realEstateDtoProps = typeof(RealEstateDto).GetProperties();
            for (int i = 0; i < realEstateProps.Length; i++)
            {
                var realEstateProp = realEstateProps[i];
                for (int j = 0; j < realEstateDtoProps.Length; j++)
                {
                    var realEstateDtoProp = realEstateDtoProps[j];
                    if (realEstateProp.Name == realEstateDtoProp.Name)
                    {
                        realEstateProp.SetValue(realEstate, realEstateDtoProp.GetValue(dto));
                    }
                }
            }
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;

            //realEstate.Id = Guid.NewGuid();
            //realEstate.Type = dto.Type;
            //realEstate.ListingDescription = dto.ListingDescription;
            //realEstate.Address = dto.Address;
            //realEstate.City = dto.City;
            //realEstate.PostalCode = dto.PostalCode;
            //realEstate.ContactPhone = dto.ContactPhone;
            //realEstate.ContactFax = dto.ContactFax;
            //realEstate.SquareMeters = dto.SquareMeters;
            //realEstate.Floor = dto.Floor;
            //realEstate.FloorCount = dto.FloorCount;
            //realEstate.Price= dto.Price;
            //realEstate.RoomCount = dto.RoomCount;
            //realEstate.BedroomCount = dto.BedroomCount;
            //realEstate.BathroomCount = dto.BathroomCount;
            //realEstate.WhenEstateListedAt = dto.WhenEstateListedAt;
            //realEstate.IsPropertySold = dto.IsPropertySold;
            //realEstate.DoesHaveSwimmingPool = dto.DoesHaveSwimmingPool;
            //realEstate.BuiltAt = dto.BuiltAt
        }
    }
}
