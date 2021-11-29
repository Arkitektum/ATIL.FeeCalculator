using System;
using System.Collections.Generic;
using System.Linq;
using ATILFeeCalculation.Models;

namespace ATILFeeCalculation.Services
{
    public class AtilFeeCalculationService
    {
        Category _category_1;
        Category _category_2;
        Category _category_3;
        Category _category_5;
        List<Category> _categories;


        public AtilFeeCalculationService()
        {
            List<string> tiltakstyper_kat_1_3 = new List<string>() { "202", "203", "205", "206", "400", "401", "402", "403", "406", "407", "504", "508", "910" };
            List<string> tiltakstyper_kat_5 = new List<string>() { "300", "301", "302", "303", "304", "404", "405", "409", "506", "51", "53", "54", "55" };

            IEnumerable<string> bygningstype_kat_1 = new List<string>() { "223", "229", "233", "243", "245", "429", "431", "439", "523", "524", "529", "611", "654", "659", "825", "829", "830", "840" };
            IEnumerable<string> bygningstype_kat_2 = new List<string>() { "231", "232", "239", "241", "248", "249", "311", "312", "313", "319", "321", "322", "329", "330", "412", "511", "512", "519", "521", "522", "612", "613", "614", "615", "616", "619", "621", "622", "629", "641", "642", "643", "649", "651", "652", "653", "655", "661", "662", "663", "669", "671", "672", "673", "674", "675", "679", "722", "723", "732", "739", "819", "821" };
            IEnumerable<string> bygningstype_kat_3 = new List<string>() { "211", "212", "214", "216", "219", "221", "244", "323", "411", "415", "416", "419", "441", "449", "531", "532", "533", "539", "623", "719", "721", "729", "731", "822", "823", "824" };

            IEnumerable<string> bygningstype_kat_5 = bygningstype_kat_1.ToList().Concat(bygningstype_kat_2).ToList().Concat(bygningstype_kat_3).ToList();

            IEnumerable<string> xxenum = new List<string>() { "" };
            List<string> xx = new List<string>() { "" };
            xx.AddRange(xxenum);

            _category_1 = new Category()
            {
                Description = "Kategori 1 (Publikumsbygg og yrkesbygg uten faste arbeidsplasser)",
                Bygningstype = bygningstype_kat_1.ToList(),
                Tiltakstype = tiltakstyper_kat_1_3,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100, CategoryCode = "1a", Price = 703 },
                    new Area() { Lower = 100, Upper = 500, CategoryCode = "1b", Price = 1407 },
                    new Area() { Lower = 500, Upper = 1000, CategoryCode = "1c", Price = 2110 },
                    new Area() { Lower = 1000, Upper = 10000, CategoryCode = "1d", Price = 2814 },
                    new Area() { Lower = 10000, Upper = 100000000, CategoryCode = "1e", Price = 3895 }
                }
            };

            _category_2 = new Category()
            {
                Description = "Kategori 2 (Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger)",
                Bygningstype = bygningstype_kat_2.ToList(),
                Tiltakstype = tiltakstyper_kat_1_3,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100, CategoryCode = "2a", Price = 2110 },
                    new Area() { Lower = 100, Upper = 500, CategoryCode = "2b", Price = 4221 },
                    new Area() { Lower = 500, Upper = 1000, CategoryCode = "2c", Price = 6331 },
                    new Area() { Lower = 1000, Upper = 10000, CategoryCode = "2d", Price = 8441 },
                    new Area() { Lower = 10000, Upper = 100000000, CategoryCode = "2e", Price = 11685 }
                }
            };

            _category_3 = new Category()
            {
                Description = "Kategori 3 (Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger)",
                Bygningstype = bygningstype_kat_3.ToList(),
                Tiltakstype = tiltakstyper_kat_1_3,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100, CategoryCode = "3a", Price = 4221 },
                    new Area() { Lower = 100, Upper = 500, CategoryCode = "3b", Price = 8441 },
                    new Area() { Lower = 500, Upper = 1000, CategoryCode = "3c", Price = 12662 },
                    new Area() { Lower = 1000, Upper = 10000, CategoryCode = "3d", Price = 16883 },
                    new Area() { Lower = 10000, Upper = 100000000, CategoryCode = "3e", Price = 23370 }
                }
            };

            _category_5 = new Category()
            {
                Description = "Kategori 5 (Andre enkeltsaker)",
                Bygningstype = bygningstype_kat_5.ToList(),
                Tiltakstype = tiltakstyper_kat_5,
                CategoryAreas = new List<Area>()
                {   
                    new Area() { Lower = 0, Upper = 100000000, CategoryCode = "5", Price = 1126 }
                }
            };

            _categories = new List<Category>() { _category_1, _category_2, _category_3, _category_5 };
        }


        public Fee Calculate(string tiltakstype, string bygningstype, string areal)
        {
            if (Int32.TryParse(areal, out int arealTall))
            {
                var foundCategory = _categories.FirstOrDefault(x => x.Tiltakstype.Contains(tiltakstype) && x.Bygningstype.Contains(bygningstype));
                if (foundCategory != null)
                {
                    var foundArea = foundCategory.CategoryAreas.First(x => arealTall > x.Lower && arealTall <= x.Upper);
                    return new Fee() { FeeAmount = foundArea.Price, FeeCategory = foundArea.CategoryCode };
                }
                throw new ArgumentException($"Angitt tiltakstype ('{tiltakstype}') eller bygningstype ('{bygningstype}') er ikke tillatt.");
            }
            else
            {
                throw new ArgumentException($"Areal må være et tall. '{areal}' er ikke gyldig.");
            }
        }
    }
}
