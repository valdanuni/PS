   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   6    0PS_Hospital_System_Project_2019.HospitalRegister   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5          � Title$  Hospital Register��5	   	   $	��517��6#   $	��800��60    � 
ResizeMode$ NoResize=�6<    � WindowStyle$
 None=�6R    � WindowStartupLocation$ CenterScreen=�6e   {�. $	��800��6�   $	��720��6�   $��Disabled=�6�    � ShowInTaskbar . |�. .��5
      � $��Disabled=�6   $	��800��6?   $	��720��6N   .+�5   
   �� $	��517��6   $	��Top=�6"   $��0,0,-3,-0.2q�6:   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��404��6   
�������$	��Top=�6.   $��
25,69,19,0q�6F   	 �� RadiusY$
	 21.2��6Z   
 �� RadiusX$

 21.2��6i   � 5   
   $	��750��6   $	��623��6   $��Bottom=�6(   $��
25,0,25,10q�6C   .+�5      �� $��Hospital Register ��6   $��Center=�62   $	��Top=�6O   $��304,135,296,0q�6g   
�������$��18(�6�   $��30��6�   $	��150��6�   �� 5      $��Center=�6   $��20,221,0,122q�65   $	��280��6K   .+�5      �� -   5         ��Name$
 Name��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Hospital Name��6(   $��55��6W    %  !MaterialDesignFloatingHintTextBox#��[  6c   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5      -   5        $ Owner��5      $  Owner(First and Last Name)��6)   $��55��6e   #��[  6q   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   6�   �� 5      -   5        $ Address��5      $ Address��6+   $��51��6T   #��[  6`   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   �� 5      -   5        $ MobilePhone��5      $ MobilePhone��6/   $��51��6\   #��[  6h   $��Champagne & Limousines)�6�   $��18(�6�   $��0,0,10,0q�6�   5      5      �� 5    
   -   5        $��Bottom=�5       $��299,0,301,105q�6,   $��Center=�6C   $	��200��6`   $��Register��6l   ���	#FF30F130$��18(�6�   
���   � J� RenderTransformOrigin$ 0.504,-1.387&�6�   6�   �� 5!   
   -   5         ��Name$ ExitBtn��5!      
������ 
������ $
��Left=�6U   $��
745,0,-3,0q�6p   $	��Top=�6�   $��58��6�   $��35��6�   .��5"      �� .��5#      �� $��../Assets/xButton.png��6   $��24��67   $ 0.5,0.5&�6C   $��55��6c   5$      5%      �� 5&   
   -   5        $ MinimizeBtn��5&      
������ 
������ $
��Left=�6Y   $��	712,0,0,0q�6t   $	��Top=�6�   $��58��6�   $��35��6�   .��5'      �� .��5(      �� $��../Assets/minimize.png��6   $��26��68   $ 0.5,0.5&�6D   $��33��6d   5)      5*      5+      5,      