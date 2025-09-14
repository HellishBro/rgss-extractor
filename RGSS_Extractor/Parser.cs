using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RGSS_Extractor
{
    internal abstract class Parser
    {
        protected BinaryReader inFile;

        protected BinaryWriter outFile;

        protected int magicKey;

        public List<Entry> entries = new List<Entry>();

        protected byte[] data;

        public Parser(BinaryReader file)
        {
            inFile = file;
        }

        public static string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public void CreateFile(string path)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path2 = Path.Combine(directoryName, Path.GetDirectoryName(path));
            string path3 = Path.Combine(directoryName, path);
            Directory.CreateDirectory(path2);
            outFile = new BinaryWriter(File.OpenWrite(path3));
        }

        public byte[] ReadData(long offset, long size, int dataKey)
        {
            inFile.BaseStream.Seek(offset, SeekOrigin.Begin);
            data = inFile.ReadBytes((int)size);
            int num = (int)size / 4;
            int i;
            for (i = 0; i < num; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    byte[] expr_43_cp_0 = data;
                    int expr_43_cp_1 = i * 4 + j;
                    expr_43_cp_0[expr_43_cp_1] ^= (byte)(dataKey >> 8 * j);
                }

                dataKey = dataKey * 7 + 3;
            }

            int num2 = i * 4;
            while (num2 < size)
            {
                byte[] expr_82_cp_0 = data;
                int expr_82_cp_1 = num2;
                expr_82_cp_0[expr_82_cp_1] ^= (byte)(dataKey >> 8 * num2);
                num2++;
            }

            return data;
        }

        public void WriteFile(Entry e, string path)
        {
            CreateFile(Path.Join(path, e.Name));
            data = ReadData(e.Offset, e.Size, e.DataKey);
            outFile.Write(data);
            outFile.Close();
            Console.WriteLine("{0} wrote out successfully", e.Name);
        }

        public void WriteEntries(string path)
        {
            foreach (var entry in entries)
            {
                WriteFile(entry, path);
            }
        }

        public void CloseFile()
        {
            inFile.Close();
        }

        public abstract void ParseFile();
    }
}