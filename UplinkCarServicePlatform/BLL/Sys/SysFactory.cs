using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.BLL
{
    public class SysFactory : BaseFactory
    {
        public static SysAppKeySecretProvider AppKeySecret
        {
            get
            {
                return new SysAppKeySecretProvider();
            }
        }
    }
}
