using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Chat_Server
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
    }
}
