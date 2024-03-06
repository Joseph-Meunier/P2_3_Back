using API.DbContext;
using API.Models;
using API.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class ProfessionalEventRepository : IProfessionalEventRepository
{
    private readonly AppDbContext _context;
    
    public ProfessionalEventRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task Add(ProfessionalEvent professionalEvent)
    {
        _context.ProfessionalEvents.Add(professionalEvent);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int professionalEventId)
    {
        var professionalEvent = await Find(professionalEventId);
        _context.ProfessionalEvents.Remove(professionalEvent);
        await _context.SaveChangesAsync();
    }

    public async Task Update(ProfessionalEvent professionalEvent)
    {
        _context.ProfessionalEvents.Update(professionalEvent);
        await _context.SaveChangesAsync();
    }

    public async Task<ProfessionalEvent> Find(int professionalEventId)
    {
        return await _context.ProfessionalEvents.Where(a => a.Id == professionalEventId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ProfessionalEvent>> FindAll()
    {
        return await _context.ProfessionalEvents.ToListAsync();
    }
}