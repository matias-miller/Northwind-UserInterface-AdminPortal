using Infrastructure.Models;
using Infrastructure;

public class CategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Category CreateCategory(string name, string description, byte[] picture)
    {
        var category = new Category
        {
            CategoryName = name,
            Description = description,
            Picture = picture
        };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.Find(id);
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    public Category UpdateCategory(int id, string name, string description, byte[] picture)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            category.CategoryName = name;
            category.Description = description;
            category.Picture = picture;
            _context.SaveChanges();
        }
        return category;
    }

    public bool DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}