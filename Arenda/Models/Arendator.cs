using System;
using System.Collections.Generic;

#nullable disable

namespace Arenda.Models
{
    public partial class Arendator
    {
        public Arendator()
        {
            Comments = new HashSet<Comment>();
            Contacts = new HashSet<Contact>();
            PdfFiles = new HashSet<PdfFile>();
            WordFiles = new HashSet<WordFile>();
        }

        public int ArendatorId { get; set; }
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
        public string Post { get; set; }
        public string Email { get; set; }
        public string Sale { get; set; }
        public string Advertising { get; set; }
        public string SpecCondition { get; set; }
        public string ParkingCondition { get; set; }
        public byte[] Logo { get; set; }
        public string PayCondition { get; set; }
        public string ProductCategory { get; set; }
        public string RoomNumber { get; set; }
        public string Area { get; set; }
        public string ExplPay { get; set; }
        public string MarkPay { get; set; }
        public string CommunalPay { get; set; }
        public string Curs { get; set; }
        public string IndexSize { get; set; }
        public string AvansPay { get; set; }
        public string Deposit { get; set; }
        public DateTime? DateOpen { get; set; }
        public string PayStart { get; set; }
        public string RepairTime { get; set; }
        public string ElectricPower { get; set; }
        public string TermArenda { get; set; }
        public string ContactPerson { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<PdfFile> PdfFiles { get; set; }
        public virtual ICollection<WordFile> WordFiles { get; set; }
    }
}
