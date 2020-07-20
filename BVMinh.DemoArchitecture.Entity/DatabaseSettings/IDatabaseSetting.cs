using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.Entity.DatabaseSetting
{
    public interface IDatabaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
