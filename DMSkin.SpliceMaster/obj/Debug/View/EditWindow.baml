   M S B A M L   `   `   `  ����E  ADMSkin.WPF, Version=2.5.1.4, Culture=neutral, PublicKeyToken=null;,clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF
DMSkin.WPF  5      M5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPFDMSkin.WPF.Controls  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U<clr-namespace:System.Windows.Input;assembly=PresentationCoreSystem.Windows.Input 5      N JDMSkin.SpliceMaster, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DMSkin.CloudMusic.ViewModelDMSkin.CloudMusic.ViewModel 5	      '   !DMSkin.CloudMusic.View.EditWindow   5      7DMSkin,clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      L
dmcontrols5clr-namespace:DMSkin.WPF.Controls;assembly=DMSkin.WPF     5      Ninput<clr-namespace:System.Windows.Input;assembly=PresentationCore     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      9	viewmodel)clr-namespace:DMSkin.CloudMusic.ViewModel  5	      $��338.399��5
      $��214.399��5        � Title$  
EditWindow��5       � DataContext 5      / )DMSkin.CloudMusic.ViewModel.EditViewModel  5   
   .��5      �    
ThemeColor#���   6   $��0,0,-0.4,146.4q�65    � ColumnDefinitions 5   
   �� 5      $	��190 �6   �� 5      �� 5      .+�5   
   � $��15,0,0,0q�5      $
��Left=�5      $��Center=�5      .+�5      �� $��4,0,0,0q�5      $��Center=�5        	FontTitle#��[ 5      $��15(�5      
�������$��自定义剪切��5       $��23��6"   $��88��6.   5!      �� 5"   
   $��1��5#      $��Center=�5$       �� Orientation$ 
Horizontal=�5%      .+�5&      �� $	��220��5'      $��10,0,0,0q�5(        ThemeColor3#��[ 5)       �� CornerRadius$ 10��5*      ._�5+      � $��8,0,5,0q�6    5,      �� 5-      �� 5.      $��20 �6+   50      51      52      �� 53   
   $��
0,2,-0.2,3q�54      $��Right=�55      $��Center=�56      $ 
Horizontal=�57      $��2��6*   $	��110��6>   $��1��6J   .+�58      "   DMSkin.WPF.Controls.DMButton  $��	10,0,15,0q�59        TransparentColor#��[ 5:      $��0q�5;       � Cursor$
 Hand��5<      .��5=      � 5>      � 5?      �� 5@      $��1��5A      $��22��5B      $��	14,0,10,0q�5C      #���  5D      +   %DMSkin.WPF.Controls.DMSystemMinButton  5E      $
 Hand��6=   (   "DMSkin.WPF.Controls.DMSystemButton   DMSystemButtonForeground$ #EEC1C1��5F         DMSystemButtonHoverColor$ Transparent��5G      $   DMSystemButtonHoverForeground$ White��5H      	   DMSystemButtonSize$	 22Q�5I        Icon_Min
   Icon#
 [ 5J      -   'DMSkin.WPF.Controls.DMSystemCloseButton  5K      -   5        $
 Hand��5L      $ #EEC1C1��5M      $ Transparent��5N      $ White��5O      $	 22Q�5P      6-   5Q      � 5R   
     LeftGridColor#��[ 6   $
��Left=�6;   $	��155��6V   $��0,30,0,-146.6q�6c   $	��Top=�6z   $	��332��6�   $��3��6�    J� RenderTransformOrigin$ 0.501,0.488&�6�   .+�5S      �� -   5        $
��Left=�5S      $��19��61   $��	48,38,0,0q�6=    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $��65��6|    �� IsInputMethodEnabled .  ��5T      �� *
StartBar+6W   �� 5U      -   5        $
��Left=�5U      $��19��61   $��
166,97,0,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   $��65��6}    .  ��5V      �� *	EndNote+6V   �� 5W      -   5        $
��Left=�5W      $��19��61   $��	48,97,0,0q�6=   $
 Wrap=�6P   $	��Top=�6d   $��65��6|    .  ��5X      �� *	StartNote+6X   �� 5Y      -   5        $
��Left=�5Y      $��19��61   $��
166,38,0,0q�6=   $
 Wrap=�6Q   $	��Top=�6e   $��65��6}    .  ��5Z      �� *EndBar+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5[      $��起始小节��6   
�������$
��Left=�65   $��48,7,0,0q�6P   $	��Top=�6b   �� 5\      $��终止音符��6   
�������$
��Left=�65   $��
173,66,0,0q�6P   $	��Top=�6d   �� 5]      $��起始音符��6   
�������$
��Left=�65   $��	48,62,0,0q�6P   $	��Top=�6c   �� 5^      $��终止小节��6   
�������$
��Left=�65   $��	173,7,0,0q�6P   $	��Top=�6c   �� 5_      $��30��5`      $��30��5a      $��251,104,51,21q�5b        MusicButton#��[ 5c      ��5d      �� *	Confirm+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5e      +  %Microsoft.Xaml.Behaviors.EventTrigger  5f         	EventName$ Click��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5g      4	  .Microsoft.Xaml.Behaviors.Core.CallMethodAction	   	  
MethodName$ Close��6-    	  TargetObject 5h      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�5k      .��5m      F� $��10��5n      $��10��5o        Icon_Play_Right#��[ 5p      
������� �� Stretch$ Uniform=�5r      5s      5t      5u      5v      