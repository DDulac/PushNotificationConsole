using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PushSharp.Core;
using PushSharp.Google;
using System.Web;

namespace MemberNotification
{
	class Program
	{
		#region MemberNotification Internals 

		#region MemberNotification ConsoleMessages
		public static string ConsoleInvalidSelection = "\n Invalid selection, please try again...";
		public static string ConsoleName = "\n Push Notification";
		public static string ConsoleContiue = "\n Continue... ";
		public static string ConsolePushNotificationTypes = "\n\n Select push type:\n\n  Amazon      = \"1\" \n  Apple       = \"2\" \n  Blackberry  = \"3\" \n  Firefox     = \"4\" \n  Google      = \"5\" \n  Windows     = \"6\" \n\n                 ";
		public static string ConsoleAccountId = "\n     Account Id: ";
		public static string ConsoleApplicationId = "\n Application Id: ";
		public static string ConsoleSubscriberId = "\n  Subscriber Id: ";
		public static string ConsoleSenderId = "\n      Sender Id: ";
		public static string ConsoleRegistrationId = "\nRegistration Id: ";
		public static string ConsoleRecipientId = "\n   Recipient Id: ";
		public static string ConsoleNotificationMessage = "\n   Notification: ";
		public static string ConsoleWebResponse = "\n   Web Response: ";
		#endregion MemberNotification ConsoleMessages

		#region MemberNotification Application Variables
		public static string StubbedMethod = "Stubbed Method, no data sent. Contact Mobile Delivery Development Team.";
		public static string PushService = String.Empty;
		public static string GoogleConsoleRegistrationId = "\nRegistration Id: ";
		public static string GoogleDeviceRegistrationId = String.Empty;
		public static string GoogleConsoleApplicationId = "\n Application Id: ";
		public static string GoogleApplicationId = String.Empty;
		public static string GoogleConsoleSenderId = "\n      Sender Id: ";
		public static string GoogleSenderId = String.Empty;
		public static string GoogleConsoleNotificationMessage = "\n   Notification: ";
		public static string GoogleNotificationMessage = String.Empty;
		#endregion MemberNotification Application Variables

		#endregion MemberNotification Internals 

		static void Main(string[] args)
		{
			Console.Write(ConsoleName);
			Console.WriteLine(" {0:d} {0:T}", DateTime.Now);
			Console.Write(ConsoleContiue);
			while (Console.ReadKey().Key != ConsoleKey.Enter) { }
			try
			{
				Console.Write(ConsolePushNotificationTypes);
				PushService = Console.ReadLine();
				string loopAgain = "No";
				do
				{
					switch (PushService)
					{
						case "1":
							loopAgain = "No";
							break;
						case "2": 
							loopAgain = "No";
							break;
						case "3": 
							loopAgain = "No";
							break;
						case "4": 
							loopAgain = "No";
							break;
						case "5":
							Console.Write(GoogleConsoleRegistrationId);
							GoogleDeviceRegistrationId = Console.ReadLine(); 
							Console.Write(GoogleConsoleApplicationId);
							GoogleApplicationId = Console.ReadLine();
							Console.Write(GoogleConsoleSenderId);
							GoogleSenderId = Console.ReadLine();
							Console.Write(GoogleConsoleNotificationMessage);
							GoogleNotificationMessage = Console.ReadLine();
							PushNotificationToGoogle(GoogleDeviceRegistrationId, GoogleApplicationId, GoogleSenderId, GoogleNotificationMessage);
							loopAgain = "No";
							break;
						case "6":
							loopAgain = "No";
							break;
						default:
							Console.WriteLine(ConsoleInvalidSelection);
							loopAgain = "Yes";
							break;
					}
				} while (loopAgain != "No");

			}
			catch (Exception ex)
			{
				Console.WriteLine();
				Console.WriteLine("Exception caught: " + ex.Message);
			}
			finally
			{
			}

			Console.WriteLine(ConsoleContiue);
			while (Console.ReadKey().Key != ConsoleKey.Enter) { }
		}

		public static string NotifyAmazon(string registrationId, string applicationId, string senderId, string message)
		{
			return StubbedMethod;
		}

		public static string NotifyApple(string registrationId, string applicationId, string senderId, string message)
		{
			// Examples
			//https://forums.asp.net/t/2086679.aspx?Push+Notification+for+iPhone+in+C+
			//https://stackoverflow.com/questions/28086819/send-push-notification-to-iphone-from-asp-net-c-sharp

			//int port = 2195;
			//String hostname = "gateway.push.apple.com";
			//String certificatePath = System.Web.Hosting.HostingEnvironment.MapPath("pushkey.p12");
			//X509Certificate2 clientCertificate = new X509Certificate2(System.IO.File.ReadAllBytes(certificatePath), "yourPassword");
			//X509Certificate2Collection certificatesCollection = new X509Certificate2Collection(clientCertificate);

			//TcpClient client = new TcpClient(hostname, port);
			//SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

			//try
			//{
			//	sslStream.AuthenticateAsClient(hostname, certificatesCollection, SslProtocols.Tls, false);
			//	MemoryStream memoryStream = new MemoryStream();
			//	BinaryWriter writer = new BinaryWriter(memoryStream);
			//	writer.Write((byte)0);
			//	writer.Write((byte)0);
			//	writer.Write((byte)32);

			//	writer.Write(HexStringToByteArray(deviceID.ToUpper()));
			//	String payload = "{\"aps\":{\"alert\":\"" + "Hi,, This Is a Sample Push Notification For IPhone.." + "\",\"badge\":1,\"sound\":\"default\"}}";
			//	writer.Write((byte)0);
			//	writer.Write((byte)payload.Length);
			//	byte[] b1 = System.Text.Encoding.UTF8.GetBytes(payload);
			//	writer.Write(b1);
			//	writer.Flush();
			//	byte[] array = memoryStream.ToArray();
			//	sslStream.Write(array);
			//	sslStream.Flush();
			//	client.Close();
			//}
			//catch (System.Security.Authentication.AuthenticationException ex)
			//{
			//	client.Close();
			//}
			//catch (Exception e)
			//{
			//	client.Close();
			//}

			return StubbedMethod;
		}

		public static string NotifyBlackberry(string registrationId, string applicationId, string senderId, string message)
		{
			return StubbedMethod;
		}

		public static string NotifyFirefox(string registrationId, string applicationId, string senderId, string message)
		{
			// Examples
			//
			//


			return StubbedMethod;
		}

		public static string PushNotificationToGoogle(string registrationId, string applicationId, string senderId, string message)
		{
			// Prep the notification
			WebRequest googleNotification = WebRequest.Create("https://android.googleapis.com/gcm/send");
			googleNotification.Method = "post";
			googleNotification.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
			googleNotification.Headers.Add(string.Format("Authorization: key={0}", applicationId)); 
			googleNotification.Headers.Add(string.Format("Sender: id={0}", senderId));

			// Add message, timestamp, and registration id to payload
			string postDataToServer = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + message + "&data.time=" + System.DateTime.Now.ToString() + "®istration_id=" + registrationId + "";

			Byte[] byteArray = Encoding.UTF8.GetBytes(postDataToServer);
			googleNotification.ContentLength = byteArray.Length;

			// Send the notification as an http request
			Stream dataStream = googleNotification.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();

			// Return the http response to the http request
			WebResponse tResponse = googleNotification.GetResponse();
			dataStream = tResponse.GetResponseStream();
			StreamReader tReader = new StreamReader(dataStream);
			ConsoleWebResponse = tReader.ReadToEnd();
			tReader.Close();
			dataStream.Close();
			tResponse.Close();

			return ConsoleWebResponse;
		}

		public static string NotifyWindows(string registrationId, string applicationId, string senderId, string message)
		{
			return StubbedMethod;
		}
	}
}