using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTransition.Forms.Infrastructure.Utilities
{
    public static class RazorUtility
    {
        public static IList<SelectListItem> ToSelectList<TItem, TValue>
            (
            this IEnumerable<TItem> items,
            Func<TItem, string> itemName,
            Func<TItem, TValue> itemId
            )
        {
            var selectList = (from item in items
                             select new SelectListItem
                             (itemName(item), itemId(item).ToString())).ToList();
            return selectList;
        }
    }
}
