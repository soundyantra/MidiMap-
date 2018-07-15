using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Midi;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using NAudio.CoreAudioApi;


namespace miditests
{

    public partial class Form1 : Form
    {
        //private CoreAudioDevice defaultPlaybackDevice;
        static private int div = 100;
        static private Thread myThread = new Thread(new ThreadStart(midirandom));
        static MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        static MMDevice device;
        private static SessionCollection ok;
        static private List<AudioSessionControl> ASCList = new List<AudioSessionControl>();
        static private List<AudioSessionControl> ASCList2 = new List<AudioSessionControl>();


        public Form1()
        {
            InitializeComponent();
            Class1.tb = trackBar1;
            trackBar1.Maximum = 0;
            trackBar1.Maximum = 129;
            trackBar2.Maximum = 0;
            trackBar2.Maximum = 129;
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        }

        bool boo = false;
        
        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                Thread myThread = new Thread(new ThreadStart(mb));
                
                myThread.Start();
            }
            //myThread.Start();

        }

        public static void mb()
        {
            TrackBar tb = Class1.tb;
            while (true)
            {
                MessageBox.Show(Convert.ToString(tb.Value));
                Thread.Sleep(500);

            }     
            
        }

        public static void midirandom()
        {
            bool boo = true;
            List<int> notes = new List<int> { 62, 70, 81, 56, 64, 67 };
            //List<int> times = new List<int> { 150, 300, 250, 200, 400, 500 };

            //should change that
            List<int> times = new List<int> { 50, 60,40,60,30,80 };
            times.Add(60);
            notes.Add(60);

            MidiOut midiOut = new MidiOut(4);
            //MidiIn midin = new MidiIn(0);
            Console.WriteLine(MidiOut.DeviceInfo(0));
            Console.WriteLine(MidiOut.NumberOfDevices);
            Console.WriteLine(MidiIn.NumberOfDevices);
            Console.ReadLine();
            for (int i = 0; i < MidiOut.NumberOfDevices; i++)
            {
                Console.WriteLine(MidiOut.DeviceInfo(i).ProductName);
                //Console.WriteLine(MidiIn.DeviceInfo(i).ProductName);
            }
            Random r = new Random();
            //MessageBox.Show("kkee");
            int ii = 0;
            while (boo)
            {
                MidiEventCollection col = new MidiEventCollection(0, 120);
                string[] files = Directory.GetFiles(@"D:\Production\Midis");
                var strictMode = false;

                var mf = new MidiFile(files[r.Next(0,files.Length)], strictMode);
                /*
                if (div > 60)
                {
                    mf = new MidiFile("untitled.mid", strictMode);
                }
                else
                {
                    mf = new MidiFile("arp.mid", strictMode);
                }
                */

                for (int i = 0; i < 16; i++)
                {
                    if (ii < mf.Events[1].Count())
                    {
                        midiOut.Send(mf.Events[1][ii].GetAsShortMessage());
                        System.Threading.Thread.Sleep(div);
                    }
                    else
                    {
                        ii = 0;
                    }
                    ii++;
                }
                /*
                foreach (var midiEvent in mf.Events[1])
                {
                    midiOut.Send(midiEvent.GetAsShortMessage());
                    System.Threading.Thread.Sleep(div);
                }
                */

                /*
                for (int k = 0; k < 4; k++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < notes.Count; i++)
                        {
                            midiOut.Send(MidiMessage.StartNote(notes[i], r.Next(50, 127), 1).RawData);
                            midiOut.Send(MidiMessage.StartNote(notes[i] - 10, r.Next(50, 127), 2).RawData);
                            //midiOut.Send(MidiMessage.ChangeControl(2, kek, 1).RawData);
                            System.Threading.Thread.Sleep(div);
                            midiOut.Send(MidiMessage.StopNote(notes[i], 0, 1).RawData);
                            midiOut.Send(MidiMessage.StopNote(notes[i] - 10, 0, 2).RawData);
                        }
                        notes.Add(r.Next(50, 100));
                        times.Add(r.Next(10, 150));
                    }
                    notes = notes.OrderBy(a => Guid.NewGuid()).ToList();
                    times = times.OrderBy(a => Guid.NewGuid()).ToList();
                }
                */
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var tupleList = new List<(List<AudioSessionControl>, string)>();
            //Audio.tupleList[i].Item2


            MidiIn midiIn = new MidiIn(0);
            //MidiIn midiIn = new MidiIn(4);
            midiIn.MessageReceived += midiIn_MessageReceived;
            midiIn.Start();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            Audio.device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            richTextBox1.Text += Convert.ToString(MidiIn.NumberOfDevices);
            
            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
            {
                richTextBox1.Text += MidiIn.DeviceInfo(i).ProductName +"\n";
                //Console.WriteLine(MidiIn.DeviceInfo(i).ProductName);
            }

            Audio.ASCList =GetThat("firefox");
            Audio.ASCList2 = GetThat("foobar2000");
            Audio.tupleList.Add((GetThat("firefox"), "firefox"));
            Audio.tupleList.Add((GetThat("foobar2000"), "foobar2000"));
            //Audio.ASCListMAIN = GetThat("ShellExperienceHost");
        }

        public void ChangeVol(ControlChangeEvent cce)
        {
            MMDevice nd = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            nd.AudioEndpointVolume.MasterVolumeLevelScalar = (float)cce.ControllerValue / 127;
            
        }

        private async void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            //TrackBar t = trackBar2;
            if (e.MidiEvent.CommandCode == MidiCommandCode.ControlChange)
            {
                MidiEvent me = e.MidiEvent;
                ControlChangeEvent cce = me as ControlChangeEvent;
                if (cce != null)
                {
                    switch (cce.Controller)
                    {
                            
                        case MidiController.Modulation:
                            //foreach (var item in Audio.ASCList)
                            foreach (var item in Audio.tupleList.Find(x => x.Item2 == "firefox").Item1)
                            {
                                item.SimpleAudioVolume.Volume = (float)cce.ControllerValue / 127;
                            }
                            break;
                        case MidiController.BreathController:
                            foreach (var item in Audio.tupleList.Find(x => x.Item2 == "foobar2000").Item1)
                            {
                                item.SimpleAudioVolume.Volume = (float)cce.ControllerValue / 127;
                                
                            }
                            break;
                        default:
                            
                            ChangeVol(cce);
                            GC.Collect(); //Bullshit solution
                            break;
                    }
                    //device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                    //var k = ok[1].DisplayName;
                    //ok[8].SimpleAudioVolume.Mute = true;
                    //ok[8].SimpleAudioVolume.Volume = (float)cce.ControllerValue / 127;
                    
                    /*
                    this.trackBar2.BeginInvoke((MethodInvoker)(() => this.trackBar2.Value = cce.ControllerValue));
                    
                    this.textBox1.BeginInvoke((MethodInvoker)(() => this.textBox1.Text = Convert.ToString(cce.ControllerValue)));
                    if (cce.ControllerValue>10)
                    {
                        div = cce.ControllerValue;
                    }
                    */

                }

            }
            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
            {
                InputSimulator insim = new InputSimulator();
                var k = e.MidiEvent.Clone();
                NoteEvent mk = (NoteEvent) k;
                switch (mk.NoteNumber)
                {
                    case 43:
                        device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                        if (device.AudioEndpointVolume.MasterVolumeLevelScalar > 0.79)
                        {
                            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float) 0.99;
                        }
                        else
                        {
                            device.AudioEndpointVolume.MasterVolumeLevelScalar += (float) 0.2;
                        }

                        break;
                    case 39:
                        device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                        if (device.AudioEndpointVolume.MasterVolumeLevelScalar < 0.21)
                        {
                            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float) 0.01;
                        }
                        else
                        {
                            device.AudioEndpointVolume.MasterVolumeLevelScalar -= (float) 0.2;
                        }
                        break;
                    case 40:

                        VirtualKeyCode s = (VirtualKeyCode)Keys.VolumeDown;
                        insim.Mouse.MoveMouseToPositionOnVirtualDesktop(1, 1);
                        insim.Mouse.Sleep(300);
                        insim.Mouse.MoveMouseBy(10, 1280);
                        insim.Mouse.RightButtonClick();
                        break;
                    case 36:
                        insim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);
                        break;
                    default:
                        //insim.Keyboard.KeyPress(VirtualKeyCode.LWIN);
                        //insim.Keyboard.ModifiedKeyStroke(new[] {VirtualKeyCode.CONTROL, VirtualKeyCode.MENU}, VirtualKeyCode.DELETE);
                        insim.Keyboard.Sleep(100);
                        //insim.Keyboard.KeyDown(VirtualKeyCode.MENU);
                        //insim.Keyboard.KeyDown(VirtualKeyCode.TAB);
                        //insim.Keyboard.Key(VirtualKeyCode.SLEEP);
                        //insim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK);
                        //insim.Keyboard.ModifiedKeyStroke(new[] { VirtualKeyCode.MENU},
                        //    VirtualKeyCode.TAB);
                        insim.Keyboard.Sleep(1000);
                        break;
                }
                
                
            }
        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (myThread.IsAlive)
            {
                myThread.Resume();
            }
            else
            {
                myThread.Start();
            }

        }

        public List<AudioSessionControl> GetThat(string name)
        {
            device = Audio.device;
            
            var ok = device.AudioSessionManager.Sessions;
            
            ok = Audio.ok;
            List<string> ls = new List<string>();
            List<Process> pcs = new List<Process>();
            List<string> pnames = new List<string>();
            for (int i = 0; i < ok.Count; i++)
            {
                ls.Add(ok[i].DisplayName);
                Process p = Process.GetProcessById((int)ok[i].GetProcessID);
                pnames.Add(p.ProcessName);
            }
            List<AudioSessionControl> ASCList = new List<AudioSessionControl>();
            for (int i = 0; i < ok.Count; i++)
            {
                if (Process.GetProcessById((int)ok[i].GetProcessID).ProcessName == name)
                {
                    ASCList.Add(ok[i]);
                }
            }
            return ASCList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            myThread.Suspend();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            div = trackBar2.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            InputSimulator ids = new InputSimulator();
            //for (int i = 0; i < 100; i++)
            //{
            //    button4.Select();
            //    button4.Select();
            //}
            //ids.Keyboard.KeyPress((VirtualKeyCode)e.KeyCode);
            ids.Keyboard.KeyPress(VirtualKeyCode.LWIN);
            ids.Keyboard.KeyUp((VirtualKeyCode) e.KeyCode);

        }
    }
}
