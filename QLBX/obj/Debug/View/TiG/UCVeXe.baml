   M S B A M L   `   `   `  ����?  ;QLBX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QLBX.FormChucNangQLBX.FormChucNang  5          QLBX.FormChucNang.UCVeXe   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:QLBX.FormChucNang     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $
��vexe��5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      $��Stretch=�5      $��Stretch=�6,   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5        DVVM � DataContext# [ 5      .��5      � -   5         �Name$ 
mainTicket��5      ���#b4e0df$��Stretch=�64   $��Stretch=�6R    � ColumnDefinitions 5   
   �� 5      $	��28* �6   6-   �� 5      $	��12* �6   6-   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��3* �6    6.   �� 5      $	��30* �6    6/   �� 5       $��1* �6    6.   �� 5!      $	��30* �6    6/   .+�5#      �� $��0��6      MaterialDesignTitleTextBlock#��[ 6%    �� TextAlignment$ Center=�6[   SƠ ĐỒ XE luan6�   � 5$      -   5        $ frist��5$       $��1��6    5%      �� 5&      6&   �� 5'      6&   �� 5(      6&   �� 5)      6&   �� 5*      6&    5.      �� 5/      6)   �� 50      6)   �� 51      6)   �� 52      6)   �� 53      6)   �� 54      6)   �� 55      6)   �� 56      6)   .+�58      �� $��	1st floor��6   $ Center=�6-   $��50(�6D   $��0��6R   $��7��6_   $��5��6o    � LayoutTransform 59      �� 5:       �� Angle$ 90Q�6*   67   5<      5>      � 5@      $��2��6   $��10��6    ���#2D1E69$��0 5 0 5q�6A   6T   � 5B      -   5        $ second��5B       $��3��6    5C      �� 5D      6&   �� 5E      6&   �� 5F      6&   �� 5G      6&   �� 5H      6&    5J      �� 5K      6)   �� 5L      6)   �� 5M      6)   �� 5N      6)   �� 5O      6)   �� 5P      6)   �� 5Q      6)   �� 5R      6)   .+�5T      �� $��	2nd floor��6   $ Center=�6-   $��50(�6D   $��0��6R   $��7��6_   $��5��6o    5U      �� 5V      $ 90Q�6*   67   5X      5Y      5Z      � 5\   
   -   5        $ 
frmbooking��5\      $��1��6#   ���#4ec3ca 5]      �� 5^      $��1* �6#   60   �� 5_      $	��25* �6#   61   �� 5`      $��1* �6#   60   .+�5b      � $��0��6   6%   � 5c      $��1��6   .+�5d      �� 	 �� Orientation$	 Vertical=�6   .+�5e      9� $��Italic$�6   ���#4ec3ca��5f      �� 5g      $��BOOKING��6$   $��Normal$�63   $
��Bold"�6F   ���#000d34$��15(�6m   6}   .��5h      �� .+�5n      �� -   5        
 ��Name$
 NameHK��5n   "   
������� % !MaterialDesignFloatingHintTextBox#��[ 6l   ��62   �� *
tenkhach+ �� Mode$ TwoWay=�.��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5o      �� 5p   "   $	 
Horizontal=�6-   $��-2 0 0 0q�6F   .+�5q   &   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6>   �� 5r   &   Customer Name6?   5s   #   .��5t   >   5u      �� 5v      -   5        $
 SdtKhach��5v   "   
�������#��[ 6q   ��6G   �� *sodienthoai+$ TwoWay=�.��6�    5w      �� 5x   "   $	 
Horizontal=�6-   $��-2 0 0 0q�6F   .+�5y   &     $ Phone=�6>   �� 5z   &   Phone Number6>   5{   #   .��5|   >   5}      �� 5~      -   5        $
 diach��5~   "   
�������#��[ 6i   ��6D   �� *diachi+$ TwoWay=�.��6�    5      �� 5�   "   $	 
Horizontal=�6-   $��-2 0 0 0q�6F   .+�5�   &     $ Phone=�6>   �� 5�   &   ADD65   5�   #   .��5�   >   5�      �� 5�      .+�5�      9� ���#4ec3ca
�������$
��Left=�6P   $��Ticket Booking��6k   .��5�   "   �� $	 Vertical=�6-   #���   6D   $��0,0,0,0q�6�   .+�5�   &   �� -	   5         ��Name$ listghe��5�   /   
����������#3580BF��6@   �� *Dsghe+$ OneWayToSource=�5�   '   5�   #   5�      5�      �� 5�      $	 
Horizontal=�6%   .+�5�      	� -
   5         	�Name$
 csat��5�   *   
������� 	� 	GroupName$ 	ThanhToan��6L   $
��Left=�6b    d� 	IsChecked 6}   �� *cast+$ OneWayToSource=�.��6�   Cash6�   �� 5�      6&   	� 5�      $ 	ThanhToan��6*   
�������$��Right=�6�    6@   �� *book+$ OneWayToSource=�.��6�   	Booking6�   5�      �� 5�      6&   �� 5�      $	 
Horizontal=�6%   .+�5�      �� 
��������� 6<   .�6A   Total:6J   6Q   �� 5�      -   5         ��Name$ tongtien��5�   (   
���������6:   �� *total+$ TwoWay=��� 6r   6y   6�   �� 5�      
��������� 6<   .�6A   $6D   6K   5�      �� 5�      6&   �� 5�      -   5         ��Name$ buttoncommit��5�   !    " MaterialDesignRaisedDarkButton#��[ 6�   $	��100��6�   ���#555555 � ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton��6�   ��67   �� *commit+��6R   ��  �� ElementName$
 vexe��.��6.  COMMIT5�      5�      5�      9� 5�      $��Italic$�6   ���#4ec3ca��5�      �� 5�      $��STATUS��6$   $��Normal$�62   $
��Bold"�6E   ���#000d34$��15(�6l   6|   .��5�      �� -   5        $ listvedadat��5�   #    �� View 5�      �� 5�   "   .P�5�   &   �� $��Number Chair��65    �� DisplayMemberBinding 6K   �� *
soghedamua+6y   �� 5�   &   $��Status��65    6E   �� *	trangthai+6r   5�   #    �� 
GroupStyle 5�      (  "System.Windows.Controls.GroupStyle  5�   "      HeaderTemplate 5�   &   �� 5�   *   .R�5�   2   �� ��6<   �� *Name+6T   5�   +   5�   #   .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�   "      	EventName$ SelectionChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   &   6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 6<   �� *
removeve+ 	  CommandParameter 6Y   �� $ listvedadat��5�   '   5�   #   5�      5�      9� 5�      $��Italic$�6   ���#4ec3ca��5�      �� 5�      $��DELIVER��6(   $��Normal$�67   $
��Bold"�6J   ���#000d34$��15(�6q   6�   .��5�      �� $	 Vertical=�6%   .+�5�      �� $ Name:��6P   #��[ 6w   ��6&   �� *
tenkhachhh+$ TwoWay=�6w   �� 5�      $
 Add:��6M   #��[ 6s   ��6&   �� *
diachihh+$ TwoWay=�6s   �� 5�      $ Phone number:��6J   #��[ 6y   ��6&   �� *sdthh+$ TwoWay=�6y   �� 5�      $ Stuff:��6J   #��[ 6r   ��6&   �� *tenhh+$ TwoWay=�6r   �� 5�      $ Total:��6L   #��[ 6t   ��6&   �� *	totalhh+$ TwoWay=�6t   �� 5�      $��Center=�6)   $	 
Horizontal=�6F   .+�5�   "   �� $��5 5 5 5q�6u   #��[ 6�   $	��100��6�   $8 2Resource name: MaterialDesignRaisedLightDarkButton��6�   ��6*   �� *
commithh+��6G   �� $
 vexe��.��6  COMMIT6  5�      5�      5�      9� 5�      $��Italic$�6   ���#4ec3ca��5�      �� 5�      $��
DECRIPTION��6(   $��Normal$�6:   $
��Bold"�6M   ���#000d34$��15(�6t   6�   .��5�      �� -   5        $ listhanghoa��5�   #    5�      �� 5�   "   .P�5�   &   �� $��	Full Name��65    6H   �� *hoten+6q   �� 5�   &   $	��ADD��65    6B   �� *diachi+6l   �� 5�   &   $��Phone��65    6D   �� *sdt+6k   �� 5�   &   $��Stuff��65    6D   �� *	tenhang+6o   �� 5�   &   $��Total��65    6D   �� *	giatien+6o   5�   #   5     5     5     5     � 5     $��2��6   6%   5     5     5     