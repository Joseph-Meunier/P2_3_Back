using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.AzureFunctions.AzureFunctions.ProfessionalEvent;

public class AddProfessionalEvent
{
    private readonly IProfessionalEventService _professionalEventService;
    private readonly ILogger<AddProfessionalEvent> _logger;

    public AddProfessionalEvent(IProfessionalEventService professionalEventService, ILogger<AddProfessionalEvent> logger)
    {
        _professionalEventService = professionalEventService;
        _logger = logger;
    }

    [Function("AddProfessionalEvent")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "professional-event")] 
        HttpRequestData req)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Models.ProfessionalEvent professionalEvent = JsonConvert.DeserializeObject<Models.ProfessionalEvent>(requestBody);

            await _professionalEventService.Add(professionalEvent); 
            return new StatusCodeResult(StatusCodes.Status201Created);  
        }
        catch(Exception e)
        {
            _logger.LogError(e, "An error occurred in AddProfessionalEvent Azure function");
            return new ObjectResult(e.Message) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}
