   M S B A M L   `   `   `  ����U  QHalcube Store Manager v0.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Halcube_Store_ManagerHalcube_Store_Manager  5   	   ,    &Halcube_Store_Manager.AddProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Halcube_Store_Manager     5   	   $	��435��5   	   $	��319��5	   	   ���#F0F2F5  � 
ResizeMode$  NoResize=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  '��       '�� �     '�� �    �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � �� �#3336+   �� 5       � ��$
 Left=�64   �� 5       � ��$ 0,0,0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       � ��$ Stretch=�64   �� 5       � ��$	 Top=�62   5      �� 5   
   " ��6   .�5      ��  � �� �#3F51B56+   �� 5       � ��
 �����6+   �� 5        � ��$ 16(�6)   �� 5!       � ��$
 10,5q�6(   �� 5"       � ��$ Center=�64   �� 5#       � ��$
 0,20q�6'    5$      P� 5%       �@J�IsMouseOver$
 True��61   . �5&      ��  � �� �#2C3E9163   5'      5)      5*      .��5,      �� $��20q�6   .+�5-   
   �� $��Add product��6   $��24(�6&   $
��Bold"�64   ���#333$��Center=�6X   �� 5.   
   $��Product name��6   �� 5/   
   -   5         ��Name$ ProductNameBox��5/      $	��250��6*   �� 50   
   $��Item quantity��6   �� 51   
   -   5        $ ItemQuantityBox��51      $	��250��6+   �� 52   
   $��Price��6   �� 53   
   -   5        $ PriceBox��53      $	��250��6$   �� 54   
   -   5        	 ��Name$	 ProductApplyButton��54      $��Apply��6-   $	��150��6=   $��50��6I   6U   55      56      