using API.Models;

namespace API.Services.Contracts;

public interface IProfessionalEventService
{
    public Task Add(ProfessionalEvent professionalEvent);
    
    public Task Delete(int professionalEventId);
    
    public Task Update(ProfessionalEvent professionalEvent);
    
    public Task<ProfessionalEvent> Find(int professionalEventId);
    
    public Task<IEnumerable<ProfessionalEvent>> FindAll();
}