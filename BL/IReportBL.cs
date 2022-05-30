using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IReportBL
    {
        Task create_pdf(DateTime date, string type);
    }
}
