using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using QLBX.FormChucNang;
using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class DatVeVM : BaseViewModel
    {
        private string _tenkhach;
        public string tenkhach { get => _tenkhach; set { _tenkhach = value; OnPropertyChanged(); } }
        private string _sodienthoai;
        public string sodienthoai { get => _sodienthoai; set { _sodienthoai = value; OnPropertyChanged(); } }
        private float _total;
        public float total { get => _total; set { _total = value; OnPropertyChanged(); } }
        private string _diachi;
        public string diachi { get => _diachi; set { _diachi = value; OnPropertyChanged(); } }
        private List<int> _Dsghe;
        public List<int> Dsghe { get => _Dsghe; set { _Dsghe = value; OnPropertyChanged(); } }
        private bool _cast;
        public bool cast { get => _cast; set { _cast = value; OnPropertyChanged(); } }
        private bool _book;
        public bool book { get => _book; set { _book = value; OnPropertyChanged(); } }
        public ICommand commit { get; set; }
        public ICommand removeve { get; set; }
        int tien=0;
        /// <Hang_Hoa>
        private string _tenkhachhh;
        public string tenkhachhh { get => _tenkhachhh; set { _tenkhachhh = value; OnPropertyChanged(); } }
        private string _diachihh;
        public string diachihh { get => _diachihh; set { _diachihh = value; OnPropertyChanged(); } }
        private string _sdthh;
        public string sdthh { get => _sdthh; set { _sdthh = value; OnPropertyChanged(); } }
        private string _tenhh;
        public string tenhh { get => _tenhh; set { _tenhh = value; OnPropertyChanged(); } }
        private string _totalhh;
        public string totalhh { get => _totalhh; set { _totalhh = value; OnPropertyChanged(); } }
        public ICommand commithh { get; set; }
        /// </Hang_Hoa>
        public DatVeVM()
        {
            commit = new RelayCommand<UserControl>((p) => { return kt(); }, (p) =>
               {
                   if (MessageBox.Show("Add?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                   {
                       addve();
                       addkhach();
                       addchitietve();

                       tenkhach = sodienthoai = diachi = null;
                       total = 0;
                       Dsghe = new List<int>();
                       FrameworkElement c1 = p.Parent as FrameworkElement;
                       UCVeXe uc1 = new UCVeXe();
                       Grid abc = c1 as Grid;
                       abc.Children.Clear();
                       abc.Children.Add(uc1);
                   }

                   

               });
            removeve = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
                //MessageBox.Show(form1.kq);
                //if (MessageBox.Show("Remove?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                if(form1.kq=="xoa")
                {
                    int a = Convert.ToInt32((p.SelectedItem as UCVeXe.user).idkhach);
                    int b = Convert.ToInt32((p.SelectedItem as UCVeXe.user).soghedamua);
                    var vexe = (from c in DataProvider.Ins.DB.CHITIETVEs where (c.IDKHACH == a && c.SOGHE == b) select c).ToList();
                    if (vexe != null)
                    {
                        int? bd = vexe[0].IDVE;
                        DataProvider.Ins.DB.CHITIETVEs.Remove(vexe[0]);
                        DataProvider.Ins.DB.SaveChanges();
                        
                        xoave(bd);
                        xoakhacch(a);
                        try
                        {
                            foreach (var it in GetListIDvexe.ListChoNgoiVaTrangThai)
                            {
                                if (it == null) break;
                                if (it.chongoi == b)
                                    GetListIDvexe.ListChoNgoiVaTrangThai.Remove(it);
                            }
                        }
                        catch { }
                    }
                    FrameworkElement c1 = p as FrameworkElement;
                    
                    for(int i=0;i<7;i++)
                    {
                        c1 = c1.Parent as FrameworkElement;
                    }
                    UCVeXe uc1 = new UCVeXe();
                    Grid abc = c1 as Grid;
                    abc.Children.Clear();
                    abc.Children.Add(uc1);
                }
                if (form1.kq == "thanhtoan")
                {
                    bool? ktnek = (p.SelectedItem as UCVeXe.user).trangthai;
                    if (ktnek != false)
                    {
                        MessageBox.Show("Ve Da Thanh Toan", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    int a = Convert.ToInt32((p.SelectedItem as UCVeXe.user).idkhach);
                    int b = Convert.ToInt32((p.SelectedItem as UCVeXe.user).soghedamua);
                    var vexe = (from c in DataProvider.Ins.DB.CHITIETVEs where (c.IDKHACH == a && c.SOGHE == b) select c).ToList();
                    if (vexe != null)
                    {
                        int? bd = vexe[0].IDVE;
                        var vexe123 = DataProvider.Ins.DB.VEXEs.Where(x => x.IDVE == bd).SingleOrDefault();
                        vexe123.TRANGTHAI = true;
                        DataProvider.Ins.DB.SaveChanges();
                        try
                        {
                            foreach (var it in GetListIDvexe.ListChoNgoiVaTrangThai)
                            {
                                if (it == null) break;
                                if (it.chongoi == b)
                                {
                                    it.trangthai = true;

                                }
                            }
                        }
                        catch { }
                    }

                    FrameworkElement c1 = p as FrameworkElement;

                    for (int i = 0; i < 7; i++)
                    {
                        c1 = c1.Parent as FrameworkElement;
                    }
                    UCVeXe uc1 = new UCVeXe();
                    Grid abc = c1 as Grid;
                    abc.Children.Clear();
                    abc.Children.Add(uc1);
                }
            });

            commithh = new RelayCommand<UserControl>((p) => 
            {
                try
                {
                    tien = int.Parse(totalhh);
                    return kt1();
                }
                catch { return false; }
            }, (p) =>
            {
                var result = new GUIHANGHOA() { HOTEN = tenkhachhh, DIACHI = diachihh, SDT = sdthh, IDCHUYEN = StaticIDChuyen.StaIDchuyen, TENHANG = tenhh, GIATIEN = tien };
                DataProvider.Ins.DB.GUIHANGHOAs.Add(result);
                DataProvider.Ins.DB.SaveChanges();
                var str = from c in DataProvider.Ins.DB.NhanViens where c.UserName == MainViewModelTiG.idnvNOW select c;
                //string abucu = (str.First() as NhanVien).HoTen;
                var getChuyen = from ch in DataProvider.Ins.DB.CHUYENXEs where ch.IDCHUYEN == StaticIDChuyen.StaIDchuyen select ch;
                string bks = (getChuyen.First() as CHUYENXE).BIENSO;
                DateTime? dateDI;
                TimeSpan? hourss;
                dateDI = (getChuyen.First() as CHUYENXE).NGAYKHOIHANH;
                hourss = (getChuyen.First() as CHUYENXE).THOIGIANKHOIHANH;
                var asss = DataProvider.Ins.DB.GUIHANGHOAs;
                int caijdo = asss.OrderByDescending(x => x.IDKHACHGUIHANG).First().IDKHACHGUIHANG;
                PrintReceipt123(MainViewModelTiG.idnvNOW, " ", caijdo.ToString(), tenkhachhh, sdthh, diachihh, bks, tenhh, dateDI.ToString(), hourss.ToString(), laychuyenra(StaticIDChuyen.StaIDchuyen), tien.ToString());

                tenkhachhh = diachihh = sdthh = tenhh = totalhh = null;

                FrameworkElement c1 = p.Parent as FrameworkElement;
                UCVeXe uc1 = new UCVeXe();
                Grid abc = c1 as Grid;
                abc.Children.Clear();
                abc.Children.Add(uc1);

                //print cript
                //rintReceipt123();
            });
        }
        
        void xoakhacch(int b)
        {
            if(DataProvider.Ins.DB.CHITIETVEs.Where(c=>c.IDKHACH==b).Count()==0)
            {
                var vexe = (from d in DataProvider.Ins.DB.KHACHDIXEs where d.IDKHACH == b select d).ToList();
                DataProvider.Ins.DB.KHACHDIXEs.Remove(vexe[0]);
                DataProvider.Ins.DB.SaveChanges();
            }
        }
        void xoave(int? b)
        {
            int n = DataProvider.Ins.DB.CHITIETVEs.Where(c => c.IDVE == b).Count();
            if(n==0)
            {
                var vexe = (from d in DataProvider.Ins.DB.VEXEs where d.IDVE == b select d).ToList();
                DataProvider.Ins.DB.VEXEs.Remove(vexe[0]);
                DataProvider.Ins.DB.SaveChanges();
                return;
            }
            n++;
            if (n != 0)
            {
                var result = (from d in DataProvider.Ins.DB.VEXEs where d.IDVE == b select d.TONGTIEN).ToList();
                int? tongtien = Convert.ToInt32(result[0]);
                int? tongtien1 = tongtien / n;
                if (n - 1 > 0)
                    tongtien = tongtien1 * (n - 1);
                var unit = DataProvider.Ins.DB.VEXEs.Where(x => x.IDVE == b).SingleOrDefault();
                unit.TONGTIEN = tongtien;
                DataProvider.Ins.DB.SaveChanges();
            }
        }
        
        #region dat ve
        private bool kt()
        {
            if (cast == true || book == true)
            {
                if (tenkhach != null && sodienthoai != null && diachi != null && Dsghe != null && total != 0)
                    return true;
            }
            return false;
        }
        private bool kt1()
        {
                if (tenkhachhh != null && diachihh != null && sdthh != null && tenhh != null && totalhh!=null)
                    return true;
            return false;
        }
        public void addve()
        {

            if (book==true)
            {
                var result = new VEXE() { IDCHUYEN = StaticIDChuyen.StaIDchuyen, TONGTIEN = int.Parse(total.ToString()), TRANGTHAI = false };
                DataProvider.Ins.DB.VEXEs.Add(result);
                DataProvider.Ins.DB.SaveChanges();
            }
            else
            {
                var result = new VEXE() { IDCHUYEN = StaticIDChuyen.StaIDchuyen, TONGTIEN = int.Parse(total.ToString()), TRANGTHAI = true };
                DataProvider.Ins.DB.VEXEs.Add(result);
                DataProvider.Ins.DB.SaveChanges();
            }

        }
        public void addkhach()
        {
            var result = new KHACHDIXE() { HOTEN = tenkhach, DIACHI = diachi, SDT = sodienthoai };
            DataProvider.Ins.DB.KHACHDIXEs.Add(result);
            DataProvider.Ins.DB.SaveChanges();
        }
        public void addchitietve()
        {
            var resul = (from c in DataProvider.Ins.DB.KHACHDIXEs select c).ToList();
            int idk = resul.OrderByDescending(p => p.IDKHACH).First().IDKHACH;
            var resu = (from c in DataProvider.Ins.DB.VEXEs select c).ToList();
            int idv = resu.OrderByDescending(p => p.IDVE).First().IDVE;
            string numberchair="";
            foreach (var item in Dsghe)
            {
                var result = new CHITIETVE() { SOGHE = item, IDKHACH = idk, IDVE = idv };
                DataProvider.Ins.DB.CHITIETVEs.Add(result);
                DataProvider.Ins.DB.SaveChanges();
                ItemListVeVM p123 = new ItemListVeVM();
                p123.chongoi = item;
                p123.idkhach = idk;
                if (cast == true)
                    p123.trangthai = true;
                else p123.trangthai = false;
                {
                    GetListIDvexe.ListChoNgoiVaTrangThai.Add(p123);
                }
                numberchair += item + " ";
            }
            //var str = DataProvider.Ins.DB.NhanViens.Where(x => x.UserName == MainViewModel.idnvNOW);
            //MessageBox.Show(MainViewModel.idnvNOW);
            var str = from c in DataProvider.Ins.DB.NhanViens where c.UserName == MainViewModel.idnvNOW select c;
            string abucu = (str.First() as NhanVien).HoTen;

            string bks;
            DateTime? dateDI;
            TimeSpan? hourss;
            var getChuyen = from ch in DataProvider.Ins.DB.CHUYENXEs where ch.IDCHUYEN == StaticIDChuyen.StaIDchuyen select ch;
            bks = (getChuyen.First() as CHUYENXE).BIENSO;
            dateDI= (getChuyen.First() as CHUYENXE).NGAYKHOIHANH;
            hourss = (getChuyen.First() as CHUYENXE).THOIGIANKHOIHANH;


            PrintReceipt(idv.ToString(), MainViewModelTiG.idnvNOW, abucu, tenkhach, sodienthoai, diachi, bks, dateDI.ToString(), hourss.ToString(), laychuyenra(StaticIDChuyen.StaIDchuyen), numberchair, total.ToString());
        }
        #endregion
        #region xuat hoa don ve
        private  void PrintReceipt( string ts2, string ts3, string ts4, string ts5, string ts6, string ts7, string ts8, string ts10, string ts11, string ts12, string ts13, string ts14)
        {
            #region ve xe made by me!!!
            Chunk header = new Chunk("COMPANY TRANSPORTATION TLL", FontFactory.GetFont("Times New Roman"));
            header.Font.Size = 14;
            header.Font.SetStyle(Font.BOLD);
            Paragraph parHead = new Paragraph();
            parHead.Alignment = Element.ALIGN_CENTER;
            parHead.Add(header);

            Chunk header1 = new Chunk("140 Le Trong Tan, F Tay Thanh, Tan Phu Dis, Ho Chi Minh", FontFactory.GetFont("Times New Roman"));
            header1.Font.Size = 8;
            Paragraph parhead2 = new Paragraph();
            parhead2.Alignment = Element.ALIGN_CENTER;
            parhead2.Add(header1);

            Chunk header2 = new Chunk("Hotline: 19009999", FontFactory.GetFont("Times New Roman"));
            header1.Font.Size = 8;
            Paragraph parhead3 = new Paragraph();
            parhead3.Alignment = Element.ALIGN_CENTER;
            parhead3.Add(header2);

            Chunk header4 = new Chunk("www.thecoffehouse.com", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLUE));
            header4.Font.Size = 8;
            Paragraph parhead4 = new Paragraph();
            header4.Font.SetStyle(Font.ITALIC);
            parhead4.Alignment = Element.ALIGN_CENTER;
            parhead4.Add(header4);

            Chunk footer = new Chunk("Thank you anh see you again!!!!!!!!!!!!", FontFactory.GetFont("Times New Roman"));
            footer.Font.Size = 8;
            Paragraph parfooter = new Paragraph();
            footer.Font.SetStyle(Font.ITALIC);
            parfooter.Alignment = Element.ALIGN_CENTER;
            parfooter.Add(footer);

            Chunk khoangtrang = new Chunk("   ");
            khoangtrang.Font.Size = 8;
            Paragraph doantrang = new Paragraph();
            doantrang.Add(khoangtrang);

            LineSeparator line = new LineSeparator(0.5f, 100f, BaseColor.BLUE, Element.ALIGN_CENTER, 0.5f);
            //////////////////////////////////////////////////
            PdfPTable table1 = new PdfPTable(2);

            Font font = new Font();
            font.Size = 8;
            PdfPCell a1 = new PdfPCell(new Phrase("Times: "+DateTime.Now.ToShortDateString(), font));
            PdfPCell a2 = new PdfPCell(new Phrase("ID Ticket: "+ts2, font));
            PdfPCell a3 = new PdfPCell(new Phrase("ID Staff: "+ts3, font));
            PdfPCell a4 = new PdfPCell(new Phrase("Staff: "+ts4, font));

            a1.BorderWidth = 0;
            a2.BorderWidth = 0;
            a3.BorderWidth = 0;
            a4.BorderWidth = 0;

            table1.AddCell(a1);
            table1.AddCell(a2);
            table1.AddCell(a3);
            table1.AddCell(a4);
            table1.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
            /////////////////////////////////////////////////////////////
            PdfPTable table2 = new PdfPTable(2);

            PdfPCell b1 = new PdfPCell(new Phrase("Customer: "+ts5, font));
            PdfPCell b2 = new PdfPCell(new Phrase("Phone number: "+ts6, font));
            PdfPCell b3 = new PdfPCell(new Phrase("Add: "+ts7, font));
            PdfPCell b4 = new PdfPCell(new Phrase(" ", font));

            b1.BorderWidth = 0;
            b2.BorderWidth = 0;
            b3.BorderWidth = 0;
            b4.BorderWidth = 0;

            table2.AddCell(b1);
            table2.AddCell(b2);
            table2.AddCell(b3);
            table2.AddCell(b4);
            table2.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
            ///////////////////////////////////////////////////////////////////
            PdfPTable table3 = new PdfPTable(2);

            PdfPCell c1 = new PdfPCell(new Phrase("BKS: "+ts8, font));
            PdfPCell c2 = new PdfPCell(new Phrase("Number Chair: "+ts13, font));
            PdfPCell c3 = new PdfPCell(new Phrase("Date: "+ts10, font));
            PdfPCell c4 = new PdfPCell(new Phrase("Hour: "+ts11, font));
            PdfPCell c5 = new PdfPCell(new Phrase("Destiantion: "+ts12, font));
            PdfPCell c6 = new PdfPCell(new Phrase(" ", font));

            c1.BorderWidth = 0;
            c2.BorderWidth = 0;
            c3.BorderWidth = 0;
            c4.BorderWidth = 0;
            c5.BorderWidth = 0;
            c6.BorderWidth = 0;

            table3.AddCell(c1);
            table3.AddCell(c2);
            table3.AddCell(c3);
            table3.AddCell(c4);
            table3.AddCell(c5);
            table3.AddCell(c6);
            table3.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
            ///////////////////////////////////////////////////////

            Chunk footer1 = new Chunk("Total: "+ts14+" VND", FontFactory.GetFont("Times New Roman"));
            footer1.Font.Size = 8;
            Paragraph parfooter1 = new Paragraph();
            footer1.Font.SetStyle(Font.BOLD);
            parfooter1.Alignment = Element.ALIGN_RIGHT;
            parfooter1.Add(footer1);

            #endregion


            using (FileStream stream = new FileStream("D:\\"+ts2+".pdf", FileMode.Create))
            {
                Rectangle rectangle = new Rectangle(PageSize.A5);
                Document pdfDoc = new Document(rectangle);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
       

                pdfDoc.Add(parHead);
                pdfDoc.Add(parhead2);
                pdfDoc.Add(parhead3);
                pdfDoc.Add(parhead4);

                pdfDoc.AddAuthor("Luan dai ca");
                pdfDoc.AddTitle("Tickets");
                pdfDoc.AddKeywords("vexe");

                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(table1);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(table2);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(table3);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(parfooter1);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(parfooter);

                pdfDoc.Close();
                stream.Close();
            }


        }

        private  void PrintReceipt123(string idnv, string tennv, string id, string hoten, string sdt, string add, string bks, string stuff, string date, string hour, string chuyen, string total)
        {

            #region ve xe made by me!!!
            Chunk header = new Chunk("COMPANY TRANSPORTATION TLL", FontFactory.GetFont("Times New Roman"));
            header.Font.Size = 14;
            header.Font.SetStyle(Font.BOLD);
            Paragraph parHead = new Paragraph();
            parHead.Alignment = Element.ALIGN_CENTER;
            parHead.Add(header);

            Chunk header1 = new Chunk("140 Le Trong Tan, F Tay Thanh, Tan Phu Dis, Ho Chi Minh", FontFactory.GetFont("Times New Roman"));
            header1.Font.Size = 8;
            Paragraph parhead2 = new Paragraph();
            parhead2.Alignment = Element.ALIGN_CENTER;
            parhead2.Add(header1);

            Chunk header2 = new Chunk("Hotline: 19009999", FontFactory.GetFont("Times New Roman"));
            header1.Font.Size = 8;
            Paragraph parhead3 = new Paragraph();
            parhead3.Alignment = Element.ALIGN_CENTER;
            parhead3.Add(header2);

            Chunk header4 = new Chunk("www.tllssss.com", FontFactory.GetFont("Times New Roman", 8, BaseColor.BLUE));
            header4.Font.Size = 8;
            Paragraph parhead4 = new Paragraph();
            header4.Font.SetStyle(Font.ITALIC);
            parhead4.Alignment = Element.ALIGN_CENTER;
            parhead4.Add(header4);

            Chunk footer = new Chunk("Thank you anh see you again!!!!!!!!!!!!", FontFactory.GetFont("Times New Roman"));
            footer.Font.Size = 8;
            Paragraph parfooter = new Paragraph();
            footer.Font.SetStyle(Font.ITALIC);
            parfooter.Alignment = Element.ALIGN_CENTER;
            parfooter.Add(footer);

            Chunk khoangtrang = new Chunk("   ");
            khoangtrang.Font.Size = 8;
            Paragraph doantrang = new Paragraph();
            doantrang.Add(khoangtrang);

            LineSeparator line = new LineSeparator(0.5f, 100f, BaseColor.BLUE, Element.ALIGN_CENTER, 0.5f);
            //////////////////////////////////////////////////
            PdfPTable table1 = new PdfPTable(2);

            Font font = new Font();
            font.Size = 8;
            PdfPCell a1 = new PdfPCell(new Phrase("Times: " + DateTime.Now.ToShortDateString(), font));
            PdfPCell a2 = new PdfPCell(new Phrase("ID Ticket: " + id, font));
            PdfPCell a3 = new PdfPCell(new Phrase("Staff: " + tennv, font));
            PdfPCell a4 = new PdfPCell(new Phrase("ID Staff: " + idnv, font));

            a1.BorderWidth = 0;
            a2.BorderWidth = 0;
            a3.BorderWidth = 0;
            a4.BorderWidth = 0;

            table1.AddCell(a1);
            table1.AddCell(a2);
            table1.AddCell(a3);
            table1.AddCell(a4);
            table1.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
            /////////////////////////////////////////////////////////////
            PdfPTable table2 = new PdfPTable(2);

            PdfPCell b1 = new PdfPCell(new Phrase("Customer: " + hoten, font));
            PdfPCell b2 = new PdfPCell(new Phrase("Phone number: " + sdt, font));
            PdfPCell b3 = new PdfPCell(new Phrase("Add: " + add, font));
            PdfPCell b4 = new PdfPCell(new Phrase(" ", font));

            b1.BorderWidth = 0;
            b2.BorderWidth = 0;
            b3.BorderWidth = 0;
            b4.BorderWidth = 0;

            table2.AddCell(b1);
            table2.AddCell(b2);
            table2.AddCell(b3);
            table2.AddCell(b4);
            table2.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
            ///////////////////////////////////////////////////////////////////
            PdfPTable table3 = new PdfPTable(2);

            PdfPCell c1 = new PdfPCell(new Phrase("BKS: " + bks, font));
            PdfPCell c2 = new PdfPCell(new Phrase("Stuff: " + stuff, font));
            PdfPCell c3 = new PdfPCell(new Phrase("Date: " + date, font));
            PdfPCell c4 = new PdfPCell(new Phrase("Hour: " + hour, font));
            PdfPCell c5 = new PdfPCell(new Phrase("Destiantion: " + chuyen, font));
            PdfPCell c6 = new PdfPCell(new Phrase("", font));

            c1.BorderWidth = 0;
            c2.BorderWidth = 0;
            c3.BorderWidth = 0;
            c4.BorderWidth = 0;
            c5.BorderWidth = 0;
            c6.BorderWidth = 0;

            table3.AddCell(c1);
            table3.AddCell(c2);
            table3.AddCell(c3);
            table3.AddCell(c4);
            table3.AddCell(c5);
            table3.AddCell(c6);
            table3.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
            ///////////////////////////////////////////////////////

            Chunk footer1 = new Chunk("Total: " + total + "VND", FontFactory.GetFont("Times New Roman"));
            footer1.Font.Size = 8;
            Paragraph parfooter1 = new Paragraph();
            footer1.Font.SetStyle(Font.BOLD);
            parfooter1.Alignment = Element.ALIGN_RIGHT;
            parfooter1.Add(footer1);

            #endregion


            using (FileStream stream = new FileStream("D:\\"+id+"_hh.pdf", FileMode.Create))
            {
                Rectangle rectangle = new Rectangle(PageSize.A5);
                Document pdfDoc = new Document(rectangle);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                #region PAGE-1
                //pdfDoc.Add(pdfTable1);
                //pdfDoc.Add(pdfTable2);
                //pdfDoc.Add(pdfTableBlank);
                //pdfDoc.Add(jpg);
                //pdfDoc.Add(pdfTable3);
                //pdfDoc.Add(pdfTableFooter);
                //pdfDoc.NewPage();
                #endregion

                // pdfDoc.Add(jpg);

                //pdfDoc.Add(pdfTable2);

                pdfDoc.Add(parHead);
                pdfDoc.Add(parhead2);
                pdfDoc.Add(parhead3);
                pdfDoc.Add(parhead4);

                pdfDoc.AddAuthor("Luan dai ca");
                pdfDoc.AddTitle("Tickets");
                pdfDoc.AddKeywords("vexe");

                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(table1);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(table2);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(table3);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(parfooter1);
                pdfDoc.Add(doantrang);
                pdfDoc.Add(line);
                pdfDoc.Add(doantrang);

                pdfDoc.Add(parfooter);

                pdfDoc.Close();
                stream.Close();
            }


        
    }

        #endregion
        #region lay chuyen
        private string laychuyenra(int ts1)
        {
            var idtuyent = DataProvider.Ins.DB.CHUYENXEs.Where(x => x.IDCHUYEN == ts1);
            int? idtuyentha = idtuyent.First().IDTUYEN;
            var ben = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == idtuyentha);
            int? bendi = ben.First().BENDI;
            int? benden = ben.First().BENDEN;
            return layben(bendi).Replace(" ","") + " - " + layben(benden).Replace(" ", "");
        }
        private string layben(int? a)
        {
            var resule = DataProvider.Ins.DB.BENXEs.Where(x => x.IDBEN == a);
            return resule.First().TENBEN;
        }
        #endregion
    }
}
