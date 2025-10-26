using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO.Compression;
using System.IO.Compression;
using System.Net.Security;
namespace File_Organizer
{
    internal class Program
    {
        string folderPath = "";
        string s = Directory.GetCurrentDirectory();
        static bool hasstarted = false;
        static void Main(string[] args)
        { Program p = new Program();
            char s;
            hasstarted = true;


            while (hasstarted == true)
            {
                Console.WriteLine("Welcome to XFR. What Would You Like to Do?");
                Console.WriteLine("Please Input a Number.");
                Console.WriteLine("1:Initialize Sorting Folder");
                Console.WriteLine("2:Create Backup of File's");
                Console.WriteLine("3:Sort File's");
                Console.WriteLine("4:Restore Folder's");
                Console.WriteLine("5:Compress File's");
                Console.WriteLine("6:Stop");
                s = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (s)
                {
                    case '1':
                        p.initialize();
                        break;
                    case '2':
                        p.CopyItems();
                        break;
                    case '3':
                        p.MoveItemss();
                        break;
                    case '4':
                        p.initialize();
                        break;


                    case '5':
                        p.Compress();
                        break;
                    case '6':
                        hasstarted = false;
                        break;
                }




            }

        }
        public void initialize()
        {


            if ((Directory.Exists(s + @"\Backup") == false))
            {
                Directory.CreateDirectory(s + @"\Archives");
                Directory.CreateDirectory(s + @"\Backup");
                Directory.CreateDirectory(s + @"\Backup\100GB+");
                Directory.CreateDirectory(s + @"\Backup\80-100GB");
                Directory.CreateDirectory(s + @"\Backup\50-80GB");
                Directory.CreateDirectory(s + @"\Backup\10-50GB");
                Directory.CreateDirectory(s + @"\Backup\1-10GB");
                Directory.CreateDirectory(s + @"\Backup\1GB BELOW");
                Directory.CreateDirectory(s + @"\Add Stuff Here");
            }
            else if ((Directory.Exists(s + @"\Add Stuff Here") == true))
            {
                Console.WriteLine("Folder's Already Created");
            }

            string[] dirs = Directory.GetDirectories(s + @"\Add Stuff Here");
            foreach (string dir in dirs)
            {

                Console.WriteLine(dir);
            }
        }

        public void CopyItems()
        {
            int i = 0;
            hasstarted = false;
            var files = Directory.GetFiles(s + @"\Add Stuff Here", "*", SearchOption.AllDirectories);
            List<FileInfo> list = new List<FileInfo>();

            foreach (string file in files)
            {
                list.Add(new FileInfo(file));


            }
            i++;

            try
            {
                foreach (var item in list)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (((double)item.Length / 1000 / 1000 / 1000) < 1)
                    {
                        File.Copy(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\1GB BELOW\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }
                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 10 && ((double)item.Length / 1000 / 1000 / 1000) > 1)
                    {
                        File.Copy(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\1-10GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }

                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 50 && ((double)item.Length / 1000 / 1000 / 1000) > 100)
                    {
                        File.Copy(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\10-50GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }
                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 80 && ((double)item.Length / 1000 / 1000 / 1000) > 50)
                    {
                        File.Copy(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\50-80GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }
                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 100 && ((double)item.Length / 1000 / 1000 / 1000) > 80)
                    {
                        File.Copy(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\80-100GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }

                    else
                    {
                        File.Copy(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\100GB+\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");
                    }






                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Duplicates Already Exist");
                Console.ForegroundColor = ConsoleColor.White;
            }
            hasstarted = true;
        }




        public void MoveItemss()
        {
            int i = 0;
            hasstarted = false;
            var files = Directory.GetFiles(s + @"\Add Stuff Here", "*", SearchOption.AllDirectories);
            List<FileInfo> list = new List<FileInfo>();

            foreach (string file in files)
            {
                list.Add(new FileInfo(file));


            }
            i++;

            try
            {
                foreach (var item in list)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (((double)item.Length / 1000 / 1000 / 1000) < 1)
                    {
                        File.Move(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\1GB BELOW\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");
                    }
                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 10 && ((double)item.Length / 1000 / 1000 / 1000) > 1)
                    {
                        File.Move(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\1-10GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }

                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 50 && ((double)item.Length / 1000 / 1000 / 1000) > 100)
                    {
                        File.Move(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\10-50GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }
                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 80 && ((double)item.Length / 1000 / 1000 / 1000) > 50)
                    {
                        File.Move(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\50-80GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }
                    else if (((double)item.Length / 1000 / 1000 / 1000) <= 100 && ((double)item.Length / 1000 / 1000 / 1000) > 80)
                    {
                        File.Move(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\80-100GB\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");

                    }

                    else
                    {
                        File.Move(s + @"\Add Stuff Here\" + item.Name, s + @"\Backup\100GB+\" + item.Name);
                        Console.WriteLine(item.Name + " " + Math.Round(((double)item.Length / 1000 / 1000 / 1000), 2) + "GB");
                    }






                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Duplicates Already Exist");
                Console.ForegroundColor = ConsoleColor.White;
            }
            hasstarted = true;
        }





        public void Compress()
        {
            int i = 0;
            hasstarted = false;
            var files = Directory.GetFiles(s + @"\Add Stuff Here", "*", SearchOption.AllDirectories);
            List<FileInfo> list = new List<FileInfo>();

            foreach (string file in files)
            {
                list.Add(new FileInfo(file));


            }
            i++;
            Console.WriteLine(" What Would You Like to Compress?");
            Console.WriteLine("Please Input a Number.");
            Console.WriteLine("1:1GB Below Folder");
            Console.WriteLine("2:1-10GB Below Folder");
            Console.WriteLine("3:10-50GB Below Folder");
            Console.WriteLine("4:50-80GB Below Folder");
            Console.WriteLine("5:80-100GB Below Folder");
            Console.WriteLine("6:100GB+  Folder");
            Console.WriteLine("7:Cancel");
            char a = Console.ReadKey().KeyChar;


            try
            {

                switch (a)
                {

                    case '1':
                        ZipFile.CreateFromDirectory(s + @"\Backup\1GB BELOW\", s + @"\Archives\1GB.zip", CompressionLevel.Fastest, true);
                        Console.WriteLine(@"\Backup\1GB BELOW\" + "Has Been Compressed");

                        break;

                    case '2':
                        ZipFile.CreateFromDirectory(s + @"\Backup\1-10GB\",s+ @"\Archives\1_10GB.zip", CompressionLevel.Fastest, true);
                        Console.WriteLine(@"\Backup\1GB BELOW\" + "Has Been Compressed");
                        break;
                    case '3':
                        ZipFile.CreateFromDirectory(s + @"\Backup\10-50GB\", s + @"\Archives\", CompressionLevel.Fastest, true);
                        Console.WriteLine(@"\Backup\1GB BELOW\" + "Has Been Compressed");
                        break;
                    case '4':
                        ZipFile.CreateFromDirectory(s + @"\Backup\50-80GB\", s + @"\Archives\", CompressionLevel.Fastest, true);
                        Console.WriteLine(@"\Backup\1GB BELOW\" + "Has Been Compressed");
                        break;
                    case '5':
                        ZipFile.CreateFromDirectory(s + @"\Backup\80-100GB\", s + @"\Archives\", CompressionLevel.Fastest, true);
                        Console.WriteLine(@"\Backup\1GB BELOW\" + "Has Been Compressed");
                        break;

                    case '6':
                        ZipFile.CreateFromDirectory(s + @"\Backup\100GB\", @"\Archives\", CompressionLevel.Fastest, true);
                        Console.WriteLine(@"\Backup\1GB BELOW\" + "Has Been Compressed");
                        break;

                    case '7':
                        hasstarted = false;
                        break;



                }
            }

            catch(IOException)
            {

            }










            hasstarted = true;
        }
    } }


