using API.Models;

namespace API.Repository.Contracts;

public interface IProfessionalEventRepository
{
    public Task Add(ProfessionalEvent professionalEvent);
    
    public Task Delete(int applicationId);
    
    public Task Update(ProfessionalEvent professionalEvent);
    
    public Task<ProfessionalEvent> Find(int professionalEventId);

    public Task<IEnumerable<ProfessionalEvent>> FindAll();
}