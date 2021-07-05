using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb.Models
{
    public static class Paginator
    {
        public static List<T> GetPage<T>(this List<T> list, int page, int pageSize)
        {
            try
            {
                list = list.Skip(page * pageSize).Take(pageSize).ToList();
                return list;
            }
            catch (Exception)
            {
                list = list.TakeLast(pageSize).ToList();
                return list;
            }
        }
    }
}
