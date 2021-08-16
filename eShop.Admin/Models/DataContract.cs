using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    [DataContract]
	public class DataPoint
	{
		public DataPoint(int? x, int? y)
		{
			this.X = x;
			this.Y = y;
		}
 
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "x")]
		public Nullable<int> X = null;
 
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<int> Y = null;		
	}
}
