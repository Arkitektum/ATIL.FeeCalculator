using System;
using System.Collections.Generic;
using System.Linq;
using ATIL.FeeCalculator.Data;
using ATIL.FeeCalculator.Exceptions;
using ATIL.FeeCalculator.Models;

namespace ATIL.FeeCalculator.Services
{
    public class AtilFeeCalculationService
    {
        private Repository _repository;

        public AtilFeeCalculationService(Repository repository)
        {
            _repository = repository;
        }

        public List<Tiltakstype> GetTiltakstyper()
        {
            return _repository.GetTiltakstyper();
        }

        public List<Bygningstype> GetBygningstyper()
        {
            return _repository.GetBygningstyper();
        }

        public List<FeeCategoryDescription> GetGebyrKategoriBeskrivelser()
        {
            return _repository.GetGebyrKategoriBeskrivelser();
        }

        public CalculationResult Calculate(IEnumerable<string> tiltakstypekode, string bygningstypekode, string areal)
        {
            bool illegalTiltakstype = false;
            int maxFee = 0;
            CalculationResult result = null;

            foreach (var tiltakstype in tiltakstypekode)
            {
                try
                {
                    var calculation = Calculate(tiltakstype, bygningstypekode, areal);
                    if (calculation != null)
                    {
                        if (calculation.Fee.FeeAmount > maxFee)
                        {
                            maxFee = calculation.Fee.FeeAmount;
                            result = calculation;
                        }
                    }
                }
                catch (IllegalTiltakstypeException)
                {
                    illegalTiltakstype = true;
                }

            }
            if (result == null && illegalTiltakstype)
            {
                throw new ArgumentException($"Ingen gyldige koder for tiltakstype er angitt.");
            }

            return result;
        }


        public CalculationResult Calculate(string tiltakstypekode, string bygningstypekode, string areal)
        {
            try
            {
                if (Int32.TryParse(areal, out int arealTall))
                {
                    if (arealTall < 0)
                    {
                        throw new ArgumentException($"Areal kan ikke være et negativt tall. '{areal}' er ikke gyldig.");
                    }

                    if (!_repository.GetTiltakstyper().Exists(x => x.Kode.Equals(tiltakstypekode)))
                    {
                        throw new IllegalTiltakstypeException($"Angitt kode '{tiltakstypekode}' for tiltakstype er ikke tillatt.");
                    }

                    if (arealTall == 0 && _repository.GetTiltakstyper().Any(tiltakstype => tiltakstype.Kode.Equals(tiltakstypekode) && !tiltakstype.AllowZeroBRA))
                    {
                        throw new ArgumentException($"Areal må være et heltall større enn 0. '{areal}' er ikke gyldig.");
                    }

                    if (!_repository.GetBygningstyper().Exists(x => x.Kode.Equals(bygningstypekode)))
                    {
                        throw new ArgumentException($"Angitt kode '{bygningstypekode}' for bygningstype er ikke tillatt.");
                    }

                    var foundCategory = _repository.GetKategorier().FirstOrDefault(x => x.Tiltakstype.Contains(tiltakstypekode) && x.Bygningstype.Contains(bygningstypekode));
                    var foundArea = foundCategory.CategoryAreas.First(x => arealTall >= x.Lower && arealTall <= x.Upper);
                    var res = new CalculationResult()
                    {
                        Area = areal,
                        Bygningstype = GetBygningstyper().FirstOrDefault(x => x.Kode.Equals(bygningstypekode)),
                        Tiltakstype = GetTiltakstyper().FirstOrDefault(x => x.Kode.Equals(tiltakstypekode)),
                        Description = foundCategory.Description,
                        Fee = new Fee() { FeeAmount = foundArea.Price, FeeCategory = foundArea.CategoryCode, FeeCategoryDescription = GetGebyrKategoriBeskrivelser().FirstOrDefault(x => x.Kode.Equals(foundArea.CategoryCode)).Beskrivelse }
                    };

                    return res;

                }
                else
                {
                    throw new ArgumentException($"Areal må være et heltall. '{areal}' er ikke gyldig.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
