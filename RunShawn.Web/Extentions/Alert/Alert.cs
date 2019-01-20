using FluentBootstrap;

namespace RunShawn.Web.Extentions
{
    public class Alert
    {
        #region Ctor
        public Alert(string text, AlertState alertState)
        {
            this.Text = text;
            this.AlertState = alertState;
        }

        public Alert(string text, AlertState alertState, string restoreLink)
        {
            this.Text = text;
            this.AlertState = alertState;
            this.RestoreLink = restoreLink;
        }
        #endregion

        public string RestoreLink { get; set; }
        public string Text { get; set; }
        public AlertState AlertState { get; set; }
    }
}