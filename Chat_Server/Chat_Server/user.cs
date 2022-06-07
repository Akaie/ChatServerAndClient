using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace Chat_Server
{
    public class user
    {
        public String username;
        public IPAddress ip;
        public List<message> buffer;
        public int counter;
        public Color color;
        public Color backgroundColor;

        public user(String s, Color c, Color bc)
        {
            counter = 0;
            buffer = new List<message>();
            username = s;
            color = c;
            backgroundColor = bc;
        }
    }
}
