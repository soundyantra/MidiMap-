using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace miditests
{
    public static class Audio
    {
        public static MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        public static MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        public static SessionCollection ok = device.AudioSessionManager.Sessions;
        public static List<AudioSessionControl> ASCList;
        public static List<AudioSessionControl> ASCList2;
        public static List<AudioSessionControl> ASCListMAIN;
        public static List<(List<AudioSessionControl>, string)> tupleList = new List<(List<AudioSessionControl>, string)>();



    }
}
