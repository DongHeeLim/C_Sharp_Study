   M S B A M L   `   `   `  ����W  SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property �� Value �� 
TargetType-   'System.Windows.Input.KeyboardNavigation    TabNavigation � RowDefinitions'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty8   2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name K� ZIndex K� IsItemsHost    TabIndex ��Name �� CornerRadius    DirectionalNavigation �� EndPoint �� 
StartPoint � Color � Offset ��Name �Name<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value �� Color �� Triggers P� Property P� Value   	Btn_Start  J� Opacity! J� SnapsToDevicePixels" � UseLayoutRounding# �� BitmapScalingMode$ �� 
TargetName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %  '��       '�� �    &	  �    �� 5      "  ��6   .�5   
   ��  �@�OverridesDefaultStyle$
 True��62   �� 5   
    �@J�SnapsToDevicePixels$
 True��60   �� 5	   
    � �� 5
      �� 5      " ��6"   .R�5      � $ Local=�6    5      �� 5      $
��Auto �6,   �� 5      $��* �6,    5        5      CommonStates��. 5   "     Disabled��. 5   &   �� .��5   *   �� $	 Border��6G   $2
 ,(Border.BorderBrush).(SolidColorBrush.Color)�5   G   .g�5   .     $ 0��6B   $ 	#FFAA55AA��6N   5   +   5   '   5   #   5      .+�5      �� $ HeaderPanel��6#   $��0��5   #   $ 1��60   $��	0,0, 0,-1q�5    #   $
 True��66   $ 1��5!   #   
���   �5"   #   �� 5#      $ Border��6!   $��1��5$   !   
���   �$��1q�5&   !   $ 2��5'   !   $ Local=�5(   !   $ 	Contained=�5)   !   $ 2��5*   !   ��5,   "   �� 5-   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��52   &   � $ Black��63   $	 0.5Q�53   3   � 54   &   $ 	#FF8C1A00��63   $ 2Q�55   3   56   #   ._�58      �� $ PART_SelectedContentHost��6/   $��4q�59   /   $��SelectedContent��5:   /   5;      5<      5=      5?      5@      �� 5B      "  ��6   .�5C   
   ��  � �� 5D      �� 5E      " ��6"   .R�5G      � $
 Root��6   $��40��5H       5I        5J      SelectionStates��. 5K   "     
Unselected��6.     5L   "   Selected��. 5M   &   �� .��5N   *   �� $	 Border��6G   $N
 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5O   G   .g�5Q   .     $ 0��6B   $	 Red��6N   5R   +   r� 5S   *   $
 (Border.BorderThickness)�6K   $	 Border��5T   K   .	�5U   .     $ 0��6F   $ 1,10,1,0q�6R   5V   +   5W   '   5X   #   5Y        5Z      CommonStates��. 5[   "     
Normal��6.     5\   "   	MouseOver��6.     5]   "   Disabled��. 5^   &   �� .��5_   *   �� $	 Border��6G   $N
 H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5`   G   .g�5b   .     $ 0��6B   $	 Red��6N   5c   +   �� 5d   *   $	 Border��6G   $2
 ,(Border.BorderBrush).(SolidColorBrush.Color)�5e   G   .g�5g   .     $ 0��6B   $	 Red��6N   5h   +   5i   '   5j   #   5k      .+�5m      �� $ Border��6!   $��0,0,-4,1q�5n   !   $��4q�5o   !   $ 7��5p   !   ��5q      �� 5r   "   $ 	#FF373737��62   ��5t      �� 5u   "   $	 0,0&�66   $	 0,1&�5v   $   ��5x   *   � � 5{   .   $ #1e1e1e��6;   $	 1.0Q�6K   � 5|   .   $ DarkGray��6;   $	 1.0Q�6L   5}   +   5   #   ._�5�      �� $ ContentSite��6/   $��Center=�5�      $��Center=�5�      $��Header��5�      $��	12,2,12,2q�5�      $
��True��5�      5�      5�       5�      P� 5�       �@��
IsSelected$
 True��68   . �5�      ��  �@K�ZIndex$	 100��6=   �� 5�       � ��
 �����6;   �� 5�       � ��$
 Bold"�6;   5�      P� 5�       �@��
IsSelected$ False��68   . �5�      ��  �@K�ZIndex$	 100��6=   �� 5�       � ��
 �����6;   �� 5�       � ��$ Medium"�6;   5�      5�      5�      5�      �� 5�      "  d�6   .�5�   
   ��  �@J�SnapsToDevicePixels$
 True��60   �� 5�   
    � �� 5�      �� 5�      " d�6"   .R�5�      � $
 Root��6   $��0q�5�      
���   �.+�5�      �� $ Border��6!   
������ $��1q�5�      $��10, 1, 10, 1q�5�      $ 10��5�      $	  0.2Q�5�      ._�5�      �� $ CP��5�      $��Center=�5�      $��Center=�5�      $��1q�5�      5�      5�      �� 5�      $ InnerBorder��6!   $��5, 10, 5, 10q�5�   !   $	��100��5�   !   $��80��5�   !   $ 10��5�   !   ���	#FF2FFF20$��3q�5�   !   $��Center=�5�   !   ._�5�      �� $��0��6%   $��..\Data\Start_37108.png��5�   %   $��50��5�   %   $��50��61   $��Center=�5�   %   $��Center=�5�   %   $
! True��5�   %   $" False��5�   %   $# NearestNeighbor=�5�   %   5�      5�       5�      P� 5�       �@J�IsMouseOver$
 True��6:   . �5�      �� $$ Border��6%    � �� �#0FAF0E6O   5�      P� 5�       �@J�IsMouseOver$ False��69   . �5�      �� $$ Border��6%    � ��
 �   �6O   5�      P� 5�       �@d�	IsChecked$
 TrueY�67   . �5�      �� $$ InnerBorder��6%    � �� �#00FF1E6T   5�      P� 5�       �@d�	IsChecked$ FalseY�67   . �5�      �� $$ InnerBorder��6%    � ��
 �   �6T   5�      5�      5�      5�      5�      