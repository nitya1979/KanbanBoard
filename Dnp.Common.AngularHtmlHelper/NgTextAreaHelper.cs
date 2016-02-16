using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dnp.Common.AngularHtmlHelper
{
    public static class NgTextAreaHelper
    {

        public static MvcHtmlString NgTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string cssClass)
        {
            MemberInfo member = ((MemberExpression)expression.Body).Member;

            var tagBuilder = new TagBuilder("textarea");

            tagBuilder.AddCssClass(cssClass);

            List<TagBuilder> validationSpans = new List<TagBuilder>();

            foreach (CustomAttributeData cs in member.CustomAttributes)
            {
                if (cs.AttributeType == typeof(RequiredAttribute))
                {
                    tagBuilder.MergeAttribute("Required", string.Empty);

                    validationSpans.Add(NgHtmlHelper.GetRequiredSpan(cs, member));
                }
                else if (cs.AttributeType == typeof(MaxLengthAttribute))
                {
                    tagBuilder.MergeAttribute("maxlength", cs.ConstructorArguments[0].Value.ToString());
                }
            }

            tagBuilder.MergeAttribute("ng-model", member.Name);

            string finalHtml = tagBuilder.ToString(TagRenderMode.Normal);

            foreach (TagBuilder span in validationSpans)
            {
                finalHtml += span.ToString(TagRenderMode.Normal);
            }

            return MvcHtmlString.Create(finalHtml);

        }
    }
}
