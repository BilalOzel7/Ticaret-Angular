using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticaret.WebAPI.Helpers
{
    public class Pagination<T> where T:class
    {
        public Pagination(int pageIndex,int pageSize,int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSixe = pageSize;
            Count = count;
            Data = data;
        }
        public int PageIndex { get; set; }
        public int PageSixe { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
