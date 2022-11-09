using ApplicationsServices.Features.Commands.CreateCommands;
using AutoMapper;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Mapping
{
    public class GeneralMaping : Profile
    {
        public GeneralMaping()
        {
            CreateMap<Client, ClientFullDto>();
            CreateMap<CreateClientCommand, Client>();

            CreateMap<User, UserFullDto>();
            CreateMap<CreateUserCommand, User>();

            CreateMap<Pet, PetFullDto>();
            CreateMap<CreatePetCommand, Pet>();

            CreateMap<PetType, PetTypeFullDto>();
            CreateMap<CreatePetTypeCommand, PetType>();

            CreateMap<UserRol, UserRolFullDto>();
            CreateMap<CreateUserRolCommand, UserRol>();
        }
    }
}
