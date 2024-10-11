using LiveCharts.Wpf;
using LiveCharts;
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

namespace PriceMaster
{
    public partial class frmChaseEfficency : Form
    {
        public frmChaseEfficency(string fullName, DateTime startDate)
        {
            InitializeComponent();


            fillCombo();

            dteStart.Value = startDate;
            dteEnd.Value = startDate.AddDays(7);

            cmbStaff.Text = fullName;

            load_data();

        }

        private void fillCombo()
        {

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("select distinct sales_member FROM [order_database].dbo.view_sales_table_grouped",conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                        cmbStaff.Items.Add(row[0]);

                }    

                conn.Close();
            }
        }



        public DataTable runSQL(string sql, DataTable dt)
        {

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                conn.Close();
            }
            return dt;
        }



        private void load_data()
        {


            //get the ID from the combobox
            string sql = "SELECT id FROM [user_info].dbo.[user] WHERE forename + ' ' + surname = '" + cmbStaff.Text + "'";

            DataTable dt = new DataTable();
            dt = runSQL(sql, dt);

            int user_id = Convert.ToInt32(dt.Rows[0][0]);

            //old string
            //string sql_won = "SELECT quote_id as [Quote ID],[Status],[chase_date] as [Chased Date],[chase_description] as Chase," +
            //  "order_id as [Order ID],value as [Order Value],[Customer] " +
            //  "FROM (select chase.quote_id,main.status,chase.chased_by as last_chased_by,chase.chase_date,chase_description,s.customer " +
            //  "FROM [order_database].dbo.quotation_feed_back main " +
            //  "left join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log group by quote_id ) as max_id_chase on main.quote_id = max_id_chase.quote_id " +
            //  "left join [order_database].dbo.quotation_chase_log chase on max_id_chase.id = chase.id " +
            //  "left join [order_database].dbo.solidworks_quotation_log s on main.quote_id = s.quote_id " +
            //  "where chase.chased_by is not null and main.status = 'won' ) as chases " +
            //  "left join (select order_id,left(min(quote_number), charindex('-', min(quote_number))-1) as quote,sum(v.line_total) as value " +
            //  "FROM [order_database].dbo.door d " +
            //  "left join [order_database].dbo.view_door_value v on d.id = v.id " +
            //  "where quote_number like '%-%' AND quote_number NOT LIKE '%SL%' " +
            //  "group by order_id) as orders on chases.quote_id = orders.quote " +
            //  "WHERE order_id is not null and last_chased_by = " + user_id + " AND " +
            //  "[chase_date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND [chase_date] <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";

            string sql_won = "SELECT quote_id as [Quote ID],[Status],[chase_date] as [Chased Date],[chase_description] as Chase," +
                "order_id as [Order ID],ROUND(value,2) as [Order Value],[Customer],CAST(0 AS BIT) AS Slimline  " +
                "FROM (select chase.quote_id,main.status,chase.chased_by as last_chased_by,chase.chase_date,chase_description,s.customer, 0 as slimline " +
                "FROM [order_database].dbo.quotation_feed_back main " +
                "left join (SELECT * FROM [order_database].dbo.quotation_chase_log q " +
                "right join (select max(id) as id2 FROM [order_database].dbo.quotation_chase_log group by quote_id) as q2 on q.id = q2.id2) as chase on main.quote_id = chase.quote_id " +
                "left join (select sw.* FROM [order_database].dbo.solidworks_quotation_log sw " +
                "right join [order_database].dbo.view_solidworks_max_rev mr on sw.quote_id = mr.quote_id AND sw.revision_number = mr.revision_number) s on main.quote_id = s.quote_id " +
                "where chase.chased_by is not null and main.status = 'won' ) as chases " +
                "left join (select order_id,left(min(quote_number), charindex('-', min(quote_number))-1) as quote,sum(v.line_total) as value " +
                "FROM [order_database].dbo.door d " +
                "left join [order_database].dbo.view_door_value v on d.id = v.id " +
                "where quote_number like '%-%' AND quote_number NOT LIKE '%SL%' group by order_id) as orders on chases.quote_id = orders.quote " +
                "WHERE  order_id is not null and last_chased_by = " + user_id + " AND " +
                "[chase_date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND [chase_date] <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' " +
                "UNION ALL " +
                "SELECT main.quote_id as [Quote ID],[Status],[chase_date] as [Chased Date],[chase_description] as Chase," +
                "order_id as [Order ID],value as [Order Value],[Customer],CAST(1 AS BIT) AS Slimline " +
                "FROM [order_database].dbo.quotation_feed_back_slimline main " +
                "left join (SELECT * FROM [order_database].dbo.quotation_chase_log_slimline q " +
                "right join (select max(id) as id2 FROM [order_database].dbo.quotation_chase_log_slimline group by quote_id) as q2 on q.id = q2.id2) as chases on main.quote_id = chases.quote_id " +
                "left join (select order_id,CASE WHEN min(quote_number) LIKE '%i%' then REPLACE(SUBSTRING(min(quote_number),0, CHARINDEX('i',min(quote_number))),'SL','') " +
                "ELSE REPLACE(min(quote_number),'SL','') end as quote,sum(v.line_total) as value,min(s.NAME) as customer " +
                "FROM [order_database].dbo.door d " +
                "left join [order_database].dbo.view_door_value v on d.id = v.id " +
                "left join [order_database].dbo.[SALES_LEDGER] s on d.customer_acc_ref = s.ACCOUNT_REF " +
                "where quote_number like '%SL%' and date_order >= '20230101' group by order_id) as orders on chases.quote_id = orders.quote " +
                "where status = 'Won' and chased_by is not null  and order_id is not null and " +
                "chased_by = " + user_id + " AND " +
                "[chase_date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND [chase_date] <= '" + dteEnd.Value.ToString("yyyyMMdd") + "'";


            DataTable dt_won = new DataTable();
            dgvWon.DataSource = runSQL(sql_won, dt_won);

            //old string
            //string sql_lost = "SELECT quote_id as [Quote ID],[Status],chase_date as [Chase Date], chase_description as [Chase],[Customer] FROM " +
            //    "(select chase.quote_id,main.status,chase.chased_by as last_chased_by,chase.chase_date,chase_description,s.customer " +
            //    "FROM [order_database].dbo.quotation_feed_back main " +
            //    "left join (select max(id) as id,quote_id FROM [order_database].dbo.quotation_chase_log group by quote_id ) as max_id_chase on main.quote_id = max_id_chase.quote_id " +
            //    "left join [order_database].dbo.quotation_chase_log chase on max_id_chase.id = chase.id " +
            //    "left join [order_database].dbo.solidworks_quotation_log s on main.quote_id = s.quote_id " +
            //    "where chase.chased_by is not null and main.status = 'Lost' ) as chases " +
            //  "WHERE last_chased_by = " + user_id + " AND " +
            //"[chase_date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND [chase_date] <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";

            string sql_lost = "select chase.quote_id as [Quote ID],main.status as [Status],chase.chase_date as [Chase Date],chase_description as [Chase],s.Customer,CAST(0 AS BIT)  AS Slimline  " +
                "FROM [order_database].dbo.quotation_feed_back main " +
                "left join (SELECT * FROM [order_database].dbo.quotation_chase_log q " +
                "right join (select max(id) as id2 FROM [order_database].dbo.quotation_chase_log " +
                "group by quote_id) as q2 on q.id = q2.id2) as chase on main.quote_id = chase.quote_id " +
                "left join (select sw.* FROM [order_database].dbo.solidworks_quotation_log sw " +
                "right join [order_database].dbo.view_solidworks_max_rev mr on sw.quote_id = mr.quote_id AND " +
                "sw.revision_number = mr.revision_number) s on main.quote_id = s.quote_id " +
                "where chase.chased_by is not null and main.status = 'Lost' " +
                "and chased_by = " + user_id + " AND " +
                "[chase_date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND [chase_date] <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' " +
                "UNION ALL " +
                "select chase.quote_id as [Quote ID],main.status as [Status],chase.chase_date as [Chase Date],chase_description as [Chase],sl.Customer,CAST(1 AS BIT)  AS Slimline  " +
                "FROM [order_database].dbo.quotation_feed_back_slimline main " +
                "left join (SELECT * FROM [order_database].dbo.quotation_chase_log_slimline q " +
                "right join (select max(id) as id2 FROM [order_database].dbo.quotation_chase_log_slimline " +
                "group by quote_id) as q2 on q.id = q2.id2) as chase on main.quote_id = chase.quote_id " +
                "left join (select quote_id,NAME as customer fROM [price_master].dbo.[sl_quotation] sl " +
                "left join [dsl_fitting].dbo.SALES_LEDGER s on sl.customer_acc_ref = s.ACCOUNT_REF " +
                "where highest_issue = -1) as sl on main.quote_id = sl.quote_id " +
                "where chase.chased_by is not null and main.status = 'Lost'  " +
                "and chased_by = " + user_id + " AND " +
                "[chase_date] >= '" + dteStart.Value.ToString("yyyyMMdd") + "' AND [chase_date] <= '" + dteEnd.Value.ToString("yyyyMMdd") + "' ";


            DataTable dt_lost = new DataTable();
            dgvLost.DataSource = runSQL(sql_lost, dt_lost);




            //win / lose as piechart

            List<string> sectorList = new List<string>();
            List<int> achievedlist = new List<int>();

            //string[] datearray = datelist.ToArray();
            string[] sectorArray = sectorList.ToArray();
            int[] achievedArray = achievedlist.ToArray();



            //Values = new ChartValues<int>(itemarray)



            var seriesCollection = new SeriesCollection();


            Func<ChartPoint, string> labelPoint = chartPoint =>
              string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation); //this is for a percentage


            PieSeries ps = new PieSeries
            {
                Title = "Chases Won",
                Values = new ChartValues<double> { dgvWon.Rows.Count },
                DataLabels = true,
                // LabelPoint = labelPoint,
                Foreground = System.Windows.Media.Brushes.Black,
                PushOut = 15,

            };

            // add this slice to the others

            seriesCollection.Add(ps);


            PieSeries ps2 = new PieSeries
            {
                Title = "Lost",
                Values = new ChartValues<double> { dgvLost.Rows.Count },
                DataLabels = true,
                Foreground = System.Windows.Media.Brushes.Black,
                Fill = System.Windows.Media.Brushes.PaleVioletRed,

            };
            // Add the target to the SeriesCollection
            seriesCollection.Add(ps2);
           

            pieChart1.Series = seriesCollection;

            pieChart1.LegendLocation = LegendLocation.Bottom;


            format_grids();

        }


        private void format_grids()
        {


            //won dgv
            foreach (DataGridViewColumn col in dgvWon.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvWon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvWon.Columns[5].DefaultCellStyle.Format = "c";


            //Lost dgv
            foreach (DataGridViewColumn col in dgvLost.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvLost.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }


        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        private void dteStart_CloseUp(object sender, EventArgs e)
        {
            load_data();
        }

        private void dteEnd_CloseUp(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
