using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ATILFeeCalculation.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ILogger<ControllerBase> _logger;
        protected BaseController(
    ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleException(Exception exception)
        {
            _logger.LogError(exception.ToString());

            return exception switch
            {
                ArgumentException _ or InvalidDataException _ or FormatException _ => BadRequest(),
                Exception _ => StatusCode(StatusCodes.Status500InternalServerError),
                _ => null,
            };
        }
    }
}
