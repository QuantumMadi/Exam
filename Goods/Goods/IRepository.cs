using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    public interface IRepository<T>
    {
        void AddItem(T item);
        List<T> GetItemList();
    }
}
