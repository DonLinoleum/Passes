using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.Helpers
{
   public class CreateActionUrl
    {
        public static string CreateActionUrlOnDetail(string? ActionName)
        {
            return $"/api/{ActionName}";
        }
    }
}
