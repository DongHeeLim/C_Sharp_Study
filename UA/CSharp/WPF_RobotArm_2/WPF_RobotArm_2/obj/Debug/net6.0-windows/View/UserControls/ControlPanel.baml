   M S B A M L   `   `   `  ����I  EWPF_RobotArm_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:WPF_RobotArm_2.View.UserControls WPF_RobotArm_2.View.UserControls  5      3    -WPF_RobotArm_2.View.UserControls.ControlPanel   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:WPF_RobotArm_2.View.UserControls     5      .��5
      �   � RowDefinitions  5   
   �� 5      �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��75* �6#   �� 5      $	��25* �6#   .+�5      � $��0��6     5      �� 5      �� 5      �� 5      �� 5       5      �� 5      �� 5      �� 5      .+�5       �� -   5         ��Name$ rpbtn_Rotate��5    @   $��0��6   $��3��6,    �� Interval$ 50��6V   
���   �   EndEffectorButton#��[  6�   .��5!      �� $%��..\..\Data\red_rotate_arrow.png��6   $
��Fill=�6E    J� SnapsToDevicePixels$
 True��5"       � UseLayoutRounding$ False��5#       �� BitmapScalingMode$ NearestNeighbor=�5$      5%      �� 5'      -   5        $ rpbtn_up��5'   =   $��1��6   $��1��6,   $ 50��6O   
���   �#��[  6�   .��5(      �� $ ��..\..\Data\North_arrow.png��6   $
��Fill=�6@   5)      �� 5+      -   5        $ 
rpbtn_down��5+   =   $��3��6   $��1��6,   $ 50��6Q   
���   �#��[  6�   .��5,      �� $ ��..\..\Data\South_arrow.png��6   $
��Fill=�6@   5-      �� 50      -   5        $ 
rpbtn_left��50   =   $��2��6   $��0��6,   $ 50��6Q   
���   �#��[  6�   .��51      �� $��..\..\Data\West_arrow.png��6   $
��Fill=�6?   52      �� 54      -   5        $ rpbtn_right��54   =   $��2��6   $��2��6,   $ 50��6R   
���   �#��[  6�   .��55      �� $��..\..\Data\East_arrow.png��6   $
��Fill=�6?   56      �� 58      -   5        $ 
rpbtn_stop��58   =   $��2��6   $��1��6,   $ 50��6Q   
���   �#��[  6�   .��59      �� $��..\..\Data\STOP.png��6   $
��Fill=�69   5:      5;      � 5<      $��1��6     5=      �� 5>      �� 5?      .+�5A      �� -   5        $ 	rpbtn_zup��5A   -   $��0��6   $ 50��6@   
���   �#��[  6u   .��5B      �� $��..\..\Data\Z_Up_arrow.png��6   $
��Fill=�6?   5C      �� 5D      -   5        $ rpbtn_zdown��5D   -   $��1��6   $ 50��6B   
���   �#��[  6w   .��5E      �� $!��..\..\Data\Z_Down_arrow.png��6   $
��Fill=�6A   5F      5G      5H      � 5J   
   $��1��6    � ShowGridLines$
 True��6    5K      �� 5L      $	��45* �6#   �� 5M      $��5* �6#   �� 5N      $	��45* �6#   �� 5O      $��5* �6#   .+�5Q      � $��0��6     5R      �� 5S      �� 5T      �� 5U      �� 5V      �� 5W       5Y      �� 5Z      �� 5[      �� 5\      �� 5]      .+�5_      � $��0��6   $��0��6'   $��4��64   $��7��6H   .+�5`      �� $��../../Data/indy7.png��6   $
��Left=�6:   $
��Fill=�6U   5a      d� 5j      -	   5         d�Name$ btn_J1��5j      $��30(�6/   $��3��6=   $��2��6J   $��2��6Z   $��2��6k   
���   �	 J� Opacity$		 0.7Q�6�     EnableJoint1#��[ 6�   6�   d� 5k      -
   5        $ btn_J2��5k      $��30(�6/   $��1��6=   $��0��6J   $��3��6Z   $��2��6k   
���   �$		 0.7Q�6�     EnableJoint2#��[ 6�   6�   d� 5l      -   5        $ btn_J3��5l      $��30(�6/   $��1��6=   $��2��6J   $��2��6Z   $��2��6k   
���   �$		 0.7Q�6�     EnableJoint3#��[ 6�   6�   d� 5m      -   5        $ btn_J4��5m      $��30(�6/   $��0��6=   $��2��6J   $��2��6Z   
���   �$		 0.7Q�6�     EnableJoint4#��[ 6�   6�   d� 5n      -   5        $ btn_J5��5n      $��30(�6/   $��0��6=   $��0��6J   $��2��6Z   
���   �$		 0.7Q�6�     EnableJoint5#��[ 6�   6�   d� 5o      -   5        $ 	btn_J_All��5o      $��50(�62   $��6��6@   $��0��6M   $��2��6]   
���   �$		 0.7Q�6�     EnableAllJoint#��[ 6�   6�   5q      � 5r      $��2��6     5s      �� 5t      �� 5u      �� 5v      �� 5w      �� 5x      �� 5y      �� 5z       5|      �� 5}      $	��15* �6'   �� 5~      $	��85* �6'   .+�5�      �� $��0��6   $��0��6%   �� 5�      -   5        
 ��Name$
 lbl_j6��5�      $��1��6(   $��0��65   $��J6��6E   $��30��6R   $��30��6`   $��20(�6k   $��Center=�6y   
�������6�   �� 5�      -   5        $
 lbl_j5��5�      $��2��6(   $��0��65   $��J5��6E   $��30��6R   $��30��6`   $��20(�6k   $��Center=�6y   
�������6�   �� 5�      -   5        $
 lbl_j4��5�      $��3��6(   $��0��65   $��J4��6E   $��30��6R   $��30��6`   $��20(�6k   $��Center=�6y   
�������6�   �� 5�      -   5        $
 lbl_j3��5�      $��4��6(   $��0��65   $��J3��6E   $��30��6R   $��30��6`   $��20(�6k   $��Center=�6y   
�������6�   �� 5�      -   5        $
 lbl_j2��5�      $��5��6(   $��0��65   $��J2��6E   $��30��6R   $��30��6`   $��20(�6k   $��Center=�6y   
�������6�   �� 5�      -   5        $
 lbl_j1��5�      $��6��6(   $��0��65   $��J1��6E   $��30��6R   $��30��6`   $��20(�6k   $��Center=�6y   
�������6�   �� 5�      -   5         ��Name$ btn_JointExecutor��5�      $��0��5�      $��0��6&   $��2��66     Move_Joint_btn#��[ 5�      �� 5�      -   5         ��Name$ 	slider_j6��5�      $��1��6,   $��1��69    � Minimum$ 0Q�6I    � Maximum$	 240Q�6U   $
{�True��6c    �� IsSnapToTickEnabled$
 True��6t     CustomSliderStyle#��[ 6�   �� 5�      -   5        $ 	slider_j5��5�      $��2��6,   $��1��69   $ 0Q�6I   $	 240Q�6U   ${�False��6c   $
 True��6u   #��[ 6�   �� 5�      -   5        $ 	slider_j4��5�      $��3��6,   $��1��69   $ 0Q�6I   $	 240Q�6U   ${�False��6c   $
 True��6u   #��[ 6�   �� 5�      -   5        $ 	slider_j3��5�      $��4��6,   $��1��69   $ 0Q�6I   $	 240Q�6U   ${�False��6c   $
 True��6u   #��[ 6�   �� 5�      -   5        $ 	slider_j2��5�      $��5��6,   $��1��69   $ 0Q�6I   $	 240Q�6U   ${�False��6c   $
 True��6u   #��[ 6�   �� 5�      -   5        $ 	slider_j1��5�      $��6��6,   $��1��69   $ 0Q�6I   $	 240Q�6U   ${�False��6c   $
 True��6u   #��[ 6�   5�      5�      5�      5�      