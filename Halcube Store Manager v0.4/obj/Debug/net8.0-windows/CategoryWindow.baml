   M S B A M L   `   `   `  ����U  QHalcube Store Manager v0.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Halcube_Store_ManagerHalcube_Store_Manager  5   	   *    $Halcube_Store_Manager.CategoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Halcube_Store_Manager     5   	     � 
ResizeMode$  NoResize=�5   	   $	��450��5	   
   $	��496��6   ���#F0F2F5 � 	Resources 5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid   AddCategoryButtonStyle �� Triggers P� Property P� Value��%k  '��       '  �     '�� �    &	  �    �� 5   
   " ��6   .�5      ��  � ��$ 20(�6)   �� 5       � �� �#3336+   �� 5       � ��$ Center=�64   5      �� 5   
   "  6   .�5      ��  � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       � ��$ Stretch=�64   �� 5       � ��$	 Top=�62   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5        � ��$ 14(�6)   �� 5!       � ��$ Center=�64   �� 5"       � ��$	 Top=�62   �� 5#       � ��$ 5q�6(   5$      �� 5&   
   " ��6/   .�5'      ��  � �� �#3F51B56+   �� 5(       � ��
 �����6+   �� 5)       � ��$ 14(�6)   �� 5*       � ��$
 10,5q�6(   �� 5+       � ��$ Center=�64   �� 5,       � ��$	 0,5q�6'    5-      P� 5.       �@J�IsMouseOver$
 True��61   . �5/      ��  � �� �#2C3E9163   50      52      53      .��55      � $	��434��6   $��Bottom=�6   .+�58   
   �� -   5         ��Name$ 	NameLabel��58      $��
Categories��6#   $��0��68   $
��Bold"�6E   $��	0,18,0,10q�6W   �� 5:   
   -   5        	 ��Name$	 CategoryNameBox��5:      $��0��6+   $	��343��6;   $��35��6G   $��	10,63,0,0q�6S   $
��Left=�6f   �� 5<   
   -   5        
 ��Name$
 AddCategoryButton��5<      $��Add Category��6,   $	��110��6C   $��35��6O   #��[  6[   $��Right=�6�   $��0,63,10,336q�6�   6�     5>   
   -   5          Name$ CategoriesGrid��5>      $��10,121,10,0q�6+   $	��266��6@   5?      5@      