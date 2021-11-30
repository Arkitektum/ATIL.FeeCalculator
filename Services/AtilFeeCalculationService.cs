using System;
using System.Collections.Generic;
using System.Linq;
using ATIL.FeeCalculator.Models;

namespace ATIL.FeeCalculator.Services
{
    public class AtilFeeCalculationService
    {
        Category _category_1;
        Category _category_2;
        Category _category_3;
        Category _category_5;
        List<Category> _categories;
        List<Tiltakstype> _tiltakstyper;
        List<Bygningstype> _bygningstyper;

        public AtilFeeCalculationService()
        {
            List<string> tiltakstyper_kat_1_3 = new List<string>() { "202", "203", "205", "206", "400", "401", "402", "403", "406", "407", "504", "508", "910" };
            List<string> tiltakstyper_kat_5 = new List<string>() { "300", "301", "302", "303", "304", "404", "405", "409", "506", "51", "53", "54", "55" };

            IEnumerable<string> bygningstype_kat_1 = new List<string>() { "223", "229", "233", "243", "245", "429", "431", "439", "523", "524", "529", "611", "654", "659", "825", "829", "830", "840" };
            IEnumerable<string> bygningstype_kat_2 = new List<string>() { "231", "232", "239", "241", "248", "249", "311", "312", "313", "319", "321", "322", "329", "330", "412", "511", "512", "519", "521", "522", "612", "613", "614", "615", "616", "619", "621", "622", "629", "641", "642", "643", "649", "651", "652", "653", "655", "661", "662", "663", "669", "671", "672", "673", "674", "675", "679", "722", "723", "732", "739", "819", "821" };
            IEnumerable<string> bygningstype_kat_3 = new List<string>() { "211", "212", "214", "216", "219", "221", "244", "323", "411", "415", "416", "419", "441", "449", "531", "532", "533", "539", "623", "719", "721", "729", "731", "822", "823", "824" };

            IEnumerable<string> bygningstype_kat_5 = bygningstype_kat_1.ToList().Concat(bygningstype_kat_2).ToList().Concat(bygningstype_kat_3).ToList();

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

            _tiltakstyper = new List<Tiltakstype>();
            _tiltakstyper.Add(new Tiltakstype() { Kode = "202", Navn = "Nytt bygg - ikke boligformål over 70 m²", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "nyttbyggover70m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "203", Navn = "Nytt bygg - ikke boligformål under 70 m²", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "nyttbyggunder70m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "205", Navn = "Nytt bygg - driftsbygning i landbruket med samlet areal over 1000 m2", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "nyttbyggdriftsbygningover1000m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "206", Navn = "Nytt bygg - driftsbygning i landbruk med samlet areal under 1000 m2", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "nyttbyggdriftsbygningunder1000m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "300", Navn = "Endring innvendig i bygg - brannskille i bygg", Kategori = "5", TiltakstypekodeGeonorge = "brannskille" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "301", Navn = "Endring innvendig i bygg - lydskille i bygg", Kategori = "5", TiltakstypekodeGeonorge = "lydskille" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "302", Navn = "Endring innvendig i bygg - fundamenter i bygg", Kategori = "5", TiltakstypekodeGeonorge = "fundamenter" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "303", Navn = "Endring innvendig i bygg - bærekonstruksjoner i bygg", Kategori = "5", TiltakstypekodeGeonorge = "berekonstruksjoner" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "304", Navn = "Endring innvendig i bygg - våtrom i bygg", Kategori = "5", TiltakstypekodeGeonorge = "vatrom" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "400", Navn = "Endring av bygg - utvendig tilbygg større enn 50 m²", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "tilbyggover50m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "401", Navn = "Endring av bygg - utvendig tilbygg mindre enn 50 m²", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "tilbyggunder50m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "402", Navn = "Endring av bygg - påbygg", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "pabygg" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "403", Navn = "Endring av bygg - underbygg", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "underbygg" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "404", Navn = "Endring av bygg - endring av driftsbygning i landbruket over 1000m2 (BRA)", Kategori = "5", TiltakstypekodeGeonorge = "driftsbygningendringover1000m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "405", Navn = "Endring av bygg - endring av driftsbygning i landbruket under 1000m2 (BRA)", Kategori = "5", TiltakstypekodeGeonorge = "driftsbygningendringunder1000m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "406", Navn = "Endring av bygg - tilbygg til driftsbygning i landbruket med samlet area over 1000 m2 (BRA)", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "driftsbygningtilbyggover1000m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "407", Navn = "Endring av bygg - tilbygg til driftsbygning i landbruket med samlet area under 1000 m2 (BRA)", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "driftsbygningtilbyggunder1000m2" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "409", Navn = "Endring av bygg - fasade", Kategori = "5", TiltakstypekodeGeonorge = "fasade" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "504", Navn = "Endring av bruk - bruksendring", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "bruksendring" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "506", Navn = "Endring av bygg - annet", Kategori = "5", TiltakstypekodeGeonorge = "endringbyggannet" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "508", Navn = "Endring av bruk - vesentlig endring av tidligere drift", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "endringdrift" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "51",  Navn = "Byggtekniske installasjoner - nyanlegg", Kategori = "5", TiltakstypekodeGeonorge = "installasjonernyttanlegg" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "53",  Navn = "Byggtekniske installasjoner - utvendige tekniske installasjoner", Kategori = "5", TiltakstypekodeGeonorge = "utvendigeinstallasjoner" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "54",  Navn = "Byggtekniske installasjoner - teknisk installasjon i bygg", Kategori = "5", TiltakstypekodeGeonorge = "installasjonibygg" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "55",  Navn = "Byggtekniske installasjoner - reparasjon", Kategori = "5", TiltakstypekodeGeonorge = "installasjonerreparasjon" });
            _tiltakstyper.Add(new Tiltakstype() { Kode = "910", Navn = "Plassering av midlertidige bygninger, konstruksjoner og anlegg", Kategori = "1, 2, 3", TiltakstypekodeGeonorge = "plasseringmidlertidig" });

            _bygningstyper = new List<Bygningstype>();
            _bygningstyper.Add(new Bygningstype() { Kode = "211", Navn = "Fabrikkbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "212", Navn = "Verkstedbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "214", Navn = "Bygning for renseanlegg", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "216", Navn = "Bygning for vannforsyning, bl.a. pumpestasjon", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "219", Navn = "Annen industribygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "221", Navn = "Kraftstasjon (>15 000 kVA)", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "223", Navn = "Transformatorstasjon (>10 000 kVA)", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "229", Navn = "Annen energiforsyningsbygning", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "231", Navn = "Lagerhall", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "232", Navn = "Kjøle- og fryselager", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "233", Navn = "Silobygning", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "239", Navn = "Annen lagerbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "241", Navn = "Hus for dyr, fôrlager, strølager, frukt- og grønnsakslager, landbrukssilo, høy-/korntørke", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "243", Navn = "Veksthus", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "244", Navn = "Driftsbygning for fiske og fangst, inkl. oppdrettsanlegg", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "245", Navn = "Naust/redskapshus for fiske", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "248", Navn = "Annen fiskeri- og fangstbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "249", Navn = "Annen landbruksbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "311", Navn = "Kontor- og administrasjonsbygning, rådhus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "312", Navn = "Bankbygning, posthus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "313", Navn = "Mediebygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "319", Navn = "Annen kontorbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "321", Navn = "Kjøpesenter, varehus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "322", Navn = "Butikkbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "323", Navn = "Bensinstasjon", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "329", Navn = "Annen forretningsbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "330", Navn = "Messe- og kongressbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "411", Navn = "Ekspedisjonsbygning, flyterminal, kontrolltårn", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "412", Navn = "Jernbane- og T-banestasjon", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "415", Navn = "Godsterminal", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "416", Navn = "Postterminal", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "419", Navn = "Annen ekspedisjons- og terminalbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "429", Navn = "Telekommunikasjonsbygning", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "431", Navn = "Parkeringshus", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "439", Navn = "Annen garasje- hangarbygning", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "441", Navn = "Trafikktilsynsbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "449", Navn = "Annen veg- og trafikktilsynsbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "511", Navn = "Hotellbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "512", Navn = "Motellbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "519", Navn = "Annen hotellbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "521", Navn = "Hospits, pensjonat", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "522", Navn = "Vandrerhjem, feriehjem/-koloni, turisthytte", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "523", Navn = "Appartement", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "524", Navn = "Campinghytte/utleiehytte", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "529", Navn = "Annen bygning for overnatting", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "531", Navn = "Restaurantbygning, kafébygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "532", Navn = "Sentralkjøkken, kantinebygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "533", Navn = "Gatekjøkken, kioskbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "539", Navn = "Annen restaurantbygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "611", Navn = "Lekepark", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "612", Navn = "Barnehage", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "613", Navn = "Barneskole", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "614", Navn = "Ungdomsskole", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "615", Navn = "Kombinert barne- og ungdomsskole", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "616", Navn = "Videregående skole", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "619", Navn = "Annen skolebygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "621", Navn = "Universitets- og høgskolebygning med integrerte funksjoner, auditorium, lesesal o.a.", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "622", Navn = "Spesialbygning for universitet og høgskole", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "623", Navn = "Laboratoriebygning", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "629", Navn = "Annen universitets-, høgskole- og forskningsbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "641", Navn = "Museum, kunstgalleri", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "642", Navn = "Bibliotek, mediatek", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "643", Navn = "Zoologisk og botanisk hage", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "649", Navn = "Annen museums- og bibliotekbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "651", Navn = "Idrettshall", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "652", Navn = "Ishall", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "653", Navn = "Svømmehall", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "654", Navn = "Tribune og idrettsgarderobe", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "655", Navn = "Helsestudio", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "659", Navn = "Annen idrettsbygning", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "661", Navn = "Kinobygning, teaterbygning, opera/konserthus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "662", Navn = "Samfunnshus, grendehus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "663", Navn = "Diskotek", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "669", Navn = "Annet kulturhus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "671", Navn = "Kirke, kapell", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "672", Navn = "Bedehus, menighetshus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "673", Navn = "Krematorium, gravkapell, bårehus", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "674", Navn = "Synagoge, moské", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "675", Navn = "Kloster", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "679", Navn = "Annen bygning for religiøse aktiviteter", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "719", Navn = "Sykehus", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "721", Navn = "Sykehjem", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "722", Navn = "Bo- og behandlingssenter, aldershjem", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "723", Navn = "Rehabiliteringsinstitusjon, kurbad", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "729", Navn = "Annet sykehjem", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "731", Navn = "Klinikk, legekontor/-senter/-vakt", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "732", Navn = "Helse- og sosialsenter, helsestasjon", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "739", Navn = "Annen primærhelsebygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "819", Navn = "Fengselsbygning", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "821", Navn = "Politistasjon", Kategori = "2" });
            _bygningstyper.Add(new Bygningstype() { Kode = "822", Navn = "Brannstasjon, ambulansestasjon", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "823", Navn = "Fyrstasjon, losstasjon", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "824", Navn = "Stasjon for radarovervåkning av fly- og/eller skipstrafikk", Kategori = "3" });
            _bygningstyper.Add(new Bygningstype() { Kode = "825", Navn = "Tilfluktsrom/bunker", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "829", Navn = "Annen beredskapsbygning", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "830", Navn = "Monument", Kategori = "1" });
            _bygningstyper.Add(new Bygningstype() { Kode = "840", Navn = "Offentlig toalett", Kategori = "1" });
        }

        public List<Tiltakstype> GetTiltakstyper()
        {
            return _tiltakstyper;
        }

        public List<Bygningstype> GetBygningstyper()
        {
            return _bygningstyper;
        }

        public CalculationResult Calculate(string tiltakstype, string bygningstype, string areal)
        {
            if (Int32.TryParse(areal, out int arealTall))
            {
                if (arealTall <= 0)
                {
                    throw new ArgumentException($"Areal må være et heltall større enn 0. '{areal}' er ikke gyldig.");
                }

                var foundCategory = _categories.FirstOrDefault(x => x.Tiltakstype.Contains(tiltakstype) && x.Bygningstype.Contains(bygningstype));
                if (foundCategory != null)
                {
                    var foundArea = foundCategory.CategoryAreas.First(x => arealTall > x.Lower && arealTall <= x.Upper);
                    var res = new CalculationResult()
                    {
                        Area = areal,
                        Bygningstype = _bygningstyper.FirstOrDefault(x => x.Kode.Equals(bygningstype)),
                        Tiltakstype = _tiltakstyper.FirstOrDefault(x => x.Kode.Equals(tiltakstype)),
                        Description = foundCategory.Description,
                        Fee = new Fee() { FeeAmount = foundArea.Price, FeeCategory = foundArea.CategoryCode }
                    };


                    return res;
                }
                throw new ArgumentException($"Angitt tiltakstype ('{tiltakstype}') eller bygningstype ('{bygningstype}') er ikke tillatt.");
            }
            else
            {
                throw new ArgumentException($"Areal må være et heltall. '{areal}' er ikke gyldig.");
            }
        }
    }
}
