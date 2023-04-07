using MyPrecious.AT.Framework.Configuration.Model;
using MyPrecious.AT.Framework.Configuration;

namespace MyPrecious.AT.Framework.Logger
{
    public static class LoggerSettings
    {
        public static LoggerInfo LoggerInfo => ConfigurationHelper.GetBindConfiguration<LoggerInfo>(section: "LogConf") ?? new LoggerInfo();
    }
}