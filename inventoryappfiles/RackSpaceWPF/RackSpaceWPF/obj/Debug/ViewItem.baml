   M S B A M L   `   `   `  ����G  CRackSpaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RackSpaceWPFRackSpaceWPF  5          RackSpaceWPF.ViewItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:RackSpaceWPF     5        N� Title$  ViewItem��5	      .��5      � $��
10,0,10,10q�6    � 	Resources 5   
   ��%    5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       .+�5"   
   ]� $��0��6   $��0��6$   $��5��61   ��.  $��2��6X   .+�5#      �� $��45��6   
�����w�   questionLabelStyle#��[  6<   $	��Top=�6h   $	��Top=�6�   .��6�   Is this a unit?5%      �� 5&      
�����w�$��45��61   #��[  6=   $	��Top=�6i   $	��Top=�6�   .��6�   Name:5(      �� 5)      
�����w�$��45��60   #��[  6<   $	��Top=�6h   $	��Top=�6�   .��6�   Serial number:5+      �� 5,      
�����w�$��45��60   #��[  6<   $	��Top=�6h   $	��Top=�6�   .��6�   
Voltage:5.      �� 5/      
�����w�$��45��60   #��[  6<   $	��Top=�6h   $	��Top=�6�   .��6�   Phase:51      52      ]� 53   
   $��2��6   $��0��6$   $��5��61   ��.  $��3��6X   .+�54      �� -   5        $��IsUnitCheckBox��54   c   
�������$��45��6*   $	��Top=�66   $	��Top=�6N   55      �� 56      -   5        $��NameTextBox��56   c   
�������$��45��6*   $	��Top=�66   $	��Top=�6N   .��6�   57      �� 58      -   5        $��SerialNumTextBox��58   b   
�������$��45��6)   $	��Top=�65   $	��Top=�6M   .��6�   59      �� 5:      -   5        $��VoltsTextBox��5:   b   
�������$��45��6)   $	��Top=�65   $	��Top=�6M   .��6�   5;      �� 5<      -   5        $��PhaseTextBox��5<   b   
�������$��45��6)   $	��Top=�65   $	��Top=�6M   .��6�   5=      5>      �� 5?   
   -   5        $��ItemImageBox��5?   S   $��0��6   $��2��6    $��5��6-   $��3��6B   $	��700��6g   $	��700��6t   5@      5A      5B      