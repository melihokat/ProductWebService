using MainProjectCORE.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MainProjectAPI.Filters
{

    public class ValidateFilterAttribute : ActionFilterAttribute
    { //method çalışıyorken , çalıştıktan sonra gibi 4 tane method var.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid) //true geliyorsa problem yoktur.
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                //Bir liste gelsin , buradan bize hata mesajlarını göster ve listele.

                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
                //filteri kullanmak için gider controllerin içine gideriz ve tepesine koyarız :).
                //global olduğu için program.cs içine gömeriz.
            }

        }
    }
}
