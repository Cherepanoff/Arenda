using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arenda.ViewModels
{
    public class ArendatorModel
    {
        public string ArendatorName { get; set; }
        public int? ArendatorFloor { get; set; }
        public string ArendatorType { get; set; }
        public string LegalPerson { get; set; }
        public string GeneralDirector { get; set; }
        public string NumberContract { get; set; }
        public DateTime? DateContract { get; set; }
        public string AdressLegal { get; set; }
        public string AdressFact { get; set; }
        public DateTime? AllowAct { get; set; }
        public DateTime? StartAct { get; set; }
        public string Commercial { get; set; }
        public string Contact { get; set; }
        public string Object { get; set; }
        public string PastArenda { get; set; }
        public string Curator { get; set; }
        public string Rate { get; set; }
        public string Marketing { get; set; }
        public string Communal { get; set; }
        public string Contact1 { get; set; }
        public string Post { get; set; }
        public string Email { get; set; }
        public string Sale { get; set; }
        public string Advertising { get; set; }
        public string SpecCondition { get; set; }
        public string ParkingCondition { get; set; }
        public byte[] Logo { get; set; }
        public string PayCondition { get; set; }
    }
}
