﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace WPF_RobotArm_2
{


    class WindowResizer
    {
        // 함수포인터 연결하기

        MainWindow main = new MainWindow();


        //MainWindow.SendPointHandler ;
        //public event MainWindow.SendPointHandler receiveEvent;


        // 연결된 것을 어떻게 가공할 것인지
        private static void ReceivePoint(object sender, EventArgs e) 
        {
        
        }

        public enum ResizeDirection
        {
            None = 0,
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
            Drag = 10,
        }

        private const int WM_SYSCOMMAND = 0x112;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static ResizeDirection GetDirection(DependencyObject obj)
        {
            return (ResizeDirection)obj.GetValue(DirectionProperty);
        }
        public static void SetDirection(DependencyObject obj, ResizeDirection value)
        {
            obj.SetValue(DirectionProperty, value);
        }
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.RegisterAttached("Direction", typeof(ResizeDirection), typeof(WindowResizer),
            new UIPropertyMetadata(ResizeDirection.None, OnResizeDirectionChanged));


        private static Window GetTargetWindow(DependencyObject obj)
        {
            return (Window)obj.GetValue(TargetWindowProperty);
        }
        private static readonly DependencyProperty TargetWindowProperty =
            DependencyProperty.RegisterAttached("TargetWindow", typeof(Window), typeof(ResizeDirection), new UIPropertyMetadata(null));

        protected static void OnResizeDirectionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            
            
            FrameworkElement? Target = sender as FrameworkElement;
            ResizeDirection Direction = (ResizeDirection)e.NewValue;

            switch (Direction)
            {
                case ResizeDirection.Left:
                case ResizeDirection.Right:
                    Target.Cursor = Cursors.SizeWE;
                    break;
                case ResizeDirection.Top:
                case ResizeDirection.Bottom:
                    Target.Cursor = Cursors.SizeNS;
                    break;
                case ResizeDirection.TopLeft:
                case ResizeDirection.BottomRight:
                    Target.Cursor = Cursors.SizeNWSE;

                    break;
                case ResizeDirection.TopRight:
                case ResizeDirection.BottomLeft:
                    
                        Target.Cursor = Cursors.SizeNESW;
                    break;
                default:
                    Target.Cursor = Cursors.Arrow;
                    break;
            }

            Target.SetBinding(TargetWindowProperty, new Binding()
            { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1) });

            // 이벤트 핸들러
            Target.MouseLeftButtonDown += (ss, ee) =>
            {
                if (Direction == ResizeDirection.Drag)
                {
                    
                    
                    DragWindow(Target);
                }
                else 
                {
                    ResizeWindow(Target, Direction);
                } 
                ee.Handled = true;
            };
        }



        private static void DragWindow(FrameworkElement Target)
        {
            Window Window = GetTargetWindow(Target);
            if (Window == null) return;
            Window.DragMove();
        }

        private static void ResizeWindow(FrameworkElement Target, ResizeDirection Direction)
        {
            if (Direction == ResizeDirection.None) return;

            Window Window = GetTargetWindow(Target);
            if (Window == null) return;

            Cursor CurrentCursor = Window.Cursor;   // 원래 커서 기억
            Window.Cursor = Target.Cursor;  // 다른 것으로 바꾸기

            HwndSource? HwndSource = PresentationSource.FromVisual(Window) as HwndSource;
            SendMessage(HwndSource.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + Direction), IntPtr.Zero);

            Window.Cursor = CurrentCursor;

        }


    }
}
