   M S B A M L   `   `   `  ����U  QHalcube Store Manager v0.4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Halcube_Store_ManagerHalcube_Store_Manager  5   	   &     Halcube_Store_Manager.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Halcube_Store_Manager     5   	     � 
ResizeMode$  NoResize=�5   	   $	��600��5	   	   $	��600��6   ���#F0F2F5 � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value&   System.Windows.Controls.DataGrid��%�  'm�       '  T    �� 5   
   " m�6   .�5      ��  � ��$ 14(�6)   �� 5       � ��
 �OO/�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0,2,0,2q�6'    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   5      5      �� 5   
   "  6   .�5      ��  � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       �@ AutoGenerateColumns$ False��64   �� 5       � ��
 �����6,   �� 5        � ��$ 1q�60   �� 5!       � ��$ Stretch=�64   �� 5"       � ��$ Stretch=�62   5#      5$      .��5&      �  � RowDefinitions 5'   
   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $��* �6   	 � ColumnDefinitions	 5-   
   �� 5.      $��* �6   .+�52   
   o� $��0��6   ���#3F51B5
�������$	��Top=�6D   $��Stretch=�6\   .@�53      m� $��_File��6   
�������.@�54      m� -   5        $��_Save data to yaml File��54      6<   m� 55      -   5        $��_Load data from yaml File��55      6>   56      m� 57      $��_Events��6   
�������.@�58      m� -   5        $��
_Add event��58      6/   m� 59      -   5        $��_Delete event��59      62   m� 5:      -   5        $��_Edit event��5:      60   �� 5;      6   m� 5<      -   5        $��_Clear all data��5<      64   5=      5>      �� 5A   
   $��1��6   $��Events��6   $��Center=�6.   $��24(�6K   $
��Bold"�6Y   $��10q�6k   ���#3336w   �� 5D   
   $��2��6   
�������$��1q�61   
�������$��10q�6X   
 J� Effect
 5E      3  -System.Windows.Media.Effects.DropShadowEffect  5F         Color$ Black��6#      
BlurRadius$ 10Q�61      	Direction$	 315Q�6A      ShadowDepth$ 3Q�6Q   ._�5H        -   5          Name$ CompetitionsGrid��5H      5I      5J      5K      