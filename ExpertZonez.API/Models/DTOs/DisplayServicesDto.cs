using ExpertZonez.API.Models;
namespace ExpertZonez.API.Models;

public class DisplayServicesDto
{
    public IEnumerable<Service> services { get; set; }
    public IEnumerable<ServiceGenre> Genres { get; set; }
    public int currentPage { get; set; }
    public int totalPages { get; set; }
    public int pageSize { get; set; }
    public string sTerm { get; set; } = "";
    public int genreId { get; set; } = 0;
}
