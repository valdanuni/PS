   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   4    .PS_Hospital_System_Project_2019.DoctorRegister   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  DoctorRegister��5	   	   $	��720��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$
 None=�6^   {�. $	��720��6�   $	��800��6�   $��Disabled=�6�    � 
ResizeMode$ CanMinimize=�6�    � ShowInTaskbar . |�. .��5
      � .+�5   
   �� $	��720��6   $	��Top=�6"   $��	0,0,0,-24q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��596��6   
�������$��Bottom=�6.   $��
22,0,22,39q�6I   	 �� RadiusY$
	 21.2��6]   
 �� RadiusX$

 21.2��6l   � 5   
   $	��750��6   $	��623��6   $��Bottom=�6(   $��10,0,-40,-101q�6C   .+�5      �� $��Doctor Register ��6   $��Center=�60   $	��Top=�6M   $��294,-168,327,0q�6e   
�������$��18(�6�   $��28��6�   �� 5      $��Center=�6   $��32,-104,54.4,270q�65   $	��457��6O   $��2��6\   .+�5      �� -   5         ��Name$
 Name��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��6(   $��55��6T    %  !MaterialDesignFloatingHintTextBox#��[  6`   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,52,0q�6�   6�   �� 5      -   5        $ 
MiddleName��5      $ Second Name��6.   $��59��6[   #��[  6g   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,52,0q�6�   6�   �� 5      -   5        $ 
FamilyName��5      $ 	Last Name��6.   $��57��6Y   #��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,52,0q�6�   6�   �� 5      -   5        $	 Egn��5      $	 EGN��6'   $��52��6L   #��[  6X   $��Champagne & Limousines)�6�   $��18(�6�   $
��Left=�6�   $	��612��6�   6�   �� 5      -   5        $ Address��5      $ Address��6+   $��52��6T   #��[  6`   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,52,0q�6�   �� 5      -   5        $ MobilePhone��5      $ Mobile Phone��6/   $��51��6]   #��[  6i   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,52,0q�6�   6�   �� 5       -   5        $ Specialization��5       $ Specialization��62    �� TextWrapping$
 Wrap=�6b    �� TextAlignment$
 Left=�6v   $	��Top=�6�    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   #��[  6�   $��18(�6#  " �� VerticalScrollBarVisibility$
 Auto=�61  $��0,0,52,0q�6T  $��54��6f  5!      5"      �� 5#   
   -	   5         ��Name$ RegisterBtn��5#      $��Bottom=�6&   $��251,0,269,75q�6A   $��Center=�6W   $	��200��6t   $��Register��6�   ���	#FF30F130$��18(�6�   
���   �6�   �� 5$   
   -
   5        $ ExitBtn��5$      
������ 
������ $
��Left=�6U   $��	660,0,0,0q�6p   $	��Top=�6�   $��60��6�   $��35��6�   .��5%      �� .��5&      �� $��../Assets/xButton.png��6   $��25��67    J� RenderTransformOrigin$ 0.5,0.5&�6C   $��25��6c   5'      5(      �� 5)   
   -   5        $ MinimizeBtn��5)      
������ 
������ $
��Left=�6Y   $��	627,0,0,0q�6t   $	��Top=�6�   $��60��6�   $��35��6�   .��5*      �� .��5+      �� $��../Assets/minimize.png��6   $��25��68   $ 0.5,0.5&�6D   $��33��6d   5,      5-      5.      5/      