using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("Created")]
        Created = 1,
        [Description("InProgress")]
        InProgress = 2,
        [Description("Established")]
        Established = 3
    }
}
