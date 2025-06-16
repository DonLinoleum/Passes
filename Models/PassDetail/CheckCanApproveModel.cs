using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.PassDetail
{
    public class CheckCanApproveModel
    {
        [JsonPropertyName("data")]
        public CanApproveDataMovel? Data { get; set; }
    }

    public class CanApproveDataMovel
    {
        [JsonPropertyName("showApproveButton")]
        public bool ShowApproveButton { get; set; }

        [JsonPropertyName("idsOfChildrenPassesCanApprove")]
        public List<string>? IdsOfChildrenPassesCanApprove { get; set; }
    }
}
