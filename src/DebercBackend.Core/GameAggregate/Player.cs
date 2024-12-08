using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DebercBackend.Core.GameAggregate;

public class Player : EntityBase, IAggregateRoot
{
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    [MaxLength(64)]
    public string Password { get; set; } = string.Empty;
    public byte[]? Image { get; set; } 
    public int Index { get; set; }
}