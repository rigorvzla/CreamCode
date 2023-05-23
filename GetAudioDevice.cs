  //OPTION 1
  
  public static void nAudio()
  {
    //API nAudio
    MMDeviceEnumerator names = new MMDeviceEnumerator();
    
    //DataFlow = Device Type
    var devices = names.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
  
    foreach (var device in devices)
      {
        Console.WriteLine(device.FriendlyName);
      }
      names.Dispose();
   }
   
   //OPTION 2
   
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern uint waveInGetNumDevs();

        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint waveInGetDevCaps(uint hwo, ref WAVEOUTCAPS pwoc, uint cbwoc);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WAVEOUTCAPS
        {
            public ushort wMid;
            public ushort wPid;
            public uint vDriverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szPname;
            public uint dwFormats;
            public ushort wChannels;
            public ushort wReserved1;
            public uint dwSupport;
        }

        
        public static string[] GetSoundDevices()
        {
            uint devices = waveInGetNumDevs();
            string[] result = new string[devices];
            WAVEOUTCAPS caps = new WAVEOUTCAPS();
          
                for (uint i = 0; i < devices; i++)
                {
                    waveInGetDevCaps(i, ref caps, (uint)Marshal.SizeOf(caps));
                    result[i] = caps.szPname;
                }
                return result;
         }
   
