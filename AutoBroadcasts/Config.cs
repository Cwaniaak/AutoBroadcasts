using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace AutoBroadcasts
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int Delay { get; set; } = 15;
        public string Text { get; set; } = "this is an example broadcast!";
        public ushort Text_duration { get; set; } = 5;
    }
}
