using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Chat_Client
{
    public class StateObject
    {
        public Socket workSocket = null;
        public const int bsize = 1024;
        public byte[] buffer = new byte[bsize];
        public StringBuilder sb = new StringBuilder();
    }

    public static class AsyncClient
    {
        private const int port = 5000;
        private static List<string> msgs = new List<string>();
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent recieveDone = new ManualResetEvent(false);
        public static String response = String.Empty;
        public static String ipaddress = String.Empty;
        public static ListBox users;
        public static ListBox chat;
        public static TextBox message_txtbox;
        public static TextBox username_txtbox;
        public static TextBox setting_txtbox;
        public static Form3 setting_form;
        public static bool connected = false;
        public static user_noip userinfo;
        public static user_noip old_userinfo;
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            Converters =
            {
                new ColorJsonConverter(),
            },
        };

        public static Socket getConnection()
        {
            IPHostEntry localhost = Dns.GetHostEntry(ipaddress);
            IPAddress ipAddress = localhost.AddressList[0];
            IPEndPoint iPEnd = new IPEndPoint(ipAddress, port);
            Socket client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.BeginConnect(iPEnd, new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();
            return client;
        }
        public static void StartClient()
        {
            try
            {
                userinfo = new user_noip(username_txtbox.Text, username_txtbox.ForeColor, username_txtbox.BackColor);
                string json = JsonSerializer.Serialize(userinfo, options);
                Socket client = getConnection();
                Send(client, "0:" + json + "</end>");
                sendDone.WaitOne();
                Recieve(client);
                recieveDone.WaitOne();
                if (response.StartsWith("taken"))
                {
                    username_txtbox.Text = "Username Taken or Invalid! Try again!";
                }
                else if(response.StartsWith("ip"))
                {
                    username_txtbox.Text = "IP address is in use.";
                }
                else
                {
                    connected = true;
                }
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static bool getConnected()
        {
            return connected;
        }

        public static void getUsers()
        {
            try
            {
                Socket cli = getConnection();
                Send(cli, "1</end>");
                sendDone.WaitOne();
                Recieve(cli);
                recieveDone.WaitOne();
                List<user_noip> usersS = JsonSerializer.Deserialize<List<user_noip>>(response, options);
                users.Items.Clear();
                foreach(user_noip u in usersS)
                {
                    users.Items.Add(u);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static void sendMessage()
        {
            Socket cli = getConnection();
            message m = new message();
            m.content = message_txtbox.Text;
            m.username = userinfo.username;
            m.color = userinfo.color;
            m.backgroundColor = userinfo.backgroundColor;
            string json = JsonSerializer.Serialize(m, options);
            Send(cli, "2:"+json+"</end>");
            sendDone.WaitOne();
        }

        public static void poll()
        {
            Socket cli = getConnection();
            Send(cli, "3</end>");
            sendDone.WaitOne();
            Recieve(cli);
            recieveDone.WaitOne();
            if (response.StartsWith("disconnected"))
            {
                MessageBox.Show("Disconnected from Server.", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                if(!response.StartsWith("no_msg")) {
                    List<message> messages = JsonSerializer.Deserialize<List<message>>(response, options);
                    foreach (message m in messages)
                    {
                        chat.Items.Add(m);
                    }
                }
            }
            getUsers();
        }

        public static void changeSettings()
        {
            string json = JsonSerializer.Serialize(userinfo, options);
            Socket client = getConnection();
            Send(client, "4:" + json + "</end>");
            Recieve(client);
            recieveDone.WaitOne();
            if (response.StartsWith("taken"))
            {
                setting_txtbox.Text = "Username Taken or Invalid! Try again!";
                userinfo = old_userinfo;
            }
            else
            {
                old_userinfo = null;
                setting_form.Dispose();
            }

        }

        public static user_noip getUser()
        {
            old_userinfo = new user_noip(userinfo.username, userinfo.color, userinfo.backgroundColor);
            return userinfo;
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                connectDone.Set();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static void Recieve(Socket client)
        {
            try
            {
                recieveDone.Reset();
                StateObject state = new StateObject();
                state.workSocket = client;
                client.BeginReceive(state.buffer, 0, StateObject.bsize, 0, new AsyncCallback(RecieveCallback), state);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private static void RecieveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                int bytesRead = client.EndReceive(ar);
                if(!Encoding.ASCII.GetString(state.buffer, 0, bytesRead).Contains("</end>"))
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    client.BeginReceive(state.buffer, 0, StateObject.bsize, 0, new AsyncCallback(RecieveCallback), state);
                }
                else
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead).Replace("</end>", ""));
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString().Replace("</end>", "");
                    }
                    recieveDone.Set();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public static void Send(Socket client, String data)
        {
            byte[] bytedata = Encoding.ASCII.GetBytes(data);
            client.BeginSend(bytedata, 0, bytedata.Length, 0, new AsyncCallback(sendCallback), client);
        }

        private static void sendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
                sendDone.Set();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
