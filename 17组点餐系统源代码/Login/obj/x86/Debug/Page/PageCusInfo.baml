   M S B A M L   `   `   `  ����	  Login    Login.Page.PageCusInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  PageCusInfo��5       � 	Resources 5	      &   System.Windows.Controls.DataGrid �� 
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
 �   �67   5n      5p      5q      .��5t      � $	��449��6   $	��520��6   .+�5u   
   �� -   5        $��textBox1��5u   M   $��23��6   $
��Left=�6   $��
198,59,0,0q�69   $	��Top=�6]   $	��120��6u   �� 5v   
   -   5        $��button1��5v   Z   $��搜索��6   $��24��6   $��Right=�6*   $��
0,60,122,0q�6F   $	��Top=�6i   $��48��6�   $��13(�6�   �� 5w   
   -   5        $��
textBlock1��5w   N   $��23��6   $
��Left=�6    $��	24,60,0,0q�6;   $*��$搜索以查询具体顾客信息：��6`   $	��Top=�6t   $��14(�6�   $
��Bold"�6�   �� 5x   
   -   5        $��
textBlock2��5x   O   $��23��6   $
��Left=�6    $��
24,115,0,0q�6;   $��所有顾客：��6a   $	��Top=�6n   $��14(�6�   $
��Bold"�6�     5y   
   -   5        $��	dataGrid1��5y   �      AutoGenerateColumns .     CanUserAddRows .  $	��200��6H   $
��Left=�6U   $��
24,152,0,0q�6p   $	��Top=�6�   $	��448��6�      Columns 5z      0  *System.Windows.Controls.DataGridTextColumn  5{      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��69      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *ID+6i     5|       . $ 	顾客名��67   $	 110 6e    6D   �� *cus_nickname+6s     5}       . $ 顾客手机账号��67   $	 110 6i    6G   �� *cus_telephone+6w     5~       . $ 顾客积分情况��67   $	 110 6e    6G   �� *	cus_score+5      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $ 删除��6)   $ * 65    	  CellTemplate 5�      �� 5�      .R�5�      �� -   5        5�   @   5�      5�      5�      5�      5�      