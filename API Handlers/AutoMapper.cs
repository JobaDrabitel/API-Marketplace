using AutoMapper;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;

namespace API_Marketplace_.net_7_v1.API_Handlers
{
	public class MappingProfile<T, TCollection> : Profile
	where T : class
	where TCollection : class
	{
		public MappingProfile()
		{
			CreateMap<T, TCollection>();
		}
	}

}
