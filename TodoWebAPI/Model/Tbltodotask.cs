using System.Numerics;
namespace TodoWebAPI.Model
{

        public class Tbltodotask
        {

            public long Id { get; set; }
            public string taskname { get; set; }
            public string description { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public long todolistId { get; set; }
        }
    
}
