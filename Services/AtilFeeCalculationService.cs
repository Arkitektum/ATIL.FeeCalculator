using System;
using System.Collections.Generic;
using System.Linq;
using ATIL.FeeCalculator.Data;
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

        public CalculationResult Calculate(string tiltakstypekode, string bygningstypekode, string areal)
        {
            try
            {
                if (Int32.TryParse(areal, out int arealTall))
                {
                    if (arealTall <= 0)
                    {
                        throw new ArgumentException($"Areal må være et heltall større enn 0. '{areal}' er ikke gyldig.");
                    }

                    if (!_repository.GetTiltakstyper().Exists(x => x.Kode.Equals(tiltakstypekode)))
                    {
                        throw new ArgumentException($"Angitt kode for tiltakstype ('{tiltakstypekode}') er ikke tillatt.");
                    }

                    if (!_repository.GetBygningstyper().Exists(x => x.Kode.Equals(bygningstypekode)))
                    {
                        throw new ArgumentException($"Angitt kode for bygningstype ('{bygningstypekode}') er ikke tillatt.");
                    }

                    var foundCategory = _repository.GetKategorier().FirstOrDefault(x => x.Tiltakstype.Contains(tiltakstypekode) && x.Bygningstype.Contains(bygningstypekode));
                    var foundArea = foundCategory.CategoryAreas.First(x => arealTall > x.Lower && arealTall <= x.Upper);
                    var res = new CalculationResult()
                    {
                        Area = areal,
                        Bygningstype = GetBygningstyper().FirstOrDefault(x => x.Kode.Equals(bygningstypekode)),
                        Tiltakstype = GetTiltakstyper().FirstOrDefault(x => x.Kode.Equals(tiltakstypekode)),
                        Description = foundCategory.Description,
                        Fee = new Fee() { FeeAmount = foundArea.Price, FeeCategory = foundArea.CategoryCode, FeeCategoryDescription = GetGebyrKategoriBeskrivelser().FirstOrDefault(x => x.Code.Equals(foundArea.CategoryCode)).Description }
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
