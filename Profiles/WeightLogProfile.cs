using AutoMapper;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Profiles;

public class WeightLogProfile: Profile
{
    public WeightLogProfile()
    {
        CreateMap<WeightLog, WeightLogDto>();
    }
}