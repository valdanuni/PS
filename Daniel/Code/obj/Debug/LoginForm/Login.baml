   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   +    %PS_Hospital_System_Project_2019.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          � Title$  Login��5	   	   $	��500��6   $	��350��6$    � 
ResizeMode$ CanMinimize=�60    � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$
 None=�6o   {�. .��5
      �  J� RenderTransformOrigin$ 0.503,0.459&�6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         RenderingBias$ Quality=�6      ShadowDepth$ 0Q�67      
BlurRadius$ 0Q�6G   	   Color$	 	#FFB4B4B4��6V   .+�5   
   �� $	��280��6   $	��Top=�6"   ��5      �� 5      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF93FA93��6#   � 5      $ 	#FF11E87C��6#    � Offset$	 0.2Q�65   � 5      $ 	#FF5CD45A��6#   $	 0.5Q�65   5      5      �� 5   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��0,100q�6U    �� RadiusY$
 21.2��6d    �� RadiusX$
 21.2��6s    5        5      $	 	#FFBBBBBB��6#   $ Quality=�65   $ 1Q�6M   $ 15Q�6]   5      � 5    
   $	��280��6   $	��240��6   $��Bottom=�6(   $��0,100q�6C   .+�5!      �� $��LOGIN ��6   $��Center=�6&   $	��Top=�6C   $��5q�6[   
�������$��18(�6x   6�   �� 5"      $��Center=�6   $��10q�64   .+�5#      �� -   5         ��Name$ Username��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��6,   $��50��6V    %  !MaterialDesignFloatingHintTextBox#��[  6b   $
��0,10q�6�   $��Champagne & Limousines)�6�   $��18(�6�   6�   G� 5$      -   5         G�Name$ Password��5$      $ Password��60   $��50��6Z    ) %MaterialDesignFloatingHintPasswordBox#��[ 6f   $
��0,10q�6�   $��Champagne & Limousines)�6�   $��18(�6�   6�   5%      5'      �� 5(   
   -   5         ��Name$ LoginBtn��5(      $��Bottom=�6#   $
��0,85q�6>   $	��150��6L   $��Login��6X   $��18(�6h   ���	#FF30F130
�������6�   �� 5+   
   $��../Assets/home.png��6   $	��100��6,   $	��100��68   $	��Top=�6E   $��20q�6]   �� 5,   
   -   5        $ ExitBtn��5,      
������ 
������ $
��Left=�6V   $��
302,0,-8,0q�6q   $	��Top=�6�   $��56��6�   .��5-      �� .��5.      �� $��../Assets/xButton.png��6   $��24��67   $ 0.5,0.5&�6C   $��44��6c   5/      50      51      52      