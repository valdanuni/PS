   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   1    +PS_Hospital_System_Project_2019.DoctorsList   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5        $	��600��5      $
��1000��6(     � 
ResizeMode$  NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � WindowStyle$
 None=�6p    � ShowInTaskbar . |�. .��5	      � .+�5
   
   � -   5         �Name$ GridMain��5
      $��10,0,-0.2,10q�6!   .+�5      �� $	��607��6   $��Center=�6&   $��-10,0,0.2,-17q�6B   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FF36EA36��6'   � 5      $ 	#FF2FDA85��6'    � Offset$	 0.5Q�69   � 5      $ 	#FF3DB93B��6'   $	 0.8Q�69   5      5      5      �� 5   
   -   5        	 ��Name$	 ExitBtn��5      
������ 
������ $
��Left=�6W   $��
947,0,-7,0q�6r   $	��Top=�6�   
 J� RenderTransformOrigin$
 -0.613,0.156&�6�   $��60��6�   $��40��6�   .��5      �� .��5      �� $��../Assets/xButton.png��6   $��28��67   $
 0.5,0.5&�6C   $��55��6c   5      5      �� 5   
   -   5        $	 minimizeBtn��5      
������ 
������ $
��Left=�6Z   $��	909,0,0,0q�6u   $	��Top=�6�   $
 -0.613,0.156&�6�   $��55��6�   $��40��6�   .��5      �� .��5      �� $��../Assets/minimize.png��6   $��25��68   $
 -0.339,0.508&�6D   $��33��6i   5      5      �� 5   
   $��Doctors List��6   
�������$��20(�68   $	��Top=�6F   $��Center=�6^   $��452,10,430,0q�6{   $	��118��6�   6�   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ Doctors��5          AutoGenerateColumns .  $y�Visible=�6C   $	��533��6Y   $��Center=�6g   $	��Top=�6�   $
��1000��6�   
������ 
������ $��0,67,0,0q�6�   ��. $
��Auto=�5!   9   $��Hidden=�6i      
IsReadOnly . .  (MaterialDesignThemes.Wpf.ScrollBarAssist   ThumbHeight$	 300Q�6�   $
 0.462,-0.162&�6�      ColumnHeaderStyle 5"      �� 5#       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5$      ��  �� Property � �� �� Value$ 16(�61   �� 5%       � ��
 ���� 63   �� 5&       � ��
 ���� 64   �� 5'       � ��$ Center=�6C   5(         RowStyle 5*      �� 5+      )  #System.Windows.Controls.DataGridRow"  6   .�5,      ��  � ��$ 16(�61   �� 5-       � ��
 ���� 63   �� 5.       � ��
 ���� 64   �� 5/       � ��$ Center=�6C   -   5        51         	CellStyle 53      �� 54      *  $System.Windows.Controls.DataGridCell"  6   .�55      ��  � ��
 ���� 63   �� 56       � ��
 ���� 64   �� 57       � ��$ 16(�61   �� 58       � ��$ Center=�6C   59         Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Full Name��6%      FontSize$ 16Q�6:      MinWidth$	 335Q�6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   ��  �� Path$ FullName�   ElementStyle 5>      �� 5?      " ��6    .�5@      ��  � ��$ Center=�6D   5A      5C        5E      $ Specialization��6%   $ 16Q�6=   $	 335Q�6s    6K   �� $ Specialization� 5F      �� 5G      " ��6    .�5H      ��  � ��$ Center=�6D   5I      5K        5L      $ Mobile Phone��6)   $ 16Q�6?   $	 335Q�6r    6M   �� $ MobilePhone� 5M      �� 5N      " ��6    .�5O      ��  � ��$ Center=�6D   5P      5R      5U      5V      5W      