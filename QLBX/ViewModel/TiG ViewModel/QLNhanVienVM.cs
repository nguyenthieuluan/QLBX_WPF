using QLBX.FormChucNang;
using QLBX.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class QLNhanVienVM:BaseViewModel
    {
        bool ktdkthem = false;
        bool ktdkxoa = false;
        String idpermisson = null;
        private ObservableCollection<NhanVien> _ListNV;
        public ObservableCollection<NhanVien> ListNV { get=>_ListNV; set { _ListNV = value;OnPropertyChanged(); } }
        private ObservableCollection<USER> _ListUserChuaQuyen;
        public ObservableCollection<USER> ListUserChuaQuyen { get => _ListUserChuaQuyen; set { _ListUserChuaQuyen = value; OnPropertyChanged(); } }
        private NhanVien _Selecteditem;
        public NhanVien Selecteditem
        {
            get => _Selecteditem;
            set
            {
                _Selecteditem =value;OnPropertyChanged();
                if (Selecteditem != null)
                {
                    username = Selecteditem.UserName;
                    hoten = Selecteditem.HoTen;
                    diachi = Selecteditem.DiaChi;
                    cmnd = Selecteditem.CMND;
                    ngaysinh = Selecteditem.NgaySinh;
                    hinh = Selecteditem.Hinh;
                    status = Selecteditem.status;
                    sdt = Selecteditem.SDT;
                }
            }
        }

        // Tao item source
        private string _username;
        public string username { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _hoten;
        public string hoten { get => _hoten; set { _hoten = value; OnPropertyChanged(); } }
        private string _diachi;
        public string diachi { get => _diachi; set { _diachi = value; OnPropertyChanged(); } }
        private string _cmnd;
        public string cmnd { get => _cmnd; set { _cmnd = value; OnPropertyChanged(); } }
        private DateTime? _ngaysinh;
        public DateTime? ngaysinh { get => _ngaysinh; set { _ngaysinh = value; OnPropertyChanged(); } }
        private string _hinh;
        public string hinh { get => _hinh; set { _hinh = value; OnPropertyChanged(); } }
        private string _status;
        public string status { get => _status; set { _status = value; OnPropertyChanged(); } }
        private string _sdt;
        public string sdt { get => _sdt; set { _sdt = value; OnPropertyChanged(); } }
        //commit
        public ICommand addnv { get; set; }
        public ICommand fixnv { get; set; }
        public ICommand xoanhanvien { get; set; }


        /// <Phanquyen>
        private ObservableCollection<PERMISSION> _cbpermisson;
        public ObservableCollection<PERMISSION> cbpermisson { get => _cbpermisson; set { _cbpermisson = value; OnPropertyChanged(); } }
        public ICommand SelectionChangedCBPermisson { get; set; }
        public ICommand themquyen { get; set; }
        public ICommand xoanhomquyen { get; set; }
        private ObservableCollection<USER> _listpermisson;
        public ObservableCollection<USER> listpermisson { get => _listpermisson; set { _listpermisson = value; OnPropertyChanged(); } }
        public ICommand selectlistchuaquyen { get; set; }
        String iduser = null;
        public ICommand selectdsquyen { get; set; }
        public ICommand xoaquyen { get; set; }
        public ICommand themnhomquyen { get; set; }
        private ObservableCollection<PERMISSION> _dsquyen;
        public ObservableCollection<PERMISSION> dsquyen { get => _dsquyen; set { _dsquyen = value; OnPropertyChanged(); } }
        /// </summary>

        private PERMISSION _selectedchietiequyen;
        public PERMISSION selectedchietiequyen
        {
            get => _selectedchietiequyen;
            set
            {
                _selectedchietiequyen = value;OnPropertyChanged();
                if(selectedchietiequyen!=null)
                {
                    var result = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == selectedchietiequyen.IDPermission).ToList();
                    check1 = (result[0] as PERMISSION).khachdixe;
                    check2 = (result[0] as PERMISSION).nhanvienxe;
                    check3 = (result[0] as PERMISSION).tuyen;
                    check4 = (result[0] as PERMISSION).chuyen;
                    check5 = (result[0] as PERMISSION).nhanvien;

                    //check1 = selectedchietiequyen.khachdixe;
                    //check2 = selectedchietiequyen.nhanvienxe;
                    //check3 = selectedchietiequyen.tuyen;
                    //check4 = selectedchietiequyen.chuyen;
                    //check5 = selectedchietiequyen.nhanvien;
                    idperthem = selectedchietiequyen.IDPermission;
                    nameperthem = selectedchietiequyen.NamePermission;
                }
            }
        }

        private string _idperthem;
        public string idperthem { get => _idperthem; set { _idperthem = value; OnPropertyChanged();} }
        private string _nameperthem;
        public string nameperthem { get => _nameperthem; set { _nameperthem = value; OnPropertyChanged(); } }

        private bool? _check1;
        public bool? check1 { get => _check1; set { _check1 = value; OnPropertyChanged(); } }
        private bool? _check2;
        public bool? check2 { get => _check2; set { _check2 = value; OnPropertyChanged(); } }
        private bool? _check3;
        public bool? check3 { get => _check3; set { _check3 = value; OnPropertyChanged(); } }
        private bool? _check4;
        public bool? check4 { get => _check4; set { _check4 = value; OnPropertyChanged(); } }
        private bool? _check5;
        public bool? check5 { get => _check5; set { _check5 = value; OnPropertyChanged(); } }

        /// <summary>
        public ICommand capquyen1 { get; set; }
        public ICommand capquyen2 { get; set; }
        public ICommand capquyen3 { get; set; }
        public ICommand capquyen4 { get; set; }
        public ICommand capquyen5 { get; set; }
        String idpermissonPhanQuyen = null;
        public ICommand selectlitquyen { get; set; }
        /// </summary>


        public QLNhanVienVM()
        {
            ListNV = new ObservableCollection<NhanVien>(DataProvider.Ins.DB.NhanViens);
            ListUserChuaQuyen = new ObservableCollection<USER>(DataProvider.Ins.DB.USERs.Where(x=>x.IDPermission==idpermisson));
            cbpermisson = new ObservableCollection<PERMISSION>(DataProvider.Ins.DB.PERMISSIONs);
            dsquyen = new ObservableCollection<PERMISSION>(DataProvider.Ins.DB.PERMISSIONs);
            addnv = new RelayCommand<object>((p)=> 
            {
                if (string.IsNullOrEmpty(username))
                    return false;
                var display = DataProvider.Ins.DB.NhanViens.Where(x => x.UserName == username);
                if (display == null || display.Count() != 0)
                    return false;
                return true;
            },(p)=> 
            {
                var uSER = new USER() { UserName = username, PassWord = "1" };
                DataProvider.Ins.DB.USERs.Add(uSER);
                DataProvider.Ins.DB.SaveChanges();

                var nHanVien = new NhanVien() { UserName = username,HoTen=hoten,DiaChi=diachi,CMND=cmnd,NgaySinh=ngaysinh,Hinh=hinh,status="2",SDT=sdt };
                DataProvider.Ins.DB.NhanViens.Add(nHanVien);
                DataProvider.Ins.DB.SaveChanges();

                ListUserChuaQuyen.Add(uSER);
                ListNV.Add(nHanVien);
            });

            fixnv = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(username)||Selecteditem==null)
                    return false;
                var display = DataProvider.Ins.DB.NhanViens.Where(x => x.UserName == username);
                if (display == null)
                    return false;
                return true;
            }, (p) =>
            {
                var uSER = DataProvider.Ins.DB.NhanViens.Where(x => x.UserName == Selecteditem.UserName).SingleOrDefault();
                uSER.HoTen = hoten;
                uSER.DiaChi = diachi;
                uSER.CMND = cmnd;
                uSER.NgaySinh = ngaysinh;
                uSER.Hinh = hinh;
                uSER.status = status;
                uSER.SDT = sdt;
                DataProvider.Ins.DB.SaveChanges();
            });
            //xoa nhom quyen
            xoanhomquyen = new RelayCommand<UserControl>((p) =>
            {
                if (idperthem != null)
                    return true;
                else return false;
            },(p)=>
            {
             //   try
                {
                    var xoakq = (from c in DataProvider.Ins.DB.PERMISSIONs where (c.IDPermission == idperthem) select c).ToList();
                    var cccac = DataProvider.Ins.DB.USERs.ToList();
                    foreach(var item in cccac)
                    {
                        if (xoakq != null)
                        {
                            if (item.IDPermission == xoakq[0].IDPermission)
                            {
                                MessageBox.Show("Dam bao rang khong co nhan vien nao thuoc nhom quyen nay", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                        }
                    }
                    
                    if (xoakq != null)
                    {
                        DataProvider.Ins.DB.PERMISSIONs.Remove(xoakq[0]);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Successfully", "Notic", MessageBoxButton.OK, MessageBoxImage.Information);
                        dsquyen.Remove(xoakq[0]);
                    }
                    Grid c1 = p.Parent as Grid;
                    UCPhanQuyen uc1 = new UCPhanQuyen();

                    c1.Children.Clear();
                    c1.Children.Add(uc1);
                }
                //catch
                //{
                    
                //}
            });
            //xoa nhan vien
            xoanhanvien = new RelayCommand<object>((p) =>
            {
                  return true;
            },(p)=>
            {
                username = username.Replace(" ", "");
                //MessageBox.Show("nhan vien hien tai" + MainViewModel.idnvNOW + "adf");
                //MessageBox.Show("nhan vien hien tai" + username+"adf");
                if (username == MainViewModelTiG.idnvNOW)
                {
                    MessageBox.Show("Tai khoan dang hoat dong", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    var xoakq = (from c in DataProvider.Ins.DB.NhanViens where (c.UserName == username) select c).ToList();
                    if (xoakq != null)
                    {
                        DataProvider.Ins.DB.NhanViens.Remove(xoakq[0]);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    var xoakq1 = (from d in DataProvider.Ins.DB.USERs where (d.UserName == username) select d).ToList();
                    if (xoakq1 != null)
                    {
                        DataProvider.Ins.DB.USERs.Remove(xoakq1[0]);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    ListNV.Remove(xoakq[0]);
                }
            });
            //quan ly phan quyen
            SelectionChangedCBPermisson = new RelayCommand<ComboBox>((p) => { return true; },(p)=> 
            {
                idpermisson = (p.SelectedItem as PERMISSION).IDPermission.ToString();
                listpermisson = new ObservableCollection<USER>(DataProvider.Ins.DB.USERs.Where(x=>x.IDPermission==idpermisson));
            });

            selectlistchuaquyen = new RelayCommand<ListView>((p) => { return true; }, (p) =>
               {
                   try
                   {
                       iduser = (p.SelectedItem as USER).UserName;
                       ktdkthem = true;
                       ktdkxoa = false;
                   }
                   catch { iduser = null; }
               });

            themquyen = new RelayCommand<object>((p) => { if (iduser != null && idpermisson != null && ktdkthem == true && ktdkxoa==false) return true; else return false; }, (p) =>
            {
                var user = DataProvider.Ins.DB.USERs.Where(x => x.UserName == iduser).SingleOrDefault();
                user.IDPermission = idpermisson;
                DataProvider.Ins.DB.SaveChanges();
                ListUserChuaQuyen.Remove(user);
                listpermisson.Add(user);
                ktdkthem = false;
                ktdkxoa = false;
            });

            selectdsquyen = new RelayCommand<ListView>((p) => { return true; }, (p) => { try { iduser = (p.SelectedItem as USER).UserName; ktdkthem = false;
                    ktdkxoa = true;
                } catch { iduser = null; } });

            xoaquyen = new RelayCommand<object>((p) => { if (selectdsquyen != null && iduser != null && ktdkthem == false && ktdkxoa == true) return true; else return false; }, (p) =>
             {
                 try
                 {
                     var user = DataProvider.Ins.DB.USERs.Where(x => x.UserName == iduser).SingleOrDefault();
                     user.IDPermission = null;
                     DataProvider.Ins.DB.SaveChanges();
                     ListUserChuaQuyen.Add(user);
                     listpermisson.Remove(user);
                     ktdkthem = false;
                     ktdkxoa = false;
                 }
                 catch { }
             });

            selectlitquyen = new RelayCommand<ListView>((p) => { return true; }, (p) => { idpermissonPhanQuyen = (p.SelectedItem as PERMISSION).IDPermission;  });

            capquyen1 = new RelayCommand<CheckBox>((p) => { if (idpermissonPhanQuyen != null) return true; else return false; }, (p) => 
            {
                var user = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == idpermissonPhanQuyen.Replace(" ","")).SingleOrDefault();
                user.khachdixe = p.IsChecked;
                DataProvider.Ins.DB.SaveChanges();

                FrameworkElement c1 = p.Parent as FrameworkElement;
                int i = 0;
                while (i<6)
                {
                    c1 = c1.Parent as FrameworkElement;
                    i++;
                }
                Grid c2 = c1.Parent as Grid;
                UCPhanQuyen uc1 = new UCPhanQuyen();
                
                c2.Children.Clear();
                c2.Children.Add(uc1);
                

            });
            capquyen2 = new RelayCommand<CheckBox>((p) => { if (idpermissonPhanQuyen != null) return true; else return false; }, (p) => 
            {
                var user = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == idpermissonPhanQuyen.Replace(" ", "")).SingleOrDefault();
                user.nhanvienxe = p.IsChecked;
                DataProvider.Ins.DB.SaveChanges();
            });
            capquyen3 = new RelayCommand<CheckBox>((p) => { if (idpermissonPhanQuyen != null) return true; else return false; }, (p) => 
            {
                var user = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == idpermissonPhanQuyen.Replace(" ", "")).SingleOrDefault();
                user.tuyen = p.IsChecked;
                DataProvider.Ins.DB.SaveChanges();
            });
            capquyen4 = new RelayCommand<CheckBox>((p) => { if (idpermissonPhanQuyen != null) return true; else return false; }, (p) => 
            {
                var user = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == idpermissonPhanQuyen.Replace(" ", "")).SingleOrDefault();
                user.chuyen = p.IsChecked;
                DataProvider.Ins.DB.SaveChanges();
            });
            capquyen5 = new RelayCommand<CheckBox>((p) => { if (idpermissonPhanQuyen != null) return true; else return false; }, (p) => 
            {
                var user = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == idpermissonPhanQuyen.Replace(" ", "")).SingleOrDefault();
                user.nhanvien = p.IsChecked;
                DataProvider.Ins.DB.SaveChanges();
            });
            themnhomquyen = new RelayCommand<UserControl>((p) => 
            {
                if (string.IsNullOrEmpty(idperthem) && string.IsNullOrEmpty(nameperthem))
                    return false;
                var dis = DataProvider.Ins.DB.PERMISSIONs.Where(x => x.IDPermission == idperthem);
                if (dis.Count() !=0)
                    return false;
                return true;
            },
            (p) => 
            {
                var permisson = new PERMISSION() {IDPermission=idperthem,NamePermission=nameperthem,ve=false,chuyen=false,tuyen=false,thongke=false,nhanvien=false,khachdixe=false,khachguihang=false,hanghoa=false,nhanvienxe=false };
                DataProvider.Ins.DB.PERMISSIONs.Add(permisson);
                DataProvider.Ins.DB.SaveChanges();

                dsquyen.Add(permisson);
                cbpermisson.Add(permisson);

                Grid c1 = p.Parent as Grid;
                UCPhanQuyen uc1 = new UCPhanQuyen();               
                
                c1.Children.Clear();
                c1.Children.Add(uc1);

            });
        }
    }

}
