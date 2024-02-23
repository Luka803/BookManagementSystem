using AutoMapper;
using BookManagementSystem.Application.Features.Review.Commands.AddReview;

namespace BookManagementSystem.Application.MappingProfiles;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<MyDomain.Review, AddReviewCommand>().ReverseMap();
    }
}
