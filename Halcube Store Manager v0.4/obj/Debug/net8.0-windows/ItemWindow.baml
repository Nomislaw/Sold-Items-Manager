   M S B A M L   `   `   `  ����U  QHalcube Store Manager v0.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Halcube_Store_Manager_v0._2Halcube_Store_Manager_v0._2  5   	   ,    &Halcube_Store_Manager_v0._2.ItemWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Halcube_Store_Manager_v0._2     5   	   $	��600��5   	   $	��600��6   ���#F0F2F5  � 
ResizeMode$  NoResize=�5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value&   System.Windows.Controls.DataGrid��%M  '��       '�� �     '  �    �� 5   
   " ��6   .�5      ��  � ��$ 18(�6)   �� 5       � �� �#3336+   �� 5       � ��$ Center=�64   5      �� 5   
   " ��6   .�5      ��  � �� �#3F51B56+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$	 0,5q�6'    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#2C3E9163   5      5      �� 5    
   "  6   .�5!      ��  � ��$ 20q�6'   �� 5"       � ��
 �����6+   �� 5#       � ��
 �����6,   �� 5$       � ��$ 1q�60   �� 5%       � ��$ Stretch=�64   �� 5&       � ��$	 Top=�62   �� 5'       �@ AutoGenerateColumns$ False��64   5(      5*      .��5,      � $��20q�6    � RowDefinitions 5-   
   �� 5.      $
��Auto �6   �� 5/      $��* �6   �� 50      $
��Auto �6   	 � ColumnDefinitions	 52   
   �� 53      $��* �6   .+�56   
   �� -   5        
 ��Name$
 	LabelName��56      $��Items��6#   $��0��63   $��28(�6@   $
��Bold"�6N   ���#333$��0,0,0,30q�6r   �� 57   
   -   5        $
 
LabelPrice��57      $��Price:��6$   $
��Left=�65   $��20(�6P   ���#333$��	20,47,0,0q�6q     59   
   -   5          Name$ 	ItemsGrid��59      $��1��6&   $��Stretch=�63   $��Stretch=�6Q   �� 5;   
   -   5        $��Apply��5;   &   $��2��66   $��Center=�6C   $	��150��6`   $��50��6l   5<      5=      