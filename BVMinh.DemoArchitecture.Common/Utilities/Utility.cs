using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.Common.Utilities
{
    public class Utility
    {
        public static string GetEntityName<T>()
        {
            return Activator.CreateInstance<T>().GetType().Name;
        }
    }
}
