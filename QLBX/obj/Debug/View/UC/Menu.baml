   M S B A M L   `   `   `  ����?  ;QLBX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QLBX.ConverterQLBX.Converter  5          QLBX.UC.Menu   5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2	viewModelclr-namespace:QLBX.Converter     5        � 	Resources  5
         ToggleButton �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   From	   To	   GeneratedEasingFunction0  *System.Windows.Media.Animation.QuarticEase7  1System.Windows.Media.Animation.EasingFunctionBase
   
EasingMode   
Storyboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   GeneratedDuration   States   System.Windows.VisualState   
Storyboard'  !MaterialDesignThemes.Wpf.PackIcon  Name�	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]] 	  Kind J� Opacity J� RenderTransformOrigin  ExpanderDownHeaderStyle �� Padding � ColumnDefinitions �� ContentStringFormat �� ContentStringFormat d� 	IsChecked �� Path �� Mode �� RelativeSource��%�  &	        &	 �    7   �� 5   
   " d�6%   .�5      ��  � �� 5      �� 5      " d�6&   .R�5      �� 
������  5        5   "   CheckStates�� 5   &     5   *   $ 	Unchecked��6;   $ Checked��6L   	 5   .     5   2   $
 EaseOut=�6>   . 5   .   �� .��5   2   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6P   $ 
ExpandPath��6�   .\�5   6     $ 0��6K   $ 0Q�6W     5   6   $ 0:0:0.2��6K   $
 -180Q�6]   5   3   5   /   5   +     5   *   $ 0D�6;   $ 	Unchecked��6Q   . 5    .   �� .��5!   2   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6P   $ 
ExpandPath��6�   .\�5"   6     $ 0��6K   $
 -180Q�6W   5#   3   5$   /   5%   +     5&   *   $ 0D�6;   $ Checked��6Q   . 5'   .   �� .��5(   2   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6P   $ 
ExpandPath��6�   .\�5)   6     $ 0��6K   $ 0Q�6W   5*   3   5+   /   5,   +     5-   *   $ Checked��6;   $ 0D�6J   $ 	Unchecked��6`   	 5.   .     5/   2   $
 EaseOut=�6>   . 51   .   �� .��52   2   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6P   $ 
ExpandPath��6�   .\�53   6     $ 0��6K   $
 -180Q�6W     54   6   $ 0:0:0.2��6K   $ 0Q�6]   55   3   56   /   57   +   . 59   &     Checked��. 5:   *   �� .��5;   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6L   $ 
ExpandPath��6�   .\�5<   2     $ 0:0:0.2��6G   $
 -180Q�6Y   5=   /   5>   +   5?   '     5@   &   	Unchecked��. 5A   *   �� .��5B   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6L   $ 
ExpandPath��6�   .\�5C   2     $ 0:0:0.2��6G   $ 0Q�6Y   5D   /   5E   +   5F   '   5G   #   ._�5I        $ 
ExpandPath��6T   $ MenuDown=�66   $	 .38Q�6F   $ 0.5,0.5&�6h   $��24��5J   '   $��24��63   #��z��6>   z�5K   "   V� 5L   &   .~�5M   *   �� �� 5N   *   �� 5O   *   T� 5P   *   5Q   '   5S      5T      5U      5W      5X      �� 5[   
   " d�60   .�5\      ��  � ��
 ���� 6+   �� 5]       � ��$ 20(�6)   �� 5^       � ��$ Stretch=�64   �� 5_       � ��$ Center=�62   �� 5`       � �� 5a      �� 5b      " d�6&   .R�5c      �� #��z��6!   $ 24,5,5,5q�6K   ._�5d      �  5e   "   �� 5f   &   �� 5g   &   $
��Auto �67   .+�5i   "   �� #��z��63   #��z��5j   /   # z 5k   /   #��z��5l   /   $��Center=�5m   /   $��0,0,16,0q�5n   /   d� 5o   "   $��1��6/   $��Center=�5p   +   #��z��5q   +   8��   5r   +   �� $ 	IsChecked�$ TwoWay=� �� *TemplatedParent+5s   +   5t      5u      5v      5x      5y      5z      .��5{      �� .+�5|   
   �� ���	#FF6CE3FB$
��Bold"�6?   ��6   Z�   5}      *
   $QLBX.Converter.MathMultipleConverter  MathMlpMultipleConverter 
  	Operation  �� AncestorType.  (System.Windows.Media.Animation.CubicEase! R� KeyTime  System.Windows.Visibility"   Visible# R� Value	$ W� To% g� Duration&   	Collapsed'   Hidden( � Cursor) �� HeaderStringFormat* `� 	Converter+ �� ElementName, �� Triggers- P� Property. P� Value/ �� 
TargetName  	luanStyle��%�  &	       '9� "     7  7  7  7  &	 `    
  5      $ Multiply=�6S   �� 5�      " 9�6   .�5�      ��  �@9�
IsExpanded 5�      �� $ 
IsSelected� �� "  ���� 5�       � ��$ 18(�61   �� 5�       � ��$ 40��62   �� 5�       � ��$ 0q�68   �� 5�       � �� �	#00FFFFFF63   �� 5�       � �� 63   ��  �� "  �$ (TextElement.Foreground)��� 5�       � ��$ Stretch=�6C   �� 5�       � ��$	 Top=�6A   �� 5�       � �� 5�      �� 5�      " 9�6.   .R�5�   "   �� #��z��6)   #��z��6]    5�   &     5�   *   ExpansionStates�� 5�   .     5�   2   $ 0D�6C   $ Expanded��6Y   	 5�   6     5�   :   $
 EaseOut=�6D   . 5�   6   �� .��5�   :   T� $ PART_Content��6X   $ 
Visibility�6}   ..�5�   >   i� $! 0��6U   ## Z" 6a   5�   ;   W� 5�   :   $ Opacity�6J   $ PART_Content��6n   $$ 1X�6�   $% 0:0:0.3D�6�   5�   7   5�   3     5�   2   $ 0D�6C   $ 	Collapsed��6Y   	 5�   6     5�   :   $
 EaseOut=�6D   . 5�   6   �� .��5�   :   T� $ PART_Content��6X   $ 
Visibility�6}   ..�5�   >   i� $! 0:0:0.3��6U   ## Z& 6g   5�   ;   W� 5�   :   $ Opacity�6J   $ PART_Content��6n   $$ 0X�6�   $% 0:0:0.3D�6�   5�   7   5�   3   . 5�   .     Expanded��. 5�   2   �� .��5�   6   W� $ Opacity�6F   $ PART_Content��6j   $$ 1X�6�   $% 0D�6�   T� 5�   6   $ PART_Content��6T   $ 
Visibility�6y   ..�5�   :   i� $! 0��6Q   ## Z" 6]   5�   7   5�   3   5�   /     5�   .   	Collapsed��. 5�   2   �� .��5�   6   W� $ Opacity�6F   $ PART_Content��6j   $$ 0X�6�   $% 0D�6�   T� 5�   6   $ PART_Content��6T   $ 
Visibility�6y   ..�5�   :   i� $! 0��6Q   ## Z' 6]   5�   7   5�   3   5�   /   5�   +   ._�5�   &   ]� #��z��60   .+�5�   *   d� $��
HeaderSite��67   $	��Top=�5�   /   $��0q�5�   /   $
( Hand��6C   8��  $��14(�5�   /   $	 .87Q�5�   /   #��z��5�   /   #��z��5�   /   #��z��5�   /   #��z��5�   /   # z) 5�   /    5�   /   �� $ 
IsExpanded�$ TwoWay=� �� *TemplatedParent+5�   /   �� 5�   *   $��ContentSite��61   $��Bottom=�5�   )   ._�5�   .   �� $��ContentPanel��69   #��z��5�   1   #��z��5�   1   #��z��5�   1   ��5�   2   `� 5�   6   8*  .1�5�   :   �� $+ PART_Content��6B   $ ActualHeight�6]   �� 5�   :   $+ PART_Content��6B   $ Opacity�6]   5�   7   ��5�   2   `� 5�   6   8*  .1�5�   :   �� $+ PART_Content��6B   $ ActualWidth�6]   �� 5�   :   $+ PART_Content��6B   $ Opacity�6]   5�   7   .+�5�   2   �� $��PART_Content��6C   |�.  #��z��5�   ;   # z 5�   ;   #��z��5�   ;   5�   /   5�   +   5�   '   5�   #   , 5�   "   P� 5�   &   - �@9�ExpandDirection$
. Down=�6I   . �5�   *   �� $/ 
HeaderSite��6K    � ��$	 Top=�6c   �� 5�   *   $/ ContentSite��6K    � ��$ Bottom=�6d   �� 5�   *   $/ ContentPanel��6H    �@��Orientation$ Vertical=�6b   �� 5�   *   $/ ContentPanel��6B    � ��$
 Auto��6\   �� 5�   *   $/ 
HeaderSite��6B   8   � ��6Z   5�   '   5�      5�      5�      �� 5�      " ��6   .�5�      ��  � ��$
 Left=�6<   6K   �� 5�       � �� 63   Z� 6F   �� 5�       � �� 64   Z� 6G   �� 5�       � �� �	#FF6CE3FB6G   �� 5�       � ��$ 20 0 0 0q�6/   5�      5�      ��5�      �� 5�      " ��6"   .R�5�      �� 5�      ��5     �� 5     " ��6   .�5     ��  � �� 5     �� 5     " ��6.   .R�5  "   �� #��z��63   5     5	     5
     .@�5     ��   MaterialDesignDivider#���  6   $��1��6J   $��Stretch=�6U   0 J� SnapsToDevicePixels0 . 6s   9� 5     ��5     �� 5     VÉ6$   .��5     �� $��20,0,0,0q�6   .+�5     �� #��[ 6   $��
Đặt Vé��6a   ��6@   �� *DatVeCommand+��6r   �� $
+ luna��6�   �� 5     #���  6   $��1��6R   $��Stretch=�6]   0 . 6{   5     5     �� 5     #���  6   $��1��6J   $��Stretch=�6U   0 . 6s   9� 5     ��5     �� 5     NHÂN VIÊN6+   .��5     �� $��20,0,0,0q�6   .+�5     �� $��	Tài Xế��6   #��[ 6O   ��6.   �� *TaiXeCommand+��5  *   �� $
+ luna��6Z   �� 5      #���  6   $��1��6R   $��Stretch=�6]   0 . 6{   �� 5!     $��Phụ Xe��6   #��[ 6O   ��6.   �� *PhuXeCommand+��5"  )   �� $
+ luna��6Y   �� 5#     #���  6   $��1��6R   $��Stretch=�6]   0 . 6{   �� 5$     $��Bán Vé Xe��6   #��[ 6Z   ��61   �� *NhanVienBanVeCommand+��5%  )   �� $
+ luna��6Y   5(     5)     �� 5*     #���  6   $��1��6J   $��Stretch=�6U   0 . 6s   9� 5,     ��5-     �� 5.     SẮP LỊCH6*   .��50     �� $��20,0,0,0q�6   .+�51     �� $��Chuyến Xe��6   #��[ 52  W   ��51  1   �� *SapLichCommand+��52  )   �� $
+ luna��6|   �� 53     #���  6   $��1��6R   $��Stretch=�6]   0 . 6{   54     55     �� 56     #���  6   $��1��6J   $��Stretch=�6U   0 . 6s   9� 58     ��59     �� 5:     QUẢN LÝ XE6,   .��5<     �� $��20,0,0,0q�6   .+�5=     �� $��Chuyến Xe��6   #��[ 6U   ��61   �� *ChuyenXeCommand+��5>  )   �� $
+ luna��6Y   �� 5?     #���  6   $��1��6R   $��Stretch=�6]   0 . 6{   �� 5@     $��
Tuyến Xe��6   #��[ 6S   ��60   �� *TuyenXeCommand+��5A  )   �� $
+ luna��6Y   5B     5C     �� 5D     #���  6   $��1��6J   $��Stretch=�6U   0 . 6s   9� 5F     ��5G     �� 5H     
BẾN XE6(   .��5J     �� $��20,0,0,0q�6   .+�5K     �� $��Bến Xe��6   #��[ 6O   ��6.   �� *BenXeCommand+��5L  )   �� $
+ luna��6Y   5M     5N     �� 5O     #���  6   $��1��6J   $��Stretch=�6U   0 . 6s   9� 5Q     ��5R     �� 5S     .��6   THỐNG KÊ6(   .��5U     �� $��20,0,0,0q�6   .+�5V     �� $��Thống Kê��6   #��[ 6S   ��60   �� *ThongkeCommand+��5W  )   �� $
+ luna��6Y   5X     5Y     5Z     5[     5\     