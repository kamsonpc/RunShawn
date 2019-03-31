using FluentBootstrap;

namespace RunShawn.Web.Extentions
{
    public class Alert
    {
        #region Ctor

        public Alert(string text, AlertState alertState)
        {
            Text = text;
            AlertState = alertState;
        }

        public Alert(string text, AlertState alertState, string restoreLink)
        {
            Text = text;
            AlertState = alertState;
            RestoreLink = restoreLink;
        }

        #endregion Ctor

        public string RestoreLink { get; set; }
        public string Text { get; set; }
        public AlertState AlertState { get; set; }
    }
}