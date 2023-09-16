using KpopZtation.Dataset;
using KpopZtation.Handler;
using KpopZtation.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = getData(PurchaseHandler.getTransaction());
            report.SetDataSource(data);
        }
        private static DataSet1 getData(List<TransactionHeader> transaction)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (TransactionHeader t in transaction)
            {
                var headerRow = headerTable.NewRow();
                headerRow["TransactionID"] = t.TransactionID;
                headerRow["TransactionDate"] = t.TransactionDate;
                headerRow["CustomerID"] = t.CustomerID;
                headerRow["GrandTotalValue"] = "5000000";
                headerTable.Rows.Add(headerRow);

                foreach (TransactionDetail td in t.TransactionDetails)
                {
                    var detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = td.TransactionID;
                    detailRow["AlbumID"] = td.Album.AlbumName;
                    detailRow["Qty"] = td.Qty;
                    detailRow["AlbumPrice"] = td.Album.AlbumPrice;
                    detailRow["SubTotalValue"] = td.Qty * td.Album.AlbumPrice;
                    detailTable.Rows.Add(detailRow);
                }
            }

            return data;
        }
    }
}