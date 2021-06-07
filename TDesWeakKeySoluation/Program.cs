namespace TDesWeakKeySoluation
{
    /// <summary>
    /// Testing 3Des Encryption Algorithm with weak key
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var weakKey = new byte[] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };
            var data = new byte[] { 0x36, 0x39, 0x31, 0x39, 0x45, 0x38, 0x31, 0x37, 0x36, 0x37, 0x44, 0x42, 0x43, 0x45, 0x43, 0x33, 0x36 };
            var tdesResult = SecurityHelper.TDes(data, weakKey);
            var result = tdesResult.ByteArrayToHexString(); //FF5164C0796D34062D15804B8D038BF1DA6157FD507AE35C
        }
    }
}
