
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class SocketService
    {

        public SocketIO socket { get; set; }
        public static bool isConnected = false;


        public async void Connect(string url)
        {


            try
            {
                socket = new SocketIO(url, new SocketIOOptions
                {
                    Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
                });

                socket.OnConnected += Socket_OnConnected;

                await socket.ConnectAsync();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("OCURRIO UN ERROR Y NO SE PUDO CONECTAR");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }



        }


        private static void Socket_OnConnected(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SOCKET CONECTADO");
            isConnected = true;


        }



        public async void Disconnect()
        {
            await socket.DisconnectAsync();
            isConnected = false;
        }


    }
}
