using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MEOMB
{
    public class Profile
    {
        public int Undock=1;
        public int WarpToAB1=1;
        public int WarpToStation1=1;
        public bool Interchange;
        public int WarpToAB2=1;
        public int WarpToStation2=1;
        public int CargoFilling=1;
        public int Dock=1;
        public bool Drones;
        public int ResolutionX=1;
        public int ResolutionY=1;
        public int TargetLock = 1;
        public static string[] GetProfiles()
        {
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(Environment.CurrentDirectory);
                FileInfo[] MEOMBPFiles = Dir.GetFiles("*.meombp");
                string[] Names = new string[MEOMBPFiles.Length];
                for (int i = 0; i < MEOMBPFiles.Length; ++i)
                {
                    Names[i] = MEOMBPFiles[i].Name.Substring(0, MEOMBPFiles[i].Name.Length-7);
                }
                return Names;
            }
            catch(Exception e)
            {
                string[] Names = new string[0];
                return Names;
            }
        }
        public bool LoadProfile(string name)
        {
            try
            {
                    if (File.Exists(@name+".meombp"))
                    {
                        XmlSerializer XmlSer = new XmlSerializer(typeof(Profile));
                        FileStream Set = new FileStream(Environment.CurrentDirectory +@"\"+ @name + ".meombp", FileMode.Open);
                        Profile P = (Profile)XmlSer.Deserialize(Set);
                        Set.Close();
                        this.Undock = P.Undock;
                        this.WarpToAB1 = P.WarpToAB1;
                        this.WarpToStation1 = P.WarpToStation1;
                        this.Interchange = P.Interchange;
                        this.WarpToAB2 = P.WarpToAB2;
                        this.WarpToStation2 = P.WarpToStation2;
                        this.CargoFilling = P.CargoFilling;
                        this.Dock = P.Dock;
                        this.Drones = P.Drones;
                        this.ResolutionX = P.ResolutionX;
                        this.ResolutionY = P.ResolutionY;
                        this.TargetLock = P.TargetLock;
                        return true;
                    }
                    else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception loading profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        public bool SaveProfile(string name)
        {
            Profile P = new Profile();
            P.Undock=this.Undock;
            P.WarpToAB1=this.WarpToAB1;
            P.WarpToStation1=this.WarpToStation1;
            P.Interchange=this.Interchange;
            P.WarpToAB2=this.WarpToAB2;
            P.WarpToStation2=this.WarpToStation2;
            P.CargoFilling=this.CargoFilling ;
            P.Dock=this.Dock;
            P.Drones=this.Drones;
            P.ResolutionX=this.ResolutionX;
            P.ResolutionY=this.ResolutionY;
            P.TargetLock = this.TargetLock;
            try
            {
                XmlSerializer XmlSer = new XmlSerializer(P.GetType());
                StreamWriter Writer = new StreamWriter(Environment.CurrentDirectory + @"\" + @name + ".meombp");
                XmlSer.Serialize(Writer, P);
                Writer.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception saving profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        public bool DeleteProfile(string name)
        {
            try
            {
                File.Delete(Environment.CurrentDirectory + @"\" + @name + ".meombp");
                this.Reset();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error deleting profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        public static bool IntVal(string val)
        {
            if (Regex.IsMatch(val, @"^\d+$"))
            {
                try
                {
                    if ((Convert.ToInt32(val)) > 0 && (Convert.ToInt32(val)) < (Math.Abs(Int32.MaxValue)))
                    {
                        return true;
                    }
                    else return false;
                }
                catch (OverflowException)
                {
                    return false;
                }
            }
            else return false;
        }
        public void Reset()
        {
            this.CargoFilling = 1;
            this.Dock = 1;
            this.Drones = false;
            this.Interchange = false;
            this.ResolutionX = 1;
            this.ResolutionY = 1;
            this.Undock = 1;
            this.WarpToAB1 = 1;
            this.WarpToAB2 = 1;
            this.WarpToStation1 = 1;
            this.WarpToStation2 = 1;
            this.TargetLock = 1;
        }
    }
}
