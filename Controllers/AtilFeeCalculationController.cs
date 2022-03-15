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
        private readonly AtilFeeCalculationService _atilFeeCalculationService;
        public AtilFeeCalculationController(ILogger<AtilFeeCalculationController> logger, AtilFeeCalculationService atilFeeCalculationService) : base(logger)
        {
            _atilFeeCalculationService = atilFeeCalculationService;
        }

        [Route("api/atil-gebyr")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculationResult> CalculatAtilFee(string tiltakstype, string bygningstype, string areal)
        {
            try
            {
                var calculationResult = _atilFeeCalculationService.Calculate(tiltakstype, bygningstype, areal);

                return Ok(calculationResult);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/atil-gebyr-basis")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculationResultBasis> CalculatAtilFeeBasis(string tiltakstype, string bygningstype, string areal)
        {

            try
            {
                var calculationResult = _atilFeeCalculationService.Calculate(tiltakstype, bygningstype, areal);

                CalculationResultBasis result = new CalculationResultBasis() { FeeCategory = calculationResult.Fee.FeeCategory, FeeAmount = calculationResult.Fee.FeeAmount };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
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
                var tiltakstyper = _atilFeeCalculationService.GetTiltakstyper();

                return Ok(tiltakstyper);
            }
            catch (Exception)
            {
                throw;
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
                var bygningstyper = _atilFeeCalculationService.GetBygningstyper();

                return Ok(bygningstyper);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
