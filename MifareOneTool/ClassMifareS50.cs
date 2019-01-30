using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace MifareOneTool
{
    class Utils
    {
        public static string Hex2Str(byte[] bytes)
        {
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                ret.AppendFormat("{0:x2}", b);
            }
            return ret.ToString();
        }
        public static string Hex2StrWithSpan(byte[] bytes)
        {
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                ret.AppendFormat("{0:x2}", b);
                ret.Append(" ");
            }
            return ret.ToString();
        }
        public static byte[] Hex2Block(string hex, int bytelen)
        {
            hex = hex.Replace(" ", "");
            byte[] returnBytes = new byte[bytelen];
            for (int i = 0; i < bytelen; i++)
                returnBytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        public static byte[] ReadAC(byte[] ac)
        {
            byte[] acbits = new byte[4];
            acbits[0] = (byte)(((ac[2] & 0x10) >> 4)
                + ((ac[2] & 0x01) << 1)
                + ((ac[1] & 0x10) >> 2));
            acbits[1] = (byte)(((ac[2] & 0x20) >> 5)
                + ((ac[2] & 0x02))
                + ((ac[1] & 0x20) >> 3));
            acbits[2] = (byte)(((ac[2] & 0x40) >> 6)
                + ((ac[2] & 0x04) >> 1)
                + ((ac[1] & 0x40) >> 4));
            acbits[3] = (byte)(((ac[2] & 0x80) >> 7)
                + ((ac[2] & 0x08) >> 2)
                + ((ac[1] & 0x80) >> 5));
            return acbits;
        }
        public static byte[] ReadRAC(byte[] ac)
        {
            byte[] acbits = new byte[4];
            for (int i = 0; i < ac.Length; i++)
            {
                ac[i] = (byte)~ac[i];
            }
            acbits[0] = (byte)(((ac[0] & 0x01) << 2)
                + ((ac[0] & 0x10) >> 3)
                + ((ac[1] & 0x01)));
            acbits[1] = (byte)(((ac[0] & 0x02) << 1)
                + ((ac[0] & 0x20) >> 4)
                + ((ac[1] & 0x02) >> 1));
            acbits[2] = (byte)(((ac[0] & 0x04))
                + ((ac[0] & 0x40) >> 5)
                + ((ac[1] & 0x04) >> 2));
            acbits[3] = (byte)(((ac[0] & 0x08) >> 1)
                + ((ac[0] & 0x80) >> 6)
                + ((ac[1] & 0x08) >> 3));
            return acbits;
        }
        public static byte[] GenAC(byte[] ac)
        {
            byte[] acbits = new byte[4];
            acbits[3] = 0x00;
            acbits[1] = (byte)(((ac[0] << 2) & 0x10)
                | ((ac[1] << 3) & 0x20)
                | ((ac[2] << 4) & 0x40)
                | ((ac[3] << 5) & 0x80));
            acbits[2] = (byte)(((ac[0] >> 1) & 0x01)
                | ((ac[1]) & 0x02)
                | ((ac[2] << 1) & 0x04)
                | ((ac[3] << 2) & 0x08)
                | ((ac[0] << 4) & 0x10)
                | ((ac[1] << 5) & 0x20)
                | ((ac[2] << 6) & 0x40)
                | ((ac[3] << 7) & 0x80));
            for (int i = 0; i < ac.Length; i++)
            {
                ac[i] = (byte)~ac[i];
            }
            acbits[1] = (byte)(acbits[1] |
                ((ac[0]) & 0x01)
                | ((ac[1] << 1) & 0x02)
                | ((ac[2] << 2) & 0x04)
                | ((ac[3] << 3) & 0x08));
            acbits[0] = (byte)(((ac[0] >> 2) & 0x01)
                | ((ac[1] >> 1) & 0x02)
                | ((ac[2]) & 0x04)
                | ((ac[3] << 1) & 0x08)
                | ((ac[0] << 3) & 0x10)
                | ((ac[1] << 4) & 0x20)
                | ((ac[2] << 5) & 0x40)
                | ((ac[3] << 6) & 0x80));
            return acbits;
        }
        //public static bool DtKeyAB(byte[] ac)
        //{
        //    byte[] acbits = new byte[4];
        //    acbits[0] = (byte)(((ac[2] & 0x10) >> 4)
        //        + ((ac[2] & 0x01) << 1)
        //        + ((ac[1] & 0x10) >> 2));
        //    acbits[1] = (byte)(((ac[2] & 0x20) >> 5)
        //        + ((ac[2] & 0x02))
        //        + ((ac[1] & 0x20) >> 3));
        //    acbits[2] = (byte)(((ac[2] & 0x40) >> 6)
        //        + ((ac[2] & 0x04) >> 1)
        //        + ((ac[1] & 0x40) >> 4));
        //    acbits[3] = (byte)(((ac[2] & 0x80) >> 7)
        //        + ((ac[2] & 0x08) >> 2)
        //        + ((ac[1] & 0x80) >> 5));
        //    return acbits;
        //}
    }
    enum AccessBitsT
    {
        KeyAW_KeyAR_KeyARW,
        keyAW_KeyARW_KeyARW,
        Never_KeyAR_KeyAR,
        KeyBW_KeyABRKeyBW_KeyBW,
        KeyBW_KeyABR_KeyBW,
        Never_KeyABRKeyBW_Never,
        Never_KeyABR_Never,
        Never_KeyABR_Never2
    }
    enum AccessBitsD
    {
        AB_AB_AB_AB,
        AB_N_N_AB,
        AB_N_N_N,
        B_B_N_N,
        AB_B_N_N,
        B_N_N_N,
        AB_B_B_AB,
        N_N_N_N
    }
    class Sector
    {
        private byte[][] _sector = new byte[4][] { new byte[16], new byte[16], new byte[16], new byte[16], };
        public byte[][] Block
        {
            get { return _sector; }
            set { _sector = value; }
        }
        private bool _isSector0 = false;
        public bool IsSector0
        {
            get { return _isSector0; }
            set { _isSector0 = value; }
        }
        public void Wipe()
        {
            byte[] zeroBlock = this._sector[0];
            this._sector = new byte[4][]{
            new byte[16]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
            new byte[16]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
            new byte[16]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00},
            new byte[16]{0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,
                0xFF,0x07,0x80,0x69,
                0xFF,0xFF,0xFF,0xFF,0xFF,0xFF},
        };
            if (this._isSector0)
            {
                this._sector[0] = zeroBlock;
            }
        }
        public Sector(bool sector0 = false)
        {
            this._isSector0 = sector0;
            this.Wipe();
            if (sector0)
            {
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] uid = new byte[4];
                rng.GetNonZeroBytes(uid);
                byte bcc = (byte)(uid[0] ^ uid[1] ^ uid[2] ^ uid[3]);
                this._sector[0] = new byte[16] { uid[0], uid[1], uid[2], uid[3], bcc, 0x08, 0x04, 0x00, 
                    0x62, 0x63, 0x64, 0x65, 0x66,0x67,0x68,0x69 };
            }
        }
        public Sector(byte[] uid)
        {
            if (uid.Length != 4) { throw new Exception("不恰当的4字节UID长度"); }
            this._isSector0 = true;
            this.Wipe();
            byte bcc = (byte)(uid[0] ^ uid[1] ^ uid[2] ^ uid[3]);
            this._sector[0] = new byte[16] { uid[0], uid[1], uid[2], uid[3], bcc, 0x08, 0x04, 0x00, 
                    0x62, 0x63, 0x64, 0x65, 0x66,0x67,0x68,0x69 };
        }
        public int Verify()
        {
            /* 检验该块内容是否合法
             * 0块：检查BCC
             * 非0块：检查访问控制
             * ********
             * 0000：正常
             * 0001：BCC错
             * 0010：访问控制无效
             * 0100：访问控制损坏
             * 
             */
            int retCode = 0;
            if (this._isSector0)
            {
                byte bc0 = (byte)(_sector[0][0] ^ _sector[0][1] ^ _sector[0][2] ^ _sector[0][3] ^ _sector[0][4]);
                if (bc0 != 0x00) { retCode = retCode | 0x01; }
            }
            byte[] ac = new byte[4] { _sector[3][6], _sector[3][7], _sector[3][8], _sector[3][9] };
            byte[] acP = Utils.ReadAC(ac);
            byte[] acN = Utils.ReadRAC(ac);
            if (!Enumerable.SequenceEqual(acP, acN))
            {
                retCode = retCode | 0x04;
            }
            foreach (byte acc in acP)
            {
                if (acc > 0x08)
                {
                    retCode = retCode | 0x02;
                    break;
                }
            }
            return retCode;
        }
        public string Info(int sec)
        {
            string info = "扇区" + sec.ToString();
            if (Enumerable.SequenceEqual(
                new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                this._sector[0]) &&
                Enumerable.SequenceEqual(
                new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                this._sector[1]) &&
                Enumerable.SequenceEqual(
                new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                this._sector[2]))
            {
                info += " 空扇区";
            }
            else
            {
                info += " 有数据";
            }
            if (this.Verify() != 0x00)
            {
                info += " 有错误";
            }
            return info;
        }
        public byte[] KeyA
        {
            get { return this._sector[3].Skip(0).Take(6).ToArray(); }
            set { for (int i = 0; i < 6; i++) { this._sector[3][i] = value[i]; } }
        }
        public byte[] KeyB
        {
            get { return this._sector[3].Skip(10).Take(6).ToArray(); }
            set { for (int i = 10; i < 16; i++) { this._sector[3][i] = value[i]; } }
        }
        public byte[] ACBits
        {
            get { return this._sector[3].Skip(6).Take(4).ToArray(); }
            set { for (int i = 6; i < 10; i++) { this._sector[3][i] = value[i]; } }
        }
    }
    class S50
    {
        private List<Sector> _sectors = new List<Sector>(16);

        internal byte[] SectorsRaw
        {
            get
            {
                byte[] buffer = new byte[1024];
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < 16; k++)
                        {
                            buffer[i * 64 + j * 16 + k] = this._sectors[i].Block[j][k];
                        }
                    }
                }
                return buffer;
            }
            set
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < 16; k++)
                        {
                            this._sectors[i].Block[j][k] = value[i * 64 + j * 16 + k];
                        }
                    }
                }
            }
        }

        public List<Sector> Sectors
        {
            get { return _sectors; }
            set { _sectors = value; }
        }

        public S50()
        {
            _sectors.Capacity = 16;
            for (int i = 0; i < 16; i++)
            {
                if (i == 0) { _sectors.Add(new Sector(true)); }
                else { _sectors.Add(new Sector()); }
            }
        }
        public S50(byte[] uid)
        {
            _sectors.Capacity = 16;
            if (uid.Length != 4) { throw new Exception("不恰当的4字节UID长度"); }
            for (int i = 0; i < 16; i++)
            {
                if (i == 0) { _sectors.Add(new Sector(uid)); }
                else { _sectors.Add(new Sector()); }
            }
        }
        public void Wipe()
        {
            for (int i = 0; i < 16; i++)
            {
                _sectors[i].Wipe();
            }
        }
        public int[] Verify()
        {
            int[] ret = new int[17];
            int t = 0;
            for (int i = 0; i < 16; i++)
            {
                ret[i] = _sectors[i].Verify();
                t += ret[i];
            }
            ret[16] = t;
            return ret;
        }
        public int Verify(int sector)
        {
            return _sectors[sector].Verify();
        }
        public void LoadFromMfd(string file)
        {
            if (!File.Exists(file)) { throw new IOException("加载的文件不存在。"); }
            if (new FileInfo(file).Length != 1024) { throw new IOException("加载的S50卡文件大小异常。"); }
            byte[] loadByte = File.ReadAllBytes(file);
            this.Wipe();
            this.SectorsRaw = (byte[])loadByte;
        }
        public void LoadFromMctTxt(string file)
        {
            if (!File.Exists(file)) { throw new IOException("加载的文件不存在。"); }
            long fileLength=new FileInfo(file).Length;
            if (fileLength < 2200 || fileLength > 2400) { throw new IOException("加载的S50卡文件大小异常。"); }
            List<string> lines = new List<string>(File.ReadAllLines(file));
            List<string> invaild = new List<string>();
            foreach (string line in lines)
            {
                if (!Regex.IsMatch(line, "[0-9A-Fa-f]{32}") || line.Length != 32)
                {
                    invaild.Add(line);
                }
            }
            foreach (string inv in invaild)
            {
                lines.Remove(inv);
            }
            if (lines.Count != 64)
            {
                throw new Exception("文件内不是含有64个块数据，可能不完整或不兼容。");
            }
            this.Wipe();
            for (int i = 0; i < lines.Count; i++)
            {
                this._sectors[i / 4].Block[i % 4] = Utils.Hex2Block(lines[i], 16);
            }
        }
        public void ExportToMfd(string file)
        {
            byte[] fileBuffer = this.SectorsRaw;
            File.WriteAllBytes(file, fileBuffer);
        }
        public void ExportToMctTxt(string file)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                sb.AppendLine("+Sector: " + i.ToString());
                for (int j = 0; j < 4; j++)
                {
                    sb.AppendLine(Utils.Hex2Str(this._sectors[i].Block[j]));
                }
            }
            File.WriteAllText(file, sb.ToString());
        }
        public List<byte[]> KeyList()
        {
            List<byte[]> keys = new List<byte[]>();
            foreach (Sector s in this._sectors)
            {
                keys.Add(s.KeyA);
                keys.Add(s.KeyB);
            }
            keys = keys.Distinct().ToList();
            return keys;
        }
        public List<string> KeyListStr()
        {
            List<string> keys = new List<string>();
            foreach (Sector s in this._sectors)
            {
                keys.Add(Utils.Hex2Str(s.KeyA));
                keys.Add(Utils.Hex2Str(s.KeyB));
            }
            keys = keys.Distinct().ToList();
            return keys;
        }
    }
}
