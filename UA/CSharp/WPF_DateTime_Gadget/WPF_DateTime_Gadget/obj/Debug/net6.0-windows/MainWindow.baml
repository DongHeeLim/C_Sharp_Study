   M S B A M L   `   `   `  ����N  JWPF_DateTime_Gadget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF_DateTime_GadgetWPF_DateTime_Gadget  5   	   $    WPF_DateTime_Gadget.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPF_DateTime_Gadget     5   	   -   5          � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��5	   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��450��6)   ��5      �� 5   
    �� Color 5      �� 5       �� A$ 1��6    �� R$ 50��6    �� G$	 255��6%    �� B$	 250��6-   67   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   A� -   5        $��6��5      
����� �	 J� Opacity$		 0.2Q�63   6A   �� 5   
   -   5        $��tb_date��5      $��2��6#   $��Center=�60   $��Center=�6K   $
��Date��6h   
�������$		 0.9Q�6�   �� 5    
   -   5        $��tb_time��5       $��3��6#   $��Center=�60   $��Center=�6K   $
��Time��6h   
�������$		 0.9Q�6�   �� 5"   
   -   5        
 ��Name$
 btn_exit��5"      $��4��6#   $��80��60   $
��Exit��6;   $
��Bold)�6J   
���� ��$��30(�6q   $��3q�6   ��5#      �� 5$       �� 
TargetType" ��6"   .R�5%      ��  �� CornerRadius$ 10��6   
�������$��5q�6B   
����� �._�5&      �� #��z��6+   $��Center=�5'   +   $��Center=�5(   +   5)      5*      5,      �� 5.   
   $��1��5/      ���#d1d0cf$��2,2,2,2q�51      $ 10,10,10,10��52      $��1,1,1,1q�53      $��80��54      ��55      �� 56       �� 
TargetType" ��6    �� Triggers 57      �� 58       �� Binding 6&   ��  �� ElementName$ button�� �� Path$ 	IsChecked� �� Mode$ OneWay=� �� Value true6j   .a�59      ��  �� Property � �� �� Value
 �  ��6;   5:      5<      ._�5?      � .+�5@      �� $��70��6   $��70��6$   
������ ._�5B      d� -   5         d�Name$ button��5C      $��50��5D      $��50��5E      $��Center=�5F      5G      5H      5I      5K      5O      