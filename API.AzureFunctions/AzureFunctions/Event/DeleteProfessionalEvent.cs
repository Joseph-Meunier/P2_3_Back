
using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace API.AzureFunctions.AzureFunctions.Event;

public class DeleteProfessionalEvent
{
    private readonly IProfessionalEventService _professionalEventService;
    private readonly ILogger<DeleteProfessionalEvent> _logger;

    // Constructeur pour l'injection de dépendances
    public DeleteProfessionalEvent(IProfessionalEventService applicationService, ILogger<DeleteProfessionalEvent> logger)
    {
        _professionalEventService = applicationService;
        _logger = logger;
    }

    // Fonction pour supprimer une application
    [Function("DeleteProfessionalEvent")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "professional-event/{professionalEventId}/delete")] HttpRequestData req, int professionalEventId)
    {
        try
        {
            await _professionalEventService.Delete(professionalEventId);
            return new StatusCodeResult(200);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in DeleteProfessionalEvent Azure function");
            return new ObjectResult(e.Message) { StatusCode = 500 };
        }
    }
}