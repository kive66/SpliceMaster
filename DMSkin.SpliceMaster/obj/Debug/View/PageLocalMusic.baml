   M S B A M L   `   `   `  ����N  JDMSkin.SpliceMaster, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DMSkin.CloudMusic.ControlsDMSkin.CloudMusic.Controls  5      E ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=nullM5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPFDMSkin.WPF.Controls 5      I)clr-namespace:DMSkin.CloudMusic.ViewModelDMSkin.CloudMusic.ViewModel  5	      +    %DMSkin.CloudMusic.View.PageLocalMusic   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =controls(clr-namespace:DMSkin.CloudMusic.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      L
dmcontrols5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ?	viewmodel)clr-namespace:DMSkin.CloudMusic.ViewModel     5	        N� Title$  PageLocalMusic��5
         	TextColor N� 
Foreground# [  5       � DataContext 5      9   3DMSkin.CloudMusic.ViewModel.PageLocalMusicViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��2.069 �6   �� 5      $��47.931 �6   �� 5      .+�5   
   ��   SplitterColor#��[ 6   $��0,0,0,1q�6>   $��2��6X   ._�5      �  � ColumnDefinitions 5      �� 5      $
��447* �6'   �� 5      $
��353* �6'   .+�5      � $��30,0,0,5q�5      $
��Left=�5       $��Bottom=�5!      $	��251��60   .+�5"      �� $��18(�6    $��78��6.   �� 6;   $
�Midi��6?   �� 6M   $�文件��6Q   6^   �� 5#      $��10,0,0,0q�5$      $��Bottom=�5%      ��5&      �� *MusicList.Count+�� 5'      $��Bottom=�6    $��首音乐，��6;   &   DMSkin.WPF.Controls.DMLinkButton  5(      $��Bottom=�5)      $��
选择Midi��5+         DMDisplayLine .  (  "DMSkin.WPF.Controls.DMSystemButton   DMSystemButtonHoverColor$ Transparent��5-      ���#0C73C2��5*      �� *AddFileCommand+5.      5/      � 50      $��0,0,30,5q�51      $��Right=�52      $��Bottom=�53      $��1��60   �� 54      $��开始转换��55      $
��Left=�56      $��248.103,11,0,0q�57      $	��Top=�58      $��75��59      $��28��5:      $��1��5;   7   ��6   �� *StartCreation+67   5=      5>      � 5?   
   $��2��6    5@      �� 5A      $
��203* �6#   �� 5B      $
��597* �6#   .+�5D      � $��2��6q   y�6   �� *DisplayMusicList+  BoolToVisibilityConverter �� 	Converter# [  5E      �� 5F      $��58 �6$   �� 5G      .+�5I      �� $��30,0,0,0q�6    �� Orientation$ 
Horizontal=�6/   .+�5J      "  DMSkin.WPF.Controls.DMButton  $	��100��5K      $��28��5L        
ThemeColor#��[ 5M      $��0q�5N      $��播放全部��5O      	   CornerRadius$	 5,0,0,5��5P      
�������5Q        5R      $��28��5S      $��28��5T      #��[ 5U      $��0q�5V      $	 0,5,5,0��5W      
�������.��5Y      F� $��12��5Z      $��12��5[        Icon_Add#��[ 5\      
�������
 �� Stretch$
 Uniform=�5^      5_        5`      $	��100��5a      $��28��5b      $��10,0,0,0q�5c      
�������#��[ 5e      $��1q�5f      $	 5��5g        
TextColor1#��[ 5h      .��5i      � .+�5j      F� $��12��5k   !   $��12��5l   !   #��[ 5m   !   #��[ 5n   !   $
 Uniform=�5o   !   �� 5p      $��10,0,0,0q�6(   $��匹配音乐��6:   5q      5r      5s      &   System.Windows.Controls.DataGrid  5t      $��1��5u       �� AlternationCount$ 2��5v         AutoGenerateColumns .  $��0,1,0,0q�5x         CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    CanUserResizeRows .     ColumnHeaderHeight$ 30Q�5~         GridLinesVisibility$
 None=�5         HeadersVisibility$ Column=�5�         
IsReadOnly .    	RowHeight$ 28Q�5�      ��5�      �� *	MusicList+ �� SelectedItem 5�      �� *SelectedMusic+ �� Mode$ TwoWay=� �� SelectedIndex 5�      �� *	SelectNum+$ TwoWay=� J� InputBindings 5�      d� 5�       d� MouseAction$ LeftDoubleClicke�6G    �� Command 6'   �� *PlayCommand+6G      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5�         MinWidth$ 50Q�5�          Header$   ��5�      1	  +System.Windows.Controls.DataGridBoundColumn! 	  Binding! 5�      �� *Index+5�        5�      $ * 5�      $  音乐标题��5�      ! 5�      �� *Title+5�        5�      $ * 5�      $  歌手��5�      ! 5�      �� *Artist+5�        5�      $ * 5�      $  专辑��5�      ! 5�      �� *Album+5�        5�      $ * 5�      $  时长��5�      ! 5�      �� *	TimeStr+5�        5�      $ * 5�      $  大小��5�      ! 5�      �� *	SizeStr+5�      4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      $ * 61   $  编辑(可选)��6;   " 
  CellTemplate" 5�      �� 5�   "   .R�5�   &     $��60��5�   %   $��自定义位置��5�   %   $ Transparent��5�   %    .  ���#0C73C2��5�   %   �� *DataContext.EditCommand+# �� RelativeSource# �� $ �� Mode$$ FindAncestor=�% �� AncestorType$
% PageL���5�   %   �� 5�   %   5�   #   5�      
  5�      $ * 61   $  删除��6;   " 5�      �� 5�   "   .R�5�   &     $��60��5�   %   $��删除��5�   %   $ Transparent��5�   %    .  ���#0C73C2��5�   %   �� *DataContext.Delete+# �� $$ FindAncestor=�$
% PageL���5�   %   �� 5�   %   5�   #   5�      5�      5�      �� 5�      $��104.903,150,308,0q�5�      $��Center=�5�      $	��Top=�5�      $��1��5�   �   y�6   �� *DisplayMusicList+# [ & �� ConverterParameter$
& true��.+�5�      �� $	��185��5�      $��55��5�      $��选择本地Midi文件��5�      $��16(�5�        ThemeButton#��[ 5�      ��5�      �� *AddFileCommand+5�      5�      5�      5�      5�      