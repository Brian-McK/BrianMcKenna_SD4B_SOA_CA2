using AutoMapper;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Profiles;

public class BoxerProfile: Profile
{
    public BoxerProfile()
    {
        CreateMap<Boxer, BoxerDto>().ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.Surname}"));
    }
}