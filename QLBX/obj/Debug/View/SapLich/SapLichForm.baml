   M S B A M L   `   `   `  ����?  ;QLBX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QLBX.View	QLBX.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      clr-namespace:QLBXQLBX  5          QLBX.View.SapLichForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:QLBX.View     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0sys&clr-namespace:System;assembly=mscorlib  5      cclr-namespace:QLBX  5      -   5        $��saplichForm��5         MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5        	SapLichVM � DataContext# [ 5      
������� � 	Resources 5         QLBX.tuyenConverter  myConverter    QLBX.soLuongTuyenConverter  my1Converter   QLBX.IndexConverter  IndexConverter  Template �� DataType d� IsThreeState d� 	IsChecked �� Mode��%�   &	       &	      &	 &     &	 9       5   
   6     5   
   6"     5   
   6   �� 5   
   " ��6*   .R�5      ��  .  6,   �� $ OneWay=�5      5      .��5      � 
�������$��5q�6    5   
    �� 
TargetType	 �� Property
 �� Value��%�   '��       �� 5       " ��6   .�5!      �� 	 � ��$
 Bottom=�66   �� 5"      	 � ��$
 0 0 20 0q�6+   5#      5$       � RowDefinitions 5&   
   �� 5'      $
��auto �6   �� 5(      $
��auto �6   �� 5)      �� 5*      $
��auto �6   �� 5+      $
��auto �6   .+�5.   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   
�������.��5/      � $��10q�6    � ColumnDefinitions 50      �� 51      �� 52       54      �� 55      6&   �� 56      6&   �� 57      6&   �� 58      6&   .+�5:      � $��0��6   $��2��6$    5;      �� 5<      �� 5=      .+�5A      �� $��0��6!    �� Orientation$ 
Horizontal=�61   .+�5B      �� Chọn Tuyến Xe64   �� 5C      -   5         ��Name$	 cbb��5E      $	��200��5D      
����ح� �� SelectedIndex$ 0��5E   *   ��5F      �� *ChiTietTuyens+$ TwoWay=� �� SelectedItem 5G      �� *SelectedItem+$ TwoWay=���5H      �� 5I   "   .R�5J   &   � $
��auto��6+    5K   *   �� 5L   .   $
��auto �6?   6N   �� 5M   .   6A   �� 5N   .   6A   .+�5P   *   �� $��0 0 10 0q�64   $��0��6F   ��6V   �� *	IDTUYEN+6q   �� 5Q   *   $��0 0 20 0q�64   $��1��6F   ��6V   �� *BENDI+6o   �� 5R   *   $��2��64   ��6D   �� *BENDEN+6^   5S   '   5T   #   5V      5W      �� 5Z      $��1��6!   $ 
Horizontal=�61   .+�5[      �� Chọn Ngày6/   (  "System.Windows.Controls.DatePicker  5\      -   5          Name$
 ngay��5\   %   $��Bottom=�63    �� Today   DisplayDateStart# Z 6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày Khởi Hành��5]       ( $MaterialDesignFloatingHintDatePicker#��[ 6K      Text 5\   O   �� *SelectedItem.NGAYDI+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5]   K   5^      5_      �� 5b      $��1��6   $ 
Horizontal=�6*   .+�5c      �� $��0��6!   Số lượng chuyến Xe6F   �� 5d      $	��100��6   ��6*   �� *SelectedItem.SOCHUYEN+$ TwoWay=�$ PropertyChanged=�6�   5h      5}      5~      � 5�   
   $��1��6   .+�5�      �� $��Chi Tiết Chuyến��5�      
����� �$��5q�68    5�      ��%�   '��       '�� Q     �� 5�      " ��6   .�5�      �� 	 � ��$
 Bottom=�6>   6O   5�      �� 5�      " ��6   .�5�      �� 	 � {�
 .  6F   �� 5�      	 � ��

 ���� 6N   5�      5�      .��5�      �  5�      �� 5�      �� 5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��0��6    Tên Tuyến6;   �� 5�      $��1��6   ��6.   ��  �� ElementName$	 cbb�� �� Path$ SelectedItem.IDTUYEN�6k   �� 5�      $��0��6    $��1��60   Quản đường6I   �� 5�      $��1��6   $��1��6.   ��6;   �� $	 cbb��$ SelectedItem.QUANDUONG�6{   �� 5�      $��0��6    $��2��60   Giá vé mặc định6N   �� 5�      $��1��6   $��2��6.   ��6;   �� $	 cbb��$ SelectedItem.GIAVEMACDINH�6~   �� 5�      $��2��6    $��0��60   Số lượng tài xế6N   �� 5�      -   5         ��Name$ txtbSLTX��5�   ;   $��3��6   $��0��6.   ��6M   �� $	 cbb��$ SelectedItem.SOLUONGTAIXE�6�   �� 5�      $��2��6    $��1��60   Số lượng xe6J   �� 5�      -   5        $ txtbSLX��5�      $��3��5�      $��1��6.   ��5�      �� $	 cbb��$ SelectedItem.SOLUONGXE�6Y   �� 5�      $��2��6    $��2��60   Thời gian dự kiến6P   �� 5�      -   5        $ txtbTGDK��5�      $��3��5�      $��2��6.   ��5�      �� $	 cbb��$ SelectedItem.THOIGIANDI�6Z   5�      5�      5�      � 5�   
   $��2��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��Danh sách xe��6'   $��5 5 5 5q�6=   .��5�      �� .��5�      �� ��6   �� $	 cbb��$ SelectedItem.XELIST� �� View 5�      �� 5�      .P�5�   "   �� $��#��61    �� DisplayMemberBinding 6<   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� 	Converter# [  �� CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� .��66   5�   /   5�   +   5�   #   �� 5�   "   $��Biển Số��61    6B   �� *BIENSO+6l   �� 5�   "   $��Nhà Sản Xuất��61    6G   �� *
NHASANXUAT+6u   5�      5�      5�      5�      �� 5�      $��1��6   $��Danh sách nhân viên��6'   $��5 5 5 5q�6D   .��5�      �� .��5�      �� ��6   �� $	 cbb��$ SelectedItem.NHANVIENLIST� 5�      �� 5�      .P�5�   "   �� $��#��61    5�   2   ��  �� *FindAncestor+" ��# [ 5�   X   �� 5�   "   $��Id Nhân Viên��61    6G   �� *IDNHANVIENXE+6w   �� 5�   "   $
��Tên��61    6>   �� *HOTEN+6g   �� 5�   "   $��Địa Chỉ��61    6B   �� *DIACHI+6l   5�      5�      5�      5�      5�      �� 5�   
   $��XUẤT��6   $��3��6    $
��Auto��5�   C   ��5�      �� *XuatCommand+��5�      �� $
 cbb1��6S   5�      5      