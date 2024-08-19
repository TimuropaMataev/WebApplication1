using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApplication1.Models;

namespace WebApplication1.TagHelpers;

public class SortHeaderTagHelper : TagHelper
{
    public SortState Property { get; set; }
    public SortState Current { get; set; }
    public string? Action { get; set; }
    public bool Up { get; set; }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = null!;

    private readonly IUrlHelperFactory _urlHelperFactory;

    public SortHeaderTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        IUrlHelper helper = _urlHelperFactory.GetUrlHelper(ViewContext);

        output.TagName = "a";
        string? url = helper.Action(Action, new { sortOrd = Property });

        output.Attributes.SetAttribute("href", url);

        if (Current == Property)
        {
            TagBuilder tag = new TagBuilder("i");
            tag.AddCssClass("glyphicon");

            if (Up is true)
                tag.AddCssClass("glyphicon-chevron-up");
            else
                tag.AddCssClass("glyphicon-chevron-down");

            output.PreContent.AppendHtml(tag);
        }
    }
}