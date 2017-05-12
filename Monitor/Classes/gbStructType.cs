using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Monitor.Classes
{
    public struct DbAccessInfo
    {
        public string DbName;
        public string UserName;
        public string Password;
    }

    public struct AlarmInfoSum
    {
        public int Alarmnum;
        public DateTime date;
    }
}
