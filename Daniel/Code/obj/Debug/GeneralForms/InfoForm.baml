   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   .    (PS_Hospital_System_Project_2019.InfoForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$   ��5
   	   $	��490��6   $	��800��6    � 
ResizeMode$ NoResize=�6,    � WindowStyle$
 None=�6B    � WindowStartupLocation$ CenterScreen=�6U   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5      � -   5         �Name$ InfoGrid��5      $y�Visible=�6   .+�5   
   �� $��0,0,-3,0q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#   	 � Offset$		 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $		 0.5Q�65   5      5      � 5   
   -   5        $ 
PersonInfo��5      $	��750��6#   $	��704��6/   $	��Top=�6<   $��25,0,25,-116q�6T   $y�	Collapsed=�6j   .+�5      �� $	��416��6   
�������$��Bottom=�62   $��	0,0,0,245q�6M   
 �� RadiusY$

 21.2��6`    �� RadiusX$
 21.2��6o   �� 5      -   5         ��Name$ PersonInfoTitle��5      $�� ��61    �� TextAlignment$ Center=�69   $��Center=�6P   $	��Top=�6m   $��298,10,302,0q�6�   
�������$��18(�6�   $��28��6�   $	��150��6�   �� 5      $��Center=�6   $��10,43,10,243q�65   $	��418��6K   .+�5      �� -   5         ��Name$ 	FirstName��5       �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��6a   $��55��6�    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��10,0,10.4,0q�6  ��6-   ��  �� Path$ Person.Name�6  �� 5      -   5        $ 
SecondName��5       . $ Second Name��6h   $��59��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��10,0,10.4,0q�6  ��6.   �� $ Person.MiddleName�6  �� 5      -   5        $ LastName��5       . $ 	Last Name��6f   $��57��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6   $��10,0,10.4,0q�6  ��6,   �� $ Person.FamilyName�6  �� 5      -   5        $	 Age��5       . $	 Age��6Z   $��51��6   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��10,0,10.4,0q�6�   ��6'   �� $ 
Person.Age�6�   �� 5      -	   5        $ Address��5       . $ Address��6c   $��52��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6�   $��10,0,10.4,0q�6
  ��6+   �� $ Person.Address�6
  �� 5      -
   5        $ MobilePhone��5       . $ Mobile Phone��6j   $��52��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��10,0,10.4,0q�6  ��6A   �� $ Person.MobilePhone�6  �� 5      -   5        $ Specialization��5      $ Specialization��62    �� TextWrapping$
 Wrap=�6�    �� TextAlignment$
 Left=�6�   $	��Top=�6�    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   #��[  6  $��18(�6P  " �� VerticalScrollBarVisibility$
 Auto=�6^  $y�	Collapsed=�6�  $��10,0,10.4,0q�6�  $��54��6�  ��6c   �� $ Person.Specialization�6�  5       5!      � 5"   
   -   5        $ HospitalInfo��5"      $	��588��6%   $��Bottom=�62   $y�	Collapsed=�6M   .+�5#      �� $	��304��6   
�������$��Bottom=�62   $��
28,0,28,75q�6M   $

 21.2��6a   $
 21.2��6p   �� 5$      -   5        $ HospitalTittle��5$      $��Hospital Information ��60   $��Center=�6M   $	��Top=�6j   $��307,153,326,0q�6�   
�������$��18(�6�   $��30��6�   $	��167��6�   �� 5%      $��Center=�6   $��51,234,28,108q�65   $	��246��6L   .+�5&      �� -   5        $ HospitalName��5&   I   $ Hospital Name��6    . $��55��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��6_   �� $ Hospital.Name�6  �� 5'      -   5        $ Owner��5'   V   $  Owner(First and Last Name)��6    . $��55��6�   #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��6e   �� $ Hospital.Owner�6  �� 5(      -   5        $ HospitalAddress��5(   C   $ Address��6   $��51��6�    . #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6  ��6\   �� $ Hospital.Address�6  �� 5)      -   5        $ HospitalMobilePhone��5)      $ Mobile Phone��67   $��51��6�    . #��[  6�   $��Champagne & Limousines)�6�   $��18(�6  $��0,0,10,0q�6   ��6e   �� $ Hospital.MobilePhone�6   5*      5+      �� 5,   
   -   5         ��Name$ ExitBtn��5,      $
��Left=�6"   
������ 
������ $��
742,0,-3,0q�6p   $	��Top=�6�   $��61��6�   $��36��6�   .��5-      �� .��5.      �� $��../Assets/xButton.png��6   $��28��67    J� RenderTransformOrigin$ 0.5,0.5&�6C   $��55��6c   5/      50      �� 51   
   -   5        $ MinimizeBtn��51      $
��Left=�6&   
������ 
������ $��	698,0,0,0q�6t   $	��Top=�6�   $��57��6�   $��36��6�   .��52      �� .��53      �� $��../Assets/minimize.png��6   $��25��68   $ 0.5,0.5&�6D   $��33��6d   54      55      56      57      