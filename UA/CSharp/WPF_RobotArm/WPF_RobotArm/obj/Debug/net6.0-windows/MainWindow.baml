   M S B A M L   `   `   `  ����G  CWPF_RobotArm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_RobotArmWPF_RobotArm  5   	   O,clr-namespace:WPF_RobotArm.View.UserControlsWPF_RobotArm.View.UserControls  5   	       WPF_RobotArm.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPF_RobotArm     5   	   C
uc_menubar,clr-namespace:WPF_RobotArm.View.UserControls     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   � -   5         �Name$ MenuBarRoot��5      
��� ���5      � 5   
   $��1��6    � ShowGridLines$
 True��6    � ColumnDefinitions 5      �� 5      $	��20* �6#   �� 5      $	��55* �6#   �� 5      $	��25* �6#   .+�5      �  5       �� 5!      $	��100 �6$   �� 5"      .+�5%      � -   5        $ 
StatusRoot��5%      $��0��6+   
����� �68   � 5'      -   5        $ FunctionButtonsRoot��5'      $��1��64   $
 True��6A   
���z���6V   5)      � 5,      $��1��6   $
 True��6#    5-      �� 5.      $	��100 �6$   �� 5/      $	��80* �6$   .+�53      � -   5        $ TopButtonsRoot��53      $��0��6/   
���  ��6<   � 55      $��1��6   
��� � �6$   58      � 5:      $��2��6   $
 True��6#   
����  � 5;      �� 5<      $	��45* �6$   �� 5=      $	��55* �6$   .+�5@      � -   5        $ EndEffectorControlRoot��5@      $��0��67   
����=H�6D   � 5A      -   5        $ JointControlRoot��5A      $��1��61   
�����_�6>   5C      5G      ]� 5H   
   $��False��6   $��1��6*   5J      5O      