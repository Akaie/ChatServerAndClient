using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Chat_Client
{
    [Serializable]
    public class message
    {
        [JsonInclude]
        public Color color;
        [JsonInclude]
        public Color backgroundColor;
        [JsonInclude]
        public string username;
        [JsonInclude]
        public string content;
        override public string ToString()
        {
            return username + ": " + content;
        }
    }
}
