using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]    
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult OkResponse(object data) => Ok(data);

        protected IActionResult CreatedResponse(
            string actionName,
            object routeValues,
            object value)
            => CreatedAtAction(actionName, routeValues, value);                

        protected IActionResult NoContentResponse() => NoContent();

        protected IActionResult NotFoundResponse() => NotFound();
    }
}
