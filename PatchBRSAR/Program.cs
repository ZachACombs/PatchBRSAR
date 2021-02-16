using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatchBRSAR
{
    enum PatchMode
    {
        Null=-1,
        File=0,
        Folder=1,
    }
    class OptionString
    {
        public string Value { get; }
        public OptionString(string value)
        {
            Value = value;
        }
    }
    class OptionBool
    {
        public bool Value { get; }
        public OptionBool(bool value)
        {
            Value = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            void ShowInfo()
            {
                AdvConsole.WriteLine(ConsoleColor.Cyan,
                    "PatchBRSAR\n" +
                    "by Zach Combs\n" +
                    "\n" +
                    "\n" +
                    "PatchBRSAR file <input file> <source brstm file> [<option 1>...<option N>]\n" +
                    "PatchBRSAR folder <input file> <source brstm folder> [<option 1>...<option N>]\n" +
                    "\n" +
                    "\n" +
                    "Options\n" +
                    "output=<filename>       Saves patched BRSAR to <filename>\n" +
                    "mkwbrstm=<brstmname>    Name of MKW BRSTM file in entry to patch\n" +
                    "                            (Only used in \"file\" mode)\n" +
                    "showfileinfo            Shows info about input BRSAR file"
                    );
            }
            void ShowError(string s)
            {
                AdvConsole.WriteLine(ConsoleColor.Red,
                    "ERROR: " + s
                    );
            }
            
            if (args == null)
            {
                ShowInfo();
            }
            else
            {
                if (args.Length == 0)
                {
                    ShowInfo();
                }
                else
                {
                    if (args.Length < 1)
                    {
                        ShowError(
                            "You must specify a patch mode (\"file\" or \"folder\")"
                            );
                    }
                    else
                    {
                        try
                        {
                            PatchMode patchmode;
                            #region Read Patch Mode
                            string strpatchmode = args[0];
                            if (strpatchmode == "file") patchmode = PatchMode.File;
                            else if (strpatchmode == "folder") patchmode = PatchMode.Folder;
                            else
                            {
                                patchmode = PatchMode.Null;
                                ShowError(String.Format(
                                    "Unknown patch mode: \"{0}\""
                                    , strpatchmode));
                            }
                            #endregion

                            bool cont = true;

                            string source_brsar = "";
                            string dest_brsar = "";
                            string file_brstm = "";
                            string folder_brstm = "";
                            bool showfileinfo = false;
                            OptionString option_output = null;
                            OptionString option_mkwbrstm = null;
                            OptionBool option_showfileinfo = null;
                            #region Extract arguments and options
                            bool CheckArgCountAndFindOptions(int optionargsstart, out string[] arrguments)
                            {
                                if ((args.Length - 1) >= optionargsstart)
                                {
                                    arrguments = new string[optionargsstart];
                                    Array.Copy(args,
                                        1,
                                        arrguments, 0,
                                        arrguments.Length
                                        );
                                    int n = optionargsstart + 1;
                                    bool kill = false;
                                    while (n < args.Length & (!kill))
                                    {
                                        string arg = args[n];
                                        OptionString str_option;
                                        OptionString str_value;
                                        int equaloffset = arg.IndexOf("=");
                                        if (equaloffset == -1)
                                        {
                                            str_option = new OptionString(arg);
                                            str_value = null;
                                        }
                                        else
                                        {
                                            str_option = new OptionString(arg.Substring(0, equaloffset));
                                            str_value = new OptionString(arg.Substring(equaloffset + 1));
                                        }

                                        //Options with a defintion
                                        if (str_option.Value == "output")
                                        {
                                            if (str_value != null)
                                            {
                                                option_output = new OptionString(str_value.Value);
                                            }
                                            else
                                            {
                                                ShowError(String.Format(
                                                    "\"{0}\" needs a definition"
                                                    , str_option.Value));
                                                kill = true;
                                            }
                                        }
                                        else if (str_option.Value == "mkwbrstm")
                                        {
                                            if (patchmode == PatchMode.File)
                                            {
                                                if (str_value != null)
                                                {
                                                    option_mkwbrstm = new OptionString(str_value.Value);
                                                }
                                                else
                                                {
                                                    ShowError(String.Format(
                                                        "\"{0}\" needs a definition"
                                                        , str_option.Value));
                                                    kill = true;
                                                }
                                            }
                                            else
                                            {
                                                ShowError(
                                                "\"mkwbrstm\" can be defined in \"file\" mode"
                                                );
                                                kill = true;
                                            }
                                        }
                                        
                                        //Options without a defintion
                                        else if (str_option.Value == "showfileinfo")
                                        {
                                            if (str_value == null)
                                            {
                                                option_showfileinfo = new OptionBool(true);
                                            }
                                            else
                                            {
                                                ShowError(String.Format(
                                                    "\"{0}\" doesn't have a definition"
                                                    , str_option.Value));
                                                kill = true;
                                            }
                                        }

                                        //Unknown option
                                        else
                                        {
                                            ShowError(String.Format(
                                                "Unknown option: \"{0}\""
                                                , str_option.Value));
                                            kill = true;
                                        }

                                        n += 1;
                                    }

                                    if (kill)
                                    {
                                        arrguments = null;
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    ShowError(
                                        "Not enough arguments"
                                        );
                                    arrguments = null;
                                    return false;
                                }
                            }
                            if (patchmode == PatchMode.File)
                            {
                                string[] arguments = null;
                                if (CheckArgCountAndFindOptions(2, out arguments))
                                {
                                    source_brsar = arguments[0];
                                    dest_brsar = arguments[0];
                                    file_brstm = arguments[1];
                                }
                                else
                                {
                                    cont = false;
                                }
                            }
                            else if (patchmode == PatchMode.Folder)
                            {
                                string[] arguments = null;
                                if (CheckArgCountAndFindOptions(2, out arguments))
                                {
                                    source_brsar = arguments[0];
                                    dest_brsar = arguments[0];
                                    folder_brstm = arguments[1];
                                }
                                else
                                {
                                    cont = false;
                                }
                            }
                            if (option_output != null)
                            {
                                dest_brsar = option_output.Value;
                            }
                            if (option_showfileinfo != null)
                            {
                                showfileinfo = option_showfileinfo.Value;
                            }
                            #endregion

                            #region Check if files/directories exist
                            if (cont)
                            {
                                if (!File.Exists(source_brsar))
                                {
                                    cont = false;
                                    ShowError(String.Format(
                                        "\"{0}\" does not exist"
                                        , source_brsar));
                                }
                                else if (patchmode == PatchMode.File & !File.Exists(file_brstm))
                                {
                                    cont = false;
                                    ShowError(String.Format(
                                        "\"{0}\" does not exist"
                                        , file_brstm));
                                }
                                else if (patchmode == PatchMode.Folder & !Directory.Exists(folder_brstm))
                                {
                                    cont = false;
                                    ShowError(String.Format(
                                        "\"{0}\" does not exist"
                                        , folder_brstm));
                                }
                                else if (option_output != null & File.Exists(dest_brsar))
                                {
                                    cont = false;
                                    ShowError(String.Format(
                                        "\"{0}\" already exists"
                                        , dest_brsar));
                                }
                            }
                            #endregion

                            Dictionary<string, string> fnames = new Dictionary<string, string>();
                                //key:   mkwii filenames
                                //value: user filenames
                            #region Load files
                            string FixMKWFileName(string fname)
                            {
                                string newname = fname.Replace("\\", "/");

                                int lastindexof = newname.LastIndexOf("/");
                                if (lastindexof != -1)
                                {
                                    newname = newname.Substring(lastindexof + 1);
                                }
                                newname = "strm/" + newname;

                                int indexofperiod = newname.LastIndexOf(".");
                                if (indexofperiod != -1)
                                {
                                    newname = newname.Substring(0, indexofperiod);
                                }
                                newname = newname + ".brstm";

                                return newname;
                            }
                            if (cont)
                            {
                                if (patchmode == PatchMode.File)
                                {
                                    string key;
                                    string value = file_brstm;
                                    if (option_mkwbrstm != null)
                                    {
                                        key = FixMKWFileName(option_mkwbrstm.Value);
                                    }
                                    else
                                    {
                                        key = FixMKWFileName(value);
                                    }
                                    fnames.Add(key, value);
                                }
                                else if (patchmode == PatchMode.Folder)
                                {
                                    string[] files = Directory.GetFiles(folder_brstm);
                                    for (int n = 0; n < files.Length; n += 1)
                                    {
                                        string file = files[n];

                                        if (Path.GetExtension(file) == ".brstm")
                                        {
                                            string key = FixMKWFileName(Path.GetFileName(file));
                                            string value = file;
                                            fnames.Add(key, value);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region Open and Patch BRSAR
                            int initialfnamecount = fnames.Count;
                            byte[] GetSection(
                                string sectionname,
                                byte[] array,
                                long offsett,
                                long uint32offsetbytesstart,
                                long uint32sizebytesstart)
                            {
                                const string space = "                       ";
                                
                                byte[] byte_offset = { 0, 0, 0, 0,
                                    array[uint32offsetbytesstart],
                                    array[uint32offsetbytesstart+1],
                                    array[uint32offsetbytesstart+2],
                                    array[uint32offsetbytesstart+3],
                                };
                                Array.Reverse(byte_offset);
                                long offset = BitConverter.ToInt64(byte_offset, 0) + offsett;
                                if (showfileinfo & sectionname != "") AdvConsole.WriteLine(ConsoleColor.Green,
                                    "{0}  {1}",
                                    (sectionname + " Offset:" + space).Substring(0, space.Length)
                                    , offset);

                                long size;
                                if (uint32sizebytesstart > 0x00)
                                {
                                    byte[] byte_size = { 0, 0, 0, 0,
                                        array[uint32sizebytesstart],
                                        array[uint32sizebytesstart+1],
                                        array[uint32sizebytesstart+2],
                                        array[uint32sizebytesstart+3],
                                    };
                                    Array.Reverse(byte_size);
                                    size = BitConverter.ToInt64(byte_size, 0);
                                    if (showfileinfo & sectionname != "") AdvConsole.WriteLine(ConsoleColor.Green,
                                        "{0}  {1}",
                                        (sectionname + " Size:" + space).Substring(0, space.Length)
                                        , size);
                                }
                                else
                                {
                                    size = array.Length - offset;
                                }

                                byte[] data = new byte[size];
                                Array.Copy(array, offset, data, 0, size);
                                
                                return data;
                            }
                            long GetUInt32(
                                string propertyname,
                                byte[] array,
                                long uint32bytesstart)
                            {
                                const string space = "                       ";

                                byte[] byte_value = { 0, 0, 0, 0,
                                    array[uint32bytesstart],
                                    array[uint32bytesstart+1],
                                    array[uint32bytesstart+2],
                                    array[uint32bytesstart+3],
                                };
                                Array.Reverse(byte_value);
                                long value = BitConverter.ToInt64(byte_value, 0);
                                if (showfileinfo & propertyname!="") AdvConsole.WriteLine(ConsoleColor.Green,
                                    "{0}  {1}",
                                    (propertyname + ":" + space).Substring(0, space.Length)
                                    , value);

                                return value;
                            }
                            string GetString(
                                byte[] array,
                                long uint32bytesstart)
                            {
                                List<byte> string_bytes = new List<byte>();
                                long pos = uint32bytesstart;
                                bool stop = false;
                                while (pos < array.LongLength & !stop)
                                {
                                    byte value = array[pos];
                                    if (value == 0x00)
                                    {
                                        stop = true;
                                    }
                                    else
                                    {
                                        string_bytes.Add(value);
                                    }

                                    pos += 1;
                                }

                                return Encoding.ASCII.GetString(string_bytes.ToArray());
                            }
                            void SetUInt32(
                                byte[] array,
                                long uint32bytesstart,
                                long value)
                            {
                                byte[] byte_value = BitConverter.GetBytes(value);
                                Array.Reverse(byte_value);
                                array[uint32bytesstart] = byte_value[4];
                                array[uint32bytesstart+1] = byte_value[5];
                                array[uint32bytesstart+2] = byte_value[6];
                                array[uint32bytesstart+3] = byte_value[7];
                            }
                            if (cont)
                            {
                                byte[] brsar_data = File.ReadAllBytes(source_brsar);

                                //Find INFO section
                                long offset = 8;
                                byte[] info_data = GetSection("INFO", brsar_data, 0, 0x18, 0x1C);
                                long info_offset = GetUInt32("", brsar_data, 0x18);
                                
                                //Find collection table
                                byte[] collection_data = GetSection("Collection", info_data, offset, 0x24, 0x00);
                                
                                //Find entries
                                long CollectionTableEntryCount = GetUInt32("Entry Count", collection_data, 0x00);
                                List<string> entries = new List<string>();
                                AdvConsole.Write(ConsoleColor.Green, "Searching Entries: ");
                                int top = Console.CursorTop;
                                int left = Console.CursorLeft;
                                for (long n = 0; n <= CollectionTableEntryCount; n += 1)
                                {
                                    Console.CursorTop = top;
                                    Console.CursorLeft = left;
                                    AdvConsole.Write(ConsoleColor.Green,
                                        "                                                          "
                                        );
                                    Console.CursorTop = top;
                                    Console.CursorLeft = left;
                                    AdvConsole.Write(ConsoleColor.Green,
                                        "{0}/{1}  "
                                        , n, CollectionTableEntryCount);

                                    if (n < CollectionTableEntryCount)
                                    {
                                        byte[] entry_data = new byte[0x20];
                                        long entryoffset = GetUInt32("", collection_data, 0x08 + n * 8);
                                        Array.Copy(info_data,
                                            entryoffset,
                                            entry_data, 0, 0x20
                                            );

                                        long filelength = GetUInt32("", entry_data, 0x00);

                                        long filenameoffset = GetUInt32("", entry_data, 0x18);
                                        string filename = GetString(
                                            info_data,
                                            filenameoffset + 8);
                                        AdvConsole.Write(ConsoleColor.Green, "{0}", filename);

                                        if (fnames.ContainsKey(filename))
                                        {
                                            string userfname = fnames[filename];
                                            byte[] userfiledata = File.ReadAllBytes(userfname);
                                            SetUInt32(
                                                brsar_data,
                                                info_offset + entryoffset + offset,
                                                userfiledata.Length);
                                            fnames.Remove(filename);
                                        }

                                        entries.Add(filename);
                                    }
                                }
                                Console.WriteLine();
                                AdvConsole.WriteLine(ConsoleColor.Green,
                                    "{0} out of {1} entries patched",
                                    initialfnamecount - fnames.Count, initialfnamecount);
                                
                                AdvConsole.WriteLine(ConsoleColor.Green, 
                                    "Saving BRSAR"
                                    );
                                File.WriteAllBytes(dest_brsar, brsar_data);

                                AdvConsole.WriteLine(ConsoleColor.Green,
                                    "Done"
                                    );
                            }

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            ShowError(
                                "Cannot complete command\n" +
                                ex.Message
                                );
                        }
                    }
                }
            }
        }
    }
}
