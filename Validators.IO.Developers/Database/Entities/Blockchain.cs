namespace Validators.IO.Developers.Database.Entities
{
	public class Blockchain
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Currency { get; internal set; }
	}
}