using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	class RequestResponeClient : IClient
	{
		public IPEndPoint IpAndPort { get; set; }

		// keep private tcpClient, and binary writer so the send function can use them.

		private TcpClient tcpClient;

		private StreamWriter connectionWriter = null;
		private StreamReader connectionReader = null;


		// send to the server by opening new connection for each message.

		public string Request(string message)
		{
			// varify they connect function called before send.

			if (connectionWriter == null) return null;

			try
			{			
				connectionWriter.WriteLine(message);
				return connectionReader.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		// Connect - simple tcp connection to the IpAndPort.

		public void Connect()
		{
			tcpClient = new TcpClient();
			tcpClient.Connect(IpAndPort);

			var stream = tcpClient.GetStream();
			connectionWriter = new StreamWriter(stream);
			connectionReader = new StreamReader(stream);
		}

		// Disconnect - simple disconnection.

		public void Disconnect()
		{
			if (tcpClient != null)
			{
				tcpClient.Close();
				tcpClient = null;
			}
		}
	}
}
