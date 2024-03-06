using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace API.AzureFunctions.AzureFunctions.Event;

public class GetProfessionalEvents
{
    private readonly IProfessionalEventService _professionalEventService;
    private readonly ILogger<GetProfessionalEvents> _logger;

    // Constructeur pour l'injection de dépendances
    public GetProfessionalEvents(IProfessionalEventService professionalEventService, ILogger<GetProfessionalEvents> logger)
    {
        _professionalEventService = professionalEventService;
        _logger = logger;
    }

    [Function("GetProfessionalEvent")]
    public async Task<IActionResult> Run(
               [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "professional-events")] HttpRequestData req)
    {
        try
        {
            var professionalEvent = await _professionalEventService.FindAll();
            return new OkObjectResult(professionalEvent);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in GetProfessionalEvents Azure function");
            return new ObjectResult(e.Message) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}

