   M S B A M L   `   `   `  ����E  ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=null;,clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF
DMSkin.WPF  5      N JDMSkin.SpliceMaster, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DMSkin.CloudMusic.ControlsDMSkin.CloudMusic.Controls 5      M5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPFDMSkin.WPF.Controls  5      5clr-namespace:DMSkin.CloudMusicDMSkin.CloudMusic 5	      I)clr-namespace:DMSkin.CloudMusic.ViewModelDMSkin.CloudMusic.ViewModel 5      "   DMSkin.CloudMusic.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ?DMSkin,clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF     5      =controls(clr-namespace:DMSkin.CloudMusic.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      L
dmcontrols5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPF     5      1localclr-namespace:DMSkin.CloudMusic     5	      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
      ?	viewmodel)clr-namespace:DMSkin.CloudMusic.ViewModel     5        � Title$  SpliceMaster��5      $��975.6��5      $��644.4��5      $
��1062��5      $	��710��5      #   DMSkin.WPF.DMSkinSimpleWindow   DMWindowShadowColor$ #888888��5         DMWindowShadowOpacity$	 0.4Q�5         DMWindowShadowSize$ 20Q�5         
FontNormal#��[  5        	TextColor#��[ 5       � 
ResizeMode$ CanResizeWithGrip=�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      5  /DMSkin.CloudMusic.ViewModel.MainWindowViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5       �� 5!      $��50 �6   .+�5#   
   �   
ThemeColor#���  6   	 � ColumnDefinitions	 5$      �� 5%      $	��190 �6#   �� 5&      �� 5'      .+�5)      � $��15,0,0,0q�5*      $
��Left=�5+      $��Center=�5,      .+�5-      �� $��4,0,0,0q�5.      $��Center=�5/        	FontTitle#��[ 50      $��17(�51      
��������� 53      $�Splice��6   �� 6+   $�Master��6/   6@   54      �� 55      $��1��56      $��Center=�57      
 �� Orientation$
 
Horizontal=�58      .+�59      �� $	��220��5:      $��10,0,0,0q�5;        ThemeColor3#��[ 5<       �� CornerRadius$ 10��5=      ._�5>      � $��8,0,5,0q�6   	 5?      �� 5@      �� 5A      $��20 �6/   5C      5D      5E      �� 5F      $��2��5G      $��0,0,12,0q�5H      $��Right=�5I      $��Center=�5J      $
 
Horizontal=�5K      .+�5L      "   DMSkin.WPF.Controls.DMButton  $��	10,0,15,0q�5M        TransparentColor#��[ 5N      $��0q�5O       � Cursor$
 Hand��5P      .��5Q      � 5R      � 5S      �� 5T      $��1��5U      $��22��5V      $��	14,0,10,0q�5W      #��[ 5X      +   %DMSkin.WPF.Controls.DMSystemMinButton  5Y      $
 Hand��5Z      (   "DMSkin.WPF.Controls.DMSystemButton   DMSystemButtonForeground$ #EEC1C1��5[         DMSystemButtonHoverColor$ Transparent��5\      $   DMSystemButtonHoverForeground$ White��5]         DMSystemButtonSize$ 22Q�5^        Icon_Min   Icon# [ 5_      +   %DMSkin.WPF.Controls.DMSystemMaxButton  5`      $
 Hand��5a      $ #EEC1C1��5b      $ Transparent��5c      $ White��5d      $ 24Q�5e        
Icon_Close# [ 5f      -   'DMSkin.WPF.Controls.DMSystemCloseButton  5g      -   5        $
 Hand��5h      $ #EEC1C1��5i      $ Transparent��5j      $ White��5k      $ 22Q�5l      6-   5m      5n      � 5o   
   $��1��6   	 5p      �� 5q      $	��200 �6#   $	��200��6/   �� 5r      $��* �6#   $	��822��6-   .+�5t      �   LeftGridColor#��[ 6   .+�5u      ��  	 for_scrollviewer#��[	 5v      $��
0,0,0,-0.2q�6?   .��5w      �� .+�5x      9� $��0,10,0,0q�5y      $��模式选择��5z       9� 
IsExpanded .  
 
NoExpander#��[
 5|      $	��360��6A   .��5}      �� .+�5~   "   1	  +DMSkin.CloudMusic.Controls.ImageRadioButton	  1
  +DMSkin.CloudMusic.Controls.ImageRadioButton 
  Checked$  ImageRadioButton_Checked_1��5�   �   $��转换��5   %    	� 	GroupName$
 Menu��5�   %     
Icon_Music 	  Image# [ 5�   %    	  
ImageWidth$ 14Q�5�   %    d� 	IsChecked 5�   %   �� *
SelectMenu+ �� ConverterParameter$ 
LocalMusic��  EnumToBooleanConverter �� 	Converter# [  �� Mode$ TwoWay=�6�   	  5�   "   $��乐谱��5�   %   $
 Menu��5�   %   # [ 5�   %   $ 14Q�5�   %   ��5�   %   �� *PageSheetMusic+5�      5�      5�      5�      5�      �� 5�      $��1��6     SplitterColor#��[ 6%   � 5�      $��1��6     RightGridColor#��[ 6#    5�      �� 5�      $	��83* �6$   �� 5�      $
��497* �6$   .+�5�       � -   5          �Name$ Frame��5�        � NavigationUIVisibility$ Hidden=�5�      $��0,0,0,0q�6Q   $��2��6b   ��5�      �� *CurrentPage+5�   b   5�      5�      �� 5�   
   $��2��5�        BottomGridColor#��[ 5�      #��[ 5�      $��0,1,0,0q�5�      ._�5�      � 	 5�      �� 5�      $	��200 �6'   �� 5�      .+�5�      � 	 5�      �� 5�      �� 5�      $��40 �6+   �� 5�      .+�5�      �� $��30��5�      $��30��5�      $��8,0,0,0q�5�        MusicButton#��[ 5�      ��5�      �� *
PriorMusic+.��5�      F� $��10��5�      $��10��5�        Icon_Play_Left#��[ 5�      
������� �� Stretch$ Uniform=�5�      5�      d� 5�      $��1��5�      $��35��5�      $��35��5�        MusicPlayButton#��[ 5�      ��5�      �� *Pause+�� 5�      $��2��5�      $��30��5�      $��30��5�      $��0,0,8,0q�5�      #��[ 5�      ��5�      �� *	NextMusic+.��5�      F� $��10��5�      $��10��5�        Icon_Play_Right#��[ 5�      
�������$ Uniform=�5�      5�      5�      � 5�      $��1��6   	 5�      �� 5�      $
��Auto �6+   $��42��68   �� 5�      �� 5�      $
��Auto �6+   $��42��68   �� 5�      $
��Auto �6+   $��80��68   .+�5�      �� $��Center=�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
Position+$ OneWay=�  TimeSpanToStringConverter# [ �� 5�      $��1��5�      $��Center=�5�       �� IsMoveToPointEnabled .  �� IsSelectionRangeEnabled .   �� SelectionStart$  0Q�5�        DMSlider#��[ 5�      ! � Maximum! 5�      �� *Duration.TotalSeconds+" �� SelectionEnd" 5�      �� # �� RelativeSource# �� $ �� Mode$
$ Self=�% �� Path$% Value�& � Value& 5�      �� *MediaPosition+�� 5�      $��2��5�      $��Center=�5�      $��Center=�5�      #��[ 5�      ��5�      �� *
Duration+# [ �� 5�      $��3��6!   $
 
Horizontal=�61   .+�5�      d� $��15,0,0,0q�6'     MusicVolumeButton#��[ 69   ��6d   �� *Mute+�� 5�      $��1��5�      $	��115��5�      $��Center=�5�       .  . $	! 100Q�5�      $  0Q�5�      #��[ 5�      " 5�      �� # �� $
$ Self=�$% Value�& 5�      �� *Volume+�� 5�      $��	10,0,12,0q�5�      $��Center=�5�      $
 
Horizontal=�5�      5�      5      5     5     �� 5  
   $��2��6     WyyResizeGrip#��[ 6"   5     5     