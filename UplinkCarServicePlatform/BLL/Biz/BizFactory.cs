using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.BLL
{
    public class BizFactory: BaseFactory
    {
        public static AppSettingsProvider AppSettings
        {
            get
            {
                return new AppSettingsProvider();
            }
        }
    }
}
