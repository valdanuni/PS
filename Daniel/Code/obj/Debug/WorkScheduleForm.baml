   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   6    0PS_Hospital_System_Project_2019.WorkScheduleForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$  WorkScheduleForm��5	   	   $��414.733��6#   $	��800��64    � 
ResizeMode$ NoResize=�6A    � WindowStyle$
 None=�6W    � WindowStartupLocation$ CenterScreen=�6j   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5
      � .+�5   
   �� $	��414��6   $	��Top=�6"   $��0,0,-3,0q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��282��6   
�������$��Bottom=�6.   $��10,0,10,62.4q�6I   	 �� RadiusY$
	 21.2��6_   
 �� RadiusX$

 21.2��6n   � 5   
   -   5         �Name$ DoctorWSForm��5      $	��542��6%   $��Bottom=�62   $��40,-56,-3,-29.2q�6M   $y�	Collapsed=�6f    � ColumnDefinitions 5      �� 5      $
��196* �6#   �� 5      $
��179* �6#   .+�5      �� -   5         ��Name$ DoctorWSTitle��5      $��Add Work Schedule��6/   $��Center=�6H   $	��Top=�6e   $��285,124,294.2,0q�6}   
�������$��18(�6�   $��28��6�   $��2��6�    J� RenderTransformOrigin$ 0.511,-0.286&�6�   $	��184��6�   6	  �� 5      $��Center=�6   $��10,195,34.2,118q�65   $	��229��6N   $��2��6[   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ DoctorWSDate��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Date��63   $��51��6Y    (  $MaterialDesignFloatingHintDatePicker#��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.2,0q�6�   )  #MaterialDesignThemes.Wpf.TimePicker  5      -   5          Name$ DoctorWSTime��5   ,    ( $MaterialDesignFloatingHintTimePicker#��[ 6B   $
 Time��6�   $��45��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5      -   5         ��Name$ DoctorWSHospital��5      $ Hospital��66   $��51��6`    & "MaterialDesignFloatingHintComboBox#��[ 6l   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5      -   5         ��Name$ DoctorWSRoom��5      $
 Room��60   $��52��6V    % !MaterialDesignFloatingHintTextBox#��[ 6b   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.2,0q�6�   5       5!      �� 5"   
   -   5         ��Name$ ExitBtn��5"      
������ 
������ $
��Left=�6W   $��	740,0,0,0q�6r   $	��Top=�6�   $ -0.613,0.156&�6�   $��60��6�   $��40��6�   .��5#      �� .��5$      �� $��Assets/xButton.png��6   $��28��64   $ 0.5,0.5&�6@   $��55��6`   5%      5&      �� 5'   
   -	   5        $ minimizeBtn��5'      
������ 
������ $
��Left=�6Z   $��	704,0,0,0q�6u   $	��Top=�6�   $ -0.613,0.156&�6�   $��55��6�   $��40��6�   .��5(      �� .��5)      �� $��Assets/minimize.png��6   $��25��65   $ 0.5,0.5&�6A   $��33��6a   5*      5+      �� 5,   
   -
   5        $ saveBtn��5,      $y�	Collapsed=�6"   $
��Save��69   $��18(�6H   
���   �
����+��$
��Left=�6�   $��260,367,0,15.4q�6�   $	��264��6�   5-      5.      