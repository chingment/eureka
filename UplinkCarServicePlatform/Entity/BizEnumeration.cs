using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.Entity
{
    /// <summary>
    /// 业务的枚举
    /// </summary>
    public partial class Enumeration
    {
        public enum PosMachineStatus
        {
            [Remark("未知")]
            Unknow = 0,
            [Remark("正常")]
            Normal = 1,
            [Remark("未激活")]
            NoActive = 2,
            [Remark("租金到期")]
            Rentdue = 3
        }

        public enum ExtendedAppType
        {
            Unknow = 0,
            CarService = 1
        }


    }
}
