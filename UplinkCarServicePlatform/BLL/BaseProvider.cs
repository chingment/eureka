using Lumos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.BLL
{
    public abstract class BaseProvider
    {
        private LumosDbContext _CurrentDb;

        public BaseProvider()
        {
            _CurrentDb = new LumosDbContext();
        }

        protected LumosDbContext CurrentDb
        {
            get
            {
                return _CurrentDb;
            }
        }

        public object CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();
            Object p = t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    object value = pi.GetValue(o, null);
                    pi.SetValue(p, value, null);
                }
            }
            return p;
        }

    }
}
