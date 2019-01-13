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
        private int key = 0;
        private Thread demoThread = null;
        static private int div = 100;
        static MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
        static MMDevice device;
        private static SessionCollection ok;
        static private List<AudioSessionControl> ASCList = new List<AudioSessionControl>();
        static private List<AudioSessionControl> ASCList2 = new List<AudioSessionControl>();
        static private bool mapping = false;
        static private MidiEvent LastMidiEvent;
        static private string LastMidiEventText="";
        static private Dictionary<int, VirtualKeyCode> dictOfVirtualKeyCodes;

        public Form1()
        {
            dictOfVirtualKeyCodes=new Dictionary<int, VirtualKeyCode>();
            InitializeComponent();
            Class1.tb = trackBar1;
            trackBar1.Maximum = 0;
            trackBar1.Maximum = 129;
            trackBar2.Maximum = 0;
            trackBar2.Maximum = 129;
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
        }

        bool boo = false; //!TODO: What is this?
        
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread myThread = new Thread(new ThreadStart(mb));
                
                myThread.Start();
            }
            //myThread.Start();
        }

        public void SelectDesk1()
        {
            InputSimulator ids = new InputSimulator();
            List<VirtualKeyCode> keysCodes = new List<VirtualKeyCode>();
            keysCodes.Add(VirtualKeyCode.CONTROL);
            keysCodes.Add(VirtualKeyCode.LWIN);
            ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
            ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
            ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
            ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
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

        delegate void Method(); //Just delegate

        public void startup()
        {
            MidiIn midiIn = new MidiIn(0);
            midiIn.MessageReceived += midiIn_MessageReceived;
            midiIn.Start();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            Audio.device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            //richTextBox1.Text += Convert.ToString(MidiIn.NumberOfDevices);

            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
            {
                richTextBox1.Text += MidiIn.DeviceInfo(i).ProductName + "\n";
            }

            Audio.ASCList = GetThat("firefox");
            Audio.ASCList2 = GetThat("foobar2000");
            Audio.tupleList.Add((GetThat("firefox"), "firefox"));
            Audio.tupleList.Add((GetThat("foobar2000"), "foobar2000"));
            //TODO: Change to have ALL programs, not hardcoded
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void ChangeVol(ControlChangeEvent cce)
        {
            MMDevice nd = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            nd.AudioEndpointVolume.MasterVolumeLevelScalar = (float)cce.ControllerValue / 127;
        }

        public void flash_listbox()
        {
            foreach (var item in MappingListBox.Items)
            {
                if (item.ToString().Split('/')[0]==Convert.ToString(key))
                {
                    Action action = () => MappingListBox.SetSelected(MappingListBox.Items.IndexOf(item), true); 
                    if (MappingListBox.InvokeRequired)
                    {
                        MappingListBox.Invoke(action);
                    }
                    else
                    {
                        MappingListBox.SetSelected(MappingListBox.Items.IndexOf(item), true);
                    }
                    break;
                }
            }
        }

        private async void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            LastMidiEvent = e.MidiEvent;
            LastMidiEventText = e.MidiEvent.ToString();
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
                        case MidiController.FootController:
                            InputSimulator ids = new InputSimulator();
                            int lastsegment = 0;
                            List<VirtualKeyCode> keysCodes = new List<VirtualKeyCode>();
                            keysCodes.Add(VirtualKeyCode.CONTROL);
                            keysCodes.Add(VirtualKeyCode.LWIN);
                            if (cce.ControllerValue<32&& lastsegment!=1)
                            {
                                
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                lastsegment = 1;

                            }
                            else if (cce.ControllerValue>31|| cce.ControllerValue<64 && lastsegment != 2)
                            {
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                lastsegment = 2;
                            }
                            else if (cce.ControllerValue > 63 || cce.ControllerValue < 96 && lastsegment != 3)
                            {
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.LEFT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                lastsegment = 3;
                            }
                            else if (cce.ControllerValue > 95 && lastsegment != 4)
                            {
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                ids.Keyboard.ModifiedKeyStroke(keysCodes, VirtualKeyCode.RIGHT);
                                lastsegment = 4;
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
                    /* //TODO: WHat is going on here?
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
                VirtualKeyCode outVirtualKeyCode;
                //if (dictOfVirtualKeyCodes.Where(x => x.Key.NoteNumber == mk.NoteNumber)!=null)
                //{
                dictOfVirtualKeyCodes.TryGetValue(mk.NoteNumber, out outVirtualKeyCode);
                insim.Keyboard.KeyPress(outVirtualKeyCode);
                key = mk.NoteNumber;
                this.demoThread =
                    new Thread(new ThreadStart(flash_listbox));

                this.demoThread.Start();
                //flash_listbox(mk.NoteNumber);
                //insim.Keyboard.TextEntry("Жопа жопа сраный попа");
                //Process.Start("https://www.youtube.com/");
                //}
                //VirtualKeyCode.VOLUME_UP

            }
            //LastMidiEventTextbox.Refresh();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }


        public List<AudioSessionControl> GetThat(string name) //Get proces by name
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


        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            div = trackBar2.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startup();
            Method m;
            
            m = SelectDesk1;
            //yep
            Class1.TextBox = LastMidiEventTextbox;
            //premade mappings
            dictOfVirtualKeyCodes.Add(36, VirtualKeyCode.MEDIA_PLAY_PAUSE);
            dictOfVirtualKeyCodes.Add(37, VirtualKeyCode.MEDIA_NEXT_TRACK);
            dictOfVirtualKeyCodes.Add(41, VirtualKeyCode.MEDIA_PREV_TRACK);
            dictOfVirtualKeyCodes.Add(43, VirtualKeyCode.VOLUME_UP);
            dictOfVirtualKeyCodes.Add(39, VirtualKeyCode.VOLUME_DOWN);
            UpdateListView();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            InputSimulator ids = new InputSimulator();
            if (mapping) //TODO: hmhmhmh
            {
                if (LastMidiEvent.CommandCode == MidiCommandCode.ControlChange)
                {

                }
                if (LastMidiEvent.CommandCode == MidiCommandCode.NoteOff)
                {
                    List<VirtualKeyCode> codes = new List<VirtualKeyCode>();
                    VirtualKeyCode vkKeyCode = VirtualKeyCode.ACCEPT;
                    foreach (VirtualKeyCode key in (VirtualKeyCode[])Enum.GetValues(typeof(VirtualKeyCode))) //TODO: Key combinations
                    {
                        //ids.InputDeviceState.IsHardwareKeyDown()
                        if (ids.InputDeviceState.IsKeyDown(key))
                        {
                            vkKeyCode = key;
                            codes.Add(key);
                        }
                    }

                    NoteEvent note = (NoteEvent)LastMidiEvent;
                    dictOfVirtualKeyCodes.Add(note.NoteNumber, vkKeyCode);
                }

                mapping = false;
            }
            UpdateListView();

        }

        public void UpdateListView()
        {
            MappingListBox.Items.Clear();
            List<string> myList = new List<string>();
            foreach (var item in dictOfVirtualKeyCodes)
            {
                myList.Add(item.Key + "/" + item.Value.ToString());
            }

            MappingListBox.Items.AddRange(myList.ToArray());
        }

        private void MapButton_Click(object sender, EventArgs e) //Maping
        {
            mapping = !mapping;
            MappingTextbox.Text = Convert.ToString(mapping);
            LastMidiEventTextbox.Text = LastMidiEventText;
            //new
            VirtualKeyCode meh = new VirtualKeyCode();
            //ictOfVirtualKeyCodes.Add(333,VirtualKeyCode.ACCEPT);
            //dictOfVirtualKeyCodes.TryGetValue(333, out meh);
            if (meh!=null)
            {
                string wat = meh.ToString();
            }
            UpdateListView();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DeleteFromListButtton_Click(object sender, EventArgs e)
        {
            string selecteditem = MappingListBox.SelectedItem.ToString();
            int index = selecteditem.IndexOf("/");
            dictOfVirtualKeyCodes.Remove(Convert.ToInt32(selecteditem.Remove(index)));
            MappingListBox.Items.Remove(MappingListBox.SelectedItem);
        }

        private void MappingListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InputSimulator ids = new InputSimulator();
            List<VirtualKeyCode> keysCodes = new List<VirtualKeyCode>();
            //{ VirtualKeyCode.CONTROL,VirtualKeyCode.LWIN}
            keysCodes.Add(VirtualKeyCode.CONTROL);
            keysCodes.Add(VirtualKeyCode.LWIN);
            ids.Keyboard.ModifiedKeyStroke(keysCodes,VirtualKeyCode.RIGHT);
        }
    }
}
