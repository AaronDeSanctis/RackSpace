   M S B A M L   `   `   `  ����G  CRackSpaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RackSpaceWPFRackSpaceWPF  5      "    RackSpaceWPF.EditItemNonUnit   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RackSpaceWPF     5        N� Title$  EditItemNonUnit��5	      .��5
      � $��10,10,10,10q�6   
������� � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      .+�5*   
   �� $��1,1,1,1q�6   $��0��6,   $��0��6<   $��2��6I   $��10��6]   ��5+      �� 5,       �� EndPoint$ 	0.504,1.5&�6&    �� 
StartPoint$ 
0.504,0.03&�6;   .��5-      �  � Color$
 Blue��6#    � Offset$ 0Q�60   � 5.      $ 	#FFFFFFFF��6#   $ 0.567Q�65   5/      51      �� 52   
   -   5        $��
homeButton��52   �   $	��Top=�6   $��0��6)   $��2��66   $��0��6J   $��2��6Z   $��10,10,10,10q�6k   
������ $��0q�6�    � Cursor$
 Hand��6�   ��53      �� 54       �� 
TargetType" ��6"   .R�55      �� 	 ��Name$	 
homeButton��6   ._�56      �� $��Images/RSLogoFinal.png��6    6B   57      
 �� Triggers
 58      P� 59       P� Property �@J�IsMouseOver P� Value . . �5:      ��  �� 
TargetName$ 
homeButton��6%    �� Property � �� �� Value
 ���� 6S   5;      P� 5<       � �� . . �5=      �� $ 
homeButton��6%    � ��
 ���� 6S   5>      5@      5B      �� 5G   
   -   5        $��EditImageButton��5G   *   $��2��6A   $��2��6U   $��10,10,10,10q�6b   
����iA�$
��Bold"�6�   .��6�   Change Image5I      �� 5J   
   -   5        $��RemoveImageButton��5J   2   $��2��6K   $��3��6_   $��10,10,10,10q�6l   
����iA�$
��Bold"�6�   .��6�   Remove Image5L      �� 5M   
   -   5        $��
ModsButton��5M   +    � ToolTip$ Customize Racks��6=   $��2��6W   $��4��6k   $��10,10,10,10q�6x   
����iA�$
��Bold"�6�   .��6�   Add Modification5O      �� 5T   
   -   5        $��EditItemButton��5T   p   $��2��6   $��5��6%   $��10,10,10,10q�62   
����iA�$
��Bold"�6^   .��6�   Save and Complete6�   �� 5U   
   $��2��6   $��1��6%   $��5��62   $��7��6F   $��40,10,40,40q�6W   .+�5V      ��  �� Target 6   ��  �� ElementName$ ItemImageBox��.��5W      ��  �� Orientation$ 
Horizontal=�6   .+�5X      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5Y      $��_Image:��6!   5[      5]      �� 5_      
���   �$��0q�6)   $��30,10,30,10q�6>   
�������$	��353��6e   ._�5`      �� -   5        $��ItemImageBox��5`       J� RenderTransformOrigin$ .5,.5&�6,   $��10,10,10,10q�6J   z�5a      �� 5b      -   5        Rotate90��5b   *   5d      5e      5h      �� 5i   
   $��7��6   $��1��6%   $��5��62   $��7��6F   $��40,10,40,40q�6W   .+�5j      ��  6   �� $ IsUnitCheckBox��.��5k      �� $ 
Horizontal=�6   .+�5l      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5m      $��_Unit?:��6!   5n      5o      �� 5p      -   5        $��IsUnitCheckBox��5p      ��6.   �� 6c   �� 5q       6   �� $ RackComboBox��.��5r      �� $ 
Horizontal=�6   .+�5s      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5t      $��_Choose Rack:��6!   5u      5v      �� 5w      -	   5        $��RackComboBox��5w      6]   �� 5x       6   �� $ NameTextBox��.��5y      �� $ 
Horizontal=�6   .+�5z      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5{      $��_Name:��6!   5|      5}      �� 5~      -
   5        $��NameTextBox��5~      5�      5�      5�      