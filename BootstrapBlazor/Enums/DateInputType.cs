using System.ComponentModel;

namespace BootstrapBlazor
{
    public enum DateInputType
    {
        [Description("date")]
        Date,
        [Description("time")]
        Time,
        [Description("datetime-local")]
        DateTime,
        [Description("month")]
        Month
    }
}
