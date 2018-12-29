using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Summernote
{
    public static class SummerNoteHelper
    {
        public static MvcHtmlString SummerNote<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> fieldExpression)
        {
            ModelMetadata fieldmetadata = ModelMetadata.FromLambdaExpression(fieldExpression, htmlHelper.ViewData);

            var fieldName = ExpressionHelper.GetExpressionText(fieldExpression);

            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);

            var value = fieldmetadata.Model;

            var tag = new TagBuilder("textarea");
            tag.Attributes.Add("name", fullName);
            if (value != null)
                tag.InnerHtml = value.ToString();

            tag.AddCssClass("wygwsig");


            if (!string.IsNullOrEmpty(fieldName))
                tag.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(fieldName));

            var html = tag.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(html);
        }
    }
}
