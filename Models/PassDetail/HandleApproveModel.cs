using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
    class HandleApproveModel
    {
        public string? id { get; set; }
        public string? action { get; set; }
        public string? comment { get; set; }
        public List<string>? child_ids { get; set; }
    }
}
