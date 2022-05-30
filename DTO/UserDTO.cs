using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserDTO
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        //public int IdMarriageStatus { get; set; }
        public string MarriageStatus { get; set; }
        //public int IdWorkingStatus { get; set; }
        public string WorkingStatus { get; set; }
        public bool PermanentWorker { get; set; }
        public string Occupation { get; set; }
        public byte[] Fingerprint { get; set; }
    }
}
