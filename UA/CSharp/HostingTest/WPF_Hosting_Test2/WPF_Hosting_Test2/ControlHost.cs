﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using System.Runtime.InteropServices;

namespace WPF_Hosting_Test2
{

    internal class ControlHost
    {

        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //[DllImport("user32.dll")]
        //static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //[DllImport("user32.dll")]
        //static extern bool MoveWindow(IntPtr Handle, int x, int y, int w, int h, bool repaint);

        //static readonly int GWL_STYLE = -16;
        //static readonly int WS_VISIBLE = 0x10000000;


        //protected override void OnViewLoaded(object view)
        //{
        //    base.OnViewLoaded(view);
        //    var process = Process.Start("Notepad.exe");
        //    process.WaitForInputIdle();
        //    var win = view as Window;
        //    var winHandle = new WindowInteropHelper(win).Handle;
        //    SetParent(process.MainWindowHandle, winHandle);
        //    SetWindowLong(process.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
        //    MoveWindow(process.MainWindowHandle, 0, 0, (int)win.ActualWidth, (int)win.ActualHeight, true);
        //}
    }
}
