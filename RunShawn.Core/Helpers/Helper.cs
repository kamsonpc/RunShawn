namespace RunShawn.Core.Helpers
{
    public static class Helper
    {
        public static int Strong(int number)
        {
            if (number > 1)
            {
                return number * Strong(number - 1);
            }
            return 1;
        }
    }
}