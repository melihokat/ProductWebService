using MainProjectCORE.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MainProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction] //endpoint olmadığı için bunu koymamız gerekir.Get ya da post olmadığı için hata fırlatır.
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)   //204 durum kodu nocontet , geriye bir şey dönmeyeceğiz.
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            return new ObjectResult(response) //status kod 200 ise , 200 gelecek , 404 ise 404 gelecek.
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
