using System;
using System.Collections.Generic;
using System.Text;

using KangHui.Common;

namespace KangHui.DAL
{
    public class BaseDM
    {
        protected readonly string connectionString = ConfigHelper.GetConnectionString("Ucar");
    }
}
