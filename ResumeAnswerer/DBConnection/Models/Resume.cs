using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection.Models
{
    public class ResumesModel
    {
        public long CandidatesResumesNo { get; set; }

        public bool IsArchive { get; set; }

        public DateTime Date { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }
    }
}
