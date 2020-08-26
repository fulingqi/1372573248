using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MessageBox : Form
    {
        public MessageBox(string Message)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
            this.textBox2.Text = Message;
        }

        private void panelAll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAll_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {

        }

        private void panelMessage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //#region
        ///// <summary>
        ///// 读取字符串，如果读取到非托管进程中，并且读取为LPSTR LPWSTTR BSTR等字符串类型，请自行转换为byte[]并使用<see cref="ReadBytes(uint, Pointer, byte[])"/>，<see cref="ReadBytes(uint, IntPtr, byte[])"/>
        ///// </summary>
        ///// <param name="processHandle">进程句柄</param>
        ///// <param name="addr">地址</param>
        ///// <param name="value">值</param>
        ///// <param name="bufferSize">缓存大小</param>
        ///// <param name="doubleZero">是否以2个\0结尾（比如LPWSTR以2个字节\0结尾，而LPSTR以1个字节\0结尾）</param>
        ///// <param name="encoding">编码</param>
        ///// <returns></returns>
        //internal static  bool ReadStringInternal(IntPtr processHandle, IntPtr addr, out string value, int bufferSize, bool doubleZero, Encoding encoding)
        //{
        //    if (encoding == null)
        //        throw new ArgumentNullException(nameof(encoding) + "不能为null");
        //    if (bufferSize <= 0)
        //        throw new ArgumentOutOfRangeException(nameof(bufferSize) + "小于等于0");

        //    byte[] buffer;
        //    uint numberOfBytesRead;
        //    List<byte> bufferList;
        //    bool lastByteIsZero;

        //    buffer = null;
        //    numberOfBytesRead = 0;
        //    bufferList = new List<byte>(bufferSize);
        //    lastByteIsZero = false;
        //    for (int i = 0; i < int.MaxValue; i++)
        //    {
        //        buffer = new byte[bufferSize];
        //        ReadProcessMemory(processHandle, addr + bufferSize * i, buffer, (uint)bufferSize, &numberOfBytesRead);
        //        //读取到缓存
        //        if ((int)numberOfBytesRead == bufferSize)
        //        {
        //            //读取完整
        //            for (int j = 0; j < bufferSize; j++)
        //            {
        //                if (buffer[j] == 0)
        //                {
        //                    //出现\0
        //                    if (doubleZero)
        //                    {
        //                        //如果双\0结尾
        //                        if (lastByteIsZero)
        //                            //上一个字节为\0
        //                            goto addLastRange;
        //                        if (j + 1 != bufferSize)
        //                        {
        //                            //不是缓存区最后一个字节
        //                            if (buffer[j + 1] == 0)
        //                                //下一个字节也为\0
        //                                goto addLastRange;
        //                        }
        //                        else
        //                            //缓存读完，标记上一个字节为\0
        //                            lastByteIsZero = true;
        //                    }
        //                    else
        //                        //不是2个\0结尾，直接跳出
        //                        goto addLastRange;
        //                }
        //                else
        //                {
        //                    if (lastByteIsZero)
        //                        //上一个字节为\0，但当前字节不是
        //                        lastByteIsZero = false;
        //                }
        //            }
        //        }
        //        else if (numberOfBytesRead == 0)
        //        {
        //            //读取失败
        //            value = null;
        //            return false;
        //        }
        //        else
        //        {
        //            //读取不完整
        //            for (int j = 0; j < (int)numberOfBytesRead; j++)
        //            {
        //                if (buffer[j] == 0)
        //                {
        //                    //出现\0
        //                    if (doubleZero)
        //                    {
        //                        //如果双\0结尾
        //                        if (lastByteIsZero)
        //                            //上一个字节为\0
        //                            goto addLastRange;
        //                        if (j + 1 != (int)numberOfBytesRead && buffer[j + 1] == 0)
        //                            //不是缓存区最后一个字节且下一个字节也为\0
        //                            goto addLastRange;
        //                    }
        //                    else
        //                        //不是2个\0结尾，直接跳出
        //                        goto addLastRange;
        //                }
        //                else
        //                {
        //                    if (lastByteIsZero)
        //                        //上一个字节为\0，但当前字节不是
        //                        lastByteIsZero = false;
        //                }
        //            }
        //        }
        //        bufferList.AddRange(buffer);
        //    };
        //    addLastRange:
        //    numberOfBytesRead -= doubleZero ? 2u : 1u;
        //    for (int i = 0; i < (int)numberOfBytesRead; i++)
        //        bufferList.Add(buffer[i]);
        //    if (encoding.CodePage == Encoding.Unicode.CodePage)
        //        buffer = bufferList.ToArray();
        //    else
        //        buffer = Encoding.Convert(encoding, Encoding.Unicode, bufferList.ToArray());
        //    fixed (void* p = &buffer[0])
        //        value = new string((char*)p);
        //    return true;
        //}

        ///// <summary>
        ///// 在远程进程中读取结构
        ///// </summary>
        ///// <typeparam name="TStruct"></typeparam>
        ///// <param name="hWnd">控件句柄</param>
        ///// <param name="structure">读取出的结构体</param>
        ///// <param name="callbackBeforeRead">读取前回调方法</param>
        ///// <param name="callbackAfterRead">读取后回调方法</param>
        ///// <returns></returns>
        //public static bool ReadStructRemote<TStruct>(IntPtr hWnd, out TStruct structure, Func<IntPtr, IntPtr, bool> callbackBeforeRead, Func<IntPtr, IntPtr, bool> callbackAfterRead) where TStruct : IWin32ControlStruct
        //{
        //    uint processId;
        //    IntPtr hProcess;
        //    bool is64;
        //    IntPtr remoteAddr;

        //    structure = default(TStruct);
        //    processId = Process.GetProcessIdByHWnd(hWnd);
        //    //获取控件所在进程ID
        //    hProcess = OpenProcessRWQuery(processId);
        //    //打开进程
        //    if (hProcess == IntPtr.Zero)
        //        return false;
        //    if (!Process.Is64ProcessInternal(hProcess, out is64))
        //        return false;
        //    if (is64 && !Environment.Is64BitProcess)
        //        throw new NotSupportedException("目标进程为64位但当前进程为32位");
        //    try
        //    {
        //        remoteAddr = VirtualAllocEx(hProcess, IntPtr.Zero, structure.Size, MEM_COMMIT, PAGE_READWRITE);
        //        //在控件所在进程分配内存，用于储存structure
        //        try
        //        {
        //            if (callbackBeforeRead != null)
        //                if (!callbackBeforeRead(hProcess, remoteAddr))
        //                    return false;
        //            if (!ReadProcessMemory(hProcess, remoteAddr, structure.ToPointer(), structure.Size, null))
        //                //从远程进程取回到当前进程失败
        //                return false;
        //            if (callbackAfterRead != null)
        //                if (!callbackAfterRead(hProcess, remoteAddr))
        //                    return false;
        //            return true;
        //        }
        //        finally
        //        {
        //            VirtualFreeEx(hProcess, remoteAddr, 0, MEM_RELEASE);
        //            //释放之前分配的内存
        //        }
        //    }
        //    finally
        //    {
        //        CloseHandle(hProcess);
        //        //关闭句柄
        //    }
        //}

        ///// <summary>
        ///// 获取列表视图控件中Item的文本
        ///// </summary>
        ///// <param name="i">The index of the list-view item.</param>
        ///// <param name="iSubItem">The index of the subitem. To retrieve the item text, set iSubItem to zero.</param>
        ///// <returns></returns>
        //public unsafe string GetItemText(int i, int iSubItem)
        //{
        //    LVITEM item;
        //    IntPtr pStr;
        //    string text;

        //    text = null;
        //    pStr = IntPtr.Zero;
        //    item = new LVITEM
        //    {
        //        iSubItem = iSubItem,
        //        cchTextMax = 0x1000
        //    };
        //    Util.WriteStructRemote(Handle, ref item, (IntPtr hProcess, IntPtr addr) =>
        //    {
        //        pStr = VirtualAllocEx(hProcess, IntPtr.Zero, 0x1000, MEM_COMMIT, PAGE_READWRITE);
        //        //分配内存用于写入字符串
        //        if (pStr == IntPtr.Zero)
        //            return false;
        //        item.pszText = (char*)pStr;
        //        //设置缓存区地址
        //        return true;
        //    }, (IntPtr hProcess, IntPtr addr) =>
        //    {
        //        try
        //        {
        //            if (ListView_GetItemText(Handle, i, addr, 0x1000) == 0)
        //                return false;
        //            return MemoryIO.ReadStringInternal(hProcess, (IntPtr)item.pszText, out text, 0x1000, true);
        //        }
        //        finally
        //        {
        //            VirtualFreeEx(hProcess, pStr, 0, MEM_RELEASE);
        //        }
        //    });
        //    return text;
        //}
        //#endregion

    }
}
