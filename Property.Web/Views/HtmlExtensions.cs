using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace Property.Web.Views
{
    //http://stackoverflow.com/questions/5433531/using-sections-in-editor-display-templates
    public static class HtmlExtensions
    {
        private const string ScriptPrefix = "_script_";
        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items[ScriptPrefix + Guid.NewGuid()] = template;
            return MvcHtmlString.Empty;
        }



        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            var templates = from object key in htmlHelper.ViewContext.HttpContext.Items.Keys
                            where key.ToString().StartsWith(ScriptPrefix)
                            select htmlHelper.ViewContext.HttpContext.Items[key];
            foreach (var template in templates.OfType<Func<object, HelperResult>>())
            {
                htmlHelper.ViewContext.Writer.Write(template(null));
            }
            return MvcHtmlString.Empty;
        }

        //Enum support - http://stackoverflow.com/questions/388483/how-do-you-create-a-dropdownlist-from-an-enum-in-asp-net-mvc
        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            var realModelType = modelMetadata.ModelType;
            var underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var enumType = GetNonNullableModelType(metadata);
            var values = Enum.GetValues(enumType).Cast<TEnum>();

            var items = from value in values
                        select new SelectListItem
                        {
                            Text = GetEnumDescription(value),
                            Value = value.ToString(),
                            Selected = value.Equals(metadata.Model)
                        };

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }

}