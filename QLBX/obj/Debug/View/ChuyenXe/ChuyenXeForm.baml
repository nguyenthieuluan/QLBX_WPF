   M S B A M L   `   `   `  ����?  ;QLBX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QLBX.FormChucNangQLBX.FormChucNang  5   	   /clr-namespace:QLBX.ConverterQLBX.Converter  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      !clr-namespace:QLBX.UCQLBX.UC  5   	   $    QLBX.FormChucNang.ChuyenXeForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:QLBX.FormChucNang     5   	   -utilclr-namespace:QLBX.Converter     5   	   6sys&clr-namespace:System;assembly=mscorlib     5	      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   crclr-namespace:QLBX.UC  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     
ChuyenXeVM � DataContext# [ 5   	   .��5      � 
������� � 	Resources 5   
    �� 
TargetType �� Property �� Value��%X   '��       �� 5      " ��6   .�5      ��  � ��$ 5 5 15 5q�6+   5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6    � ColumnDefinitions 5   
   �� 5       �� 5!      $
��auto �6   .+�5$   
   � $��1��6   $��1��6   5%      #  MaterialDesignThemes.Wpf.Card  5'   
   $��0��6   $��2��6+   $��5q�6?   .��5(      � $��0 0 0 10q�6   .+�5)      �� $��5 5 15 5q�6   {�.  )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Id��5*       % !MaterialDesignFloatingHintTextBox#��[ 6>   ��5)   -   �� *
IDCHUYEN+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=�5*   >   �� 5+      $��5 5 15 5q�6   $	 
Id Tuyến��5,      #��[ 6D   ��5+   -   �� *	IDTUYEN+$
 PropertyChanged=�$ TwoWay=�5,   D   �� 5-      $��5 5 15 5q�6   $	 Biển Số��5.      #��[ 6D   ��5-   -   �� *BIENSO+$
 PropertyChanged=�$ TwoWay=�5.   D   (  "System.Windows.Controls.DatePicker  5/      $��Bottom=�6   $��5 5 15 5q�68    �� Today   DisplayDateStart# Z 6�   $	 Ngày Khởi Hành��50       ( $MaterialDesignFloatingHintDatePicker#��[ 6K      SelectedDate 5/   J   �� *NGAYKHOIHANH+$
 PropertyChanged=�$ TwoWay=�50   K   )  #MaterialDesignThemes.Wpf.TimePicker  51         SelectedTimeFormat$ Short=�6,   $��Bottom=�6G   $��5 5 15 5q�6c   $	 Giờ Khởi Hành��52       ( $MaterialDesignFloatingHintTimePicker#��[ 6J      Text 51   u   �� *GIOKHOIHANH+$
 PropertyChanged=�$ TwoWay=�52   J   �� 53      $��5 5 15 5q�6   $	 Giá Vé��54      #��[ 6C   ��53   -   �� *GIAVECHUYEN+$
 PropertyChanged=�$ TwoWay=�54   C   �� 55      $��5 5 15 5q�6   $��Bottom=�6-    �� DisplayMemberPath$ HOTEN��56       �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 6K   $	 	Tài Xế��59      ��57      �� *NhanVienXeList+ �� SelectedItem 58      �� *SelectedTaiXe+$
 PropertyChanged=�$ TwoWay=�59      5;      5<      � 5>   
   $��1��6   .+�5?      �� $ �� IsSynchronizedWithCurrentItem$
 TrueY�5A      !   QLBX.Converter.GridViewSort   AutoSort . ��5?      �� *ChuyenXeList+$ TwoWay=�$
 PropertyChanged=� 5@      �� *SelectedItem+$ TwoWay=� �� View 5C      �� 5D      .P�5E      �� $��
Id Tuyến��6)      PropertyName$ IDTUYEN��6d    �� DisplayMemberBinding 6;   �� *	IDTUYEN+6�   �� 5F      $��
Bến Số��6)   $ BIENSO��6a    69   �� *BIENSO+6�   �� 5G      $��Ngày Khởi Hành��6)   $ NGAYKHOIHANH��6    6A   �� *NGAYKHOIHANH+ �� StringFormat$ d��6�   �� 5H      $��Thời Gian Khởi Hành��6)   $ THOIGIANKHOIHANH��6x    6F   �� *THOIGIANKHOIHANH+6�   �� 5I      $��Giá Vé��6)   $ GIAVECHUYEN��6f    69   �� *GIAVECHUYEN+6�   �� 5J      $��	Tài Xế��6)   $ GIAVECHUYEN��6k    69   �� *NHANVIENXE.HOTEN+6�   5K      5M         QLBX.UC.hoangG  5N      $��Right=�6   $	��Top=�64   $��	0 20 20 0q�6L   5O      5P      5Q      