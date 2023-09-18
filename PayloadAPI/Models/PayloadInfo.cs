namespace PayloadAPI.Models
{
    public class PayloadInfo
    {
        public int Id { get; set; }

        public string? Deviceid { get; set; }

        public Data data { get; set; }


    }

    public class Data
    {
        public int? Temperature { get; set; }

        public int? Humidity { get; set; }

        public bool? Occupancy { get; set; }
    }
}
