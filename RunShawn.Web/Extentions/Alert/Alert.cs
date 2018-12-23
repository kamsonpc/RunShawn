using FluentBootstrap;

namespace RunShawn.Web.Extentions
{
    public class Alert
    {

        public Alert(string text, AlertState alertState)
        {
            this.Text = text;
            this.AlertState = alertState;
        }
        public string Text { get; set; }
        public AlertState AlertState { get; set; }
    }
}