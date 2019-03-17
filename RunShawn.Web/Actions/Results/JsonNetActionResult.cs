using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace RunShawn.Web.Actions.Results
{
    public class JsonNetActionResult : ActionResult
    {
        public Object Data { get; private set; }

        public JsonNetActionResult(Object data)
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.Write(JsonConvert.SerializeObject(Data));
        }
    }
}