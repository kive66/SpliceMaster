   M S B A M L   `   `   `  ���� E  ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=null9!clr-namespace:DMSkin.WPF.ControlsDMSkin.WPF.Controls  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DMTopTabControl  �� 
TargetType �� 	Resources �� Property �� Value C� ResourceKey �� Member �� 
TargetType-   'System.Windows.Input.KeyboardNavigation    TabNavigation � UseLayoutRounding	 � ColumnDefinitions
 �Name � RowDefinitions K� ZIndex K� IsItemsHost    TabIndex    DirectionalNavigation �� SelectedContent" �� SelectedContentStringFormat �� ContentStringFormat �� SelectedContentTemplate J� SnapsToDevicePixels �� Triggers P� Property �� 
TargetName P� Value#   DMSkin.WPF.Controls.DMTabItem ��Name �� CornerRadius ��Name �� HeaderStringFormat �� RelativeSource �� AncestorLevel �� AncestorType  �� Mode  TabItemStyle1! �� StrokeDashArray" �� 
StartPoint# �� EndPoint$ � Offset% � Color& �Name' J� Opacity( ^� 
Conditions) �� Binding* �� Value�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     .controls!clr-namespace:DMSkin.WPF.Controls  ,s&clr-namespace:System;assembly=mscorlib  %�%  &	        '  {    &	 �    �� "  �� �� .���  � �� C� # Z����  � �� u�0q���  � �� u�0q���  � �� ��	#FF8C8E94����  � �� ��	#FFF9F9F9����  � �� �� $  HorizontalAlignment.Center����  � �� �� $ VerticalAlignment.Center����  � �� �� " ��.R�� }�. $ Local=� . 	 �� $
 ColumnDefinition0���� $
 ColumnDefinition1��$��0 � �� $
 RowDefinition0��$��65 ��� $
 RowDefinition1��$��* �.+�� $��0��$��0��.+��� $��HeaderPanel��$��0q�$��Center=�$��Center=�$ 1�� . $ 1���� $��ContentPanel��$��1��$��0��#��z��#��z��#��z��$ 	Contained=�$ 2��$ Local=�._��� $��PART_SelectedContentHost��#��z��#��z $��SelectedContent��# z #��z # z  P�  �@��TabStripPlacement. ��� $ HeaderPanel�� � �� ��1���� $ ContentPanel�� � �� ��0���� $ RowDefinition0�� � �� �* ��� $ RowDefinition1�� � �� �Auto ��� $ HeaderPanel�� � �� u�2,0,2,2q� �� $ Dock.Bottom��P�  �@��TabStripPlacement. ��� $ HeaderPanel�� � �� ��0���� $ ContentPanel�� � �� ��0���� $ HeaderPanel�� � �� ��0���� $ ContentPanel�� � �� ��1���� $ ColumnDefinition0�� � �� �Auto ��� $ ColumnDefinition1�� � �� �* ��� $ RowDefinition0�� � �� �* ��� $ RowDefinition1�� � �� �0 ��� $ HeaderPanel�� � �� u�2,2,0,2q� �� $ 	Dock.Left��P�  �@��TabStripPlacement. ��� $ HeaderPanel�� � �� ��0���� $ ContentPanel�� � �� ��0���� $ HeaderPanel�� � �� ��1���� $ ContentPanel�� � �� ��0���� $ ColumnDefinition0�� � �� �* ��� $ ColumnDefinition1�� � �� �Auto ��� $ RowDefinition0�� � �� �* ��� $ RowDefinition1�� � �� �0 ��� $ HeaderPanel�� � �� u�0,2,2,2q� �� $ 
Dock.Right��P�  � {�. ���  � �� C� # Z�� ��	False���� "   .���  � ��$	 110����  � ��$ 12(���  � ��$ 28����  � �� �	#FF888888��  � �� �� "  .R�� 
������ .+��� $ x�����	#FFE5E5E5$��1,1,0,1q�$ 5,0,0,5��._��� $ contentPresenter��#��z��#��z��$��Header��# z #��z��|�.  ��. # z ���� *HorizontalContentAlignment+ �� *FindAncestor+$ 1��" ������ *VerticalContentAlignment+ �� *FindAncestor+$ 1��" �� P�  �@J�IsMouseOver . . ��� $ x�� �� *
HoverColor+ �� $  TemplatedParent=� � ��P�  �@ TabItemType$ Right=�. ��� $ x�� � ��$ 1q��� $ x�� �@��CornerRadius$ 0,5,5,0��P�  �@ TabItemType$ Middle=�. ��� $ x�� � ��$ 1,1,0,1q��� $ x�� �@��CornerRadius$ 0��P�  �@��
IsSelected . . ��� $ x�� � ��$ 0q���  �� *SelectedForeground+ �� $  TemplatedParent=� � ���� $ x�� �� *SelectedColor+ �� $  TemplatedParent=� � ����  � �� �� .R��� $��0q�#��z���� "  ��.���  �@�FocusVisualStyle �� .���  � �� �� .R��� $��2q� . #��� ��$	! 1 2R�$��1����  � ��
 �   ���  � �� �� $	" 0,0&�$	# 0,1&�.��� $$ 0Q�$% 	#FFF0F0F0��� $$ 1Q�$% 	#FFE5E5E5����  � �� �	#FFACACAC��  � ��$ 0q���  � ��$	 6,2q���  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R�� $& templateRoot�� . .+��� $ 
mainBorder��$��0q�#��z��#��z��$��1,1,1,0q�._��� $ innerBorder��$��-1q�
����������	#FFACACAC$��1,1,1,0q�$' 0Q��� $ contentPresenter��#��z��#��z��$��Header��# z #��z��|�.  ��. # z ���� *HorizontalContentAlignment+ �� *FindAncestor+$ 1��" ������ *VerticalContentAlignment+ �� *FindAncestor+$ 1��" �� ^� ( �� ) �� *IsMouseOver+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Left.0��� $ 
mainBorder�� � �� �� $	" 0,0&�$	# 0,1&�.��� $$ 0Q�$% 	#FFECF4FC��� $$ 1Q�$% 	#FFDCECFC���� $ 
mainBorder�� � �� �	#FF7EB4EA�� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^� ( �� ) �� *IsMouseOver+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��
* Bottom.0��� $ 
mainBorder�� � �� �� $	" 0,0&�$	# 0,1&�.��� $$ 0Q�$% 	#FFECF4FC��� $$ 1Q�$% 	#FFDCECFC���� $ 
mainBorder�� � �� �	#FF7EB4EA�� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^� ( �� ) �� *IsMouseOver+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��	* Right.0��� $ 
mainBorder�� � �� �� $	" 0,0&�$	# 0,1&�.��� $$ 0Q�$% 	#FFECF4FC��� $$ 1Q�$% 	#FFDCECFC���� $ 
mainBorder�� � �� �	#FF7EB4EA�� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^� ( �� ) �� *IsMouseOver+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Top.0��� $ 
mainBorder�� � �� �� $	" 0,0&�$	# 0,1&�.��� $$ 0Q�$% 	#FFECF4FC��� $$ 1Q�$% 	#FFDCECFC���� $ 
mainBorder�� � �� �	#FF7EB4EA�� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q�^� ( �� ) �� *	IsEnabled+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Left.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder�� � �� �	#FFF0F0F0�� $ 
mainBorder�� � �� �	#FFD9D9D9�� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^� ( �� ) �� *	IsEnabled+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��
* Bottom.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder�� � �� �	#FFF0F0F0�� $ 
mainBorder�� � �� �	#FFD9D9D9�� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^� ( �� ) �� *	IsEnabled+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��	* Right.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder�� � �� �	#FFF0F0F0�� $ 
mainBorder�� � �� �	#FFD9D9D9�� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^� ( �� ) �� *	IsEnabled+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Top.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder�� � �� �	#FFF0F0F0�� $ 
mainBorder�� � �� �	#FFD9D9D9�� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q�^� ( �� ) �� *
IsSelected+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Left.0��� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^� ( �� ) �� *
IsSelected+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Left.0���  �@K�ZIndex$ 1����  � ��$ 
-2,-2,0,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^� ( �� ) �� *
IsSelected+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��
* Bottom.0��� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^� ( �� ) �� *
IsSelected+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��
* Bottom.0���  �@K�ZIndex$ 1����  � ��$ 
-2,0,-2,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^� ( �� ) �� *
IsSelected+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��	* Right.0��� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^� ( �� ) �� *
IsSelected+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��	* Right.0���  �@K�ZIndex$ 1����  � ��$ 
0,-2,-2,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^� ( �� ) �� *
IsSelected+ �� *Self+	* false�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Top.0��� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q�^� ( �� ) �� *
IsSelected+ �� *Self+* true�� ) �� *TabStripPlacement+ �� *FindAncestor+$ 1��" ��* Top.0���  �@K�ZIndex$ 1����  � ��$ 
-2,-2,-2,0q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q�