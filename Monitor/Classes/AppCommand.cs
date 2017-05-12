namespace Monitor.Classes
{
    /// <summary>
    /// 各项控制命令
    /// </summary>
    public enum AppCommand
    {
        None = 0,
        StartMonitor = 1,//打开监视
        StopMonitor = 2,//停止监视
        CloseSystem = 3,//关闭系统
        Status = 4, //查看详情
        LoadAlarm = 5, //加载报警信息
        SeeDetails = 6

    }
}