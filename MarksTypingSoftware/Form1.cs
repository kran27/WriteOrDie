using DateTime = System.DateTime;
using Timer = System.Windows.Forms.Timer;

namespace WriteOrDie
{
    public partial class Form1 : Form
    {
        public int Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Remaining { get; private set; }

        public Timer SelfDestructTimer = new();
        public DateTime TheEnd;

        private void SetRemaining(DateTime end)
        {
            var d = (DateTime.Now - end).TotalMilliseconds;
            this.Remaining = Math.Abs(Convert.ToInt32(d));
        }
        public Form1()
        {
            InitializeComponent();

            this.timer1.Interval = 10;
            this.InitializeProgressBar(this.numericUpDown1.Value);
            this.SelfDestructTimer.Interval = 100;
            this.SelfDestructTimer.Tick += this.SelfDestruct_OnTick;

        }

        private void InitializeProgressBar(decimal seconds)
        {
            this.Duration = decimal.ToInt32(seconds) * 1000;
            this.progressBar1.Maximum = this.Duration;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Value = this.Duration;
            this.label3.Text = this.Duration.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.timer1.Start();
            this.Start = DateTime.Now;
            this.End = this.Start.AddMilliseconds(this.Duration);
        }

        private void UpdateProgress(Timer timer, DateTime end)
        {
            this.SetRemaining(end);
            this.progressBar1.Value = this.Remaining;
            this.label3.Text = this.Remaining.ToString();

            if (DateTime.Now < end) return;
            this.label3.Text = "0";
            this.richTextBox1.Text = "";
            timer.Stop();
            this.numericUpDown1.Enabled = !this.timer1.Enabled;
            MessageBox.Show("Text successfully destroyed without the ability to recover it.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.numericUpDown1.Enabled = !this.timer1.Enabled;
            this.UpdateProgress(this.timer1, this.End);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.End = DateTime.Now.AddMilliseconds(this.Duration);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.Duration = decimal.ToInt32(this.numericUpDown1.Value) * 1000;
            this.progressBar1.Maximum = this.Duration;
            this.label3.Text = this.Duration.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.label2.Visible = true;
            this.SelfDestructTimer.Start();
            this.InitializeProgressBar(Convert.ToDecimal(15));
            this.TheEnd = DateTime.Now.AddMilliseconds(this.Duration);

            var backupDir = System.Environment.GetEnvironmentVariable("TEMP");
            if (backupDir == null || !new DirectoryInfo(backupDir).Exists) return;
            try
            {
                var fd = File.Create(backupDir + $"\\{this.ProductName}_backup.txt");

                var text = System.Text.Encoding.UTF8.GetBytes(this.richTextBox1.Text);
                fd.Write(text);
                fd.Flush();
                fd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void SelfDestruct_OnTick(object? sender, EventArgs e)
        {
            this.UpdateProgress(this.SelfDestructTimer, this.TheEnd);
        }
    }
}