using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.DAL.DAO
{
    interface IDAO<T,K> where T:class where K : class //T ve K'nın class olduğunu tanımlamak için
    {
        List<K> Select();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(int ID);
    }
}
