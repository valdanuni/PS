   M S B A M L   `   `   `  ����Z  VPS_Hospital_System_Project_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS_Hospital_System_Project_2019PS_Hospital_System_Project_2019  5   	   1    +PS_Hospital_System_Project_2019.MessageForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:PS_Hospital_System_Project_2019     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $	��250��5      $	��500��6'     � 
ResizeMode$  NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I    � WindowStyle$
 None=�6n    � ShowInTaskbar . |�. .��5	      � .+�5
   
   �� -   5         ��Name$ MsgTitle��5
      $	��Top=�6'   $��Stretch=�6_   $	��Top=�6~   $��18(�6�   
���`��� �� TextAlignment$ Center=�6�   
�������$��Arial)�6�   $��DemiBold"�6�   $��35��6   �� Padding$ 5q�6   ��6<   ��  �� Path$ MessageTitle�6.  �� 5   
   $	��215��6   $	��Top=�6"   $��0,35,0,-0.4q�6:    J� RenderTransformOrigin$ 0.5,0.5&�6O   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0.2&�67   .��5      �  � Color$ Coral��6#   � 5      $ Salmon��6#    � Offset$	 0.3Q�62   � 5      $ 	Chocolate��6#   $	 0.8Q�65   5      5      �� 5   
   $	��143��6   
�������$��Bottom=�6.   $
��auto��6I   $��32,0,34,48.6q�6V    �� RadiusY$
 21.2��6l    �� RadiusX$
 21.2��6{   �� 5   
   -   5         ��Name$ ExitBtn��5      
������ 
������ $
��Left=�6W   $��448,-5,-8,0q�6r   $	��Top=�6�   $ -0.613,0.156&�6�   $��60��6�   $��40��6�   .��5      �� .��5      �� $��../Assets/xButton.png��6   $��28��67   $ 0.5,0.5&�6C   $��55��6c   5      5      �� 5   
   -   5        $ 
MsgContent��5      $
��Wrap=�6(   $ Center=�6<   $��Center=�6y   $��18(�6�   $��56,58,48,48.6q�6�   ��6T   �� $ MessageContent�6�   �� 5   
   -   5        $ 
ConfirmBtn��5      $y�	Collapsed=�6%   $	��Yes��6<   $��16(�6J   
���   �
����+��$
��Left=�6�   $��96,208,0,7.6q�6�   $��90��6�   $
��Auto��6�   6�   �� 5   
   -   5        $ 	CancelBtn��5      $y�	Collapsed=�6$   $��No��6;   $��16(�6H   
���   �
����p��$��Right=�6�   $��90��6�   $
��Auto��6�   $��0,208,117,9.6q�6�   6�   5      5       