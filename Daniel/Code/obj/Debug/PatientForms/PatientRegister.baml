   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   5    /PS_Hospital_System_Project_2019.PatientRegister   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$  Patient Register��5	   	   $	��649��6"   $	��800��6/    � 
ResizeMode$ NoResize=�6;    � WindowStyle$
 None=�6Q    � WindowStartupLocation$ CenterScreen=�6d   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5
      � .+�5   
   �� $	��649��6   $	��Top=�6"   $��0,0,-3,-0.2q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��517��6   
�������$��Bottom=�6.   $��
19,0,25,56q�6I   	 �� RadiusY$
	 21.2��6]   
 �� RadiusX$

 21.2��6l   � 5   
   $	��750��6   $	��620��6   $��Bottom=�6(   $��
22,0,22,10q�6C    � ColumnDefinitions 5      �� 5      $
��196* �6#   �� 5      $
��179* �6#   .+�5      �� $��Patient Register ��6   $��Center=�61   $	��Top=�6N   $��309,10,312.4,0q�6f   
�������$��18(�6�   $��28��6�   $��2��6�   6�   �� 5      $��Center=�6   $��10,59,10.4,166q�65   $	��395��6M   $��2��6Z   .+�5      �� -   5         ��Name$
 Name��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��6(   $��55��6T    %  !MaterialDesignFloatingHintTextBox#��[  6`   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5      -   5        $ 
MiddleName��5      $ Second Name��6/   $��59��6\   #��[  6h   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5      -   5        $ 
FamilyName��5      $ 	Last Name��6.   $��57��6Y   #��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5       -   5        $	 Age��5       $	 Age��6'   $��51��6L   #��[  6X   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5!      -   5        $	 Egn��5!      $	 EGN��6'   $��51��6L   #��[  6X   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5"      -   5        $ Address��5"      $ Address��6+   $��51��6T   #��[  6`   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5#      -   5        $ MobilePhone��5#      $ Mobile Phone��6/   $��51��6]   #��[  6i   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   5$      5%      �� 5&   
   -	   5        $��Bottom=�5&      $��301,0,299,99q�6,   $��Center=�6B   $	��200��6_   $��Register��6k   ���	#FF30F130$��18(�6�   
���   � J� RenderTransformOrigin$ 0.51,-2.059&�6�   6�   �� 5'   
   -
   5         ��Name$ ExitBtn��5'      $
��Left=�6"   
������ 
������ $��
742,0,-3,0q�6p   $	��Top=�6�   $��61��6�   $��36��6�   .��5(      �� .��5)      �� $��../Assets/xButton.png��6   $��28��67   $ 0.5,0.5&�6C   $��55��6c   5*      5+      �� 5,   
   -   5        $ MinimizeBtn��5,      $
��Left=�6&   
������ 
������ $��	698,0,0,0q�6t   $	��Top=�6�   $��57��6�   $��36��6�   .��5-      �� .��5.      �� $��../Assets/minimize.png��6   $��25��68   $ 0.5,0.5&�6D   $��33��6d   5/      50      51      52      