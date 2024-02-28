using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BookManagementSystem.UI.Components;

public partial class Table<TItem>
{
    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = null!;

    [Parameter]
    public string[]? Routes { get; set; }

    private void Details(TItem item)
    {
        var itemId = GetItemId(item);
        navigationManager.NavigateTo($"/{Routes![0]}/{itemId}");
    }

    private void Delete(TItem item)
    {
        var itemId = GetItemId(item);
    }

    private void Edit(TItem item)
    {
        var itemId = GetItemId(item);
        navigationManager.NavigateTo($"/{Routes![1]}/{itemId}");
    }

    private object? GetItemId(TItem? item)
    {
        return item?.GetType().GetProperty("ID")?.GetValue(item, null);
    }

    private string GetDisplayName(PropertyInfo propertyInfo)
    {
        var displayAttribute = propertyInfo.GetCustomAttribute<DisplayAttribute>();
        return displayAttribute?.Name ?? propertyInfo.Name;
    }


}
