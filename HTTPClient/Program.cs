using System;
using System.Net.Sockets;

namespace HTTPClient
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			TcpClient cli = new TcpClient("warhorse.dk", 80);
			NetworkStream stream = cli.GetStream ();

			String toSend = "GET / HTTP/1.1\nHost: warhorse.dk\n\n";

			Byte[] msg = System.Text.Encoding.ASCII.GetBytes(toSend);
			
			stream.Write (msg, 0, msg.Length);

			Byte[] resp = new Byte[512];

			Int32 read = stream.Read (resp, 0, resp.Length);
			String str = System.Text.Encoding.ASCII.GetString (resp, 0, read);
			Console.WriteLine (str);
			Console.ReadKey ();
		}
	}
}
