using System;
using System.Collections.Generic;

namespace Meadow.Cloud;

public class CloudEvent
{
    public int EventId { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Dictionary<string, object> Measurements { get; set; } = default!;
    public DateTime Timestamp { get; set; } = default!;
}