using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

public class ContentStatus
{
    [Key]
    public Guid ContentStatusId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //MediaInteractionStatus -> One to many
    public List<MediaInteractionStatus> MediaInteractionStatuses { get; set; } = new();

    #endregion
}
