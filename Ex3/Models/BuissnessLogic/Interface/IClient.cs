using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models.Interface
{
	public interface IClient
	{
		// the port + ip the client will talk to .
		IPEndPoint IpAndPort { get; set; }

		// connect and disconnect to/from server.
		void Connect();

		void Disconnect();

		// send data to the server. return answer.
		string Request(string message);

	}
}
