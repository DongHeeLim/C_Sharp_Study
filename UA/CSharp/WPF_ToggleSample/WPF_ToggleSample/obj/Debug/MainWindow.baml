   M S B A M L   `   `   `  ����K  GWPF_ToggleSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPF_ToggleSampleWPF_ToggleSample  5   	   !    WPF_ToggleSample.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPF_ToggleSample     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         ButtonFocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  ButtonNormalBackground �� EndPoint �� 
StartPoint � Color	 � Offset  ButtonNormalBorder
 �� Color  ToggleButtonStyle1 �� 
TargetType �� 
TargetType �� Orientation ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%9  &	        &	 �     &	 �    &	 �    7   7  7  �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $	 0,1&�6=   $	 0,0&�6L   .��5      � $ #F3F3F3��6   $	 0Q�6+   � 5      $ #EBEBEB��6   $		 0.5Q�6+   � 5      $ #DDDDDD��6   $		 0.5Q�6+   � 5      $ #CDCDCD��6   $	 1Q�6+   5      �� 5   
   $
 	#FF707070��65   �� 5   
   " d�6+   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��$ 1q�60   �� 5       � ��# � ��6+   �� 5        � ��$ Center=�6;   �� 5!       � ��$ Center=�69   �� 5"       � ��$ 1q�6(   �� 5#       � �� 5$      �� 5%      " d�6&   .R�5&      �� $ 
Horizontal=�6%   .+�5'      �� #��z��6/   #��z��6r   ��. # z 6�   #��z��6�   �� 5(      $ on��6%   $��25��61   $��25��6<   
�������$ 2,0,0,4��6_   $��10,0,0,0q�6v   ._�5)   "   �� $ onText��6,   $��On��6<   $��Center=�6F   $��Center=�6c   5*      �� 5+      $	 off��6%   $��25��62   $��25��6=   
�������$ 0,2,4,0��6`   ._�5,   "   �� $ offText��6,   $	��Off��6=   $��Center=�6H   $��Center=�6e   5-      5.       5/      P� 50       � {� .  . �51   "   ��  � �� �#ADADAD6?   52      P� 53       �@d�	IsChecked$
 trueY�6;   . �54   "   �� $ on��6)    � ��
 �����6O   �� 55   "   $ onText��6)    � ��
 �����6S   56      P� 57       �@d�	IsChecked$ FalseY�6;   . �58   "   �� $	 off��6)    � ��
 �����6P   �� 59   "   $ offText��6)    � ��
 �����6T   5:      5<      5>      5?      5@       � DataContext 5B      %   WPF_ToggleSample.Main_ViewModel  5C   
   .��5F      � .+�5G   
   �� $��Center=�6   $��Center=�60   .+�5H      d� -   5         d�Name$ ToggleButton_togglecamera��5H      #��[ 5L      ��5J      �� *togglecamera_Command+��5K      ��  �� ElementName$ ToggleButton_togglecamera��.��5M      �� $
��Bold"�6   Togglecamera68   5N      d� 5O      -   5        $ ToggleButton_Func_Test��5O      #��[ 5S      ��5Q      �� *toggleTestFunc_Command+��5R      �� $ ToggleButton_Func_Test��.��5T      �� $
��Bold"�6   ToggleButton_Test6A   5U      5V      5X      5Y      