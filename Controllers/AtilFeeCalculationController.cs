using System;
using System.Threading.Tasks;
using ATILFeeCalculation.Models;
using ATILFeeCalculation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ATILFeeCalculation.Controllers
{
    [ApiController]
    public class AtilFeeCalculationController : BaseController
    {
        public AtilFeeCalculationController(ILogger<AtilFeeCalculationController> logger) : base(logger)
        { }

        [Route("api/atil-fee")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Fee> CalculatAtilFee(string tiltakstype, string bygningstype, string areal)
        {
            //// Authentication?
            //if (!VerifyInput(input))
            //{
            //    return BadRequest();
            //}
            try
            {
                AtilFeeCalculationService feeCalculationService = new AtilFeeCalculationService();
                var gebyr = feeCalculationService.Calculate(tiltakstype, bygningstype, areal);

                return Ok(gebyr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
