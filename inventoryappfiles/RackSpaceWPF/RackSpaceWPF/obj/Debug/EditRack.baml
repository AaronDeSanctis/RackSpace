   M S B A M L   `   `   `  ����G  CRackSpaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RackSpaceWPFRackSpaceWPF  5          RackSpaceWPF.EditRack   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RackSpaceWPF     5        N� Title$  EditRack��5	      .��5      � $��10,10,10,10q�6   
������� � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   �� $��1,1,1,1q�6   $��0��6,   $��0��6<   $��2��6I   $��10��6]   ��5,      �� 5-       �� EndPoint$ 	0.504,1.5&�6&    �� 
StartPoint$ 
0.504,0.03&�6;   .��5.      �  � Color$
 Blue��6#    � Offset$ 0Q�60   � 5/      $ 	#FFFFFFFF��6#   $ 0.567Q�65   50      52      �� 55   
   -   5        $��
homeButton��55   �   $	��Top=�6   $��0��6)   $��2��66   $��0��6J   $��2��6Z   $��10,10,10,10q�6k   
������ $��0q�6�    � Cursor$
 Hand��6�   ��56      �� 57       �� 
TargetType" ��6"   .R�58      �� 	 ��Name$	 
homeButton��6   ._�59      �� $��Images/RSLogoFinal.png��6    6B   5:      
 �� Triggers
 5;      P� 5<       P� Property �@J�IsMouseOver P� Value . . �5=      ��  �� 
TargetName$ 
homeButton��6%    �� Property � �� �� Value
 ���� 6S   5>      P� 5?       � �� . . �5@      �� $ 
homeButton��6%    � ��
 ���� 6S   5A      5C      5E      �� 5F   
   -   5        $��EditImageButton��5F      $��2��6A   $��2��6U   $��10,10,10,10q�6b   
����iA�$
��Bold"�6�   .��6�   Change Image5H      �� 5I   
   -   5        $��RemoveImageButton��5I   2   $��2��6K   $��3��6_   $��10,10,10,10q�6l   
����iA�$
��Bold"�6�   .��6�   Remove Image5K      �� 5L   
   -   5        $��EditRackButton��5L   /    � ToolTip$ Customize Racks��6E   $��2��6_   $��4��6s   $��10,10,10,10q�6�   
����iA�$
��Bold"�6�   .��6�   Save and Complete5N      �� 5O   
   $��2��6   $��1��6%   $��5��62   $��7��6F   $��40,10,40,40q�6W   .+�5P      ��  �� Target 6   ��  �� ElementName$ RackImageBox��.��5Q      ��  �� Orientation$ 
Horizontal=�6   .+�5R      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5S      $��_Image:��6!   5U      5W      �� 5Y      
���   �$��0q�6)   $��30,10,30,10q�6>   
�������$	��353��6e   ._�5Z      �� -   5        $��RackImageBox��5Z       J� RenderTransformOrigin$ .5,.5&�6,   $��10,10,10,10q�6J   z�5[      �� 5\      -   5        Rotate90��5\   *   5^      5_      5`      �� 5d   
   $��7��6   $��1��6%   $��5��62   $��6��6F   $��40,10,40,40q�6W   .+�5e      ��  6   �� $ 	IdTextBox��.��5f      �� $ 
Horizontal=�6   .+�5g      �� $D��>http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_red.png��6   �� 5h      $��	_Rack Id:��6!   5i      5j      �� 5k      -   5        $��	IdTextBox��5k      5l      �� 5m   
   $,��&Images/AltoShaamRectangle (Custom).jpg��6   $��0,30,0,0q�6@   $��5��6R   $��8��6b   $��2��6o   $��2��6�   5n      5o      