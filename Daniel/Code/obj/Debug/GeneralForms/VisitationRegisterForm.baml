   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   <    6PS_Hospital_System_Project_2019.VisitationRegisterForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  VisitationRegisterForm��5	   	   $	��480��6(   $	��800��65    � 
ResizeMode$ NoResize=�6B    � WindowStyle$
 None=�6X    � WindowStartupLocation$ CenterScreen=�6k   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5      � $��0,0,0,-36.2q�6   .+�5   
   �� $	��528��6   $	��Top=�6"   $��0,0,-3,0q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��320��6   
�������$��Bottom=�6.   $��10,0,10,107q�6I   	 �� RadiusY$
	 21.2��6^   
 �� RadiusX$

 21.2��6m   � 5   
   -   5         �Name$ DoctorPSForm��5      $	��542��6%   $��Bottom=�62   $��40,-56,-3,-29.2q�6M   $y�	Collapsed=�6f    � ColumnDefinitions 5      �� 5      $
��196* �6#   �� 5      $
��179* �6#   .+�5      �� -   5         ��Name$ DoctoPSTitle��5      $��Add Visitation��6.   $��Center=�6D   $	��Top=�6a   $��299,42,352.2,0q�6y   
�������$��18(�6�   $��28��6�   $��2��6�    J� RenderTransformOrigin$ 0.511,-0.286&�6�   6�   �� 5      $��Center=�6   $��0,114,44.2,168q�65   $	��260��6M   $��2��6Z   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ DoctorPSDate��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Date��63   $��51��6Y    (  $MaterialDesignFloatingHintDatePicker#��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.2,0q�6�   )  #MaterialDesignThemes.Wpf.TimePicker  5      -   5          Name$ DoctorPSTime��5   ,    ( $MaterialDesignFloatingHintTimePicker#��[ 6B   $
 Time��6�   $��45��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5      -   5         ��Name$ DoctorPSPatient��5      $ Patient��64   $��55��6]    & "MaterialDesignFloatingHintComboBox#��[ 6i   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.4,0q�6�   �� 5       -   5        $ DoctorPSHospital��5       $ Hospital��66   $��51��6`   #��[ 6l   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5!      -   5         ��Name$ DoctorPSDiagnose��5!      $ Diagnose��64   $��52��6^    % !MaterialDesignFloatingHintTextBox#��[ 6j   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.2,0q�6�   5"      5#      � 5$   
   -	   5        $ HospitalPSForm��5$      $	��542��6'   $��Bottom=�64   $��40,-56,-3,-29.2q�6O   $y�	Collapsed=�6h    5%      �� 5&      $
��196* �6#   �� 5'      $
��179* �6#   .+�5)      �� -
   5        $ HospitalPSTitle��5)      $��Add Visitation��61   $��Center=�6G   $	��Top=�6d   $��318,35,326.8,0q�6|   
�������$��18(�6�   $��28��6�   $��2��6�   6�   �� 5*      $��Center=�6   $��0,114,44.2,168q�65   $	��260��6M   $��2��6Z   .+�5+        -   5        $ HospitalPSDate��5+      $
 Date��65   $��51��6[   #��[  6g   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.2,0q�6�     5,      -   5        $ HospitalPSTime��5,   ,   #��[ 6D   $
 Time��6�   $��45��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5-      -   5        $ HospitalPSPatient��5-      $ Patient��66   $��55��6_   #��[ 6k   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.4,0q�6�   �� 5.      -   5        $ HospitalPSDoctor��5.      $ Doctor��66   $��51��6^   #��[ 6j   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5/      -   5        $ HospitalPSDiagnose��5/      $ Diagnose��66   $��52��6`   #��[ 6l   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.2,0q�6�   50      51      �� 53   
   -   5         ��Name$ ExitBtn��53      
������ 
������ $
��Left=�6W   $��	740,0,0,0q�6r   $	��Top=�6�   $ -0.613,0.156&�6�   $��60��6�   $��40��6�   .��54      �� .��55      �� $��../Assets/xButton.png��6   $��28��67   $ 0.5,0.5&�6C   $��55��6c   56      57      �� 58   
   -   5        $ minimizeBtn��58      
������ 
������ $
��Left=�6Z   $��	704,0,0,0q�6u   $	��Top=�6�   $ -0.613,0.156&�6�   $��55��6�   $��40��6�   .��59      �� .��5:      �� $��../Assets/minimize.png��6   $��25��68   $ 0.5,0.5&�6D   $��33��6d   5;      5<      �� 5=   
   -   5        $ saveBtn��5=      $y�	Collapsed=�6"   $
��Save��69   $��18(�6H   
���   �
����+��$
��Left=�6�   $��260,421,0,40q�6�   $	��264��6�   6�   5?      5@      