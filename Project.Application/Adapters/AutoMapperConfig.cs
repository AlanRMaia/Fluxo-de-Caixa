using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Project.Application.Adapters
{
	public class AutoMapperConfig
	{
		public static void Register()
		{

			Mapper.Initialize(
				map =>
				{
					map.AddProfile<ModelToDomainEntity>();
					map.AddProfile<DomainEntityToModel>();

				});

		}
	}
}
