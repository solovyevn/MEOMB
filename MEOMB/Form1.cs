using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace MEOMB
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        Profile Current = new Profile();
        public Form1()
        {
            InitializeComponent();
        }

        private int FieldCheck()
        {
            if (textBox1.Text == "" || !Profile.IntVal(textBox1.Text))
            {
                MessageBox.Show("\"Undock time\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Undock time\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "1";
                return 0;
            }
            else
            {
                Current.Undock = (Convert.ToInt32(textBox1.Text));
            }
            if (textBox2.Text == "" || !Profile.IntVal(textBox2.Text))
            {
                MessageBox.Show("\"Warp time to Asteroid Belt 1\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Warp time to Asteroid Belt 1\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Text = "1";
                return 0;
            }
            else
            {
                Current.WarpToAB1 = (Convert.ToInt32(textBox2.Text));
            }
            if (textBox3.Text == "" || !Profile.IntVal(textBox3.Text))
            {
                MessageBox.Show("\"Warp time to Station from  Asteroid Belt 1\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Warp time to Station from  Asteroid Belt 1\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Text = "1";
                return 0;
            }
            else
            {
                Current.WarpToStation1 = (Convert.ToInt32(textBox3.Text));
            }
            if (textBox4.Text == "" || !Profile.IntVal(textBox4.Text))
            {
                MessageBox.Show("\"Cargo filling time\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Cargo filling time\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox4.Text = "1";
                return 0;
            }
            else
            {
                Current.CargoFilling = (Convert.ToInt32(textBox4.Text));
            }
            if (textBox5.Text == "" || !Profile.IntVal(textBox5.Text))
            {
                MessageBox.Show("\"Dock time\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Dock time\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox5.Text = "1";
                return 0;
            }
            else
            {
                Current.Dock = (Convert.ToInt32(textBox5.Text));
            }
            if (textBox6.Text == "" || !Profile.IntVal(textBox6.Text))
            {
                MessageBox.Show("\"Warp time to Asteroid Belt 2\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Warp time to Asteroid Belt 2\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox6.Text = "1";
                return 0;
            }
            else
            {
                Current.WarpToAB2 = (Convert.ToInt32(textBox6.Text));
            }
            if (textBox7.Text == "" || !Profile.IntVal(textBox7.Text))
            {
                MessageBox.Show("\"Warp time to Station from  Asteroid Belt 2\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Warp time to Station from  Asteroid Belt 2\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Text = "1";
                return 0;
            }
            else
            {
                Current.WarpToStation2 = (Convert.ToInt32(textBox7.Text));
            }
            if (textBox9.Text == "" || !Profile.IntVal(textBox9.Text))
            {
                MessageBox.Show("\"Screen resolution X\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Screen resolution X\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox9.Text = "1";
                return 0;
            }
            else
            {
                Current.ResolutionX = (Convert.ToInt32(textBox9.Text));
            }
            if (textBox10.Text == "" || !Profile.IntVal(textBox10.Text))
            {
                MessageBox.Show("\"Screen resolution Y\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Screen resolution Y\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox10.Text = "1";
                return 0;
            }
            else
            {
                Current.ResolutionY = (Convert.ToInt32(textBox10.Text));
            }
            if (textBox11.Text == "" || !Profile.IntVal(textBox11.Text))
            {
                MessageBox.Show("\"Target lock time\" field must contain integer from 1 to " + (Math.Abs(Int32.MaxValue) - 1) + "!", "Check \"Target lock time\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox11.Text = "1";
                return 0;
            }
            else
            {
                Current.TargetLock = (Convert.ToInt32(textBox11.Text));
            }
            if (checkBox2.Checked == true)
            {
                Current.Drones = true;
            }
            else
            {
                Current.Drones = false;
            }
            if (checkBox1.Checked == true)
            {
                Current.Interchange = true;
            }
            else
            {
                Current.Interchange = false;
            }
            return 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] profiles = Profile.GetProfiles();
            if (profiles.Length != 0)
            {
                foreach (string str in profiles)
                {
                    listBox1.Items.Add(str);
                }
                listBox1.SelectedIndex = 0;
                if (Current.LoadProfile(listBox1.SelectedItem.ToString())) button2.Enabled = true;
                else
                {
                    button2.Enabled = false;
                    Current.Reset();
                }
            }
            else
            {
                button2.Enabled = false;
                Current.Reset();
            }
            textBox1.Text = Current.Undock.ToString();
            textBox2.Text = Current.WarpToAB1.ToString();
            textBox3.Text = Current.WarpToStation1.ToString();
            textBox4.Text = Current.CargoFilling.ToString();
            textBox5.Text = Current.Dock.ToString();
            textBox6.Text = Current.WarpToAB2.ToString();
            textBox7.Text = Current.WarpToStation2.ToString();
            textBox9.Text = Current.ResolutionX.ToString();
            textBox10.Text = Current.ResolutionY.ToString();
            textBox11.Text = Current.TargetLock.ToString();
            checkBox1.Checked = Current.Interchange;
            checkBox2.Checked = Current.Drones;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox6.Text = "1";
                textBox7.Text = "1";
            }
            else
            {
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox6.Text = "1";
                textBox7.Text = "1";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            if(FieldCheck()!=0) panel1.Visible = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
#region ACTION
            MPoint Dock = new MPoint(0.011,0.97,Current.ResolutionX,Current.ResolutionY);
            MPoint AB1 = new MPoint(0.83,0.727,Current.ResolutionX,Current.ResolutionY);
            MPoint AB2 = new MPoint(0.83,0.746,Current.ResolutionX,Current.ResolutionY);
            MPoint Asteroid1 = new MPoint(0.83,0.178,Current.ResolutionX,Current.ResolutionY);
            MPoint Asteroid2 = new MPoint(0.83,0.196,Current.ResolutionX,Current.ResolutionY);
            MPoint Station = new MPoint(0.83,0.766,Current.ResolutionX,Current.ResolutionY);
            MPoint Cargo1 = new MPoint(0.05,0.63,Current.ResolutionX,Current.ResolutionY);
            MPoint Cargo2 = new MPoint(0.1,0.63,Current.ResolutionX,Current.ResolutionY);
            MPoint Drones1 = new MPoint(0.83,0.538,Current.ResolutionX,Current.ResolutionY);
            MPoint Drones2= new MPoint(0.83,0.558,Current.ResolutionX,Current.ResolutionY);
            bool change=true;
            Thread.Sleep(10000);
            while(!backgroundWorker1.CancellationPending)
            {
                Cursor.Position = new Point(Dock.x, Dock.y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Dock.x, Dock.y, 0, 0);
                if (backgroundWorker1.CancellationPending) break;
                Thread.Sleep(1000*Current.Undock);
                if (backgroundWorker1.CancellationPending) break;
                if (change)
                {
                    Cursor.Position = new Point(AB1.x, AB1.y);
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, AB1.x, AB1.y, 0, 0);
                    Thread.Sleep(1100);
                    Cursor.Position = new Point(Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.743));
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.743), 0, 0);
                    if (backgroundWorker1.CancellationPending) break;
                    Thread.Sleep(1000*Current.WarpToAB1);
                }
                else
                {
                    Cursor.Position = new Point(AB2.x, AB2.y);
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, AB2.x, AB2.y, 0, 0);
                    Thread.Sleep(1100);
                    Cursor.Position = new Point(Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.757));
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.757), 0, 0);
                    if (backgroundWorker1.CancellationPending) break;
                    Thread.Sleep(1000*Current.WarpToAB2);
                }
                if (backgroundWorker1.CancellationPending) break;
                SendKeys.SendWait("{F1}");
                SendKeys.SendWait("{F3}");
                SendKeys.SendWait("{F5}");
                Cursor.Position = new Point(Asteroid1.x, Asteroid1.y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Asteroid1.x, Asteroid1.y, 0, 0);
                if (backgroundWorker1.CancellationPending) break;
                Thread.Sleep(1100);
                Cursor.Position = new Point(Asteroid2.x, Asteroid2.y);
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, Asteroid2.x, Asteroid2.y, 0, 0);
                Thread.Sleep(1100);
                Cursor.Position = new Point(Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.257));
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.257), 0, 0);
                Thread.Sleep(1000*Current.TargetLock);
                Cursor.Position = new Point(Asteroid2.x, Asteroid2.y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Asteroid2.x, Asteroid2.y, 0, 0);
                Thread.Sleep(1000);
                SendKeys.SendWait("{F2}");
                SendKeys.SendWait("{F4}");
                SendKeys.SendWait("{F6}");
                if (backgroundWorker1.CancellationPending) break;
                Thread.Sleep(1000);
                if(Current.Drones)
                {
                    Cursor.Position = new Point(Drones1.x, Drones1.y);
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, Drones1.x, Drones1.y, 0, 0);
                    Thread.Sleep(1100);
                    Cursor.Position = new Point(Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.567));
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.567), 0, 0);
                }
                if (backgroundWorker1.CancellationPending) break;
                Thread.Sleep(1000*Current.CargoFilling);
                if(Current.Drones)
                {
                    Cursor.Position = new Point(Drones2.x, Drones2.y);
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, Drones2.x, Drones2.y, 0, 0);
                    Thread.Sleep(1100);
                    Cursor.Position = new Point(Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.619));
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.619), 0, 0);
                    Thread.Sleep(3000);
                }
                if (backgroundWorker1.CancellationPending) break;
                Cursor.Position = new Point(Station.x, Station.y);
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, Station.x, Station.y, 0, 0);
                Thread.Sleep(1100);
                Cursor.Position = new Point(Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.827));
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Convert.ToInt32(Current.ResolutionX * 0.853), Convert.ToInt32(Current.ResolutionY * 0.827), 0, 0);
                if (backgroundWorker1.CancellationPending) break;
                if (change)
                {
                    if (Current.Interchange)change=false;
                    Thread.Sleep(1000*Current.WarpToStation1);
                }
                else
                {
                    change=true;
                    Thread.Sleep(1000*Current.WarpToStation2);
                }
                if (backgroundWorker1.CancellationPending) break;
                Thread.Sleep(1000*Current.Dock);
                if (backgroundWorker1.CancellationPending) break;
                Thread.Sleep(2000);
                Cursor.Position = new Point(Cargo1.x, Cargo1.y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, Cargo1.x, Cargo1.y, 0, 0);
                Cursor.Position = new Point(Cargo1.x, Convert.ToInt32(Current.ResolutionY * 0.12));
                Thread.Sleep(1000);
                mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Cargo1.x, Convert.ToInt32(Current.ResolutionY * 0.12), 0, 0);
                //mouse_event(MOUSEEVENTF_ABSOLUTE, Cargo1.x, Convert.ToInt32(Current.ResolutionY * 0.12), 0, 0);
                Thread.Sleep(4000);
                Cursor.Position = new Point(Cargo2.x, Cargo2.y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, Cargo2.x, Cargo2.y, 0, 0);
                Cursor.Position = new Point(Cargo2.x, Convert.ToInt32(Current.ResolutionY * 0.12));
                Thread.Sleep(1000);
                mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, Cargo2.x, Convert.ToInt32(Current.ResolutionY * 0.12), 0, 0);
                //mouse_event(MOUSEEVENTF_ABSOLUTE, Cargo1.x, Convert.ToInt32(Current.ResolutionY * 0.12), 0, 0);
            }
#endregion
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                Current.DeleteProfile(listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                string[] profiles = Profile.GetProfiles();
                if (profiles.Length != 0)
                {
                    foreach (string str in profiles)
                    {
                        listBox1.Items.Add(str);
                    }
                    listBox1.SelectedIndex = 0;
                    if (Current.LoadProfile(listBox1.SelectedItem.ToString())) button2.Enabled = true;
                    else
                    {
                        button2.Enabled = false;
                        Current.Reset();
                    }
                }
                else
                {
                    button2.Enabled = false;
                    Current.Reset();
                }
                textBox1.Text = Current.Undock.ToString();
                textBox2.Text = Current.WarpToAB1.ToString();
                textBox3.Text = Current.WarpToStation1.ToString();
                textBox4.Text = Current.CargoFilling.ToString();
                textBox5.Text = Current.Dock.ToString();
                textBox6.Text = Current.WarpToAB2.ToString();
                textBox7.Text = Current.WarpToStation2.ToString();
                textBox9.Text = Current.ResolutionX.ToString();
                textBox10.Text = Current.ResolutionY.ToString();
                textBox11.Text = Current.TargetLock.ToString();
                checkBox1.Checked = Current.Interchange;
                checkBox2.Checked = Current.Drones;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FieldCheck() != 0)
            {
                backgroundWorker1.RunWorkerAsync();
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("\"Profile name\" field is empty!", "Check \"Profile name\" field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (Current.SaveProfile(textBox8.Text))
                {
                    listBox1.Items.Clear();
                    string[] profiles = Profile.GetProfiles();
                    if (profiles.Length != 0)
                    {
                        foreach (string str in profiles)
                        {
                            listBox1.Items.Add(str);
                        }
                        listBox1.SelectedIndex = listBox1.Items.IndexOf(textBox8.Text);
                        if (Current.LoadProfile(textBox8.Text)) button2.Enabled = true;
                        else
                        {
                            button2.Enabled = false;
                        }
                    }
                    else
                    {
                        button2.Enabled = false;
                        Current.Reset();
                    }
                    textBox1.Text = Current.Undock.ToString();
                    textBox2.Text = Current.WarpToAB1.ToString();
                    textBox3.Text = Current.WarpToStation1.ToString();
                    textBox4.Text = Current.CargoFilling.ToString();
                    textBox5.Text = Current.Dock.ToString();
                    textBox6.Text = Current.WarpToAB2.ToString();
                    textBox7.Text = Current.WarpToStation2.ToString();
                    textBox9.Text = Current.ResolutionX.ToString();
                    textBox10.Text = Current.ResolutionY.ToString();
                    textBox11.Text = Current.TargetLock.ToString();
                    checkBox1.Checked = Current.Interchange;
                    checkBox2.Checked = Current.Drones;
                    textBox8.Text = "";
                    panel1.Visible = false;
                }
                else
                {
                    textBox8.Text = "";
                    panel1.Visible = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            panel1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "")
            {
                if (!Current.LoadProfile(listBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("Error loading profile", "Error loading profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    listBox1.Items.Clear();
                    string[] profiles = Profile.GetProfiles();
                    if (profiles.Length != 0)
                    {
                        foreach (string str in profiles)
                        {
                            listBox1.Items.Add(str);
                        }
                        listBox1.SelectedIndex = 0;
                        if (Current.LoadProfile(listBox1.SelectedItem.ToString())) button2.Enabled = true;
                        else
                        {
                            button2.Enabled = false;
                            Current.Reset();
                        }
                    }
                    else
                    {
                        button2.Enabled = false;
                        Current.Reset();
                    }
                    textBox1.Text = Current.Undock.ToString();
                    textBox2.Text = Current.WarpToAB1.ToString();
                    textBox3.Text = Current.WarpToStation1.ToString();
                    textBox4.Text = Current.CargoFilling.ToString();
                    textBox5.Text = Current.Dock.ToString();
                    textBox6.Text = Current.WarpToAB2.ToString();
                    textBox7.Text = Current.WarpToStation2.ToString();
                    textBox9.Text = Current.ResolutionX.ToString();
                    textBox10.Text = Current.ResolutionY.ToString();
                    textBox11.Text = Current.TargetLock.ToString();
                    checkBox1.Checked = Current.Interchange;
                    checkBox2.Checked = Current.Drones;
                }
                else
                {
                    button2.Enabled = true;
                    textBox1.Text = Current.Undock.ToString();
                    textBox2.Text = Current.WarpToAB1.ToString();
                    textBox3.Text = Current.WarpToStation1.ToString();
                    textBox4.Text = Current.CargoFilling.ToString();
                    textBox5.Text = Current.Dock.ToString();
                    textBox6.Text = Current.WarpToAB2.ToString();
                    textBox7.Text = Current.WarpToStation2.ToString();
                    textBox9.Text = Current.ResolutionX.ToString();
                    textBox10.Text = Current.ResolutionY.ToString();
                    textBox11.Text = Current.TargetLock.ToString();
                    checkBox1.Checked = Current.Interchange;
                    checkBox2.Checked = Current.Drones;
                }
            }
            else
            {
                button2.Enabled = false;
                Current.Reset();
                textBox1.Text = Current.Undock.ToString();
                textBox2.Text = Current.WarpToAB1.ToString();
                textBox3.Text = Current.WarpToStation1.ToString();
                textBox4.Text = Current.CargoFilling.ToString();
                textBox5.Text = Current.Dock.ToString();
                textBox6.Text = Current.WarpToAB2.ToString();
                textBox7.Text = Current.WarpToStation2.ToString();
                textBox9.Text = Current.ResolutionX.ToString();
                textBox10.Text = Current.ResolutionY.ToString();
                textBox11.Text = Current.TargetLock.ToString();
                checkBox1.Checked = Current.Interchange;
                checkBox2.Checked = Current.Drones;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "")
            {
                if (!Current.LoadProfile(listBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("Error loading profile", "Error loading profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    listBox1.Items.Clear();
                    string[] profiles = Profile.GetProfiles();
                    if (profiles.Length != 0)
                    {
                        foreach (string str in profiles)
                        {
                            listBox1.Items.Add(str);
                        }
                        listBox1.SelectedIndex = 0;
                        if (Current.LoadProfile(listBox1.SelectedItem.ToString())) button2.Enabled = true;
                        else
                        {
                            button2.Enabled = false;
                            Current.Reset();
                        }
                    }
                    else
                    {
                        button2.Enabled = false;
                        Current.Reset();
                    }
                    textBox1.Text = Current.Undock.ToString();
                    textBox2.Text = Current.WarpToAB1.ToString();
                    textBox3.Text = Current.WarpToStation1.ToString();
                    textBox4.Text = Current.CargoFilling.ToString();
                    textBox5.Text = Current.Dock.ToString();
                    textBox6.Text = Current.WarpToAB2.ToString();
                    textBox7.Text = Current.WarpToStation2.ToString();
                    textBox9.Text = Current.ResolutionX.ToString();
                    textBox10.Text = Current.ResolutionY.ToString();
                    textBox11.Text = Current.TargetLock.ToString();
                    checkBox1.Checked = Current.Interchange;
                    checkBox2.Checked = Current.Drones;
                }
                else
                {
                    button2.Enabled = true;
                    textBox1.Text = Current.Undock.ToString();
                    textBox2.Text = Current.WarpToAB1.ToString();
                    textBox3.Text = Current.WarpToStation1.ToString();
                    textBox4.Text = Current.CargoFilling.ToString();
                    textBox5.Text = Current.Dock.ToString();
                    textBox6.Text = Current.WarpToAB2.ToString();
                    textBox7.Text = Current.WarpToStation2.ToString();
                    textBox9.Text = Current.ResolutionX.ToString();
                    textBox10.Text = Current.ResolutionY.ToString();
                    textBox11.Text = Current.TargetLock.ToString();
                    checkBox1.Checked = Current.Interchange;
                    checkBox2.Checked = Current.Drones;
                }
            }
            else
            {
                button2.Enabled = false;
                Current.Reset();
                textBox1.Text = Current.Undock.ToString();
                textBox2.Text = Current.WarpToAB1.ToString();
                textBox3.Text = Current.WarpToStation1.ToString();
                textBox4.Text = Current.CargoFilling.ToString();
                textBox5.Text = Current.Dock.ToString();
                textBox6.Text = Current.WarpToAB2.ToString();
                textBox7.Text = Current.WarpToStation2.ToString();
                textBox9.Text = Current.ResolutionX.ToString();
                textBox10.Text = Current.ResolutionY.ToString();
                textBox11.Text = Current.TargetLock.ToString();
                checkBox1.Checked = Current.Interchange;
                checkBox2.Checked = Current.Drones;
            }
        }
    }
}