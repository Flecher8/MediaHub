using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class Evaluation
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public List<MediaInteractionStatus> MediaInteractionStatuses { get; set; } = new List<MediaInteractionStatus>();
}
