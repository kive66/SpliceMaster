   M S B A M L   `   `   `  ����E  ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=null9!clr-namespace:DMSkin.WPF.ControlsDMSkin.WPF.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   RepeatButtonTransparent  �� 
TargetType �� Property �� Value �� 
TargetType!    DMSkin.WPF.Controls.DMThumb ��Name J� SnapsToDevicePixels �� RelativeSource �� Mode �� Path	 �� RadiusX
 �� RadiusY �� Triggers P� Property P� Value �� 
TargetName%   DMSkin.WPF.Controls.DMScrollBar �Name ]�Name J� IsMouseOver ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb    RadiusX    RadiusY    
ThemeColor    ThemeColorMouseOver    ThemeColorPressed �� Triggers �� PageLeftCommand �� PageRightCommand(   "DMSkin.WPF.Controls.DMScrollViewer ��Name  �� CanContentScroll! �� CanHorizontallyScroll" �� CanVerticallyScroll#  Name4  .System.Windows.Automation.AutomationProperties$   AutomationId  TransparentColor% � Cursor& �� ScrollableHeight' � Maximum( � Minimum) �� ViewportHeight* �� ViewportSize*+ �� #ComputedVerticalScrollBarVisibility,   RadiusX-   RadiusY.   ScrollBarSize/   
ThemeColor0   ThemeColorMouseOver1   ThemeColorPressed2 � Value3 �� Mode4 �� ScrollableWidth5 �� Orientation6 �� ViewportWidth,7 �� %ComputedHorizontalScrollBarVisibility�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .controls!clr-namespace:DMSkin.WPF.Controls  5      %�  &	        '   T    '  �    7   7   7   7   '  �    7  7  �� 5      "  ��6,   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5	   
    � ��
 ���� 6'   �� 5
   
    � |� .  6&   �� 5   
    � �� .  6&   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� #��z��5      #��z��5      #��z��5      5      5      5      �� 5      "    6   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � �� 5      �� 5      "   6"   .R�5       �� $ 	rectangle��5!      #��z��5"      #��z��5#       . ��5$      ��  �� $ TemplatedParent=�$ 
ThemeColor�	 5%      ��  �� $ TemplatedParent=�$ RadiusX�
 5&      ��  �� $ TemplatedParent=�$ RadiusY�5'       5(      P� 5)       �@J�IsMouseOver . . �5*      �� $ 	rectangle��6%    6L   ��  �� $ TemplatedParent=�$ ThemeColorMouseOver� � ��5+      P� 5,       �@n�
IsDragging . . �5-      �� $ 	rectangle��6%    6L   ��  �� $ TemplatedParent=�$ ThemeColorPressed� � ��5.      50      52      53      �� 57      "   6   .�58   
   ��  �@��IsPressAndHoldEnabled .  69   �� 59   
    �@��IsFlicksEnabled .  63   �� 5:   
    � �� 6"   �� *ScrollBarSize+ �� $ TemplatedParent=��� 5;   
    � �� 6%   �� *ScrollBarSize+ �� $ TemplatedParent=��� 5<   
    � ��
 ���� 6'   �� 5=   
    � ��
 ���� 6'   �� 5>   
    � �� 5?      �� 5@      "  6"   .R�5A      � $ Bg��6    . .+�5B      ]� $ 
PART_Track��5C      $��1��5D      ��. #{�z 5F       5G      �� 5H   "   #��Z 6/   8��  6\    5J      �� 5K   "   #��Z 6/   8�� 6^    5M         5N   "    5O   %   �� *	RadiusX+ �� $ TemplatedParent=� 5P   %   �� *	RadiusY+ �� $ TemplatedParent=� 5Q   %   �� *
ThemeColor+ �� *TemplatedParent+ 5R   %   �� *ThemeColorMouseOver+ �� *TemplatedParent+ 5S   %   �� *ThemeColorPressed+ �� *TemplatedParent+5U      5V      5W      5Y       5Z   
   P� 5[       �@��Orientation$ 
Horizontal=�6-   . �5\      ��  � ��$
 Auto��6*   �� 5]       � ��$ 0��6-   �� 5^       � �� 6+   �� *ScrollBarSize+ �� $ TemplatedParent=��� 5_       � �� 6.   �� *ScrollBarSize+ �� $ TemplatedParent=��� 5`       � �� 5a      �� 5b      "  6*   .R�5c      � $ Bg��6#    . .+�5d   "   ]� $ 
PART_Track��5e   %   $��1��5f   %   #{�z 5g   %    5h   &   �� 5i   *   #��Z 67   8�� 6f    5k   &   �� 5l   *   #��Z 67   8�� 6g    5n   &      5o   *    5p   -   �� *	RadiusX+ �� $ TemplatedParent=� 5q   -   �� *	RadiusY+ �� $ TemplatedParent=� 5r   -   �� *
ThemeColor+ �� *TemplatedParent+ 5s   -   �� *ThemeColorMouseOver+ �� *TemplatedParent+ 5t   -   �� *ThemeColorPressed+ �� *TemplatedParent+5v   #   5w      5x      5z      5{      5}      �� 5�      "   6   .�5�   
   ��  � ��$
 Auto=�68   �� 5�   
    � ��$ Disabled=�6:   �� 5�   
    � �� . 6-   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � $
 Grid��6   #��z��6)   .+�5�      �� $! PART_ScrollContentPresenter��5�      #��z��5�      #  z��5�      ! .  " .  #��z��5�      #��z��5�        5�      $# PART_VerticalScrollBar��5�      $��Right=�5�      $$ VerticalScrollBar��5�      8��  $% Arrow��5�      #' z& 5�      $( 0Q�5�      #* z) 5�      #y�z+ 5�      , 5�      �� *	RadiusX+ �� $ TemplatedParent=�- 5�      �� *	RadiusY+ �� $ TemplatedParent=�. 5�      �� *ScrollBarSize+ �� $ TemplatedParent=�/ 5�      �� *
ThemeColor+ �� *TemplatedParent+0 5�      �� *ThemeColorMouseOver+ �� *TemplatedParent+1 5�      �� *ThemeColorPressed+ �� *TemplatedParent+2 5�      �� *VerticalOffset+$3 OneWay=� �� *TemplatedParent+  5�      $# PART_HorizontalScrollBar��5�      $��Bottom=�5�      $$ HorizontalScrollBar��5�      8�� $% Arrow��5�      #' z4 5�      $( 0Q�5�      $5 
Horizontal=�5�      #* z6 5�      #y�z7 5�      , 5�      �� *	RadiusX+ �� $ TemplatedParent=�- 5�      �� *	RadiusY+ �� $ TemplatedParent=�. 5�      �� *ScrollBarSize+ �� $ TemplatedParent=�/ 5�      �� *
ThemeColor+ �� *TemplatedParent+0 5�      �� *ThemeColorMouseOver+ �� *TemplatedParent+1 5�      �� *ThemeColorPressed+ �� *TemplatedParent+2 5�      �� *HorizontalOffset+$3 OneWay=� �� *TemplatedParent+5�      5�      5�      5�      5�      