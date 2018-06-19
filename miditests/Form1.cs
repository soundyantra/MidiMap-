using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Midi;
using System.Threading;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;

namespace miditests
{

    public partial class Form1 : Form
    {
        private CoreAudioDevice defaultPlaybackDevice;
        static private int div = 100;

        static private Thread myThread = new Thread(new ThreadStart(midirandom));

        public Form1()
        {

            //defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            //defaultPlaybackDevice = new CoreAudioController().GetDefaultDevice(DeviceType.Playback,Role.Multimedia);
            InitializeComponent();
            Class1.tb = trackBar1;
            trackBar1.Maximum = 0;
            trackBar1.Maximum = 129;
            trackBar2.Maximum = 0;
            trackBar2.Maximum = 129;
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
            
                 MidiIn midiIn = new MidiIn(0);
            
                //MidiIn midiIn = new MidiIn(4);
                midiIn.MessageReceived += midiIn_MessageReceived;
                midiIn.Start();
                

            
            richTextBox1.Text += Convert.ToString(MidiIn.NumberOfDevices);
            
            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
            {
                richTextBox1.Text += MidiIn.DeviceInfo(i).ProductName +"\n";
                
                //Console.WriteLine(MidiIn.DeviceInfo(i).ProductName);
            }
        }

        private async void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            TrackBar t = trackBar2;
            if (e.MidiEvent.CommandCode == MidiCommandCode.ControlChange)
            {
                MidiEvent me = e.MidiEvent;
                ControlChangeEvent cce = me as ControlChangeEvent;
                if (cce != null)
                {
                    /*
                    string result = await Task.Factory.StartNew<string>(
                                                     () => Worker.SomeLongOperation(),
                                                     TaskCreationOptions.LongRunning);

                    this.label1.Text = result;
                    */
                    //Mouse.X = MousePosition.X+ cce.ControllerValue;
                    this.trackBar2.BeginInvoke((MethodInvoker)(() => this.trackBar2.Value = cce.ControllerValue));
                    //defaultPlaybackDevice.Volume=0;
                    //CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    //Debug.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);
                    /*
                    if (cce.ControllerValue > 100)
                    {
                        defaultPlaybackDevice.Volume = 100;
                    }
                    else
                    {
                        defaultPlaybackDevice.Volume = cce.ControllerValue;
                    }
                     */
                    //textBox1.Text = Convert.ToString(cce.ControllerValue);
                    //t.Value = cce.ControllerValue;
                    this.textBox1.BeginInvoke((MethodInvoker)(() => this.textBox1.Text = Convert.ToString(cce.ControllerValue)));
                    if (cce.ControllerValue>10)
                    {
                        div = cce.ControllerValue;
                    }
                    
                    //Console.WriteLine(cce.ControllerValue);
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

            //myThread = new Thread(new ThreadStart(midirandom));
            if (myThread.IsAlive)
            {
                myThread.Resume();
            }
            else
            {
                myThread.Start();
            }
            

            //midirandom();
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
    }
}
