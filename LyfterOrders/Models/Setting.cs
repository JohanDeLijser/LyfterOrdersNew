
using SQLite;
namespace LyfterOrders.Models
{
    public class Setting
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Key { set; get; }
        public string Value { set; get; }
    }
}
