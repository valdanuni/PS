   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   5    /PS_Hospital_System_Project_2019.ReservationForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Reservation��5	   	   $��456.8��6   $	��800��6,    � 
ResizeMode$ NoResize=�69    � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�6b   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5      � .+�5   
   �� $	��528��6   $	��Top=�6"   $��0,0,-3,0q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��301��6   
�������$��Bottom=�6.   $��10,0,9.6,74q�6I   	 �� RadiusY$
	 21.2��6^   
 �� RadiusX$

 21.2��6m   � 5   
   -   5         �Name$ DoctorReservationForm��5      $	��750��6.   $	��542��6:   $��Bottom=�6G   $��40,-75,10,-29.4q�6b   $y�	Collapsed=�6{    � ColumnDefinitions 5      �� 5      $
��196* �6#   �� 5      $
��179* �6#   .+�5      �� -   5         ��Name$ DoctorReservationTitle��5      $��Make a reservation��68   $��Center=�6R   $	��Top=�6o   $��281,101,318.4,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   6�   �� 5      $��Center=�6   $��10,167,34.4,115q�65   $	��260��6N   $��2��6[   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ DoctorReservationDate��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Date��6k   $��51��6�    (  $MaterialDesignFloatingHintDatePicker#��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��
0,0,10.4,0q�6     Text 6<   ��  �� Path$ AdminPatientProfile.Date�6  )  #MaterialDesignThemes.Wpf.TimePicker  5      -   5          Name$ DoctorReservationTime��5   ,    ( $MaterialDesignFloatingHintTimePicker#��[ 6K   $
 Time��6�   $��45��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5      -   5         ��Name$ DoctorReservationPatient��5      $ Patient��6=   $��55��6f    & "MaterialDesignFloatingHintComboBox#��[ 6r   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.4,0q�6�   �� 5       -   5        $ DoctorReservationHospital��5       $ Hospital��6?   $��51��6i   #��[ 6u   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5!      -   5         ��Name$ DoctorReason��5!      $ Reason��60   $��51��6Y    % !MaterialDesignFloatingHintTextBox#��[ 6e   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   5"      5#      � 5$   
   -	   5        $ HospitalReservationForm��5$      $	��750��60   $	��542��6<   $��Bottom=�6I   $��40,-75,10,-29.4q�6d   $y�	Collapsed=�6}    5%      �� 5&      $
��196* �6#   �� 5'      $
��179* �6#   .+�5)      �� -
   5        $ HospitalReservationTitle��5)      $��Make a reservation��6:   $��Center=�6T   $	��Top=�6q   $��281,101,318.4,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   6�   �� 5*      $��Center=�6   $��10,167,34.4,115q�65   $	��260��6N   $��2��6[   .+�5+        -   5        $ HospitalReservationDate��5+      $
 Date��6m   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��
0,0,10.4,0q�6   6>   �� $ AdminPatientProfile.Date�6    5,      -   5        $ HospitalReservationTime��5,   ,   #��[ 6M   $
 Time��6�   $��45��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5-      -   5        $  HospitalReservationPatient��5-      $ Patient��6?   $��55��6h   #��[ 6t   $��Champagne & Limousines)�6�   $��18(�6�   $��
0,0,10.4,0q�6�   �� 5.      -   5        $ HospitalReservationDoctor��5.      $ Doctor��6?   $��51��6g   #��[ 6s   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5/      -   5        $ HospitalReason��5/      $ Reason��62   $��51��6[   #��[ 6g   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   50      51      �� 52   
   -   5         ��Name$ ExitBtn��52      
������ 
������ $
��Left=�6W   $��	740,0,0,0q�6r   $	��Top=�6�    J� RenderTransformOrigin$ -0.613,0.156&�6�   $��60��6�   $��40��6�   .��53      �� .��54      �� $��../Assets/xButton.png��6   $��28��67   $ 0.5,0.5&�6C   $��55��6c   55      56      �� 57   
   -   5        $ minimizeBtn��57      
������ 
������ $
��Left=�6Z   $��	704,0,0,0q�6u   $	��Top=�6�   $ -0.613,0.156&�6�   $��55��6�   $��40��6�   .��58      �� .��59      �� $��../Assets/minimize.png��6   $��25��68   $ 0.5,0.5&�6D   $��33��6d   5:      5;      �� 5<   
   -   5        $ saveBtn��5<      $y�	Collapsed=�6"   $
��Save��69   $��18(�6H   
���   �
����+��$
��Left=�6�   $��260,405,0,19.8q�6�   $	��264��6�   6�   5=      5>      