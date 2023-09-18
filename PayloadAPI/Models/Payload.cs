using System;
using System.Collections.Generic;

namespace PayloadAPI.Models;

public partial class Payload
{
    public int Id { get; set; }

    public string? Deviceid { get; set; }

    public int? Temperature { get; set; }

    public int? Humidity { get; set; }

    public bool? Occupancy { get; set; }
}
