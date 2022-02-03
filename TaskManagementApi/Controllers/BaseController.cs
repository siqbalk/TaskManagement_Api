using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaskManagementApi.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ApiResponseDto ApiOkResult(dynamic _data)
        {
            return new ApiResponseDto
            {
                ResponseData = _data,
                Status = (int)HttpStatusCode.OK,
                IsSuccessful = true
            };

        }

    }
}
