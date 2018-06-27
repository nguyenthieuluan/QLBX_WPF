using QLBX.FormChucNang;
using QLBX.Model;
using QLBX.View;
using QLBX.View.TiG;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QLBX.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public static string idnvNOW = null;
        #region Commands
        //Left Menu Command
        public ICommand DatVeCommand { get; set; }
        public ICommand BenXeCommand { get; set; }
        public ICommand TaiXeCommand { get; set; }
        public ICommand DatMuaVeCommand { get; set; }
        public ICommand NhanVienBanVeCommand { get; set; }
        public ICommand KhachGuiNhanHangCommand { get; set; }
        public ICommand ChuyenXeCommand { get; set; }
        public ICommand TuyenXeCommand { get; set; }
        public ICommand BaoCaoThongKeCommand { get; set; }
        public ICommand PhuXeCommand { get; set; }
        public ICommand QuanLyXeCommand { get; set; }
        public ICommand SapLichCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ChangeBackGroundCommand { get; set; }
        public ICommand ThongkeCommand { get; set; }
        //Header Menu Command
        public ICommand DangXuatCommand { get; set; }
        public ICommand TaiKhoanCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SaoLuuCommand { get; set; }
        public ICommand testCommand { get; set; }
        
        #endregion

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{
                Isloaded = true;
                LoginForm login = new LoginForm();
                if (p == null)
                    return;
                p.Hide();
                login.ShowDialog();
                if (login.DataContext == null)
                    return;
                var loginVM = login.DataContext as LoginVM;
                if (loginVM.IsLogin)
                {
                    p.Show();
                    idnvNOW = loginVM.UserName;
                    try
                    {
                        //cocn = layhinh(loginVM.UserName);
                    }
                    catch
                    {
                        //cocn = null;
                    }
                }
                else
                    p.Close();
            });

            TaiXeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { TaiXeForm txf = new TaiXeForm();  p.Children.Add(txf); });
            ChuyenXeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { ChuyenXeForm cxf = new ChuyenXeForm(); ; p.Children.Add(cxf); });
            TuyenXeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { TuyenXeForm txf = new TuyenXeForm(); ; p.Children.Add(txf); });
            BaoCaoThongKeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { BaoCaoThongKeForm bctkf = new BaoCaoThongKeForm(); ; p.Children.Add(bctkf); });
            PhuXeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { PhuXeForm pxf = new PhuXeForm(); ; p.Children.Add(pxf); });
            QuanLyXeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { QuanLyXeForm qlxf = new QuanLyXeForm(); p.Children.Clear(); p.Children.Add(qlxf); });
            SapLichCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { SapLichForm slf = new SapLichForm(); p.Children.Add(slf); });
            BenXeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { BenXeForm bxf = new BenXeForm(); ; p.Children.Add(bxf); });
            DatVeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { UCBooking uCBooking = new UCBooking(); ; p.Children.Add(uCBooking); });
            SaoLuuCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { SaoLuuForm slf = new SaoLuuForm(); ; p.Children.Add(slf); });
            NhanVienBanVeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { UCNhanVienBanVe nvbvf = new UCNhanVienBanVe(); ; p.Children.Add(nvbvf); });
            
            ////
            ThongkeCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { UCThongKe thongke = new UCThongKe();p.Children.Add(thongke); });
            testCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => { UserControl1 u1 = new UserControl1() ; p.Children.Add(u1); });
            DangXuatCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoginForm lgf = new LoginForm(); lgf.ShowDialog(); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            int i = 1;
            ChangeBackGroundCommand = new RelayCommand<Grid>((p) => { return true; }, (p) => {
                int n = 6;
                if (i <= n)
                {
                    string uri1 = "pack://application:,,,/Img/h" + i + ".jpg";
                    ImageBrush myBrush = new ImageBrush();
                    try
                    {
                        myBrush.ImageSource = new BitmapImage(new Uri(uri1, UriKind.Absolute));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    p.Background = myBrush;
                    i++; if(i == n) i = 0;
                }
            });
        }
    }
}
