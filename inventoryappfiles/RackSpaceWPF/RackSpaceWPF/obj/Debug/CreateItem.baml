   M S B A M L   `   `   `  ����G  CRackSpaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RackSpaceWPFRackSpaceWPF  5          RackSpaceWPF.CreateItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RackSpaceWPF     5        N� Title$  
CreateItem��5	      .��5      � $��10,10,10,10q�6   
������� � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�51   
   �� $��1,1,1,1q�6   $��0��6,   $��0��6<   $��2��6I   $��10��6]   ��52      �� 53       �� EndPoint$ 	0.504,1.5&�6&    �� 
StartPoint$ 
0.504,0.03&�6;   .��54      �  � Color$
 Blue��6#    � Offset$ 0Q�60   � 55      $ 	#FFFFFFFF��6#   $ 0.567Q�65   56      58      �� 59   
   -   5        $��
homeButton��59   �   $	��Top=�6   $��0��6)   $��2��66   $��0��6J   $��2��6Z   $��10,10,10,10q�6k   
������ $��0q�6�    � Cursor$
 Hand��6�   ��5:      �� 5;       �� 
TargetType" ��6"   .R�5<      �� 	 ��Name$	 
homeButton��6   ._�5=      �� $��Images/RSLogoFinal.png��6    6B   5>      
 �� Triggers
 5?      P� 5@       P� Property �@J�IsMouseOver P� Value . . �5A      ��  �� 
TargetName$ 
homeButton��6%    �� Property � �� �� Value
 ���� 6S   5B      P� 5C       � �� . . �5D      �� $ 
homeButton��6%    � ��
 ���� 6S   5E      5G      5I      �� 5J   
   -   5        $��2��5J   )   $��2��6=   $��10,10,10,10q�6J   
����iA�$
��Bold"�6v   .��6�   Add an Image5L      �� 5N   
   -   5        $��RemoveImageButton��5N   2   $��2��6K   $��3��6_   $��10,10,10,10q�6l   
����iA�$
��Bold"�6�   .��6�   Remove Image5P      �� 5Q   
   -   5        $��
ModsButton��5Q   +    � ToolTip$ Customize Racks��6=   $��2��6W   $��4��6k   $��10,10,10,10q�6x   
����iA�$
��Bold"�6�   .��6�   Add Modification5S      �� 5T   
   -   5        $��CreateNewItemButton��5T   4   $ Customize Racks��6O   $��2��6i   $��5��6}   $��10,10,10,10q�6�   
����iA�$
��Bold"�6�   .��6�   Save and Complete5V      �� 5f   
   $��2��6   $��0��6%   $��5��62   $��6��6F   $��40,10,40,40q�6W   .+�5g      ��  �� Target 6   ��  �� ElementName$ ItemImageBox��.��5h      ��  �� Orientation$ 
Horizontal=�6   .+�5i      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5j      $��_Image:��6!   5l      5n      �� 5p      
���   �$��0q�6)   $��30,10,30,10q�6>   
�������$	��353��6e   ._�5q      �� -   5        $��ItemImageBox��5q       J� RenderTransformOrigin$ .5,.5&�6,   $��10,10,10,10q�6J   z�5r      �� 5s      -   5        Rotate90��5s   *   5u      5v      5y      �� 5�   
   $��7��6   $��0��6%   $��5��62   $��6��6F   $��40,10,40,40q�6W   .+�5�      ��  6   �� $ IsUnitCheckBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Unit?:��6!   5�      5�      �� 5�      -   5        $��IsUnitCheckBox��5�      �� 5�       6   �� $ RackComboBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Choose Rack:��6!   5�      5�      �� 5�      -	   5        $��RackComboBox��5�      6]   �� 5�       6   �� $ NameTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Name:��6!   5�      5�      �� 5�      -
   5        $��NameTextBox��5�      �� 5�       6   �� $ SerialNumTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Serial Number:��6!   5�      5�      �� 5�      -   5        $��SerialNumTextBox��5�      �� 5�       6   �� $ VoltsTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Volts:��6!   5�      5�      �� 5�      -   5        $��VoltsTextBox��5�      �� 5�       6   �� $ PhaseTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Phase:��6!   5�      5�      �� 5�      -   5        $��PhaseTextBox��5�      �� 5�       6   �� $ ModelTextBox��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $E��?http://cdn1.iconfinder.com/data/icons/fatcow/16/bullet_blue.png��6   �� 5�      $��_Model:��6!   5�      5�      �� 5�      -   5        $��ModelTextBox��5�      5�      ]� 5�   
   -   5        $��NoteBox��5�   �   ��. $��2��6)   $��6��69   $��10��6F   $��4��6[   $��40,10,40,40q�6l   $	��Top=�6�   .+�5�      �� -   5        $��DefaultNote��5�   /   $��45��6   $
��Auto��6"   ���#d7dee6 �� TextWrapping$
 Wrap=�6W    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�   $��10,10,10,10q�6�   6�   5�      �� 5  
   $,��&Images/AltoShaamRectangle (Custom).jpg��6   $��0,30,0,0q�6@   $��0��6R   $��8��6b   $��2��6o   $��2��6�   5     5     