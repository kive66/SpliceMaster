   M S B A M L   `   `   `  ���� E  ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=null9!clr-namespace:DMSkin.WPF.ControlsDMSkin.WPF.Controls  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&    System.Windows.Controls.DataGrid  �� 
TargetType �� Property �� Value �� Color �� 
TargetType �� Padding � UseLayoutRounding � ColumnDefinitions � RowDefinitionsG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter	 �� Path
 �� RelativeSource �� AncestorLevel �� AncestorType �� ConverterParameter7  1System.Windows.Controls.DataGridHeadersVisibility �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll �� ContentStringFormat �� ContentStringFormat%   DMSkin.WPF.Controls.DMScrollBar  Name �� ScrollableHeight � Maximum �� Orientation �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility � Value �� Mode �� ScrollableWidth �� ViewportWidth, �� %ComputedHorizontalScrollBarVisibility � Triggers  :� RoutedEvent! �� 
TargetName" �� TargetProperty	# W� To$ g� Duration% g� 	BeginTime& :� 
SourceName' J� SnapsToDevicePixels=  7System.Windows.Controls.Primitives.DataGridColumnHeader( �� 	Resources) �� Member* ��Name+ F�Name, J� RenderTransformOrigin- �� Stretch)  #System.Windows.Controls.DataGridRow. �� Triggers/ P� Property0 P� Value*  $System.Windows.Controls.DataGridCell�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     .controls!clr-namespace:DMSkin.WPF.Controls  ,s&clr-namespace:System;assembly=mscorlib  %	  '         '  4    '  s    '  �    �� "    .���  �@  CanUserResizeColumns .  ��  � �� Z� ��  � �� �	#FFD6D6D6��   �@  HorizontalGridLinesBrush �� $ 	#FFEEEEEE����  �@  VerticalGridLinesBrush �� $ 	#FFEEEEEE����  � �� �� "   .R��� # z��#��z��#��z��#��z�� . ._��� $��DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+�  $!��PART_ColumnHeadersPresenter��$��1��y��� $	 
Visibility�
 �� *FindAncestor+$ 1��$ DataGridL�  
Column=��� $!��PART_ScrollContentPresenter��$��1��$��2��# z�� .   .  #��z��# z #��z��  $ PART_VerticalScrollBar��$��1��$��2��# z $ Vertical=�# z #y�z  �� $	 VerticalOffset�$ OneWay=�
 �� *TemplatedParent+� $��2��$��1�� �� ���� $.	 (NonFrozenColumnsViewportHorizontalOffset�
 �� *FindAncestor+$ 1��$ DataGridL��� $��* �.+�  $ PART_HorizontalScrollBar��$��1��# z $ 
Horizontal=�# z #y�z  �� $	 HorizontalOffset�$ OneWay=�
 �� *TemplatedParent+ :� $  
MouseWheel��.[��� .���� .��W� $! PART_VerticalScrollBar��$" Opacity�$# 1X�$$ 0:0:0.5D�W� $% 0:0:1X�$! PART_VerticalScrollBar��$" Opacity�$	# 0.1X�$$ 0:0:0.5D�W� $! PART_HorizontalScrollBar��$" Opacity�$# 1X�$$ 0:0:0.5D�W� $% 0:0:1X�$! PART_HorizontalScrollBar��$" Opacity�$	# 0.1X�$$ 0:0:0.5D�:� $  
MouseEnter��$& PART_VerticalScrollBar��.[��� .���� .��W� $! PART_VerticalScrollBar��$" Opacity�$# 1X�$$ 0:0:1D�:� $  
MouseLeave��$& PART_VerticalScrollBar��.[��� .���� .��W� $! PART_VerticalScrollBar��$" Opacity�$	# 0.2X�$$ 0:0:1D�:� $  
MouseEnter��$& PART_HorizontalScrollBar��.[��� .���� .��W� $! PART_HorizontalScrollBar��$" Opacity�$# 1X�$$ 0:0:1D�:� $  
MouseLeave��$& PART_HorizontalScrollBar��.[��� .���� .��W� $! PART_HorizontalScrollBar��$" Opacity�$	# 0.2X�$$ 0:0:1D�.���� #' z' �� "   ( �� .���  �@�UseLayoutRounding . ��  � ��$ 0����  � ��$ 30����  � �� �	#FF5A5A5A��  � ��$ 14(���  �@�Cursor$
 Hand����  � �� �� $) VerticalAlignment.Center����  � �� �� "  .R�� .+��� $* BackgroundBorder��$
��Auto�����	#FFE1E1E2$��0,0,0,1q�._��  �� $��* �.+��� $��5,0,0,0q�$
��Left=�$��Center=�F� $+ 	SortArrow��$��2��$��8��$��6��$��0,0,0,0q�$��Stretch=�$��Center=�"����        �@B     � � @B 	
���   �$	, 1,1&�$
- Fill=�$y�	Collapsed=��� $��1��$��1��$��Right=����	#FFE1E1E2n� $��PART_LeftHeaderGripper��$
��Left=����� "  n�( �� .���  � �� X�8Q���  � �� ��	#00FFFFFF����  �@�Cursor ��
SizeWE����  � �� �� " n�.R��� # z��#��z��n� $��PART_RightHeaderGripper��$��Right=����� "  n�( �� .���  � �� X�8Q���  � �� ��	#00FFFFFF����  �@�Cursor ��
SizeWE����  � �� �� " n�.R��� # z��#��z���� "   .���  � �� �#FFFFFF��  � �� �	#FF666666. P� / �@ AlternationIndex$0 0��. ���  � �� �	#FFFAFAFAP� / �@ AlternationIndex$0 1��. ���  � �� �	#FFF5F5F7P� / �@J�IsMouseOver0 . . ���  � �� �	#FFEBECEDP� / �@ 
IsSelected0 . . ���  � �� �	#FFE3E3E5��  � �� �	#FF111111�� "   .���  � ��$ Stretch=���  � �� �	#FF5A5A5A��  � ��$ 11(���  � �� �� "  .R�� .+��� �� $��5,0,0,0q�$
��Left=�$��Center=�. P� / �@ 
IsSelected0 . . ���  � �� �	#FF464646