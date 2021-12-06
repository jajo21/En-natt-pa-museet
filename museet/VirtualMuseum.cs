using System;
using Simulator;

namespace Museet
{
	internal class VirtualMuseumProgram : IApplication
	{
		public void Run(string verb, string[] options)
		{
			// FIXME: Continue with your program here
			Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(',',options));
		}
	}
}