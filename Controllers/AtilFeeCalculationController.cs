using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATIL.FeeCalculator.Models;
using ATIL.FeeCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ATIL.FeeCalculator.Controllers
{
    [ApiController]
    public class AtilFeeCalculationController : BaseController
    {
        public AtilFeeCalculationController(ILogger<AtilFeeCalculationController> logger) : base(logger)
        { }

        [Route("api/atil-gebyr")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculationResult> CalculatAtilFee(string tiltakstype, string bygningstype, string areal)
        {
            //// Authentication?
            //if (!VerifyInput(input))
            //{
            //    return BadRequest();
            //}
            try
            {
                AtilFeeCalculationService feeCalculationService = new AtilFeeCalculationService();
                var calculationResult = feeCalculationService.Calculate(tiltakstype, bygningstype, areal);

                return Ok(calculationResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/tiltakstyper")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Tiltakstype>> GetTiltakstyper()
        {
            try
            {
                AtilFeeCalculationService feeCalculationService = new AtilFeeCalculationService();
                var tiltakstyper = feeCalculationService.GetTiltakstyper();

                return Ok(tiltakstyper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/bygningstyper")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Bygningstype>> GetBygningstyper()
        {
            try
            {
                AtilFeeCalculationService feeCalculationService = new AtilFeeCalculationService();
                var bygningstyper = feeCalculationService.GetBygningstyper();

                return Ok(bygningstyper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
