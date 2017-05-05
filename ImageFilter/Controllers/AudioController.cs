using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WavDotNet.Core;
using NAudio;
using NAudio.Wave;
using ImageFilter.Models;
using ImageFilter;
using System.Media;

namespace ImageFilter.Controllers
{
    class AudioController
    {

        byte[] sound;

        [Flags]
        public enum Channels : uint
        {
            FrontLeft = 0x1,
            FrontRight = 0x2,
            FrontCenter = 0x4,
            Lfe = 0x8,
            BackLeft = 0x10,
            BackRight = 0x20,
            FrontLeftOfCenter = 0x40,
            FrontRightOfCenter = 0x80,
            BackCenter = 0x100,
            SideLeft = 0x200,
            SideRight = 0x400,
            TopCenter = 0x800,
            TopFrontLeft = 0x1000,
            TopFrontCenter = 0x2000,
            TopFrontRight = 0x4000,
            TopBackLeft = 0x8000,
            TopBackCenter = 0x10000,
            TopBackRight = 0x20000
        }

        public String loadWAVFile()
        {
            String name;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Audio Files(*.wav)|*.wav";
            if (file.ShowDialog() == DialogResult.OK)
            {
                name = file.FileName;
                return name;
            }


            return null;
        }

        public void saveWav(byte[] byteArray)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "WAV|*.wav";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.FileName;
                WaveFormat waveFormat = new WaveFormat(8000, 8, 2);

                using (WaveFileWriter writer = new WaveFileWriter(name, waveFormat))
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

            }
        }

        public byte[] readWav(string filename)
        {
            WaveFileReader wave = new WaveFileReader(filename);
            long le = wave.Length;
            byte[] data = new byte[le];

            wave.Read(data, 0, (int)le);

            return data;
        }
        
        public void channelSubtraction()
        {
            String name = this.loadWAVFile();
            uint speakerMask = this.getSpeakerMask(name);
            Channels[] channels = this.FindExistingChannels(speakerMask);
            byte[] bytes = this.readWav(name);
            int channelNo = channels.Length;
            int byteNo = bytes.Length;          
            int counter = 1;
            int[] values = new int[channelNo];
            for (int i = 0; i < channelNo; i++)
            {
                Parameter dlg = new Parameter();
                dlg.nValue = 0;

                if (DialogResult.OK == dlg.ShowDialog())
                    values[i] = dlg.nValue;
            }

            for(int i = 0; i < byteNo; i++)
            {
                if(counter < channelNo)
                {
                    bytes[i] = (byte)((bytes[i] - values[counter - 1]) % 255);
                    counter++;
                }
                else
                {
                    bytes[i] = (byte)((bytes[i] - values[counter - 1]) % 255);
                    counter = 1;
                }
            }

            saveWav(bytes);


        }

        public uint getSpeakerMask(String path)
        {
            var bytes = new byte[50];

            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.Read(bytes, 0, 50);
            }

            var speakerMask = BitConverter.ToUInt32(new[] { bytes[40], bytes[41], bytes[42], bytes[43] }, 0);

            return speakerMask;
        }

        byte[] GetChannelBytes(byte[] fileAudioBytes, uint speakerMask,
Channels channelToRead, int bitDepth, uint sampleStartIndex, uint sampleEndIndex)
        {
            var channels = FindExistingChannels(speakerMask);
            var ch = GetChannelNumber(channelToRead, channels);
            var byteDepth = bitDepth / 8;
            var chOffset = ch * byteDepth;
            var frameBytes = byteDepth * channels.Length;
            var startByteIncIndex = sampleStartIndex * byteDepth * channels.Length;
            var endByteIncIndex = sampleEndIndex * byteDepth * channels.Length;
            var outputBytesCount = endByteIncIndex - startByteIncIndex;
            var outputBytes = new byte[outputBytesCount / channels.Length];
            var i = 0;

            startByteIncIndex += chOffset;

            for (var j = startByteIncIndex; j < endByteIncIndex; j += frameBytes)
            {
                for (var k = j; k < j + byteDepth; k++)
                {
                    outputBytes[i] = fileAudioBytes[(k - startByteIncIndex) + chOffset];
                    i++;
                }
            }

            return outputBytes;
        }

        Channels[] FindExistingChannels(uint speakerMask)
        {
            var foundChannels = new List<Channels>();

            foreach (var ch in Enum.GetValues(typeof(Channels)))
            {
                if ((speakerMask & (uint)ch) == (uint)ch)
                {
                    foundChannels.Add((Channels)ch);
                }
            }

            return foundChannels.ToArray();
        }

        int GetChannelNumber(Channels input, Channels[] existingChannels)
        {
            for (var i = 0; i < existingChannels.Length; i++)
            {
                if (existingChannels[i] == input)
                {
                    return i;
                }
            }

            throw new KeyNotFoundException();
        }

        public void ModifyChannels()
        {
            OpenFileDialog of = new OpenFileDialog();

            of.Filter = "Wave file (*.wav)|*.wav";

            if (of.ShowDialog() == DialogResult.OK)
            {
                byte[] input = File.ReadAllBytes(of.FileName);

                short noChannels = BitConverter.ToInt16(input, 22);
                short bps = BitConverter.ToInt16(input, 34);
                int BPS = bps / 8;

                int data = input.Length - 44;
                int bytesPerChannel = data / noChannels; //br bajtova po kanalu
                int samplesPerChannel = bytesPerChannel / BPS; //broj sempla po kanalu

                byte[] m2 = new byte[input.Length - 44];
                Buffer.BlockCopy(input, 44, m2, 0, m2.Length);

                byte[] skok = new byte[noChannels];
                for (int i = 0; i < noChannels; i++)
                {

                    Parameter dlg = new Parameter();
                    dlg.nValue = 0;

                    if (DialogResult.OK == dlg.ShowDialog())
                        skok[i] = (byte)dlg.nValue;
                }
                int p = 0;

                for (int i = 0; i < m2.Length; i++)
                {
                    m2[i] = (byte)(m2[i] - skok[p] % 255);

                    if (i % BPS == 0)
                    {
                        p++;
                        if (p == noChannels)
                            p = 0;
                    }
                }

                Buffer.BlockCopy(m2, 0, input, 44, m2.Length);

                MessageBox.Show("Choose where to save");
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Wave file (*.wav)|*.wav";

                if (sv.ShowDialog() == DialogResult.OK && sv.FileName != "")
                {
                    File.WriteAllBytes(sv.FileName, input);
                    sound = input;
                    MessageBox.Show("Done");
                    return;
                }
                MessageBox.Show("Didn't save at end, all is lost...");

            }
        }

        public void PlayStream()
        {
            if (sound != null)
            {
                using (MemoryStream ms = new MemoryStream(sound))
                {
                    SoundPlayer sp = new SoundPlayer(ms);
                    sp.Play();
                }
            }
        }

    }
}
