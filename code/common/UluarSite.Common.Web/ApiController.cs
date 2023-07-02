using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UluarSite.Common.Web;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase {
    protected IActionResult HandleErrors<T>(Func<T> func) {
        try {
            return Ok(func.Invoke());
        } catch (Exception e) {
            return Problem(Error.Failure(e.Detail(includeStackTrace: true), e.Message));
        }
    }

    protected async Task<IActionResult> HandleErrorsAsync<T>(Func<Task<T>> func) {
        try {
            return Ok(await func.Invoke());
        } catch (Exception e) {
            return Problem(Error.Failure(e.Detail(includeStackTrace: true), e.Message));
        }
    }

    protected async Task<IActionResult> HandleErrorsAsync(Func<Task> func) {
        try {
            await func.Invoke();
            return Ok();
        } catch (Exception e) {
            return Problem(Error.Failure(e.Detail(includeStackTrace: true), e.Message));
        }
    }

    private IActionResult Problem(Error error) {
        return Problem(new List<Error> { error });
    }

    private IActionResult Problem(List<Error> errors) {
        if (errors.All(e => e.Type == ErrorType.Validation)) {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors) {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

        if (errors.Any(e => e.Type == ErrorType.Unexpected)) {
            return Problem();
        }

        var firstError = errors[0];

        var statusCode = firstError.Type switch {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description, detail: firstError.Code);
    }
}
