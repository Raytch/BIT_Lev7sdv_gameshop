using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSelfHost
{
    public class ShopController : System.Web.Http.ApiController
    {
        private List<string> _GenreNames;

        public List<string> GetGenreNames()  //called when Genre-select runs/loads
        {
            DataTable lcResult = 
                clsDbConnection.GetDataTable("SELECT GenreName FROM Genre", null);
            _GenreNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                _GenreNames.Add((string)dr[0]);
            return _GenreNames;
        }

        public List<clsOrders> GetOrders()
        {
            //Dictionary<string, object> par = new Dictionary<string, object>(1);
            //par.Add("GenreName", GenreName);

            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT * FROM gameOrder", null);
            List<clsOrders> lcOrders = new List<clsOrders>();

            foreach (DataRow dr in lcResult.Rows)
                lcOrders.Add(dataRow2Orders(dr));
            return lcOrders;

        }

        public clsGenre GetGenre(string GenreName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("GenreName", GenreName);
            DataTable lcResult = clsDbConnection.GetDataTable(
                    "Select * FROM Genre WHERE GenreName = @GenreName", par);
            if (lcResult.Rows.Count > 0)
                return new clsGenre()
                {
                    GenreName = (string)lcResult.Rows[0]["GenreName"],
                    Description = (string)lcResult.Rows[0]["Description"],
                    GamesList = GetGenreGames(GenreName) //CACHE LOAD OR NON-LAZY LOADING
                };
            else
                return null;
        }

        public clsAllGames GetGame(string Code)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Code", Code);
            DataTable lcResult = clsDbConnection.GetDataTable(
                    "Select GameName, UnitPrice, Description FROM Game WHERE Code = @Code", par);
            if (lcResult.Rows.Count > 0)
                return new clsAllGames()
                {
                    //Code = (int)lcResult.Rows[0]["Code"],
                    GameName = (string)lcResult.Rows[0]["GameName"],
                    UnitPrice = (decimal)lcResult.Rows[0]["UnitPrice"],
                    //LastModified = (DateTime)lcResult.Rows[0]["LastModified"],
                    //QtyAvail = (int)lcResult.Rows[0]["QtyAvail"],
                    Description = (string)lcResult.Rows[0]["Description"]
                    //Type = (char)lcResult.Rows[0]["Type"],
                    //WarrantyExpiry = (DateTime?)lcResult.Rows[0]["WarrantyExpiry"],
                    //GameCondition = (string)lcResult.Rows[0]["GameCondition"],
                    // Age = (int?)lcResult.Rows[0]["Age"],
                    //Age = DBNull.Value.Equals(lcResult.Rows[0]["Age"]) ? null : (int?)lcResult.Rows[0]["Age"],
                    //GenreGenreName = (string)lcResult.Rows[0]["GenreGenreName"]
                };
            else
                return null;
        }

        public List<clsAllGames> GetGenreGames(string GenreGenreName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("GenreGenreName", GenreGenreName);
            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT * FROM Game WHERE GenreGenreName = @GenreGenreName", par);
            List<clsAllGames> lcWorks = new List<clsAllGames>();
            foreach (DataRow dr in lcResult.Rows)
                lcWorks.Add(dataRow2AllWork(dr));
            return lcWorks;
        }

        private clsAllGames dataRow2AllWork(DataRow prDataRow)
        {
            return new clsAllGames()
            {
                Code = Convert.ToInt32(prDataRow["Code"]),
                GameName = Convert.ToString(prDataRow["GameName"]),
                UnitPrice = Convert.ToDecimal(prDataRow["UnitPrice"]),
                LastModified = Convert.ToDateTime(prDataRow["LastModified"]),
                QtyAvail = Convert.ToInt32(prDataRow["QtyAvail"]),
                Description = Convert.ToString(prDataRow["Description"]),
                Type = Convert.ToChar(prDataRow["Type"]),
                WarrantyExpiry = prDataRow["WarrantyExpiry"] is DBNull ? (DateTime?)null : Convert.ToDateTime(prDataRow["WarrantyExpiry"]),
                GameCondition = Convert.ToString(prDataRow["GameCondition"]),
                Age = prDataRow["Age"] is DBNull ? (int?)null : Convert.ToInt16(prDataRow["Age"]),
                GenreGenreName = Convert.ToString(prDataRow["GenreGenreName"])
            };
        }

        private clsOrders dataRow2Orders(DataRow prDataRow)
        {
            return new clsOrders()
            {
                OrderNo = Convert.ToInt32(prDataRow["OrderNo"]),
                QtyOrdered = Convert.ToInt32(prDataRow["QtyOrdered"]),
                PricePerItem = Convert.ToDecimal(prDataRow["PricePerItem"]),
                DateOrdered = Convert.ToDateTime(prDataRow["DateOrdered"]),
                CustName = Convert.ToString(prDataRow["CustName"]),
                CustPhone = Convert.ToString(prDataRow["CustPhone"]),
                //TotalOrderValue = Convert.ToDecimal(prDataRow["TotalOrderValue"]),
                GameCode = Convert.ToInt32(prDataRow["GameCode"])
            };
        }

        public string PostGame(clsAllGames prGame)
        { //INSERT
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "INSERT INTO Game " +
                    "(GameName, UnitPrice, LastModified, QtyAvail, Description, Type, WarrantyExpiry, GameCondition, Age, GenreGenreName) " +
                    "VALUES (@GameName, @UnitPrice, @LastModified, @QtyAvail, @Description, @Type, @WarrantyExpiry, @GameCondition, @Age, @GenreGenreName)",
                    PrepareGameParameters(prGame));
                if (lcRecCount == 1)
                    return "One Game inserted";
                else
                    return "Unexpected game insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutGame(clsAllGames prGame)
        {   // UPDATE
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "UPDATE Game SET UnitPrice = @UnitPrice, LastModified = @LastModified, " +
                    "QtyAvail = @QtyAvail, Description = @Description, Type = @Type, " +
                    "WarrantyExpiry = @WarrantyExpiry, GameCondition = @GameCondition, Age = @Age " +
                    "WHERE GameName = @GameName AND GenreGenreName = @GenreGenreName", 
                    PrepareGameParameters(prGame));
                if (lcRecCount == 1)
                    return "One Game updated";
                else
                    return "Unexpected game update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteGame(int GameID)
        {
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("GameID", GameID);
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM Game WHERE Code = @GameID", par);
                if (lcRecCount == 1)
                    return "One Game Deleted";
                else
                    return "Unexpected Game delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteOrder(int OrderNo)
        {
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("OrderNo", OrderNo);
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM gameOrder WHERE OrderNo = @OrderNo", par);
                if (lcRecCount == 1)
                    return "One Order Deleted";
                else
                    return "Unexpected gameOrder delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> PrepareGameParameters(clsAllGames prGame)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("GameName", prGame.GameName);
            par.Add("UnitPrice", prGame.UnitPrice);
            par.Add("LastModified", prGame.LastModified);
            par.Add("QtyAvail", prGame.QtyAvail);
            par.Add("Description", prGame.Description);
            par.Add("Type", prGame.Type);
            par.Add("WarrantyExpiry", prGame.WarrantyExpiry);
            par.Add("GameCondition", prGame.GameCondition);
            par.Add("Age", prGame.Age);
            par.Add("GenreGenreName", prGame.GenreGenreName);
            return par;
        }

        private Dictionary<string, object> PrepareOrderParameters(clsOrders prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(6);
            par.Add("OrderNo", prOrder.OrderNo);
            par.Add("QtyOrdered", prOrder.QtyOrdered);
            par.Add("PricePerItem", prOrder.PricePerItem);
            par.Add("DateOrdered", prOrder.DateOrdered);
            par.Add("CustName", prOrder.CustName);
            par.Add("CustPhone", prOrder.CustPhone);
            par.Add("TotalOrderValue", prOrder.TotalOrderValue);
            return par;
        }
    }
}
