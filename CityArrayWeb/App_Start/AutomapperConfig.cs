using AutoMapper;
using CityArrayDAL.Model;
using CityArrayWeb.ModelView;
using System;
using System.Linq;

namespace CityArrayWeb
{
    public class AutomapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Review, ReviewView>()
                    .ForMember(p => p.CityName, opt => opt.MapFrom(p => p.City.Name))
                    .ForMember(p => p.PersonName, opt => opt.MapFrom(p => p.Person.NickName));

                cfg.CreateMap<Review, ReviewInfo>()
                  .ForMember(p => p.CityName, opt => opt.MapFrom(p => p.City.Name))
                  .ForMember(p => p.PersonName, opt => opt.MapFrom(p => p.Person.NickName));

                cfg.CreateMap<ReviewModify, Review>()
                    .ForMember(p => p.Id, opt => opt.Ignore())
                    .ForMember(p => p.PersonId, opt => opt.Ignore())
                    .ForMember(p => p.CreationDate, opt => opt.Ignore())
                    .ForMember(p => p.City, opt => opt.Ignore())
                    .ForMember(p => p.Person, opt => opt.Ignore())
                    .ForMember(p => p.Comments, opt => opt.Ignore());


                cfg.CreateMap<Person, PersonView>()
                    .ForMember(p => p.CountryName, opt => opt.MapFrom(p => p.Nationality.Name));

                cfg.CreateMap<Person, PersonInfo>()
                    .ForMember(p => p.CountryName, opt => opt.MapFrom(p => p.Nationality.Name))
                    .ForMember(v => v.ReviewsCount, opt => opt.MapFrom(m => m.Reviews.Count))
                    .ForMember(v => v.WishesCount, opt => opt.MapFrom(m => m.WishedCities.Count));

                cfg.CreateMap<RegisterViewModel, Person>()
                    .ForMember(p => p.Id, opt => opt.Ignore())
                    .ForMember(p => p.AddDay, opt => opt.Ignore())
                    .ForMember(p => p.Nationality, opt => opt.Ignore())
                    .ForMember(p => p.AppUser, opt => opt.Ignore())
                    .ForMember(p => p.Reviews, opt => opt.Ignore())
                    .ForMember(p => p.WishedCities, opt => opt.Ignore())
                    .ForMember(p => p.Comments, opt => opt.Ignore());


                cfg.CreateMap<City, CityView>()
                    .ForMember(v => v.CountryName, opt => opt.MapFrom(m => m.Country.Name))
                    .ForMember(v => v.Rating, opt => opt.MapFrom(m => m.Reviews.Count == 0 ? null : (int?)Math.Round(m.Reviews.Average(r => r.Rating))));

                cfg.CreateMap<City, CityInfo>()
                    .ForMember(v => v.CountryName, opt => opt.MapFrom(m => m.Country.Name))
                    .ForMember(v => v.ReviewsCount, opt => opt.MapFrom(m => m.Reviews.Count))
                    .ForMember(v => v.WishesCount, opt => opt.MapFrom(m => m.WishedCities.Count));

                cfg.CreateMap<CityModify, City>()
                    .ForMember(m => m.Country, opt => opt.Ignore())
                    .ForMember(m => m.Reviews, opt => opt.Ignore())
                    .ForMember(m => m.WishedCities, opt => opt.Ignore());


                cfg.CreateMap<WishedCity, WishedCityView>()
                    .ForMember(v => v.PersonName, opt => opt.MapFrom(m => m.Person.NickName))
                    .ForMember(v => v.CityName, opt => opt.MapFrom(m => m.City.Name));

                cfg.CreateMap<WishedCity, WishedCityInfo>()
                    .ForMember(v => v.PersonName, opt => opt.MapFrom(m => m.Person.NickName))
                    .ForMember(v => v.CityName, opt => opt.MapFrom(m => m.City.Name));

                cfg.CreateMap<WishedCityModify, WishedCity>()
                    .ForMember(v => v.PersonId, opt => opt.Ignore())
                    .ForMember(v => v.City, opt => opt.Ignore())
                    .ForMember(v => v.Person, opt => opt.Ignore());
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }

    }
}