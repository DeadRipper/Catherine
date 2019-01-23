using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.FileFormats;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Globalization;
using System.Speech.Synthesis;
using System.Threading;

namespace Catherine
{
	public partial class Form1 : Form
	{
		WaveIn waveIn;
		WaveFileWriter waveFileWriter;

		string output_file = "Sound_FIle.wav";

		public Form1()
		{
			InitializeComponent();
		}

		void StopRecord()
		{
			MessageBox.Show("Stop");
			waveIn.StopRecording();
		}

		void waveIn_DataAvailable(object sender, WaveInEventArgs e)
		{
			if (this.InvokeRequired)
				this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
			else
				waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
		}

		private void waveIn_RecordingStopped(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
				this.BeginInvoke(new EventHandler(waveIn_RecordingStopped), sender, e);
			else
			{
				waveIn.Dispose();
				waveIn = null;
				waveFileWriter.Close();
				waveFileWriter = null;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				waveIn = new WaveIn();
				waveIn.DeviceNumber = 0;
				waveIn.DataAvailable += waveIn_DataAvailable;
				waveIn.RecordingStopped += waveIn_RecordingStopped;
				waveIn.WaveFormat = new WaveFormat(8000, 1);
				waveFileWriter = new WaveFileWriter(output_file, waveIn.WaveFormat);
				waveIn.StartRecording();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (waveIn != null)
				StopRecord();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

			Grammar dictationGrammar = new DictationGrammar();
			recognizer.LoadGrammar(dictationGrammar);
			if (checkBox1.Checked == true)
				recognizer.SetInputToDefaultAudioDevice();
			else
				recognizer.SetInputToWaveFile(@"C:\Users\hardy\source\repos\VoiceSaver_\VoiceSaver_\bin\Debug\Sound_File.wav");

			RecognitionResult result = recognizer.Recognize();
			recognizer.UnloadAllGrammars();
			textBox1.Text = result.Text;

			//FileStream fs = new FileStream(@"C:\Users\hardy\source\repos\VoiceSaver_\VoiceSaver_\bin\Debug\Test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			//byte[] arr = System.Text.Encoding.Default.GetBytes(text);
			//fs.Write(arr, 0, arr.Length);
			//MessageBox.Show("In File");
		}
	}
}
