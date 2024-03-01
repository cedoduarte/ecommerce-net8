using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;

namespace ecommerce
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.FirstName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.LastName))
                .ForMember(a => a.Email, b => b.MapFrom(c => c.Email))
                .ForMember(a => a.Username, b => b.MapFrom(c => c.Username))
                .ForMember(a => a.PasswordHash, b => b.MapFrom(c => c.PasswordHash))
                .ForMember(a => a.PhoneNumber, b => b.MapFrom(c => c.PhoneNumber))
                .ForMember(a => a.Birthdate, b => b.MapFrom(c => c.Birthdate))
                .ForMember(a => a.Country, b => b.MapFrom(c => c.Country))
                .ForMember(a => a.Province, b => b.MapFrom(c => c.Province))
                .ForMember(a => a.City, b => b.MapFrom(c => c.City))
                .ForMember(a => a.ZipCode, b => b.MapFrom(c => c.ZipCode))
                .ForMember(a => a.Type, b => b.MapFrom(c => c.Type))
                .ForMember(a => a.LastModified, b => b.MapFrom(c => c.LastModified))
                .ForMember(a => a.CreatedDate, b => b.MapFrom(c => c.CreatedDate))
                .ForMember(a => a.IsDeleted, b => b.MapFrom(c => c.IsDeleted));

            CreateMap<UserViewModel, User>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.FirstName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.LastName))
                .ForMember(a => a.Email, b => b.MapFrom(c => c.Email))
                .ForMember(a => a.Username, b => b.MapFrom(c => c.Username))
                .ForMember(a => a.PasswordHash, b => b.MapFrom(c => c.PasswordHash))
                .ForMember(a => a.PhoneNumber, b => b.MapFrom(c => c.PhoneNumber))
                .ForMember(a => a.Birthdate, b => b.MapFrom(c => c.Birthdate))
                .ForMember(a => a.Country, b => b.MapFrom(c => c.Country))
                .ForMember(a => a.Province, b => b.MapFrom(c => c.Province))
                .ForMember(a => a.City, b => b.MapFrom(c => c.City))
                .ForMember(a => a.ZipCode, b => b.MapFrom(c => c.ZipCode))
                .ForMember(a => a.Type, b => b.MapFrom(c => c.Type))
                .ForMember(a => a.LastModified, b => b.MapFrom(c => c.LastModified))
                .ForMember(a => a.CreatedDate, b => b.MapFrom(c => c.CreatedDate))
                .ForMember(a => a.IsDeleted, b => b.MapFrom(c => c.IsDeleted));

            CreateMap<Product, ProductViewModel>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.Price, b => b.MapFrom(c => c.Price))
                .ForMember(a => a.Stock, b => b.MapFrom(c => c.Stock))
                .ForMember(a => a.Imagehref, b => b.MapFrom(c => c.Imagehref))
                .ForMember(a => a.LastModified, b => b.MapFrom(c => c.LastModified))
                .ForMember(a => a.CreatedDate, b => b.MapFrom(c => c.CreatedDate))
                .ForMember(a => a.IsDeleted, b => b.MapFrom(c => c.IsDeleted));

            CreateMap<ProductViewModel, Product>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForMember(a => a.Price, b => b.MapFrom(c => c.Price))
                .ForMember(a => a.Stock, b => b.MapFrom(c => c.Stock))
                .ForMember(a => a.Imagehref, b => b.MapFrom(c => c.Imagehref))
                .ForMember(a => a.LastModified, b => b.MapFrom(c => c.LastModified))
                .ForMember(a => a.CreatedDate, b => b.MapFrom(c => c.CreatedDate))
                .ForMember(a => a.IsDeleted, b => b.MapFrom(c => c.IsDeleted));
        }
    }
}
