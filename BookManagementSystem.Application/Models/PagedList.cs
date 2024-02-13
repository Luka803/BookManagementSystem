using BookManagementSystem.Application.Features.Base;
using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Application.Models;

public class PagedList<TBaseDTO>
    where TBaseDTO : BaseDTO
{
    public BaseEntity _entity { get; set; }
    public PagedList(BaseEntity entity)
    {
        _entity = entity;
    }
    public IReadOnlyList<BaseEntity> DbItems { get; set; } = new List<BaseEntity>();
    public IReadOnlyList<BaseEntity> DbItemsFiltered => DbItems.Skip(ItemsToSkip).Take(PageSize).ToList();
    public IReadOnlyList<TBaseDTO> Items { get; set; } = new List<TBaseDTO>();
    public int PageSize => 7;
    public int PageNumber { get; set; }
    public int TotalItems => DbItems.Any() ? DbItems.Count() : 0;
    public int ItemsToSkip => (PageNumber - 1) * PageSize;
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);


}
