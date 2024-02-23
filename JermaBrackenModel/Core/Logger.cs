namespace JermaBrackenModel.Core
{
    internal static class Logger
    {
        public static void LogInfo(object message)
        {
            ModBase.logger.LogInfo(message);
        }

        public static void LogWarning(object message)
        {
            ModBase.logger.LogWarning(message);
        }

        public static void LogError(object message)
        {
            ModBase.logger.LogError(message);
        }
    }
}
