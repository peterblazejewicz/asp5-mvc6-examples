using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace ProgressBarComponent.TagHelpers
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [TargetElement("div", Attributes = ProgressValueAttributeName)]
    [TargetElement("div", Attributes = ProgressLabelVisibleAttributeName)]
    [TargetElement("div", Attributes = ProgressMinAttributeName)]
    [TargetElement("div", Attributes = ProgressMaxAttributeName)]
    [TargetElement("div", Attributes = ProgressStyleAttributeName)]
    [TargetElement("div", Attributes = ProgressActiveAttributeName)]
    [TargetElement("div", Attributes = ProgressStripedAttributeName)]
    public class ProgressBarTagHelper : TagHelper
    {

        private const string ProgressActiveAttributeName = "bs-progress-active";
        private const string ProgressLabelVisibleAttributeName = "bs-progress-label-visible";
        private const string ProgressMaxAttributeName = "bs-progress-max";
        private const string ProgressMinAttributeName = "bs-progress-min";
        private const string ProgressStripedAttributeName = "bs-progress-striped";
        private const string ProgressStyleAttributeName = "bs-progress-style";
        private const string ProgressValueAttributeName = "bs-progress-value";

        [HtmlAttributeName(ProgressActiveAttributeName)]
        public bool ProgressActive { get; set; } = false;
        [HtmlAttributeName(ProgressLabelVisibleAttributeName)]
        public bool ProgressLabelVisible { get; set; } = true;
        [HtmlAttributeName(ProgressMaxAttributeName)]
        public int ProgressMax { get; set; } = 100;
        [HtmlAttributeName(ProgressMinAttributeName)]
        public int ProgressMin { get; set; } = 0;
        [HtmlAttributeName(ProgressStripedAttributeName)]
        public bool ProgressStriped { get; set; } = false;
        [HtmlAttributeName(ProgressStyleAttributeName)]
        public string ProgressStyle { get; set; }
        [HtmlAttributeName(ProgressValueAttributeName)]
        public int ProgressValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ProgressMin >= ProgressMax)
            {
                throw new ArgumentException($"{ProgressMinAttributeName} must be less than {ProgressMaxAttributeName}");
            }
            if (ProgressValue > ProgressMax || ProgressValue < ProgressMin)
            {
                throw new ArgumentOutOfRangeException($"{ProgressValueAttributeName} must be within the range of {ProgressMinAttributeName} and {ProgressMaxAttributeName}");
            }
            var progressTotal = ProgressMax - ProgressMin;
            var progressPercentage = Math.Round(((decimal)(ProgressValue - ProgressMin) / (decimal)progressTotal) * 100, 2);
            var sb = new StringBuilder("progress-bar");
            if (!string.IsNullOrEmpty(ProgressStyle))
            {
                sb.Append($" progress-bar-{ProgressStyle}");
            }
            if (ProgressActive) ProgressStriped = true;
            if (ProgressStriped) sb.Append(" progress-bar-striped");
            if (ProgressActive) sb.Append(" active");
            var progressClassValue = sb.ToString();
            string labelMarkup;
            if (ProgressLabelVisible)
            {
                labelMarkup = $"{progressPercentage}% Complete";
            }
            else
            {
                labelMarkup = $@"<span class=""sr-only"">{progressPercentage}% Complete</span>";
            }
            // multiline string interpolation
            string markup = $@"<div class=""{progressClassValue}"" role=""progressbar"" aria-valuenow=""{ProgressValue}"" aria-valuemin=""{ProgressMin}"" aria-valuemax=""{ProgressMax}"" style=""width: {progressPercentage}%;"">
                {labelMarkup}
              </div>";
            output.Content.Append(markup);
            // if container has custom class envisioned pass it along
            string classValue;
            if (context.AllAttributes.ContainsName("class"))
            {
                IReadOnlyTagHelperAttribute attribute;
                context.AllAttributes.TryGetAttribute("class", out attribute);
                classValue = $"{attribute?.Value} progress";
            }
            else
            {
                classValue = "progress";
            }
            output.Attributes["class"] = classValue;
            base.Process(context, output);
        }
    }
}
