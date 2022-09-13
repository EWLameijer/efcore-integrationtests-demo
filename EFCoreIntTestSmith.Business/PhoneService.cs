using Microsoft.EntityFrameworkCore;

namespace EFCoreIntTestSmith.Business;

public class PhoneService
{
    private readonly DataContext _context;

    public PhoneService(DataContext context)
    {
        _context = context;
    }

    public Phone? Get(int id) =>
        _context.Phones.Include(p => p.Brand).SingleOrDefault(p => p.Id == id);
}