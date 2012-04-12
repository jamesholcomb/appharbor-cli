﻿using System;
using System.IO;

namespace AppHarbor.Commands
{
	public class BuildCommand : ICommand
	{
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly IAppHarborClient _appharborClient;
		private readonly TextWriter _writer;

		public BuildCommand(IApplicationConfiguration applicationConfiguration, IAppHarborClient appharborClient, TextWriter writer)
		{
			_applicationConfiguration = applicationConfiguration;
			_appharborClient = appharborClient;
			_writer = writer;
		}

		public void Execute(string[] arguments)
		{
			throw new NotImplementedException();
		}
	}
}
