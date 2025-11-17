using EM.Core.Models.Dto;
namespace EM.Web.Interfaces
{
    public interface IBaseService
    {
         Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
