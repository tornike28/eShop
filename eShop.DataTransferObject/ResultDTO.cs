using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class ResultDTO
    {
        public bool IsError { get; set; }

        public List<string> ErrorMessages { get; set; }

        public string VerificationURL { get; set; }
        public string Email { get; set; }
    }
}
