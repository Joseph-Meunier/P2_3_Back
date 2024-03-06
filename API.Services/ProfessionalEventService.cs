using API.Models;
using API.Repository.Contracts;
using API.Services.Contracts;

namespace API.Services;

public class ProfessionalEventService : IProfessionalEventService
{
    private readonly IProfessionalEventRepository _applicationRepository;

    public ProfessionalEventService(IProfessionalEventRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public async Task Add(ProfessionalEvent application)
    {
        await _applicationRepository.Add(application);
    }

    public async Task Delete(int applicationId)
    {
        await _applicationRepository.Delete(applicationId);
    }

    public async Task Update(ProfessionalEvent application)
    {
        await _applicationRepository.Update(application);
    }

    public async Task<ProfessionalEvent> Find(int applicationId)
    {
       return await _applicationRepository.Find(applicationId);
    }
    
    public async Task<IEnumerable<ProfessionalEvent>> FindAll()
    {
        return await _applicationRepository.FindAll();
    }
}