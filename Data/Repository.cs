using ATIL.FeeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATIL.FeeCalculator.Data
{
    public class Repository
    {
        private List<Category> _categories;
        private List<Tiltakstype> _tiltakstyper;
        private List<Bygningstype> _bygningstyper;
        private List<FeeCategoryDescription> _feeCategoryDescriptions;

        public Repository()
        {
            PopulateTiltakstyper();
            PopulateBygningstyper();
            PopulateKategorier();
            PopulateFeeCategoryDescriptions();
        }
        public List<Bygningstype> GetBygningstyper()
        {
            return _bygningstyper;
        }

        public List<Category> GetKategorier()
        {
            return _categories;
        }
        public List<FeeCategoryDescription> GetGebyrKategoriBeskrivelser()
        {
            return _feeCategoryDescriptions;
        }

        public List<Tiltakstype> GetTiltakstyper()
        {
            return _tiltakstyper;
        }

        private void PopulateTiltakstyper()
        {
            _tiltakstyper = new List<Tiltakstype>();
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "berekonstruksjoner", Navn = "Endring av bygg - innvendig - Bærekonstruksjoner i bygg", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "brannskille", Navn = "Endring av bygg - innvendig - Brannskille i bygg", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "bruksendring", Navn = "Bruksendring", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "driftsbygningendringover1000m2", Navn = "Endring av driftsbygning i landbruket over 1000m2 (BRA)", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "driftsbygningendringunder1000m2", Navn = "Endring av driftsbygning i landbruket under 1000m2 (BRA)", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "driftsbygningtilbyggover1000m2", Navn = "Tilbygg til driftsbygning i landbruket med samlet area over 1000 m2 (BRA)", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "driftsbygningtilbyggunder1000m2", Navn = "Tilbygg til driftsbygning i landbruket med samlet area under 1000 m2 (BRA)", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "endringbyggannet", Navn = "Endring av bygg - Annet", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "endringdrift", Navn = "Vesentlig endring av tidligere drift", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "fasade", Navn = "Endring av bygg - utvendig - Fasade", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "fundamenter", Navn = "Endring av bygg - innvendig - Fundamenter i bygg", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "hovedombygging", Navn = "Endring av bygg - hovedombygging", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "installasjonernyttanlegg", Navn = "Bygningstekniske installasjoner - Nytt anlegg", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "installasjonerreparasjon", Navn = "Bygningstekniske installasjoner - Reparasjon", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "installasjonibygg", Navn = "Bygningstekniske installasjoner - Endring - Teknisk installasjon i bygg", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "lydskille", Navn = "Endring av bygg - innvendig - Lydskille i bygg", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "nyttbyggdriftsbygningover1000m2", Navn = "Nytt bygg - Driftsbygning i landbruket med samlet areal over 1000 m2", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "nyttbyggdriftsbygningunder1000m2", Navn = "Nytt bygg - Driftsbygning i landbruk med samlet areal under 1000 m2", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "nyttbyggover70m2", Navn = "Nytt bygg - Over 70 m2 - ikke boligformål", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "nyttbyggunder70m2", Navn = "Nytt bygg - Under 70 m2 - ikke boligformål", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "pabygg", Navn = "Endring av bygg - utvendig - Påbygg", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "plasseringmidlertidig", Navn = "Plassering av midlertidige bygninger, konstruksjoner og anlegg", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "tilbyggover50m2", Navn = "Endring av bygg - utvendig - Tilbygg med samlet areal større enn 50 m2", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "tilbyggunder50m2", Navn = "Endring av bygg - utvendig - Tilbygg med samlet areal mindre enn 50 m2", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = false, Kode = "underbygg", Navn = "Endring av bygg - utvendig - Underbygg", Kategori = "1, 2, 3" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true, Kode = "utvendigeinstallasjoner", Navn = "Bygningstekniske installasjoner - Endring - Utvendige tekniske installasjoner", Kategori = "5" });
            _tiltakstyper.Add(new Tiltakstype() {TillaterZeroIAreal = true,  Kode = "vatrom", Navn = "Endring av bygg -  innvendig - Våtrom i bygg", Kategori = "5" });

        }
        private void PopulateBygningstyper()
        {
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

        private void PopulateFeeCategoryDescriptions()
        {
            _feeCategoryDescriptions = new List<FeeCategoryDescription>();
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "1", Beskrivelse = "Kategori 1a (BRA 0-100m2) Publikumsbygg og yrkesbygg uten faste arbeidsplasser" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "3", Beskrivelse = "Kategori 1b (BRA 101-500 m2) Publikumsbygg og yrkesbygg uten faste arbeidsplasser" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "4", Beskrivelse = "Kategori 1c (BRA  501-1000 m2) Publikumsbygg og yrkesbygg uten faste arbeidsplasser" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "5", Beskrivelse = "Kategori 1d (BRA 1001-10 000 m2) Publikumsbygg og yrkesbygg uten faste arbeidsplasser" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "6", Beskrivelse = "Kategori 1e (BRA over 10 000 m2) Publikumsbygg og yrkesbygg uten faste arbeidsplasser" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "7", Beskrivelse = "Kategori 2a (BRA 0-100 m2) Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "8", Beskrivelse = "Kategori 2b (BRA 101-500 m2) Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "9", Beskrivelse = "Kategori 2c (BRA 501-1000 m2) Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "10", Beskrivelse = "Kategori 2d (BRA 1001 - 10 000 m2) Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "11", Beskrivelse = "Kategori 2e (BRA over 10 000 m2) Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "12", Beskrivelse = "Kategori 3a (BRA -100 m2) Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "13", Beskrivelse = "Kategori 3b (BRA 101-500 m2) Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "14", Beskrivelse = "Kategori 3c (BRA 501-1000 m2) Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "15", Beskrivelse = "Kategori 3d (BRA 1001-10 000 m2) Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "16", Beskrivelse = "Kategori 3e (BRA over 10 000 m2)Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "17", Beskrivelse = "Kategori 4  Større byggekomplekser" });
            _feeCategoryDescriptions.Add(new FeeCategoryDescription() { Kode = "18", Beskrivelse = "Kategori 5  Andre enkeltsaker" });
        }

        private void PopulateKategorier()
        {
            Category category_1;
            Category category_2;
            Category category_3;
            Category category_5;

            List<string> tiltakstyper_kat_1_3 = new List<string>() { "hovedombygging", "nyttbyggover70m2", "nyttbyggunder70m2", "nyttbyggdriftsbygningover1000m2", "nyttbyggdriftsbygningunder1000m2", "tilbyggover50m2", "tilbyggunder50m2", "pabygg", "underbygg", "driftsbygningtilbyggover1000m2", "driftsbygningtilbyggunder1000m2", "bruksendring", "endringdrift", "plasseringmidlertidig" };
            List<string> tiltakstyper_kat_5 = new List<string>() { "brannskille", "lydskille", "fundamenter", "berekonstruksjoner", "vatrom", "driftsbygningendringover1000m2", "driftsbygningendringunder1000m2", "fasade", "endringbyggannet", "installasjonernyttanlegg", "utvendigeinstallasjoner", "installasjonibygg", "installasjonerreparasjon" };

            IEnumerable<string> bygningstype_kat_1 = new List<string>() { "223", "229", "233", "243", "245", "429", "431", "439", "523", "524", "529", "611", "654", "659", "825", "829", "830", "840" };
            IEnumerable<string> bygningstype_kat_2 = new List<string>() { "231", "232", "239", "241", "248", "249", "311", "312", "313", "319", "321", "322", "329", "330", "412", "511", "512", "519", "521", "522", "612", "613", "614", "615", "616", "619", "621", "622", "629", "641", "642", "643", "649", "651", "652", "653", "655", "661", "662", "663", "669", "671", "672", "673", "674", "675", "679", "722", "723", "732", "739", "819", "821" };
            IEnumerable<string> bygningstype_kat_3 = new List<string>() { "211", "212", "214", "216", "219", "221", "244", "323", "411", "415", "416", "419", "441", "449", "531", "532", "533", "539", "623", "719", "721", "729", "731", "822", "823", "824" };

            IEnumerable<string> bygningstype_kat_5 = bygningstype_kat_1.ToList().Concat(bygningstype_kat_2).ToList().Concat(bygningstype_kat_3).ToList();

            category_1 = new Category()
            {
                Description = "Kategori 1 (Publikumsbygg og yrkesbygg uten faste arbeidsplasser)",
                Bygningstype = bygningstype_kat_1.ToList(),
                Tiltakstype = tiltakstyper_kat_1_3,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100, CategoryCode = "1", Price = 703 },
                    new Area() { Lower = 101, Upper = 500, CategoryCode = "3", Price = 1407 },
                    new Area() { Lower = 501, Upper = 1000, CategoryCode = "4", Price = 2110 },
                    new Area() { Lower = 1001, Upper = 10000, CategoryCode = "5", Price = 2814 },
                    new Area() { Lower = 10001, Upper = 100000000, CategoryCode = "6", Price = 3895 }
                }
            };

            category_2 = new Category()
            {
                Description = "Kategori 2 (Yrkesbygg med faste arbeidsplasser, men uten maskinelle prosesser og forurensninger)",
                Bygningstype = bygningstype_kat_2.ToList(),
                Tiltakstype = tiltakstyper_kat_1_3,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100, CategoryCode = "7", Price = 2110 },
                    new Area() { Lower = 101, Upper = 500, CategoryCode = "8", Price = 4221 },
                    new Area() { Lower = 501, Upper = 1000, CategoryCode = "9", Price = 6331 },
                    new Area() { Lower = 1001, Upper = 10000, CategoryCode = "10", Price = 8441 },
                    new Area() { Lower = 10001, Upper = 100000000, CategoryCode = "11", Price = 11685 }
                }
            };

            category_3 = new Category()
            {
                Description = "Kategori 3 (Yrkesbygg med faste arbeidsplasser og med maskinelle prosesser og fare for forurensninger)",
                Bygningstype = bygningstype_kat_3.ToList(),
                Tiltakstype = tiltakstyper_kat_1_3,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100, CategoryCode = "12", Price = 4221 },
                    new Area() { Lower = 101, Upper = 500, CategoryCode = "13", Price = 8441 },
                    new Area() { Lower = 501, Upper = 1000, CategoryCode = "14", Price = 12662 },
                    new Area() { Lower = 1001, Upper = 10000, CategoryCode = "15", Price = 16883 },
                    new Area() { Lower = 10001, Upper = 100000000, CategoryCode = "16", Price = 23370 }
                }
            };

            category_5 = new Category()
            {
                Description = "Kategori 5 (Andre enkeltsaker)",
                Bygningstype = bygningstype_kat_5.ToList(),
                Tiltakstype = tiltakstyper_kat_5,
                CategoryAreas = new List<Area>()
                {
                    new Area() { Lower = 0, Upper = 100000000, CategoryCode = "18", Price = 1126 }
                }
            };

            _categories = new List<Category>() { category_1, category_2, category_3, category_5 };
        }




    }
}
