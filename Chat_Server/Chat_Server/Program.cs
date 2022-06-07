using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Chat_Server
{
    public class StateObject
    {
        public const int bsize = 1024;
        public byte[] buffer = new byte[bsize];
        public StringBuilder sb = new StringBuilder();
        public Socket workSocket = null;
    }

    public class AsyncScoketListener {
        public static List<user> users = new List<user>();
        static System.Timers.Timer timeout_;
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            Converters =
            {
                new ColorJsonConverter(),
            },
        };

        public static void StartListening()
        {
            timeout_ = new System.Timers.Timer(1000);
            timeout_.Elapsed += TimerCallback;
            timeout_.AutoReset = true;
            timeout_.Enabled = true;
            IPHostEntry hinfo = Dns.GetHostEntry("127.0.0.1");
            IPAddress ip = hinfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ip, 5000);
            Socket listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                Console.WriteLine("Starting server on " + hinfo.HostName + "...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                while(true)
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.bsize, 0, new AsyncCallback(ReadCallback), state);
            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    content = state.sb.ToString();
                    if (content.IndexOf("</end>") > -1)
                    {
                        content = content.Replace("</end>", "");
                        if (content.StartsWith("0:"))
                        {
                            content = content.Substring(2);
                            user_noip uname = JsonSerializer.Deserialize<user_noip>(content, options);
                            Console.WriteLine("User requested username " + uname.username);
                            Boolean taken_user = false;
                            foreach (user u in users)
                            {
                                if (u.username.Equals(uname.username))
                                {
                                    Console.WriteLine("Requested username was taken.");
                                    Send(handler, "taken");
                                    taken_user = true;
                                    break;
                                }
                            }
                            IPAddress current_ip = IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString());
                            foreach(user u in users)
                            {
                                if(u.ip == current_ip)
                                {
                                    taken_user=true;
                                    Send(handler, "ip");
                                    break;
                                }
                            }
                            if (!taken_user)
                            {
                                Send(handler, "avail");
                                user new_user = new user(uname.username, uname.color, uname.backgroundColor);
                                new_user.ip = current_ip;
                                users.Add(new_user);
                                Console.WriteLine("Username is free.");
                            }
                        }
                        else if (content.Equals("1"))
                        {
                            List<user_noip> users_noip_list = new List<user_noip>();
                            foreach(user u in users)
                            {
                                user_noip new_u = new user_noip(u.username, u.color, u.backgroundColor);
                                users_noip_list.Add(new_u);
                            }
                            string userListJson = JsonSerializer.Serialize(users_noip_list, options);
                            Send(handler, userListJson);
                        }
                        else if (content.StartsWith("2:"))
                        {
                            content = content.Replace("2:", "");
                            IPAddress current_ip = IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString());
                            message m = JsonSerializer.Deserialize<message>(content, options);
                            user sending_user = null;
                            foreach (user u in users)
                            {
                                u.buffer.Add(m);
                                if (current_ip.Equals(u.ip))
                                {
                                    sending_user = u;
                                }
                            }
                            Console.WriteLine("Message recieved from " + m.username + " (" + sending_user.ip + "): " + m.content);
                        }
                        else if (content.Equals("3"))
                        {
                            IPAddress current_ip = IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString());
                            bool found = false;
                            user polling_user = null;
                            foreach (user u in users)
                            {
                                if (current_ip.Equals(u.ip))
                                {
                                    found = true;
                                    u.counter = 0;
                                    polling_user = u;
                                    break;
                                }
                            }
                            if (found)
                            {
                                if (polling_user.buffer.Count > 0)
                                {
                                    string mess = JsonSerializer.Serialize(polling_user.buffer, options);
                                    polling_user.buffer.Clear();
                                    Console.WriteLine(polling_user.username + " requested new messages, sending...");
                                    Send(handler, mess);
                                }
                                else
                                {
                                    Send(handler, "no_msg");
                                }
                            }
                            else
                            {
                                Send(handler, "disconnected");
                            }
                        }
                        else if (content.StartsWith("4:"))
                        {
                            content = content.Substring(2);
                            user_noip new_user = JsonSerializer.Deserialize<user_noip>(content, options);
                            IPAddress current_ip = IPAddress.Parse(((IPEndPoint)handler.RemoteEndPoint).Address.ToString());
                            bool taken = false;
                            foreach (user u in users)
                            {
                                if (!current_ip.Equals(u.ip) && u.username == new_user.username)
                                {
                                    taken = true;
                                    Console.WriteLine(u.username + " requested new username. Requested username " + new_user.username + " is taken.");
                                }
                            }
                            if (taken)
                            {
                                Send(handler, "taken");
                            }
                            else
                            {
                                foreach (user u in users)
                                {
                                    if (current_ip.Equals(u.ip))
                                    {
                                        u.username = new_user.username;
                                        u.color = new_user.color;
                                        u.backgroundColor = new_user.backgroundColor;
                                        Console.WriteLine(u.username + " requested new username. Requested username " + new_user.username + " is available. Granting requesst...");
                                        break;
                                    }
                                }
                                Send(handler, "avail");
                            }
                        }
                    }
                    else
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.bsize, 0, new AsyncCallback(ReadCallback), state);
                    }
                }
                else
                {
                    handler.BeginReceive(state.buffer, 0, StateObject.bsize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private static void Send(Socket handler, String data)
        {
            byte[] bytedata = Encoding.ASCII.GetBytes(data + "</end>");
            handler.BeginSend(bytedata, 0, bytedata.Length, 0, new AsyncCallback(SendCallback), handler);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            int bytesSent = handler.EndSend(ar);
        }

        private static bool userRemoval(user item)
        {
            bool answer = item.counter > 4;
            if(answer)
            {
                Console.WriteLine(item.username + " has disconnected.");
            }
            return answer;
        }
        private static void TimerCallback(Object source, ElapsedEventArgs e)
        {
            
            foreach(user u in users)
            {
                u.counter += 1;
            }
            users.RemoveAll(userRemoval);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AsyncScoketListener.StartListening();
        }
    }
}
