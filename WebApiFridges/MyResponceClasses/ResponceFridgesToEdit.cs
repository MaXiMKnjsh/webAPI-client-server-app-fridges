using System.ComponentModel.DataAnnotations;

namespace WebApiFridges.API.MyResponceClasses
{
	public class ResponceFridgesToEdit
	{
		[Required]
		public Guid fridgeGuid { get; set; }
		[Required]
		public string Name {get;set;}
		[Required]
		public Guid ModelGuid {get;set;}
		public string? OwnerName {get;set;}
	}
}
