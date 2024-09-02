using MultiGames.Application.DTOs.Base;

namespace MultiGames.Application.DTOs;

public class GameDto : BaseDto
{
    public string Title { get; set; }
    public string VersionEdition { get; set; }
    public string Status { get; set; }
    public DateTimeOffset DateOut { get; set; }
    public BrotherDto Brother { get; set; }
}
