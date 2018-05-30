using System;
using System.Linq;

namespace Utility.Comm
{
    public class ByteBuffer
    {
        public const int SIZE_UINT = 4;
        public const int SIZE_INT = 4;
        public const int SIZE_LONG = 8;
        public const int SIZE_BYTE = 1;
        public const int SIZE_SHORT = 2;
        public const int SIZE_FLOAT = 4;
        public const int SIZE_DOUBLE = 8;
        public const int SIZE_BOOL = 1;

        private int m_iPos;
        private int m_iMax;
        byte[] m_Buf;

        private bool _isLittleEndian;
        public bool IsLittleEndian
        {
            get { return _isLittleEndian; }
            set { _isLittleEndian = value; }
        }
        
        private void convert(ref byte[] array)
        {
            if (_isLittleEndian && BitConverter.IsLittleEndian)
                ;
            else
                Array.Reverse(array);
        }

        public void ClearBuf()
        {
            m_iPos = 0;
            m_iMax = 0;
            m_Buf = null;
        }

        public ByteBuffer()
        {
            m_iPos = 0;
            m_iMax = 0;
            m_Buf = null;
        }

        public ByteBuffer(byte[] arr)
        {
            m_iPos = 0;

            if (arr != null)
                m_iMax = arr.Length;
            else
                m_iMax = 0;

            m_Buf = arr;
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="iLimit">내부 배열 최대 크기</param>
        public ByteBuffer(int iLimit)
        {
            m_iPos = 0;
            m_iMax = iLimit;
            m_Buf = new byte[iLimit];
        }

        /// <summary>
        /// 주어진 크기로 객체 할당
        /// </summary>
        /// <param name="iSize">제한 크기</param>
        /// <returns></returns>
        public static ByteBuffer allocate(int iSize)
        {
            return new ByteBuffer(iSize);
        }
        
        /// <summary>
        /// 내부 배열 객체 얻기
        /// </summary>
        /// <returns></returns>
        public byte[] array() { return m_Buf; }

        /// <summary>
        /// 커서를 처음 위치로 이동시킴
        /// </summary>
        public void rewind() { m_iPos = 0; }


        /// <summary>
        /// 현재 커서 위치 얻기
        /// </summary>
        /// <returns></returns>
        public int position() { return m_iPos; }

        /// <summary>
        /// 최대 용량 정보 얻기
        /// </summary>
        /// <returns></returns>
        public int capacity() { return m_iMax; }

        public bool IsValid() { return m_iPos < m_iMax ? true : false; }
        /// <summary>
        /// 커서를 지정된 만큼 이동시킴
        /// </summary>
        /// <param name="s"></param>
        public bool MovePos(int s)
        {
            int old = m_iPos;

            m_iPos += s;

            if (m_iPos < 0 || m_iPos >= m_iMax)
            {
                m_iPos = old;
                return false;
            }

            return true;
        }

        public bool SetPos(int s)
        {
            if (s < 0 || s >= m_iMax)
                return false;

            m_iPos = s;
            return true;
        }

        /// <summary>
        /// 바이트 값 추가, 커서는 바이트 크기 만큼 전진
        /// </summary>
        /// <param name="data"></param>
        public void put(byte data)
        {
            if ((m_iPos+1) > m_iMax)
                return;
            m_Buf[m_iPos++] = data;
        }


        /// <summary>
        /// 바이트 배열 복사, 커서는 바이트 배열의 크기만큼 전진함
        /// </summary>
        /// <param name="data">바이트 배열</param>
        public void put(byte[] data)
        {
            if (data == null || (m_iPos + data.Length) > m_iMax)
                return;

            Array.Copy(data, 0, m_Buf, m_iPos, data.Length);

            m_iPos += data.Length;
        }


        /// <summary>
        /// 바이트 배열 복사, 커서는 바이트 배열의 크기만큼 전진함
        /// </summary>
        /// <param name="data">복사할 배열</param>
        /// <param name="iOffset">복사 시작점</param>
        /// <param name="iLen">복사길이 바이트</param>
        public void put(byte[] data, int iOffset, int iLen)
        {
            if ((m_iPos + iLen) > m_iMax)
                return;
            
            Array.Copy(data, iOffset, m_Buf, m_iPos, iLen);
            m_iPos += iLen;
        }


        /// <summary>
        /// short 데이터 추가, 커서는 short 길이 만큼 전진(2바이트)
        /// </summary>
        /// <param name="s">값</param>
        public void putShort(short s)
        {
            if ((m_iPos + 2) > m_iMax)
                return;

            byte[] buf = new byte[2];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);


            m_Buf[m_iPos++] = buf[0];

            m_Buf[m_iPos++] = buf[1];

        }


        /// <summary>
        /// unsigned short 데이터 추가, 커서는 unsigned short 길이 만큼 전진(2바이트)
        /// </summary>
        /// <param name="s"></param>
        public void putUShort(ushort s)
        {
            if ((m_iPos + 2) > m_iMax)
                return;

            byte[] buf = new byte[2];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = buf[0];
            m_Buf[m_iPos++] = buf[1];
        }


        /// <summary>
        /// int 값 추가 : 커서는 int 길이만큼 전진(4바이트)
        /// </summary>
        /// <param name="s">값</param>
        public void putInt(int s)
        {
            if ((m_iPos + 4) > m_iMax)
                return;

            byte[] buf = new byte[4];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = buf[0];
            m_Buf[m_iPos++] = buf[1];
            m_Buf[m_iPos++] = buf[2];
            m_Buf[m_iPos++] = buf[3];
        }

        /// <summary>
        /// unsigned int 값 추가, 커서는 unsigned int 길이만큼전진(4바이트)
        /// </summary>
        /// <param name="s">값</param>
        public void putUInt(uint s)
        {
            if ((m_iPos + 4) > m_iMax)
                return;
            byte[] buf = new byte[4];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = buf[0];
            m_Buf[m_iPos++] = buf[1];
            m_Buf[m_iPos++] = buf[2];
            m_Buf[m_iPos++] = buf[3];
        }


        /// <summary>
        /// long 값 추가 : 커서는 long길이 만큼전진(8바이트)
        /// </summary>
        /// <param name="s">값</param>
        public void putLong(long s)
        {
            if ((m_iPos + 8) > m_iMax)
                return;
            byte[] buf = new byte[8];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = buf[0];
            m_Buf[m_iPos++] = buf[1];
            m_Buf[m_iPos++] = buf[2];
            m_Buf[m_iPos++] = buf[3];
            m_Buf[m_iPos++] = buf[4];
            m_Buf[m_iPos++] = buf[5];
            m_Buf[m_iPos++] = buf[6];
            m_Buf[m_iPos++] = buf[7];
        }
        
        /// <summary>
        /// long 값 추가 : 커서는 long길이 만큼전진(8바이트)
        /// </summary>
        /// <param name="s">값</param>
        public void putLongWithKey(long s, byte btKey)
        {
            if ((m_iPos + 8) > m_iMax)
                return;
            byte[] buf = new byte[8];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = (byte)(buf[0] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[1] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[2] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[3] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[4] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[5] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[6] ^ btKey);
            m_Buf[m_iPos++] = (byte)(buf[7] ^ btKey);
        }

        /// <summary>
        /// float 값 추가 : 커서는 float길이 만큼 전진(4바이트)
        /// </summary>
        /// <param name="s">값</param>
        public void putFloat(float s)
        {
            if ((m_iPos + 4) > m_iMax)
                return;

            byte[] buf = new byte[4];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = buf[0];
            m_Buf[m_iPos++] = buf[1];
            m_Buf[m_iPos++] = buf[2];
            m_Buf[m_iPos++] = buf[3];
        }


        /// <summary>
        /// double값 추가 : 커서는 double 길이 만큼 전진(8바이트)
        /// </summary>
        /// <param name="s"></param>
        public void putDouble(double s)
        {
            if ((m_iPos + 8) > m_iMax)
                return;

            byte[] buf = new byte[8];

            buf = BitConverter.GetBytes(s);
            convert(ref buf);

            m_Buf[m_iPos++] = buf[0];
            m_Buf[m_iPos++] = buf[1];
            m_Buf[m_iPos++] = buf[2];
            m_Buf[m_iPos++] = buf[3];
            m_Buf[m_iPos++] = buf[4];
            m_Buf[m_iPos++] = buf[5];
            m_Buf[m_iPos++] = buf[6];
            m_Buf[m_iPos++] = buf[7];
        }


        /// <summary>
        /// 현재 커서 위치로 부터 1바이트값 얻어옴 : 커서는 +1바이트 전진
        /// </summary>
        /// <returns></returns>
        public byte GetByte()
        {
            if ((m_iPos + 1) > m_iMax)
                return 0;

            return m_Buf[m_iPos++];
        }

        /// <summary>
        /// 현재 커서 위치로 부터 short값 얻어옴 : 커서는 +2바이트 전진
        /// </summary>
        /// <returns></returns>
        public short getShort()
        {
            return getShort(0);
        }

        public short getShort(int s)
        {
            short n = 0;

            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;

            if ((m_iPos + 2) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToInt16(m_Buf, m_iPos);

            m_iPos += 2;

            return n;
        }

        /// <summary>
        /// 현재 커서 위치로 부터 ushort값 얻어옴 : 커서는 +2바이트 전진
        /// </summary>
        /// <returns></returns>
        public ushort getUShort()
        {
            return getUShort(0);
        }

        public ushort getUShort(int s)
        {
            ushort n = 0;
            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;
            
            if ((m_iPos + 2) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToUInt16(m_Buf, m_iPos);

            m_iPos += 2;

            return n;
        }


        /// <summary>
        /// 현재 커서 위치로 부터 int값 얻어옴 : 커서는 +4바이트 전진
        /// </summary>
        /// <returns></returns>
        public int getInt()
        {
            return getInt(0);
        }

        public int getInt(int s)
        {
            int n = 0;

            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;

            if ((m_iPos + 4) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToInt32(m_Buf, m_iPos);

            m_iPos += 4;

            return n;

        }

        /// <summary>
        /// 현재 커서 위치로 부터 uint값 얻어옴 : 커서는 +4바이트 전진
        /// </summary>
        /// <returns></returns>
        public uint getUInt32()
        {
            return getUInt32(0);
        }

        public uint getUInt32(int s)
        {
            uint n = 0;

            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;

            if ((m_iPos + 4) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToUInt32(m_Buf, m_iPos);

            m_iPos += 4;

            return n;

        }

        /// <summary>
        /// 현재 커서 위치로 부터 float값 얻어옴 : 커서는 +4바이트 전진
        /// </summary>
        /// <returns></returns>
        public float getFloat()
        {
            return getFloat(0);
        }

        public float getFloat(int s)
        {
            float n = 0;

            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;

            if ((m_iPos + 4) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToSingle(m_Buf, m_iPos);

            m_iPos += 4;

            return n;

        }


        /// <summary>
        /// 현재 커서 위치로 부터 double값 얻어옴 : 커서는 +8바이트 전진
        /// </summary>
        /// <returns></returns>
        public double getDouble()
        {
            return getDouble(0);
        }

        public double getDouble(int s)
        {
            double n = 0;

            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;

            if ((m_iPos + 8) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToDouble(m_Buf, m_iPos);

            m_iPos += 8;

            return n;

        }


        /// <summary>
        /// 현재 커서 위치로 부터 long값 얻어옴 : 커서는 +8바이트 전진
        /// </summary>
        /// <returns></returns>
        public long getLong()
        {
            return getLong(0);
        }

        public long getLong(int s)
        {
            long n = 0;

            if (s < 0 || s >= m_iMax)
                return n;

            m_iPos = s;

            if ((m_iPos + 8) > m_iMax)
                return n;

            Array.Reverse(m_Buf);
            n = BitConverter.ToInt64(m_Buf, m_iPos);

            m_iPos += 8;

            return n;

        }

        /// <summary>
        /// 현재 커서 위치로 부터 long값 얻어옴 : 커서는 +8바이트 전진
        /// </summary>
        /// <returns></returns>
        public long getLongWithKey(byte btKey)
        {
            if ((m_iPos + 8) > m_iMax)
                return 0;

            try
            {
                byte[] arr = new byte[SIZE_LONG];

                arr[0] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[1] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[2] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[3] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[4] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[5] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[6] = (byte)(m_Buf[m_iPos++] ^ btKey);
                arr[7] = (byte)(m_Buf[m_iPos++] ^ btKey);
                return BitConverter.ToInt64(arr, 0);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 주어진 바이트 배열에 주어진 길이 만큼, 데이터 복사, 커서는 길이만큼 전진
        /// </summary>
        /// <param name="buf">복사 대상 버퍼</param>
        /// <param name="len">복사할길이</param>
        /// <returns>복사된 버퍼</returns>
        public byte[] GetBytes(byte[] buf, int len)
        {
            if ((m_iPos + len) > m_iMax)
                return buf;

            Array.Copy(m_Buf, m_iPos, buf, 0, len);

            m_iPos += len;

            return buf;
        }

        public void Reverse()
        {
            m_Buf.Reverse();
        }
       
        public void putBool(bool v)
        {
            put(v ? (byte)1 : (byte)0);
        }

        public bool getBool()
        {
            if (GetByte() == 1)
                return true;

            return false;
        }
    }
}
