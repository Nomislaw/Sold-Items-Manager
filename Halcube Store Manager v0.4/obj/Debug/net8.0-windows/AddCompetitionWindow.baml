   M S B A M L   `   `   `  ����U  QHalcube Store Manager v0.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Halcube_Store_ManagerHalcube_Store_Manager  5   	   0    *Halcube_Store_Manager.AddCompetitionWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Halcube_Store_Manager     5   	   $	��550��5   	   $	��319��5	   	   ���#F0F2F5  � 
ResizeMode$  NoResize=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  '��       '�� �     '�� �    �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � �� �#3336+   �� 5       � ��$
 Left=�64   �� 5       � ��$ 0,0,0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ 10q�6(   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       � ��$ Stretch=�64   �� 5       � ��$	 Top=�62   5      �� 5   
   " ��6   .�5       ��  � �� �#3F51B56+   �� 5!       � ��
 �����6+   �� 5"       � ��$ 16(�6)   �� 5#       � ��$
 10,5q�6(   �� 5$       � ��$ Center=�64   �� 5%       � ��$
 0,10q�6'    5&      P� 5'       �@J�IsMouseOver$
 True��61   . �5(      ��  � �� �#2C3E9163   5)      5+      5,      .��5/      �� $��20q�6   .+�50   
   �� $��	Add event��6   $��24(�6$   $
��Bold"�62   ���#333$��Center=�6V   �� 52   
   $
��Name��6   �� 53   
   -   5         ��Name$ NameBox��53      $	��250��6#   �� 55   
   $
��City��6   �� 56   
   -   5        $ CityBox��56      $	��250��6#   �� 58   
   $��Country��6   �� 59   
   -   5        $ 
CountryBox��59      $	��250��6&   �� 5;   
   $��
Start date��6   (  "System.Windows.Controls.DatePicker  5<   
   -   5        	  Name$	 StartDateBox��5<      $	��250��6+   �� 5>   
   $��End date��6     5?   
   -   5        $	 
EndDateBox��5?      $	��250��6)   �� 5A   
   -   5        
 ��Name$
 ApplyButton��5A      $��Apply��6&   $	��150��66   $��50��6B   6N   5B      5C      