   M S B A M L   `   `   `  ����	  Login    Login.Page.PageOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  	PageOrder��5       � 	Resources 5	      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value �� Color=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType ��Name � ColumnDefinitions	 F�Name
 �� Stretch J� RenderTransformOrigin)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value*  $System.Windows.Controls.DataGridCell �� TextAlignment�� 5
   
   D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   :x,http://schemas.microsoft.com/winfx/2006/xaml     5      %�  '        '  y    '      '  t    �� 5      "  6   .�5      ��  �@ CanUserResizeColumns .  69   �� 5       � �� �#E6DBBB6/   �� 5       � �� �#d6c79b60   �� 5        �@ HorizontalGridLinesBrush 5      �� 5      $ #d6c79b��6*   5      �� 5       �@ VerticalGridLinesBrush 5      �� 5      $ #d6c79b��6*   5      5      �� 5&      "  6   .�5'      ��  �@J�SnapsToDevicePixels . 68   �� 5(       � ��$ 0��6-   �� 5)       � ��$ 28��6.   �� 5*       � �� �#3234336/   �� 5+       � ��$ 14(�6-   �� 5,       �@�Cursor$
 Hand��6+   �� 5-       � �� 5.      �� 5/      "  6*   .R�50      �� $ BackgroundBorder��6%   $��0,1,0,1q�6?   ���#e6dbba$
��Auto��52      ._�53   "   �  54   &   �� 55   *   $��* �6;   .+�57   &   �� $��0,0,0,0q�68   $��Center=�6I   $��Center=�6d   F� 58   &   $	 	SortArrow��6+   $y�	Collapsed=�6>   "����        �@B     � � @B 	$

 Fill=�6n   $��2��6~   $��8��6�   $��6��6�   
�������$��0,0,50,0q�6�   $��Center=�59      $	 1,1&�68   �� 5:   &   $��1��60   ���#d6c79b$��Right=�6I   $��1��6e   5=   #   5>      5?      5A      �� 5B       � ��$ 25��6+   5C      �� 5F      "  6   .�5G      ��  � �� �#F2F2F26/   �� 5H       � ��$ 25��6+   �� 5I       � ��
 �   �6/    5J      P� 5S       �@J�IsMouseOver . . �5T      ��  � ��
 � � �67   5V      P� 5X       �@ 
IsSelected . . �5Y      ��  � ��
 �   �67   5Z      5\      �� 5_      "  6   .�5`      ��  � �� 5a      �� 5b      "  6*   .R�5c      �� $ Center=�6(   $��Center=�6?   �� 5d      5e      5f      5h       5i      P� 5j       �@ 
IsSelected . . �5m      ��  � ��
 �   �67   5n      5p      5q      .��5t      � $	��476��6   .+�5u   
     -   5        $��	dataGrid1��5u   �      AutoGenerateColumns .     CanUserAddRows .  $	��137��6F   $
��Left=�6S   $��	12,12,0,0q�6n   $	��Top=�6�   $	��464��6�      Columns 5v      0  *System.Windows.Controls.DataGridTextColumn  5w      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��67      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *ID+6g     5x       . $ 电话��67   $ 90 6e    6C   �� *cus_telephone+6r     5z       . $ 菜品总价��67   $ 70 6d    6E   �� *
should_pay+6q     5{       . $ 地址��67   $	 110 6f    6C   �� *order_location+6t     5|       . $ 日期��67   $	 110 6b    6C   �� *
order_date+6p   4	  .System.Windows.Controls.DataGridTemplateColumn	  5}      $ 接单��6)   $ 40 65    	  CellTemplate 5~      �� 5      .R�5�      �� -   5        
 � Tag 5�   <   �� *order_state+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5�      5�      5�        5�   
   -   5        $��	dataGrid2��5�   �    .  $	��127��6/    .  $
��Left=�6S   $��
12,214,0,0q�6n   $	��Top=�6�   $	��405��6�    5�        5�       . $ 菜名��67   $	 135 6a    6C   �� *	dish_name+6o     5�       . $ 菜色总价��67   $	 135 6c    6E   �� *	total_pay+6q     5�       . $ 数量��67   $	 135 6c    6C   �� *dish_amount+6q   5�      �� 5�   
   -   5        $��label1��5�   [   $��订单详情:��6   $��28��6    $
��Left=�6,   $��
12,180,0,0q�6G   $	��Top=�6i   $��14(�6�   $
��Bold"�6�   5�      5�      