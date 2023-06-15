using System;
using System.Collections.Generic;
using System.Text;

using Ucar.Common;

namespace Ucar.DAL
{
    public class BaseDM
    {
        protected readonly string connectionString = ConfigHelper.GetConnectionString("Ucar");
    }
}
