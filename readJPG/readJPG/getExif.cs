using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace readJPG
{
    /// <summary>
    /// 类  名：Exif
    /// 功  能：读取JPG图像Exif信息
    /// 编  写：dnawo
    /// 日  期：2010-01-14
    /// 备  注：暂不支持IFD1信息读取,JPG支持Intel和Motorola字节序
    /// </summary>
    class Exif
    {
        #region JPG属性项类

        /// <summary>
        /// JPG属性项结构
        /// </summary>
        struct PropertyItem
        {
            /// <summary>
            /// 标识
            /// </summary>
            public int Tag;
            /// <summary>
            /// 类型
            /// </summary>
            public int Type;
            /// <summary>
            /// 值个数,Type占字节数*Count=Value长度
            /// </summary>
            public long Count;
            /// <summary>
            /// 值
            /// </summary>
            public byte[] Value;
        }

        #endregion

        #region 私有字段

        private bool _Endian = false;//true little; false big;
        private long _OffsetAPP1 = 0;
        private long _OffsetTIFF = 0;
        private long _OffsetIFD0 = 0;
        private long _OffsetIFD1 = 0;
        private long _OffsetExifIFD = 0;
        private long _OffsetGPSIFD = 0;
        private string _ImageFile = string.Empty;
        private List<PropertyItem> _Exif = new List<PropertyItem>();
        private int[] _PropertyItemTypeLength = new int[] { 0, 1, 1, 2, 4, 8, 8, 4, 8, 4, 8 };//每种类型Type占字节数

        #endregion

        #region 对象属性,可自行扩展

        /// <summary>
        /// 图片标题
        /// </summary>
        public string ImageTitle
        {
            get
            {
                byte[] b = GetValue(270);
                if (b != null)
                    return ASCIIToString(b);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 厂商
        /// </summary>
        public string Make
        {
            get
            {
                byte[] b = GetValue(271);
                if (b != null)
                    return ASCIIToString(b);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 机型
        /// </summary>
        public string Model
        {
            get
            {
                byte[] b = GetValue(272);
                if (b != null)
                    return ASCIIToString(b);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 软件
        /// </summary>
        public string Software
        {
            get
            {
                byte[] b = GetValue(305);
                if (b != null)
                    return ASCIIToString(b);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public string DateTime
        {
            get
            {
                byte[] b = GetValue(36867);
                if (b != null)
                    return ASCIIToString(b);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 水平分辨率
        /// </summary>
        public string XResolution
        {
            get
            {
                byte[] b = GetValue(282);
                if (b != null)
                    return RationalToSingle(b, 0);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 垂直分辨率
        /// </summary>
        public string YResolution
        {
            get
            {
                byte[] b = GetValue(283);
                if (b != null)
                    return RationalToSingle(b, 0);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 分辨率单位
        /// </summary>
        public string ResolutionUnit
        {
            get
            {
                byte[] b = GetValue(296);
                if (b != null)
                    return ShortToString(b, 0);
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 方向
        /// </summary>
        public string orientation
        {
            get
            {
                byte[] b = GetValue(274);
                if (b != null)
                {
                    switch (ShortToString(b, 0))
                    {
                        case "1":
                            return "上/左";
                        case "2":
                            return "上/右";
                        case "3":
                            return "下/右";
                        case "4":
                            return "下/左";
                        case "5":
                            return "左/上";
                        case "6":
                            return "右/上";
                        case "7":
                            return "右/下";
                        case "8":
                            return "左/下";
                        default:
                            return "未知";
                    }
                }
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// GPS纬度
        /// </summary>
        public string GPSLatitude
        {
            get
            {
                byte[] b = GetValue(2);
                if (b != null)
                    return string.Format("{0}°{1}′{2}″", RationalToSingle(b, 0), RationalToSingle(b, 8), RationalToSingle(b, 16));
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// GPS经度
        /// </summary>
        public string GPSLongitude
        {
            get
            {
                byte[] b = GetValue(4);
                if (b != null)
                    return string.Format("{0}°{1}′{2}″", RationalToSingle(b, 0), RationalToSingle(b, 8), RationalToSingle(b, 16));
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// GPS高度
        /// </summary>
        public string GPSAltitude
        {
            get
            {
                byte[] b = GetValue(6);
                if (b != null)
                    return RationalToSingle(b, 0) + "m";
                else
                    return string.Empty;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="imagefile">图像文件路径</param>
        public Exif(string imagefile)
        {
            if (string.IsNullOrEmpty(imagefile) || !File.Exists(imagefile))
            {
                throw new FileNotFoundException(this._ImageFile + "加载失败，请检查路径后再次尝试。");
            }
            else
            {
                this._ImageFile = imagefile;

                //存放临时内容
                byte[] bytes2 = new byte[2];
                byte[] bytes4 = new byte[4];
                byte[] bytes12 = new byte[12];

                using (FileStream file = new FileStream(this._ImageFile, FileMode.Open))
                {
                    //寻找APP1偏移
                    while (file.Read(bytes2, 0, bytes2.Length) > 0)
                    {
                        if (bytes2[0] == 0xFF && bytes2[1] == 0xE1)
                        {
                            this._OffsetAPP1 = file.Position - 2;
                            break;
                        }
                    }

                    if (this._OffsetAPP1 > 0)
                    {
                        //跳过APP1长度,2字节
                        file.Seek(2, SeekOrigin.Current);

                        //判断是否为Exif
                        if (file.Read(bytes4, 0, bytes4.Length) > 0)
                        {
                            if (Encoding.ASCII.GetString(bytes4) == "Exif")
                            {
                                //跳过固定2字节,0x0000
                                file.Seek(2, SeekOrigin.Current);

                                //TIFF偏移位置
                                this._OffsetTIFF = file.Position;

                                //获取字节序方式
                                if (file.Read(bytes2, 0, bytes2.Length) > 0)
                                {
                                    if (bytes2[0] == 0x49 && bytes2[1] == 0x49) //Intel
                                        this._Endian = true;
                                    else //Motorola
                                        this._Endian = false;

                                    /*** 暂不支持Motorola解析
                                    if (!this._Endian)
                                    {
                                        file.Dispose();
                                        throw new ArgumentOutOfRangeException("暂不支持Motorola字节序解析，可联系 270250392@qq.com 处理！");
                                    }
                                     ***/

                                    //跳过固定2字节,0x2A00
                                    file.Seek(2, SeekOrigin.Current);

                                    if (file.Read(bytes4, 0, bytes4.Length) > 0)
                                    {
                                        //IFD0偏移位置
                                        this._OffsetIFD0 = BitConverter.ToInt32(MM2II(bytes4), 0);

                                        //跳转到IFD0
                                        file.Seek(this._OffsetTIFF + this._OffsetIFD0, SeekOrigin.Begin);

                                        //获取IFD0项个数
                                        int ifd0count;
                                        int id, value;
                                        if (file.Read(bytes2, 0, bytes2.Length) > 0)
                                        {
                                            ifd0count = BitConverter.ToInt16(MM2II(bytes2), 0);

                                            //ExifIFD、GPSIFD偏移
                                            for (int i = 0; i < ifd0count; i++)
                                            {
                                                if (file.Read(bytes12, 0, bytes12.Length) > 0)
                                                {
                                                    id = BitConverter.ToUInt16(MM2II(bytes12, 0, 2), 0);//ToUInt16
                                                    value = BitConverter.ToInt32(MM2II(bytes12, 8, 4), 0);

                                                    switch (id)
                                                    {
                                                        case 34665://ExifIFD,0x8769
                                                            this._OffsetExifIFD = value;//注意,该偏移从TIFF开始计算,下同
                                                            break;
                                                        case 34853://GPSIFD,0x8825
                                                            this._OffsetGPSIFD = value;
                                                            break;
                                                    }
                                                }
                                            }

                                            //IFD1偏移
                                            if (file.Read(bytes4, 0, bytes4.Length) > 0)
                                                this._OffsetIFD1 = BitConverter.ToUInt32(MM2II(bytes4), 0);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                file.Dispose();
                                throw new FileLoadException(this._ImageFile + "解析失败，该文件不包含Exif信息，请检查后再次尝试。");
                            }
                        }
                    }
                    else
                    {
                        file.Dispose();
                        throw new FileLoadException(this._ImageFile + "解析失败，该文件不包含App1节，请检查后再次尝试。");
                    }
                }

                //避免文件被占用，放到这边解析
                if (this._OffsetIFD0 > 0)
                    ParseIFD(this._OffsetTIFF + this._OffsetIFD0);
                if (this._OffsetExifIFD > 0)
                    ParseIFD(this._OffsetTIFF + this._OffsetExifIFD);
                if (this._OffsetGPSIFD > 0)
                    ParseIFD(this._OffsetTIFF + this._OffsetGPSIFD);
            }
        }

        #endregion

        #region 私有函数

        /// <summary>
        /// IFD解析
        /// </summary>
        /// <param name="offset">IFD偏移位置,从SeekOrigin.Begin开始</param>
        private void ParseIFD(long offset)
        {
            byte[] bytes2 = new byte[2];
            byte[] bytes4 = new byte[4];
            byte[] bytes12 = new byte[12];
            PropertyItem pi;

            using (FileStream file = new FileStream(this._ImageFile, FileMode.Open))
            {
                file.Seek(offset, SeekOrigin.Begin);

                int ifdcount;
                long offset1, offset2;
                if (file.Read(bytes2, 0, bytes2.Length) > 0)
                {
                    ifdcount = BitConverter.ToInt16(MM2II(bytes2), 0);

                    for (int i = 0; i < ifdcount; i++)
                    {
                        if (file.Read(bytes12, 0, bytes12.Length) > 0)
                        {
                            pi = new PropertyItem();
                            pi.Tag = BitConverter.ToUInt16(MM2II(bytes12, 0, 2), 0);
                            pi.Type = BitConverter.ToUInt16(MM2II(bytes12, 2, 2), 0);
                            pi.Count = BitConverter.ToUInt32(MM2II(bytes12, 4, 4), 0);
                            if (pi.Type <= 12)
                            {
                                if (this._PropertyItemTypeLength[pi.Type] * pi.Count <= 4)
                                {
                                    pi.Value = new byte[] { bytes12[8], bytes12[9], bytes12[10], bytes12[11] };
                                }
                                else
                                {
                                    offset1 = file.Position;
                                    offset2 = BitConverter.ToUInt32(MM2II(bytes12, 8, 4), 0);

                                    file.Seek(this._OffsetTIFF + offset2, SeekOrigin.Begin);
                                    byte[] b = new byte[this._PropertyItemTypeLength[pi.Type] * pi.Count];
                                    file.Read(b, 0, b.Length);
                                    pi.Value = b;

                                    file.Seek(offset1, SeekOrigin.Begin);//跳回
                                }
                            }

                            _Exif.Add(pi);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 返回指定id的PropertyItem.Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private byte[] GetValue(int id)
        {
            for (int i = 0; i < _Exif.Count; i++)
            {
                if (_Exif[i].Tag == id)
                    return _Exif[i].Value;
            }
            return null;
        }

        /// <summary>
        /// Byte转String
        /// </summary>
        /// <param name="b"></param>
        /// <param name="startindex"></param>
        /// <returns></returns>
        private string ByteToString(byte[] b, int startindex)
        {
            return ((char)b[startindex]).ToString();
        }

        /// <summary>
        /// Short转String
        /// </summary>
        /// <param name="b"></param>
        /// <param name="startindex"></param>
        /// <returns></returns>
        private string ShortToString(byte[] b, int startindex)
        {
            return BitConverter.ToInt16(MM2II(b, startindex, 2), 0).ToString();
        }

        /// <summary>
        /// Rational转Single
        /// </summary>
        /// <param name="b"></param>
        /// <param name="startindex"></param>
        /// <returns></returns>
        private string RationalToSingle(byte[] b, int startindex)
        {
            return (BitConverter.ToSingle(MM2II(b, startindex, 4), 0) / BitConverter.ToSingle(MM2II(b, startindex + 4, 4), 0)).ToString();
        }

        /// <summary>
        /// ASCII转String
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private string ASCIIToString(byte[] b)
        {
            return Encoding.ASCII.GetString(b);
        }

        /// <summary>
        /// Motorola字节序转Intel字节顺
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private byte[] MM2II(byte[] b)
        {
            return MM2II(b, 0, b.Length);
        }

        /// <summary>
        /// Motorola字节序转Intel字节序
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte[] MM2II(byte[] b, int index, int length)
        {
            byte[] b1 = new byte[length];
            if (this._Endian)
            {
                for (int i = index; i < index + length; i++)
                    b1[i - index] = b[i];
            }
            else
            {
                for (int i = index; i < index + length; i++)
                    b1[i - index] = b[(index + length) - (i - index) - 1];
            }

            return b1;
        }

        #endregion

        #region 对象方法

        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("标题：{0}\r\n厂商：{1}\r\n机型：{2}\r\n软件：{3}\r\n时间：{4}\r\n水平分辨率：{5}\r\n垂直分辨率：{6}\r\nGPS纬度：{7}\r\nGPS经度：{8}\r\nGPS高度：{9 }\r\n",
                                 this.ImageTitle,
                                 this.Make,
                                 this.Model,
                                 this.Software,
                                 this.DateTime,
                                 this.XResolution,
                                 this.YResolution,
                                 this.GPSLatitude,
                                 this.GPSLongitude,
                                 this.GPSAltitude
                                );

        }

        #endregion
    }
}