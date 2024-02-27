using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Components;

public partial class GenericTable<TItem>
{
    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = null!;

    private void Details(TItem item)
    {
        var itemId = GetItemId(item);
    }

    private void Delete(TItem item)
    {
        var itemId = GetItemId(item);
    }

    private void Edit(TItem item)
    {
        var itemId = GetItemId(item);
    }

    private object? GetItemId(TItem? item)
    {
        return item?.GetType().GetProperty("Id")?.GetValue(item, null);
    }


}
