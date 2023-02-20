namespace SimpleToDo.Api.Context
{
	public class BaseEntity
	{
		public int ID { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime	{ get; set; }
	}
}
