using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util.Model
{
    public class PageResult<T>
    {
        public PageResult(List<T> result, long totalResult)
        {
            Result = result;
            TotalResult = totalResult;
        }

        public List<T> Result { get; set; }

        public long TotalResult { get; set; }
    }
}
