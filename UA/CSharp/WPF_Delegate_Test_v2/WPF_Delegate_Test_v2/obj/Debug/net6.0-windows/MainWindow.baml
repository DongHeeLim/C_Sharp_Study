   M S B A M L   `   `   `  ����O  KWPF_Delegate_Test_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPF_Delegate_Test_v2WPF_Delegate_Test_v2  5   	   %    WPF_Delegate_Test_v2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WPF_Delegate_Test_v2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	      (  "WPF_Delegate_Test_v2.MainViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ btn_Main��5      $��0��6#   60   �� 5   
   -   5         ��Name$ txt_Main��5      $��1��6$   ��61   �� *	TEXT_NAME+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� 5   
   -   5         �Name$ 	Grid_Main��5      $��2��6"   .+�5         WPF_Delegate_Test_v2.UC1  5      �� 5   
   -   5         ��Name$ scrollViewer��5      $��3��6-   .��5   
   �� -   5        $ 
scroll_txt��5      	 �� 
IsReadOnly$
	 True��5      
���   �$��20(�5      $
��Auto=�5      $
��Auto=�5      $
��True��5      
 �� TextWrapping$

 Wrap=�5       5"      5#      5$      