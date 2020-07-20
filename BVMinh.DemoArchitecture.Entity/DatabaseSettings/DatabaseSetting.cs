using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.Entity.DatabaseSetting
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
