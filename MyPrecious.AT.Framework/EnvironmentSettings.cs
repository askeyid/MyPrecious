using System;
using MyPrecious.AT.Framework.Helpers;
using MyPrecious.AT.Framework.Models;

namespace MyPrecious.AT.Framework
{
    public static class EnvironmentSettings
    {
        public static EnvironmentInfo EnvironmentInfo => ConfigurationHelper.GetBindConfiguration<EnvironmentInfo>(section: "EnvironmentConf") ?? new EnvironmentInfo();
    }
}
