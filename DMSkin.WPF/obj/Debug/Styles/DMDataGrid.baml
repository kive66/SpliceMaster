   M S B A M L   `   `   `  ����E  ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=null9!clr-namespace:DMSkin.WPF.ControlsDMSkin.WPF.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&    System.Windows.Controls.DataGrid  �� 
TargetType �� Property �� Value �� Color �� 
TargetType �� Padding � UseLayoutRounding � ColumnDefinitions � RowDefinitionsG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter	 �� Path
 �� RelativeSource �� AncestorLevel �� AncestorType �� ConverterParameter7  1System.Windows.Controls.DataGridHeadersVisibility �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll �� ContentStringFormat �� ContentStringFormat%   DMSkin.WPF.Controls.DMScrollBar  Name �� ScrollableHeight � Maximum �� Orientation �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility � Value �� Mode �� ScrollableWidth �� ViewportWidth, �� %ComputedHorizontalScrollBarVisibility � Triggers  :� RoutedEvent! �� 
TargetName" �� TargetProperty	# W� To$ g� Duration% g� 	BeginTime& :� 
SourceName' J� SnapsToDevicePixels=  7System.Windows.Controls.Primitives.DataGridColumnHeader( �� 	Resources) �� Member* ��Name+ F�Name, J� RenderTransformOrigin- �� Stretch)  #System.Windows.Controls.DataGridRow. �� Triggers/ P� Property0 P� Value*  $System.Windows.Controls.DataGridCell�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .controls!clr-namespace:DMSkin.WPF.Controls  5      ,s&clr-namespace:System;assembly=mscorlib  5      %�  '         '  $    '  s    '  �    �� 5      "    6   .�5
   
   ��  �@  CanUserResizeColumns .  61   �� 5   
    � �� 6'   Z� �� 5   
    � �� �	#FFD6D6D66(   �� 5   
     �@  HorizontalGridLinesBrush 5      �� 5      $ 	#FFEEEEEE��6"   5      �� 5   
    �@  VerticalGridLinesBrush 5      �� 5      $ 	#FFEEEEEE��6"   5      �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� # z��5      #��z��5      #��z��5      #��z��5       . ._�5       �� $��DG_ScrollViewer��6'   |�.  ��5!      �� 5"   "   " ��62   .R�5#   &   �  5$   *   �� 5%   .   $
��Auto �6?   �� 5&   .   $��* �6?   �� 5'   .   $
��Auto �6?    5)   *   �� 5*   .   $
��Auto �6<   �� 5+   .   $��* �6<   �� 5,   .   $
��Auto �6<   .+�57   *     $!��PART_ColumnHeadersPresenter��6I   $��1��6l   y�58   .   �� 59   2   $	 
Visibility�6:   
 6L   �� *FindAncestor+$ 1��$ DataGridL� 5:   6    5;   :   
Column=�6\   5=   3   5?   +   �� 5@   *   $!��PART_ScrollContentPresenter��5A   -   $��1��5B   -   $��2��5C   -   # z��5D   -    .   .  #��z��5G   -   # z 5H   -   #��z��5I   -     5J   *   $ PART_VerticalScrollBar��5K   -   $��1��5L   -   $��2��5M   -   # z 5N   -   $ Vertical=�5O   -   # z 5P   -   #y�z 5Q   -    5R   -   �� $	 VerticalOffset�$ OneWay=�
 �� *TemplatedParent+� 5S   *   $��2��6/   $��1��6<    5T   .   �� 5U   2   ��6C   �� $.	 (NonFrozenColumnsViewportHorizontalOffset�
 �� *FindAncestor+$ 1��$ DataGridL��� 5V   2   $��* �6C   .+�5X   .     $ PART_HorizontalScrollBar��5Y   1   $��1��5Z   1   # z 5[   1   $ 
Horizontal=�5\   1   # z 5]   1   #y�z 5^   1    5_   1   �� $	 HorizontalOffset�$ OneWay=�
 �� *TemplatedParent+5`   +    5a   *   :� 5b   .   $  
MouseWheel��6;   .[�5c   2   �� .��5d   6   �� .��5e   :   W� $! PART_VerticalScrollBar��5f   =   $" Opacity�5g   =   $# 1X�5h   =   $$ 0:0:0.5D�5i   =   W� 5j   :   $% 0:0:1X�5k   =   $! PART_VerticalScrollBar��5l   =   $" Opacity�5m   =   $	# 0.1X�5n   =   $$ 0:0:0.5D�5o   =   W� 5p   :   $! PART_HorizontalScrollBar��5q   =   $" Opacity�5r   =   $# 1X�5s   =   $$ 0:0:0.5D�5t   =   W� 5u   :   $% 0:0:1X�5v   =   $! PART_HorizontalScrollBar��5w   =   $" Opacity�5x   =   $	# 0.1X�5y   =   $$ 0:0:0.5D�5z   =   5{   7   5|   3   5}   /   :� 5~   .   $  
MouseEnter��6;   $& PART_VerticalScrollBar��6T   .[�5   2   �� .��5�   6   �� .��5�   :   W� $! PART_VerticalScrollBar��5�   =   $" Opacity�5�   =   $# 1X�5�   =   $$ 0:0:1D�5�   =   5�   7   5�   3   5�   /   :� 5�   .   $  
MouseLeave��6;   $& PART_VerticalScrollBar��6T   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $! PART_VerticalScrollBar��5�   =   $" Opacity�5�   =   $	# 0.2X�5�   =   $$ 0:0:1D�5�   =   5�   7   5�   3   5�   /   :� 5�   .   $  
MouseEnter��6;   $& PART_HorizontalScrollBar��6T   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $! PART_HorizontalScrollBar��5�   =   $" Opacity�5�   =   $# 1X�5�   =   $$ 0:0:1D�5�   =   5�   7   5�   3   5�   /   :� 5�   .   $  
MouseLeave��6;   $& PART_HorizontalScrollBar��6T   .[�5�   2   �� .��5�   6   �� .��5�   :   W� $! PART_HorizontalScrollBar��5�   =   $" Opacity�5�   =   $	# 0.2X�5�   =   $$ 0:0:1D�5�   =   5�   7   5�   3   5�   /   5�   '   5�   #   .��5�      �� #' z' 6-   5�      5�      5�      5�      5�      �� 5�      "   6   ( 5�   
   �� 5�      .�5�   
   ��  �@�UseLayoutRounding . 6.   �� 5�   
    � ��$ 0��6%   �� 5�   
    � ��$ 30��6&   �� 5�   
    � �� �	#FF5A5A5A6'   �� 5�   
    � ��$ 14(�6%   �� 5�   
    �@�Cursor$
 Hand��6#   �� 5�   
    � �� 5�      �� 5�      $) VerticalAlignment.Center��6   5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � .+�5�      �� $* BackgroundBorder��5�      $
��Auto��5�      ���	#FFE1E1E2$��0,0,0,1q�5�      ._�5�      �  5�   "   �� 5�   &   $��* �67   .+�5�   "   �� $��5,0,0,0q�5�   %   $
��Left=�5�   %   $��Center=�5�   %   F� 5�   "   $+ 	SortArrow��5�   %   $��2��5�   %   $��8��5�   %   $��6��5�   %   $��0,0,0,0q�5�   %   $��Stretch=�5�   %   $��Center=�5�   %   "����        �@B     � � @B 	
���   �$	, 1,1&�5�   %   $
- Fill=�5�   %   $y�	Collapsed=�5�   %   �� 5�   "   $��1��5�   %   $��1��5�   %   $��Right=�5�   %   ���	#FFE1E1E25�   %   5�      5�      n� 5�      $��PART_LeftHeaderGripper��6    $
��Left=�6>   ��5�      �� 5�   "   "  n�6(   ( 5�   &   �� 5�   *   .�5�   &   ��  � �� 5�   *   X�5�   .   8Q�6:   5�   '   �� 5�   &    � �� 5�   *   ��5�   .   	#00FFFFFF��6I   5�   '   �� 5�   &    �@�Cursor 5�   *   ��5   .   
SizeWE��6=   5  '   �� 5  &    � �� 5  *   �� 5  .   " n�6>   .R�5  2   �� # z��69   #��z��6e   5  /   5	  '   5
  #   5     n� 5     $��PART_RightHeaderGripper��6    $��Right=�6?   ��5     �� 5  "   "  n�6(   ( 5  &   �� 5  *   .�5  &   ��  � �� 5  *   X�5  .   8Q�6:   5  '   �� 5  &    � �� 5  *   ��5  .   	#00FFFFFF��6I   5  '   �� 5  &    �@�Cursor 5  *   ��5  .   
SizeWE��6=   5!  '   �� 5"  &    � �� 5#  *   �� 5$  .   " n�6>   .R�5%  2   �� # z��69   #��z��6e   5&  /   5(  '   5)  #   5+     5,     5-     5/     50     �� 56     "   6   .�57  
   ��  � �� �#FFFFFF6'   �� 58  
    � �� �	#FF6666666'   . 59  
   P� 5;     / �@ AlternationIndex$0 0��62   . �5<     ��  � �� �	#FFFAFAFA6/   5=     P� 5>     / �@ AlternationIndex$0 1��62   . �5?     ��  � �� �	#FFF5F5F76/   5@     P� 5B     / �@J�IsMouseOver0 . . �5C     ��  � �� �	#FFEBECED6/   5E     P� 5G     / �@ 
IsSelected0 . . �5H     ��  � �� �	#FFE3E3E56/   �� 5I      � �� �	#FF1111116/   5J     5L     �� 5O     "   6   .�5P  
   ��  � ��$ Stretch=�6.   �� 5Q  
    � �� �	#FF5A5A5A6'   �� 5R  
    � ��$ 11(�6%   �� 5S  
    � �� 5T     �� 5U     "  6"   .R�5V     � .+�5W     �� �� 5X     $��5,0,0,0q�5Y     $
��Left=�5Z     $��Center=�5[     5\     5]     5_     . 5`  
   P� 5a     / �@ 
IsSelected0 . . �5d     ��  � �� �	#FF4646466/   5e     5g     5h     