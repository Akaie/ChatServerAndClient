using System;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Chat_Client
{
    [Serializable]
    public class user_noip
    {
        [JsonInclude]
        public String username;
        [JsonInclude]
        public Color color;
        [JsonInclude]
        public Color backgroundColor;

        public user_noip(String s, Color c, Color bc)
        {
            username = s;
            color = c;
            backgroundColor = bc;
        }

        [JsonConstructor]
        public user_noip()
        {

        }

        public override string ToString()
        {
            return username;
        }
    }
}