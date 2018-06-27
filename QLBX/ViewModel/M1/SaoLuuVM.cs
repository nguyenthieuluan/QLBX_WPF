
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class SaoLuuVM:BaseViewModel
    {
        public ICommand BackupCommand { get; set; }
        public ICommand RestoreCommand { get; set; }

        public ICommand BrowserCommand { get; set; }
        public ICommand BrowserCommand2 { get; set; }

        private string backupFilePath;
        public string BackupFilePath { get => backupFilePath; set { backupFilePath = value; OnPropertyChanged(); } }
        private string restoreFilePath;
        public string RestoreFilePath { get => restoreFilePath; set { restoreFilePath = value; OnPropertyChanged(); } }

        public SaoLuuVM()
        {
            BackupFilePath = "D:\\QLBX.bak";
            RestoreFilePath = "";

            string s = System.Configuration.ConfigurationManager.ConnectionStrings["QLBXEntities"].ConnectionString;
            string ConnectionString = new EntityConnectionStringBuilder(s).ProviderConnectionString;

            System.Data.Common.DbConnectionStringBuilder builder = new System.Data.Common.DbConnectionStringBuilder();
            builder.ConnectionString = ConnectionString;

            string database = builder["Initial Catalog"] as string;

            //MessageBox.Show(database);

            // create Backup Command
            BackupCommand = new RelayCommand<object>((q) => { return true; }, (q) => {
                try
                {
                    CreateBackup(ConnectionString, database, BackupFilePath);
                    MessageBox.Show("Sao lưu thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thành công");
                }
            });
            // create Restore Command
            RestoreCommand = new RelayCommand<object>((q) => { return true; }, (q) => {
                //CreateRestore(ConnectionString, database, RestoreFilePath);
                try
                {
                    CreateRestore(ConnectionString, database, RestoreFilePath);
                    MessageBox.Show("Thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất bại");
                }
            });


            //get backupFilePath Command
            BrowserCommand = new RelayCommand<object>((q) => { return true; }, (q) => {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                var name = "\\QLBX(" + DateTime.Now.ToShortDateString().Replace("/","-")+").bak";
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Chọn đường dẫn!";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string temp = fbd.SelectedPath.ToString();
                    BackupFilePath = temp.Replace(@"\\",@"\").Remove(2,1) + name;
                }
            });
            BrowserCommand2 = new RelayCommand<object>((q) => { return true; }, (q) => {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                OpenFileDialog fbd = new OpenFileDialog();
                fbd.Filter = "Backup Files|*.bak|All files (*.*)|*.*";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string temp = fbd.FileName;
                    RestoreFilePath = temp;
                }
            });
        }


        #region Funtion
        //Backup Function
        private static void CreateBackup(string connectionString, string databaseName, string backupFilePath)
        {
            string backupCommand = "BACKUP DATABASE @databaseName TO DISK = @backupFilePath WITH INIT";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(backupCommand, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@databaseName", databaseName);
                cmd.Parameters.AddWithValue("@backupFilePath", backupFilePath);
                cmd.ExecuteNonQuery();
            }
        }

        //Restore Function
        private static void CreateRestore(string connectionString, string databaseName, string restoreFilePath)
        {
            string backupCommand = "USE [master] ALTER DATABASE [@databaseName] SET SINGLE_USER with rollback immediate RESTORE DATABASE [@databaseName] FROM DISK = @restoreFilePath WITH REPLACE";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(backupCommand, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@databaseName", databaseName);
                cmd.Parameters.AddWithValue("@restoreFilePath", restoreFilePath);
                cmd.ExecuteNonQuery();
            }
        }


        #endregion
    }
}
