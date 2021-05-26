using System;
using System.Collections.Generic;

#nullable disable

namespace Arenda.Models
{
    public partial class PdfFile
    {
        public int Pdfid { get; set; }
        public string Pdfkda { get; set; }
        public string Pdfpda { get; set; }
        public string Pdfdda { get; set; }
        public string Pdfstore { get; set; }
        public string Pdfdoc { get; set; }
        public string Pdfpolicy { get; set; }
        public int? Pdffk { get; set; }

        public virtual Arendator PdffkNavigation { get; set; }
    }
}
