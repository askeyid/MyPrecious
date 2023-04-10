using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Framework.Helpers;

namespace MyPrecious.AT.Framework.Logger
{
    public static class LoggerSettings
    {
        public static LoggerInfo LoggerInfo => ConfigurationHelper.GetBindConfiguration<LoggerInfo>(section: "LogConf") ?? new LoggerInfo();
    }
}