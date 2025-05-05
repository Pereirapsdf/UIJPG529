using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DallJPG529.Contratos529
{
    internal interface IgenricaJPG<T>
    {
        void Add(T obj);

        void Update(T obj);
        void Delete(T obj);
        void GetAll(T obj);
    }
}
