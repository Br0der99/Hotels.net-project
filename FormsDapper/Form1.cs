using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;

namespace WindowsFormsApp
{
    public partial class Form1 : Form                                               //Lav Catalog til HotelDB
    {
        SqlConnection con = new SqlConnection("Server = hildur.ucn.dk; Database=dmaa0220_1083750;User Id = dmaa0220_1083750; Password=Password1!;Trusted_Connection=False;");
    //    int empId = 0;
        int roomId = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)                              //Indsæt de rigtige værdier
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("EmpID", empId);
                //param.Add("@Name", txtRoomNumber.Text.Trim());                      
                //param.Add("@Mobile", txtRoomImage.Text.Trim());
                //param.Add("@Address", txtRoomPrice.Text.Trim());
                param.Add("RoomId", roomId);
                param.Add("@RoomNumber", txtRoomNumber.Text.Trim());
                param.Add("@RoomImage", txtRoomImage.Text.Trim());
                param.Add("@RoomPrice", txtRoomPrice.Text.Trim());
                param.Add("@BookingStatusId", txtBookingStatusId.Text.Trim());
                param.Add("@RoomTypeId", txtRoomTypeId.Text.Trim());
                param.Add("@RoomCapacity", txtRoomCapacity.Text.Trim());
                param.Add("@RoomDescription", txtRoomDescription.Text.Trim());
                param.Add("@IsActive", txtIsActive.Text.Trim());

                con.Execute("RoomAddOrEdit", param, commandType: CommandType.StoredProcedure);                   //Lav sql StoredProcedure så den passer til Rooms.
                if (roomId == 0)
                    MessageBox.Show("Saved Succesfully");
                else
                    MessageBox.Show("Updated Successfully");
                FillDataGridView();
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }

        }

        void FillDataGridView()                                                         //Lav sql StoredProcedure til Rooms.
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SearchText", txtSearch.Text.Trim());

            List<Rooms> list = con.Query<Rooms>("RoomViewOrSearch", param, commandType: CommandType.StoredProcedure).ToList<Rooms>();
            dgvEmployee.DataSource = list;
            dgvEmployee.Columns[0].Visible = false;


            //List<Employee> list = con.Query<Employee>("EmpViewOrSearch", param, commandType: CommandType.StoredProcedure).ToList<Employee>();
            //dgvEmployee.DataSource = list;
            //dgvEmployee.Columns[0].Visible = false;
        }

        class Rooms              //Indsæt Rooms værdier.
        {
            public int RoomId { get; set; }
            public string RoomNumber { get; set; }
            public string RoomImage { get; set; }
            public decimal RoomPrice { get; set; }
            public int BookingStatusId { get; set; }
            public int RoomTypeId { get; set; }
            public int RoomCapacity { get; set; }
            public string RoomDescription { get; set; }
            public bool IsActive { get; set; }



        }
        //class Employee              //Indsæt Rooms værdier.
        //{
        //    public int EmpID { get; set; }
        //    public string Name { get; set; }
        //    public string Mobile { get; set; }
        //    public string Address { get; set; }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        void Clear()                            //Indsæt alle værdierne
        {
            txtRoomNumber.Text = txtRoomImage.Text = txtRoomPrice.Text = txtBookingStatusId.Text = txtRoomTypeId.Text = txtRoomCapacity.Text = txtRoomDescription.Text = txtIsActive.Text = txtSearch.Text = "";
            roomId = 0;
            // empId = 0;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        private void dgvEmployee_DoubleClick(object sender, EventArgs e)
        {
            try
            {                                               // Sæt alle værdierne i databasen, så de vises i den row der double klikkes på.
                if(dgvEmployee.CurrentRow.Index != -1)
                { //value.ToString
                    roomId = Convert.ToInt32(dgvEmployee.CurrentRow.Cells[0].Value.ToString());
                    txtRoomNumber.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
                    txtRoomImage.Text = dgvEmployee.CurrentRow.Cells[2].Value.ToString();
                    txtRoomPrice.Text =  dgvEmployee.CurrentRow.Cells["RoomPrice"].Value.ToString();
                    txtBookingStatusId.Text = dgvEmployee.CurrentRow.Cells["BookingStatusId"].Value.ToString();
                    txtRoomTypeId.Text = dgvEmployee.CurrentRow.Cells["RoomTypeId"].Value.ToString();
                    txtRoomCapacity.Text = dgvEmployee.CurrentRow.Cells["RoomCapacity"].Value.ToString();
                    txtRoomDescription.Text = dgvEmployee.CurrentRow.Cells[7].Value.ToString();
                    txtIsActive.Text = dgvEmployee.CurrentRow.Cells["IsActive"].Value.ToString();
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure to delete this record?", "Message", MessageBoxButtons.YesNo) ==DialogResult.Yes)
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@RoomId", roomId);
                    con.Execute("RoomDeleteByID", param, commandType: CommandType.StoredProcedure);          //Lav Sql StoredProcedure til Rooms
                    Clear();
                    FillDataGridView();
                    MessageBox.Show("Deleted Successfully");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
