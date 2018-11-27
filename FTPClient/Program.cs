using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class Program
    {

        static void Main(string[] args)
        {
            string endPoint = "https://giphy.com/gifs/Sk3KytuxDQJQ4";
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(endPoint);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            Stream fileStream = File.Create("ff.gif");
            byte[] buffer = new byte[1024];
            int read;
            int total = 0;
            while((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, read);
                total += read;
                Console.WriteLine($"Downloaded {total} bytes");
            }
            ftpStream.Close();
            fileStream.Close();
            response.Close();
        }
    }
}
