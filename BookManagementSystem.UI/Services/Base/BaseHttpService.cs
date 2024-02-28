using AutoMapper;

namespace BookManagementSystem.UI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;
    protected IMapper _mapper;

    public BaseHttpService(IClient client, IMapper mapper)
    {
        this._client = client;
        this._mapper = mapper;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        if (ex.StatusCode == 400)
        {
            return new Response<Guid>()
            {
                Message = "Invalid data was submitted",
                ValidationErrors = ex.Response,
                Success = false
            };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response<Guid>()
            {
                Message = "The record was not found",
                Success = false
            };
        }
        else
        {
            return new Response<Guid>()
            {
                Message = "Something went wrong, please try again later",
                Success = false
            };
        }
    }
}
