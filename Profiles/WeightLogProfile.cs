using AutoMapper;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Profiles;

public class WeightLogProfile: Profile
{
    public WeightLogProfile()
    {
        CreateMap<WeightLog, WeightLogDto>().ForMember(
            dest => dest.WeighDate,
            opt => opt.MapFrom(src => $"{src.WeighDateTime:dd/MM/yyyy}")).ForMember(
            dest => dest.WeighTime,
            opt => opt.MapFrom(src => $"{src.WeighDateTime:t}"));

        CreateMap<WeightLogDto, WeightLogForCreatingDto>();
        
        CreateMap<WeightLogForCreatingDto, WeightLog>().ForMember(
            dest => dest.WeighDateTime,
            opt => opt.MapFrom(src => 
                $"{ConvertDateStringToDateTime(src.WeighDate)}"));

        CreateMap<WeightLogForUpdatingDto, WeightLog>().ForMember(
            dest => dest.WeighDateTime,
            opt => opt.MapFrom(src => 
                $"{ConvertDateStringToDateTime(src.WeighDate)}"));
        
        CreateMap<WeightLogForUpdatingDto, WeightLogForCreatingDto>();
    }
    
    private static DateTime? ConvertDateStringToDateTime(string? dateStr)
    {
        if (dateStr == null) return null;
       
        var date = DateTime.ParseExact(dateStr, "dd/MM/yyyy", null);

        return date;
    }
}