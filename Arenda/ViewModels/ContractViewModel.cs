using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arenda.ViewModels
{
    public class ContractViewModel
    {
        public int Name { get; set; }
        public IFormFile Contact1 { get; set; }
    }
}
