using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
    internal class CheckCanApproveModel
    {
        [JsonPropertyName("result")]
        public bool? Result { get; set; }
    }
}
