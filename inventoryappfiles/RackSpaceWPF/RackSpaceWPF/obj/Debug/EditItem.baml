   M S B A M L   `   `   `  ����G  CRackSpaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RackSpaceWPFRackSpaceWPF  5          RackSpaceWPF.EditItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RackSpaceWPF     5        N� Title$  EditItem��5	      .��5      � $��10,10,10,10q�6   
������� � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   �� $��1,1,1,1q�6   $��0��6,   $��0��6<   $��2��6I   $��10��6]   ��5,      �� 5-       �� EndPoint$ 	0.504,1.5&�6&    �� 
StartPoint$ 
0.504,0.03&�6;   .��5.      �  � Color$
 Blue��6#    � Offset$ 0Q�60   � 5/      $ 	#FFFFFFFF��6#   $ 0.567Q�65   50      52      �� 53   
   -   5        $��
homeButton��53   �   $	��Top=�6   $��0��6)   $��2��66   $��0��6J   $��2��6Z   $��10,10,10,10q�6k   
������ $��0q�6�    � Cursor$
 Hand��6�   ��54      �� 55       �� 
TargetType" ��6"   .R�56      �� 	 ��Name$	 
homeButton��6   ._�57      �� $��Images/RSLogoFinal.png��6    6B   58      
 �� Triggers
 59      P� 5:       P� Property �@J�IsMouseOver P� Value . . �5;      ��  �� 
TargetName$ 
homeButton��6%    �� Property � �� �� Value
 ���� 6S   5<      P� 5=       � �� . . �5>      �� $ 
homeButton��6%    � ��
 ���� 6S   5?      5A      5C      �� 5H   
   -   5        $��EditImageButton��5H   *   $��2��6A   $��2��6U   $��10,10,10,10q�6b   
����iA�$
��Bold"�6�   .��6�   Change Image5J      �� 5K   
   -   5        $��RemoveImageButton��5K   2   $��2��6K   $��3��6_   $��10,10,10,10q�6l   
����iA�$
��Bold"�6�   .��6�   Remove Image5M      �� 5N   
   -   5        $��
ModsButton��5N   +    � ToolTip$ Customize Racks��6=   $��2��6W   $��4��6k   $��10,10,10,10q�6x   
����iA�$
��Bold"�6�   .��6�   Add Modification5P      �� 5U   
   -   5        $��EditItemButton��5U   p   $��2��6   $��5��6%   $��10,10,10,10q�62   
����iA�$
��Bold"�6^   .��6�   Save and Complete6�   �� 5V   
   $��2��6   $��1��6%   $��5��62   $��7��6F   $��40,10,40,40q�6W   .+�5W      ��  �� Target 6   ��  �� ElementName$ ItemImageBox��.��5X      ��  �� Orientation$ 
Horizontal=�6   .+�5Y      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5Z      $��_Image:��6!   5\      5^      �� 5`      
���   �$��0q�6)   $��30,10,30,10q�6>   
�������$	��353��6e   ._�5a      �� -   5        $��ItemImageBox��5a       J� RenderTransformOrigin$ .5,.5&�6,   $��10,10,10,10q�6J   z�5b      �� 5c      -   5        Rotate90��5c   *   5e      5f      5i      �� 5j   
   $��7��6   $��1��6%   $��5��62   $��7��6F   $��40,10,40,40q�6W   .+�5k      ��  6   �� $ IsUnitCheckBox��.��5l      �� $ 
Horizontal=�6   .+�5m      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5n      $��_Unit?:��6!   5o      5p      �� 5q      -   5        $��IsUnitCheckBox��5q      ��6-   �� 6b   �� 5r       6   �� $ RackComboBox��.��5s      �� $ 
Horizontal=�6   .+�5t      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5u      $��_Choose Rack:��6!   5v      5w      �� 5x      -	   5        $��RackComboBox��5x      6�   �� 5y       6   �� $ NameTextBox��.��5z      �� $ 
Horizontal=�6   .+�5{      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5|      $��_Name:��6!   5}      5~      �� 5      -
   5        $��NameTextBox��5      �� 5�       6   �� $ SerialNumTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Serial Number:��6!   5�      5�      �� 5�      -   5        $��SerialNumTextBox��5�      �� 5�       6   �� $ VoltsTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Volts:��6!   5�      5�      �� 5�      -   5        $��VoltsTextBox��5�      �� 5�       6   �� $ PhaseTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Phase:��6!   5�      5�      �� 5�      -   5        $��PhaseTextBox��5�      �� 5�       6   �� $ ModelTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Model:��6!   5�      5�      �� 5�      -   5        $��ModelTextBox��5�      5�      5�      5�      