   M S B A M L   `   `   `  ����?  ;QLBX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QLBX.FormChucNangQLBX.FormChucNang  5   	   $    QLBX.FormChucNang.QuanLyXeForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:QLBX.FormChucNang     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
     
QuanLyXeVM � DataContext# [ 5   	    � 	Resources 5       �� 
TargetType  mg * &MaterialDesignFloatingActionMiniButton �� BasedOn �� Property �� Value��%e   &	       7  �� 5   
   " ��6   8   .�5      ��  � ��$ 4 8 4 8q�6'   69   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   � $��0��6   	 � RowDefinitions	 5       �� 5!      $
��auto �6    60   �� 5"      $
��auto �6    60   �� 5#      $
��416* �6    60   .+�5'      � $��2��6    5(      �� 5)      �� 5*      $
��auto �6'   .+�5,      � $��0��6    5-      �� 5.      $
��157* �6+   �� 5/      $��5* �6+   .+�51      �� $��2��6e   ��6   �� *XeList+
 �� SelectedItem
 6>   �� *SelectedItem1+ �� View 52      �� 53      .P�54   "   �� $��Biển Số��61    �� DisplayMemberBinding 6B   �� *BIENSO+6l   �� 55   "   $��Nhả Sản Xuất��61    6G   �� *
NHASANXUAT+6u   �� 56   "   $��	Ngày Mua��61    6C   �� *	NGAYMUA+ �� StringFormat$ d��6}   �� 57   "   $��	Loại Xe��61    6B   �� *IDLOAI+6l   58      5:      5;      �� 5=      $��0 0 20 0q�6   $��0��6/   $��Center=�6?   $��Right=�6Z   .+�5>      �� #��[ 5?      $
��Left=�5@       � ToolTip$, &MaterialDesignFloatingActionMiniButton��5A      ��5?   7   �� *
AddCommand+.��5B      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�62   $��24��6>   $��24��6J   5C      �� 5D      #��[ 5E      $
��Left=�5F      $, &MaterialDesignFloatingActionMiniButton��5G      ��5E   7   �� *EditCommand+.��5H        $ Pencil=�62   $��24��6@   $��24��6L   5I      �� 5J      #��[ 5K      $
��Left=�5L      $, &MaterialDesignFloatingActionMiniButton��5M      ��5K   7   �� *DeleteCommand+.��5N        $ Delete=�62   $��24��6@   $��24��6L   5O      5P      5Q      #  MaterialDesignThemes.Wpf.Card  5T      $��5q�6"   $��1��6-   .��5U      � $��5q�6    5V       % !MaterialDesignFloatingHintTextBox��%g   '��       7  �� 5W      " ��6    8   .�5X      ��  � ��$ 	10 0 10 0q�67   6K   5Y      5Z      .+�5[      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Biển Số��5]      ��5\      �� *BIENSO+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5]      �� 5^      $ Nhà Sản Xuất��5`      ��5_      �� *
NHASANXUAT+$ PropertyChanged=�$ TwoWay=�5`      (  "System.Windows.Controls.DatePicker  5a      $��2��6!   $��
10 10 10 0q�5b      $ Ngày Nhập��5d         SelectedDate 5c      �� *	NGAYMUA+$ PropertyChanged=�$ TwoWay=�5d      �� 5e      $��Bottom=�6    �� DisplayMemberPath$ TENLOAI��5f       �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 6M   $ 	Loại Xe��5i      ��5g      �� *
LoaiXeList+
 5h      �� *SelectedLoaiXe+$ PropertyChanged=�$ TwoWay=�5i      5j      5k      � 5n      $��0��6   .+�5o      �� $��Danh Sách Xe��6    �� TextAlignment$ Center=�60   6I   5p      5q      � 5v      $��1��6   	 5w      �� 5x      $
��auto �6$   64   �� 5y      $
��auto �6$   64   �� 5z      6&   .+�5}      � $��0��6   .+�5~      �� $��	Loại Xe��6    $ Center=�6/   6H   5        5�      $��1��6&   $��5q�63   .��5�      � $��5q�6    5�      ��%g   '��       7  �� 5�      " ��6    8   .�5�      ��  � ��$ 	10 0 10 0q�67   6K   5�      5�      .+�5�      �� $ 	ID Loại��5�      ��5�      �� *IDLOAI+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $ Tên Loại��5�      ��5�      �� *	TENLOAI+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $ Số Chộ Ngồi��5�      ��5�      �� *	SOCHONGOI+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $ Hệ Số Giá Vé��5�      ��5�      �� *	HESOGIAVE+$ PropertyChanged=�$ TwoWay=�5�      5�      5�      � 5�      $��2��6   .+�5�      � .+�5�      �� -   5         ��Name$ lv��5�      $
��Left=�6�   ��6+   �� *
LoaiXeList+
 6N   �� *SelectedItem+$ TwoWay=� 5�      �� 5�      .P�5�   "   �� $��	ID Loại��61    6B   �� *IDLOAI+6l   �� 5�   "   $��Tên Loại��61    6C   �� *	TENLOAI+6n   �� 5�   "   $��Số Chỗ Ngồi��61    6F   �� *	SOCHONGOI+6s   �� 5�   "   $��Hệ Số Giá Vé��61    6G   �� *	HESOGIAVE+6t   5�      5�      5�      �� 5�      $��Right=�6   $��Center=�69   $��0 0 20 0q�6T   .+�5�      �� #��[ 5�      $
��Left=�5�      $, &MaterialDesignFloatingActionMiniButton��5�      ��5�   ;   �� *AddLoaiXeCommand+.��5�        $
 Plus=�62   $��24��6>   $��24��6J   5�      �� 5�      #��[ 5�      $
��Left=�5�      $, &MaterialDesignFloatingActionMiniButton��5�      ��5�   ;   �� *EditLoaiXeCommand+.��5�        $ Pencil=�62   $��24��6@   $��24��6L   5�      �� 5�      #��[ 5�      $
��Left=�5�      $, &MaterialDesignFloatingActionMiniButton��5�      ��5�   ;   �� *DeleteLoaiXeCommand+.��5�        $ Delete=�62   $��24��6@   $��24��6L   5�      5�      5�      5�      5�      5�      