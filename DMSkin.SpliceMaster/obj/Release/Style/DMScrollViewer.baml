   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollBarThumb  �� 
TargetType �� Property �� Value �� 
TargetType �� RadiusX �� RadiusY ! HorizontalScrollBarPageButton  VerticalScrollBarPageButton   VerticalScrollBarPageButton2  for_scrollbar �Name � UseLayoutRounding � RowDefinitions	 �� PageUpCommand
 ]�Name J� IsMouseOver ]� DecreaseRepeatButton ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� Triggers P� Property P� Value �� PageLeftCommand �� PageRightCommand  for_scrollviewer � Cursor ��Name �� ScrollableHeight � Maximum �� Orientation �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility �� VerticalOffset � Value �� ScrollableWidth  �� ViewportWidth,! �� %ComputedHorizontalScrollBarVisibility" �� HorizontalOffset# �� Triggers$ :� RoutedEvent% �� 
TargetName& �� TargetProperty	' W� To( g� Duration) :� 
SourceName�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %�
  &	        &	 �     &	 c    &	 1    &	 	    7  7  7  7   7  7  7  7   &	 )    7  7  �� "  n�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � �� �� " n�.R�� .+��� ���#CFCFD1$ 3��$ 3���� "  ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  �@J�Opacity$	 0.2Q���  � �� �� " ��.R��� #��z��#��z��#��z���� "  ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  �@J�Opacity$	 0.2Q���  � �� �� " ��.R��� #��z��#��z��#��z���� "  ��.���  �@�OverridesDefaultStyle . ��  � ��
 ���� ��  � |� .  ��  � �� .  ��  �@J�Opacity$ 0Q���  � �� �� " ��.R��� $��0��$��0�����	#90000000�� "  ��.���  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��
 ���� ��  � ��$ 0,1,1,6q���  � ��$ 6����  � ��$ 6����  �@J�Opacity$ 1Q���  � �� �� " ��.R�� $ Bg�� .  �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��#��Z	 8��  ]� $
 
PART_Track��$��1����. #{�z  �� #��Z	 8��  �� #��Z 8��  n� 8�� �� $��2��#��Z 8��  P�  �@��Orientation$ 
Horizontal=�. ���  � ��
 ���� ��  � ��$ 1,0,6,1q���  � ��$ 5����  � ��$ 5����  � ��$
 Auto����  �@J�Opacity$ 1Q���  � �� �� " ��.R�� $ Bg�� . .+�]� $
 
PART_Track��#{�z  �� #��Z 8��  �� #��Z 8��  n� 8�� �� "  ��.���  � ��
 �������  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z�� . ._�� #��z��.+��� #��z��#��z��# z �� $ PART_VerticalScrollBar��$��Right=�# z $ Vertical=�8��  # z #y�z # z �� $ PART_HorizontalScrollBar��$��Bottom=�# z $ 
Horizontal=�8�� # z  #y�z! # z" # :� $$ ScrollChanged��.[��� .���� .��W� $% PART_VerticalScrollBar��$& Opacity�$' 1X�$( 0:0:0.2D�:� $$ 
MouseEnter��$) PART_VerticalScrollBar��.[��� .���� .��W� $% PART_VerticalScrollBar��$& Opacity�$' 1X�$( 0:0:0.2D�:� $$ 
MouseLeave��$) PART_VerticalScrollBar��.[��� .���� .��W� $% PART_VerticalScrollBar��$& Opacity�$	' 0.5X�$( 0:0:0.2D�:� $$ 
MouseEnter��$) PART_HorizontalScrollBar��.[��� .���� .��W� $% PART_HorizontalScrollBar��$& Opacity�$' 1X�$( 0:0:0.2D�:� $$ 
MouseLeave��$) PART_HorizontalScrollBar��.[��� .���� .��W� $% PART_HorizontalScrollBar��$& Opacity�$	' 0.5X�$( 0:0:0.2D�