using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Linq
{
    public static class LinqExtentions
    {
        public static List<SelectListItem> ToSelectList<T>(this List<T> Items, Func<T, string> getKey, Func<T, string> getValue, string selectedValue = "", string noSelection = "", bool search = false)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            if (search)
            {
                items.Add(new SelectListItem
                {
                    Selected = true,
                    Value = "-1",
                    Text = string.Format("-- {0} --", noSelection)
                });
            }

            foreach (var item in Items)
            {
                string selectedOption = selectedValue;
                items.Add(new SelectListItem
                {
                    Text = getKey(item),
                    Value = getValue(item),
                    Selected = selectedOption == getValue(item)
                });
            }

            return items
                .OrderBy(l => l.Text)
                .ToList();
        }
    }
}