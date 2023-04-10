using System.ComponentModel;

namespace MyPrecious.AT.Framework.Models.Enums
{
    public enum EnvironmentType
    {
        [Description("DEV Environment")]
        Qa,
        [Description("Staging Environment")]
        Stg
    }
}
