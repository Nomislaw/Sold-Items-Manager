   M S B A M L   `   `   `  ����U  QHalcube Store Manager v0.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Halcube_Store_ManagerHalcube_Store_Manager  5   	   )    #Halcube_Store_Manager.ProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Halcube_Store_Manager     5   	     � 
ResizeMode$  NoResize=�5   	   $	��600��5	   	   $	��600��6   ���#F0F2F5 � 	Resources 5         DefaultMenuItemStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  WhiteTextMenuItemStyle&   System.Windows.Controls.DataGrid��%
  &	        &	 T    '  �    �� 5   
   " m�6-   .�5      ��  � ��$ 14(�6)   �� 5       � ��
 �OO/�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0,2,0,2q�6'    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   5      5      �� 5   
   " m�6/   .�5      ��  � ��$ 14(�6)   �� 5       � ��
 �����6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0,2,0,2q�6'    5      P� 5        �@J�IsMouseOver$
 True��61   . �5!      ��  � ��
 �����63   �� 5"       � ��
 �   �63   5#      5%      �� 5'   
   "  6   .�5(      ��  � ��$ 10q�6'   �� 5)       � ��
 �����6+   �� 5*       �@ AutoGenerateColumns$ False��64   �� 5+       � ��
 �����6,   �� 5,       � ��$ 1q�60   �� 5-       � ��$ Stretch=�64   �� 5.       � ��$ Stretch=�62   5/      50      .��52      � ���#F0F2F5 � RowDefinitions 53   
   �� 54      $
��Auto �6   �� 55      $
��Auto �6   �� 56      $��* �6   	 � ColumnDefinitions	 59   
   �� 5:      $��* �6   .+�5=   
   o� $��0��6   ���#9B30FF
�������$	��Top=�6D   $��Stretch=�6\   .@�5>      m� $��	_Products��6   #��[ 6*   .@�5?      m� -   5        $��_Add Product��5?      #��[  6I   m� 5@      -   5        $��_Delete Product��5@      #��[  6O   5A      5B      �� 5D   
   -   5        
 ��Name$
 	NameLabel��5D      $��1��6$   $��Products��61   $��Center=�6D   $��24(�6a   $
��Bold"�6o   $��10q�6�   ���#3336�   �� 5F   
   $��2��6   
�������$��1q�61   
�������$��10q�6X    J� Effect 5G      3  -System.Windows.Media.Effects.DropShadowEffect  5H         Color$ Black��6#      
BlurRadius$ 10Q�61      	Direction$	 315Q�6A      ShadowDepth$ 3Q�6Q   ._�5J        -   5          Name$ ProductsGrid��5J      5K      5L      5M      