using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;

namespace OptionGroupsTagHelper.ViewModels.Home
{
    public class CustomerViewModel
    {
      public string Vehicle { get; set; }

      public List<SelectListItem> Vehicles { get; private set; }

      public CustomerViewModel()
      {
          var germanGroup = new SelectListGroup {Name = "German Cars"};
          var swedishGroup = new SelectListGroup { Name = "Swedish Cars" };

          Vehicles = new List<SelectListItem>
          {
              new SelectListItem
              {
                  Value = "audi",
                  Text = "Audi",
                  Group = germanGroup
              },
              new SelectListItem
              {
                  Value = "mercedes",
                  Text = "Mercedes",
                  Group = germanGroup
              },
              new SelectListItem
              {
                  Value = "saab",
                  Text = "Saab",
                  Group = swedishGroup
              },
              new SelectListItem
              {
                  Value = "volvo",
                  Text = "Volvo",
                  Group = swedishGroup
              }
          };
      }
    }
}
