using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.States
{
   public class ActionOnDetailState
    {
        public const string DeclinePass = "DeclinePass";
        public const string ApprovePass = "ApprovePass";
        public string? ActionName { get; set; }
    }
}
