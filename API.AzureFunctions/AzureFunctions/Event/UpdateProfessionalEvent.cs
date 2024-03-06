using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.AzureFunctions.AzureFunctions.Event;

public class UpdateProfessionalEvent
{
    private readonly IProfessionalEventService _professionalEvent;
    private readonly ILogger<UpdateProfessionalEvent> _logger;

    // Constructeur pour l'injection de dépendances
    public UpdateProfessionalEvent(IProfessionalEventService applicationService, ILogger<UpdateProfessionalEvent> logger)
    {
        _professionalEvent = applicationService;
        _logger = logger;
    }

    // Fonction pour mettre à jour une application
    [Function("UpdateProfessionalEvent")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "application")]
    HttpRequestData req)
    {
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Models.ProfessionalEvent application = JsonConvert.DeserializeObject<Models.ProfessionalEvent>(requestBody);

            await _professionalEvent.Update(application);
            return new StatusCodeResult(200);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in UpdateProfessionalEvent Azure function");
            return new ObjectResult(e.Message) { StatusCode = 500 };
        }
    }
}

