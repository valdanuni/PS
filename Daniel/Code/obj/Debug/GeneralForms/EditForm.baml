   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   .    (PS_Hospital_System_Project_2019.EditForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$   ��5	      $	��650��6   $	��800��6!    � 
ResizeMode$ NoResize=�6.    � WindowStyle$
 None=�6D    � WindowStartupLocation$ CenterScreen=�6W   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5
      �  � RowDefinitions 5   
   �� 5      $
��303* �6   �� 5      $��7* �6   .+�5   
   �� $	��668��6   $	��Top=�6"   $��
0,0,-3,-48q�6:   $��2��6N   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#   	 � Offset$		 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $		 0.5Q�65   5      5      �� 5   
   $	��450��6   
�������$��Bottom=�6.   $��
19,0,25,79q�6I   
 �� RadiusY$

 21.2��6]    �� RadiusX$
 21.2��6l   � 5   
   -   5         �Name$ AdminRegPatientForm��5      $	��542��6,   $��Bottom=�69   $��40,0,10,-29q�6T   $y�	Collapsed=�6i   $��2��6�    � ColumnDefinitions 5      �� 5      $
��196* �6#   �� 5      $
��179* �6#   .+�5      �� -   5         ��Name$ AdminRegPatientRecord��5      $��Edit Patient Record��67   $��Center=�6R   $	��Top=�6o   $��303,-60,296,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   6�   �� 5      $��Center=�6   $��10,10,34,132q�65   $	��400��6K   $��2��6X   .+�5       �� -   5         ��Name$ AdminPatientName��5       )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��6^   $��55��6�    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6  ��64   �� *AdminPatientProfile.Name+6  �� 5!      -   5        $ AdminPatientMiddleName��5!      $ Second Name��6j   $��59��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��6:   �� * AdminPatientProfile.MiddleName+6&  �� 5"      -   5        $ AdminPatientFamilyName��5"      $ 	Last Name��6j   $��57��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��6:   �� * AdminPatientProfile.FamilyName+6$  �� 5#      -   5        $ AdminPatientAge��5#      $	 Age��6\   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   ��63   �� *AdminPatientProfile.Age+6  �� 5$      -   5        $ AdminPatientEgn��5$      $	 EGN��6\   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   ��63   �� *AdminPatientProfile.Egn+6  �� 5%      -	   5        $ AdminPatientAddress��5%      $ Address��6d   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6  ��67   �� *AdminPatientProfile.Address+6  �� 5&      -
   5        $ AdminPatientMobilePhone��5&      $ Mobile Phone��6l   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6
  $��0,0,10,0q�6  ��6;   �� *!AdminPatientProfile.MobilePhone+6*  5'      5(      � 5)   
   -   5        $ AdminRegDoctorForm��5)      $	��393��6+   $��Bottom=�68   $��19,0,31,105q�6S   $y�	Collapsed=�6h    5*      �� 5+      $
��196* �6#   �� 5,      $
��179* �6#   .+�5.      �� -   5        $ AdminRegDoctorRecord��5.      $��Edit Doctor Record��66   $��Center=�6P   $	��Top=�6m   $��313,-90,287,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   6�   �� 5/      $��Center=�6   $��
20,-36,0,0q�65   $	��429��6I   $��2��6V   .+�50      �� -   5        $ AdminDoctorName��50      $ 
First Name��6a   $��55��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6  ��63   ��  �� Path$ AdminDoctorProfile.Name�6  �� 51      -   5        $ AdminDoctorMiddleName��51      $ Second Name��6m   $��59��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6	  $��0,0,10,0q�6  ��69   �� $# AdminDoctorProfile.MiddleName�6)  �� 52      -   5        $ AdminDoctorFamilyName��52      $ 	Last Name��6m   $��57��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��69   �� $# AdminDoctorProfile.FamilyName�6'  �� 53      -   5        $ AdminDoctorEgn��53      $	 EGN��6_   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6  ��62   �� $ AdminDoctorProfile.Egn�6  �� 54      -   5        $ AdminDoctorAddress��54      $ Address��6g   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6   $��0,0,10,0q�6  ��66   �� $  AdminDoctorProfile.Address�6   �� 55      -   5        $ AdminDoctorMobilePhone��55      $ Mobile Phone��6o   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��6:   �� $$ AdminDoctorProfile.MobilePhone�6-  �� 56      -   5        $ AdminDoctorSpecialization��56      $ Specialization��6w   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6%  ��6=   �� $' !AdminDoctorProfile.Specialization�67  57      58      � 59   
   -   5        $ AdminRegHospitalForm��59      $	��318��6-   $��Bottom=�6:   $��
40,0,10,79q�6U   $y�	Collapsed=�6i    5:      �� 5;      $
��196* �6#   �� 5<      $
��179* �6#   .+�5>      �� -   5        $ AdminRegHospitalRecord��5>      $��Edit Hospital Record��68   $��Center=�6T   $	��Top=�6q   $��261,-104,309,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   $	��180��6�   6�   �� 5?      $��Center=�6   $��-18,0,38,41q�65   $	��277��6J   $��2��6W   .+�5@      �� -   5        $ AdminHospitalName��5@      $ Hospital Name��65    �� 
IsReadOnly .  $��42��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��	27,0,30,0q�6%  ��6d   �� $ AdminHospitalProfile.Name�68  �� 5A      -   5        $ AdminHospitalOwner��5A      $ Owner ��6g   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��	27,0,30,0q�6  ��66   �� $  AdminHospitalProfile.Owner�6  �� 5B      -   5        $ AdminHospitalAddress��5B      $ Address��6k   $��51��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��	27,0,30,0q�6  ��68   �� $" AdminHospitalProfile.Address�6%  �� 5C      -   5        $ AdminHospitalMobilePhone��5C      $ Mobile Phone��6<    .  $��52��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6$  $��	27,0,30,0q�62  ��6j   �� $&  AdminHospitalProfile.MobilePhone�6E  5D      5E      � 5F   
   -   5        $ DoctorPatientVisitForm��5F      $	��360��6/   $��Bottom=�6<   $��
19,0,31,13q�6W   $y�	Collapsed=�6k   $��2��6�    5G      �� 5H      $
��345* �6#   �� 5I      $	��47* �6#   �� 5J      $	��51* �6#   �� 5K      $
��307* �6#   .+�5M      �� -   5        $" DoctorPatientVisitationTitle��5M      $��Edit Patient Visitation��6>   $��Center=�6]   $	��Top=�6z   $��273,-134,271,0q�6�   
�������$��18(�6�   $��28��6�   $��4��6�   $	��206��6�   6�   �� 5N      $��Center=�6   $��0,-32,20,123q�65   $	��269��6K   $��4��6X   .+�5O      (  "System.Windows.Controls.DatePicker  -   5          Name$ DoctorVisitDate��5O      $ Visitation Date��6f   $��91��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   $��Champagne & Limousines)�6�   $��18(�6
  $
��10,0q�6     Text 66   �� $ DoctorPatientProfile.Date�6  )  #MaterialDesignThemes.Wpf.TimePicker  5P      -   5          Name$ DoctorVisitTime��5P   ,    ( $MaterialDesignFloatingHintTimePicker#��[ 6E   $ Visitation Time��6�   $	��100��6�   $��Champagne & Limousines)�6�   $��18(�6�   $
��10,0q�6�   5Q      5R      � 5T   
   -   5        $ DoctorReservationsForm��5T      $	��340��6/   $��Bottom=�6<   $��	25,0,25,8q�6W   $y�	Collapsed=�6j    5U      �� 5V      $
��196* �6#   �� 5W      $
��179* �6#   .+�5Y      �� -   5        $ DoctorReservationTitle��5Y      $��Edit Reservation Record��68   $��Center=�6W   $	��Top=�6t   $��278,-132,240,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   $	��232��6�   6�   �� 5Z      $��Center=�6   $��10,-51,10,143q�65   $	��248��6L   $��2��6Y   .+�5[        -    5        $ DoctorReservationDate��5[      $ Reservation Date��6p   $��81��6�   #��[ 6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6#   6<   �� $# DoctorReservationProfile.Date�6#    5\      -!   5        $ DoctorReservationTime��5\   ,   #��[ 6K   $ Reservation Time��6�   $��77��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5]      -"   5        $ DoctorReservationReason��5]      $ Reason��6;    .  $��72��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  ��6c   �� $% DoctorReservationProfile.Reason�6  5^      5_      � 5`   
   -#   5        $ HospitalPatientForm��5`      $	��340��6,   $��Bottom=�69   $��	25,0,25,8q�6T   $y�	Collapsed=�6g    5a      �� 5b      $
��196* �6#   �� 5c      $
��179* �6#   .+�5e      �� -$   5        $ HospitalPatientTitle��5e      $&�� Edit Hospital Patient Visitation��66   $��Center=�6^   $	��Top=�6{   $��253,-136,246,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   $	��251��6�   6�   �� 5f      $��Bottom=�6   $��0,-32,20,124q�65   $	��248��6K   $��2��6X   .+�5g        -%   5        $ HospitalPatientDate��5g      $ Reservation Date��6l   $��88��6�   #��[ 6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6   6:   �� $! HospitalPatientProfile.Date�6    5h      -&   5        $ HospitalPatientTime��5h   ,   #��[ 6I   $ Reservation Time��6�   $��84��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   5i      5j      � 5l   
   -'   5        $ HospitalReservationForm��5l      $	��340��60   $��Bottom=�6=   $��	25,0,25,8q�6X   $y�	Collapsed=�6k    5m      �� 5n      $
��196* �6#   �� 5o      $
��179* �6#   .+�5q      �� -(   5        $ HospitalReservationTitle��5q      $��Edit Hospital Reservation��6:   $��Center=�6[   $	��Top=�6x   $��270,-142,278,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   $	��202��6�   6�   �� 5r      $��Center=�6   $��10,-48,10,140q�65   $	��248��6L   $��2��6Y   .+�5s        -)   5        $ HospitalReservationDate��5s      $ Reservation Date��6t   $��72��6�   #��[ 6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6'   6>   �� $% HospitalReservationProfile.Date�6'    5t      -*   5        $ HospitalReservationTime��5t   ,   #��[ 6M   $ Reservation Time��6�   $��78��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6   �� 5u      -+   5        $ HospitalReservationReason��5u      $ Reason��6=    .  $��76��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6   $��0,0,10,0q�6.  ��6e   �� $' !HospitalReservationProfile.Reason�6.  5v      5w      � 5x   
   -,   5        $ PatientReservationsForm��5x      $	��340��60   $��Bottom=�6=   $��	25,0,25,8q�6X   $y�	Collapsed=�6k    5y      �� 5z      $
��196* �6#   �� 5{      $
��179* �6#   .+�5}      �� --   5        $ PatientReservationTitle��5}      $��Edit Reservation Record��69   $��Center=�6X   $	��Top=�6u   $��262,-144,256,0q�6�   
�������$��18(�6�   $��28��6�   $��2��6�   $	��232��6�   6�   �� 5~      $��Center=�6   $��10,-32,10,124q�65   $	��248��6L   $��2��6Y   .+�5        -.   5        $ PatientReservationsDate��5      $ Reservation Date��6s   $��79��6�   #��[ 6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6&   6>   �� $$ PatientReservationProfile.Date�6&    5�      -/   5        $ PatientReservationsTime��5�   ,   #��[ 6M   $ Reservation Time��6�   $��79��6�   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6   5�      5�      �� 5�   
   -0   5         ��Name$ ExitBtn��5�      
������ 
������ $
��Left=�6W   $��	740,0,0,0q�6r   $	��Top=�6�    J� RenderTransformOrigin$ -0.613,0.156&�6�   $��60��6�   $��40��6�   .��5�      �� .��5�      �� $��../Assets/xButton.png��6   $��28��67   $ 0.5,0.5&�6C   $��55��6c   5�      5�      �� 5�   
   -1   5        $ minimizeBtn��5�      
������ 
������ $
��Left=�6Z   $��	704,0,0,0q�6u   $	��Top=�6�   $ -0.613,0.156&�6�   $��55��6�   $��40��6�   .��5�      �� .��5�      �� $��../Assets/minimize.png��6   $��25��68   $ 0.5,0.5&�6D   $��33��6d   5�      5�      �� 5�   
   -2   5        $ saveBtn��5�      $y�	Collapsed=�6"   $
��Save��69   $��18(�6H   
���   �
����+��$
��Left=�6�   $��25,602,0,13q�6�   $	��264��6�   $
��Auto��6�   $��2��6�   6�   �� 5�   
   -3   5        $ 	deleteBtn��5�      $y�	Collapsed=�6$   $��Delete��6;   $��18(�6L   
���   �
����p��$��Right=�6�   $	��264��6�   $��0,602,41,13q�6�   $
��Auto��6�   $��2��6�   5�      5�      