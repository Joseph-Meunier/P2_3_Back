using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class ProfessionalEvent 
{ 
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }

    
}

