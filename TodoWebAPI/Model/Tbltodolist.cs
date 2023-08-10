using System.Numerics;
using System.ComponentModel.DataAnnotations.Schema;
namespace TodoWebAPI.Model
{
    public class Tbltodolist
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        //public long userid { get; set; }
        public long userid { get; set; }
}
}
