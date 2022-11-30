using AutoMapper;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Profiles;

public class TrainerProfile: Profile
{
    public TrainerProfile()
    {
        CreateMap<Trainer, TrainerDto>().ForMember(
            dest => dest.FullName,
            opt => opt.MapFrom(src => $"{src.FirstName} {src.Surname}"));
    }
}