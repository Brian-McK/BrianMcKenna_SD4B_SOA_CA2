using AutoMapper;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Profiles;

public class BoxerProfile: Profile
{
    public BoxerProfile()
    {
        CreateMap<Boxer, BoxerDto>()
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.Surname}"))
            .ForMember(dest => dest.Dob,
                opt =>opt.MapFrom(src =>
                    $"{src.DateOfBirth:dd/MM/yyyy}"));

        CreateMap<Boxer, BoxerForUpdatingDto>().ForMember(
            dest => dest.Dob,
            opt => opt.MapFrom(src => $"{src.DateOfBirth:dd/MM/yyyy}"));
        
        CreateMap<BoxerForUpdatingDto, Boxer>().ForMember(
            dest => dest.DateOfBirth,
            opt => opt.MapFrom(src => 
                $"{ConvertDateStringToDateTime(src.Dob)}"));
        
    }

    private static DateTime? ConvertDateStringToDateTime(string? dateStr)
    {
        if (dateStr == null) return null;
       
        var date = DateTime.ParseExact(dateStr, "dd/MM/yyyy", null);

        return date;
    }
}