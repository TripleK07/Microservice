using EM.Core.Models.Dto;
namespace EM.Web.Service.IService
{
    public interface IBaseService
    {
         Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
