namespace WebApplication1.Models;

public class IndexViewModel
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
    public SortViewModel Sort { get; set; } = new SortViewModel(SortState.NameAsc);
}