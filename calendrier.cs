using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraScheduler;

namespace RibbonSimplePad
{
    public partial class calendrier : DevExpress.XtraEditors.XtraForm
    {
        public calendrier()
        {
            InitializeComponent();
        }
        public static int id = 0;
        public static int id2, id3, refreshhh;
        public static int load = 0;
        sql_gmao fun = new sql_gmao();
        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {

            Appointment currentAppointment;
            if (this.schedulerControl1.SelectedAppointments.Count == 1)
            {
                currentAppointment = schedulerControl1.SelectedAppointments[0];
                if (currentAppointment.IsOccurrence && !currentAppointment.IsException)
                {
                    id2 = Convert.ToInt32(currentAppointment.RecurrencePattern.GetValue(schedulerControl1.Storage, "UniqueID"));
                }
                else
                {

                    id2 = Convert.ToInt32(currentAppointment.GetValue(schedulerControl1.Storage, "UniqueID"));
                }
            }




           



        }
        DataSet DXSchedulerDataset;
        SqlDataAdapter AppointmentDataAdapter;
        SqlDataAdapter ResourceDataAdapter;
        private void act()
        {

            this.schedulerStorage1.Appointments.Clear();

            //recharger les données de base de données 
            this.schedulerStorage1.Appointments.ResourceSharing = true;
            this.schedulerControl1.GroupType = SchedulerGroupType.Resource;
            this.schedulerControl1.Start = DateTime.Today;
            DXSchedulerDataset = new DataSet();
           
            string selectAppointments = "SELECT * FROM Appointments where userr='"+login1.pseudo+"'";
          
            if (sql_gmao.conn.State.ToString().Equals("Closed"))
            {
                sql_gmao.conn.Open();
            }
            AppointmentDataAdapter = new SqlDataAdapter(selectAppointments, sql_gmao.conn);
            AppointmentDataAdapter.RowUpdated += new SqlRowUpdatedEventHandler(AppointmentDataAdapter_RowUpdated);
            AppointmentDataAdapter.Fill(DXSchedulerDataset, "Appointments");
         
           
            MapAppointmentData();
            MapResourceData();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(AppointmentDataAdapter);
            AppointmentDataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
            AppointmentDataAdapter.DeleteCommand = cmdBuilder.GetDeleteCommand();
            AppointmentDataAdapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
            if (sql_gmao.conn.State.ToString().Equals("Open"))
            {
                sql_gmao.conn.Close();
            }
            this.schedulerStorage1.Appointments.DataSource = DXSchedulerDataset;
            this.schedulerStorage1.Appointments.DataMember = "Appointments";
            
         
        }
        private void MapAppointmentData()
        {
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "Type";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIDs";
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("MyNote", "CustomField1"));
        }
        private void MapResourceData()
        {
            this.schedulerStorage1.Resources.Mappings.Id = "UniqueID";
            this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
        }
        void AppointmentDataAdapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            //recuperer l'id le plus grand 
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('Appointments')", sql_gmao.conn))
                {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                e.Row["UniqueID"] = id;
            }
        }
        private void calendrier_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.schedulerStorage1.Appointments.AutoReload = true;
            ChangeDefulatLabelsCaptions(schedulerControl1.Storage);
            ChangeDefulatStatusesCaptions(schedulerControl1.Storage);
            schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = HeaderImageSizeMode.ZoomImage;
            schedulerControl1.OptionsView.ResourceHeaders.ImageSize = new Size(50, 50);
        }
        void ChangeDefulatLabelsCaptions(SchedulerStorage someStorage)
        {
            for (int i = 0; i < someStorage.Appointments.Labels.Count; i++)
            {
                AppointmentLabel currentLabel = someStorage.Appointments.Labels[i];
                int ii = i + 1;
                currentLabel.DisplayName = "Couleur" + ii;
                currentLabel.MenuCaption = currentLabel.DisplayName;
            }
        }
        void ChangeDefulatStatusesCaptions(SchedulerStorage someStorage)
        {
            for (int i = 0; i < someStorage.Appointments.Statuses.Count; i++)
            {
                AppointmentStatus currentStatus = someStorage.Appointments.Statuses[i];
                int ii = i + 1;
                currentStatus.DisplayName = "Couleur" + ii;
                currentStatus.MenuCaption = currentStatus.DisplayName;
            }
        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {
            Appointment currentAppointment;
            if (this.schedulerControl1.SelectedAppointments.Count == 1)
            {
                currentAppointment = schedulerControl1.SelectedAppointments[0];
                if (currentAppointment.IsOccurrence && !currentAppointment.IsException)
                {
                    id3 = Convert.ToInt32(currentAppointment.RecurrencePattern.GetValue(schedulerControl1.Storage, "UniqueID"));
                }
                else
                {
                    id3 = Convert.ToInt32(currentAppointment.GetValue(schedulerControl1.Storage, "UniqueID"));
                }
            }
        }

        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
            if (item != null) item.Caption = "Nouveau Abonnement";
            SchedulerMenuItem item4 = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringAppointment);
            if (item != null) item4.Visible = false;
            SchedulerMenuItem item2 = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent);
            if (item != null) item2.Visible = false;
            SchedulerMenuItem item3 = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringEvent);
            if (item != null) item3.Visible = false;
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
            DXSchedulerDataset.AcceptChanges();
            id2 = 0;
        }

        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
            DXSchedulerDataset.AcceptChanges();
            id2 = 0;
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
            DXSchedulerDataset.AcceptChanges();
            id2 = 0;
        }

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
            DXSchedulerDataset.AcceptChanges();
            id2 = 0;
        }

        private void calendrier_Activated(object sender, EventArgs e)
        {

           

        }

        private void calendrier_FormClosing(object sender, FormClosingEventArgs e)
        {

          
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            schedulerStorage1.RefreshData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.schedulerStorage1.Appointments.Clear();

            act();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void schedulerControl1_EditAppointmentFormShowing_1(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            RibbonSimplePad.AppointmentFormOutlook2007Style form = new RibbonSimplePad.AppointmentFormOutlook2007Style(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void calendrier_Activated_1(object sender, EventArgs e)
        {
            schedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowAppointmentDragBetweenResources = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowAppointmentMultiSelect = true;
            schedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.All;
            printBar1.Visible = true;

            this.schedulerStorage1.Appointments.DataSource = null;
            this.schedulerStorage1.Resources.DataSource = null;

            act();
            Form1.wait = 1;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text += "a";
            if (label1.Text.ToString() == "10aaa")
            {



                label1.Text = "10";
                if (refreshhh == 1)
                {
                    this.schedulerStorage1.Appointments.Clear();
                    act();
                    refreshhh = 0;
                }

            }
        }

        private void calendrier_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void schedulerStorage1_AppointmentsChanged_1(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
                DXSchedulerDataset.AcceptChanges();
                id2 = 0;
            }catch(Exception ec)
            { }
           
        }

        private void schedulerControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void schedulerStorage1_AppointmentsDeleted_1(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
                DXSchedulerDataset.AcceptChanges();
                id2 = 0;
            }
            catch(Exception)
            { }
          
        }

        private void schedulerStorage1_AppointmentsInserted_1(object sender, PersistentObjectsEventArgs e)
        {
            AppointmentDataAdapter.Update(DXSchedulerDataset.Tables["Appointments"]);
            DXSchedulerDataset.AcceptChanges();
            id2 = 0;

           
            DataTable dd = new DataTable();
            dd = fun.getmax_id();
            int a = Convert.ToInt32(dd.Rows[0][0]);
            fun.update_app_user(login1.pseudo,a);

        }

    }
}