using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DallJPG529.Servicios529
{
    public class ProviderJPG
    {
        private static Mozo529 _instancia;
        private static readonly object lockObj = new object();
        public static Mozo529 Instancia
        {
            get
            {
                lock (lockObj)
                {
                    if (_instancia == null)
                        _instancia = new Mozo529();

                    return _instancia;
                }
            }
        }

    }
}
