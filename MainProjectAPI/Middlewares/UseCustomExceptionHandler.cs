using MainProjectCORE.DTOs;
using MainProjectService.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace MainProjectAPI.Middlewares
{
    public static class UseCustomExceptionHandler //extansion class yazmak için static olmak zorunda
    {
        public static void UserCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>  //run sonlandırıcı bir middleware'dir. buraya girildikten sonra geri yönlendirilir request.
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    { //eğer bu hatanın tipi eğer bir client exception ise 400 ata , diğer türlü ise 500 dön
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response)); //Jsone çeviririz.
                    //aktif hale getirmeliyiz.
                });
            });
        }
    }
}
