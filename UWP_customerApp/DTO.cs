using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_customerApp
{
    public class clsGenre
    {
        public string GenreName { get; set; }
        public string Description { get; set; }
        public List<clsAllGames> GamesList { get; set; }

        //public List<clsOrders> OrdersList { get; set; }
    }

    public class clsAllGames
    {
        public int Code { get; set; }
        public string GameName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime LastModified { get; set; }
        public int QtyAvail { get; set; }
        public string Description { get; set; }
        public char Type { get; set; }
        public DateTime? WarrantyExpiry { get; set; }
        public string GameCondition { get; set; }
        public int? Age { get; set; }
        public string GenreGenreName { get; set; }

        public override string ToString()
        {
            return GameName + "\t" + "$" + UnitPrice.ToString() + "\t" + Type + "\t" + QtyAvail.ToString();
        }

        public static readonly string FACTORY_PROMPT = "Enter U for Used or N for New";

        public static clsAllGames NewGame(char prChoice)  //FACTORY METHOD!!
        {
            return new clsAllGames() { Type = Char.ToUpper(prChoice) };
        }
    }

    public class clsOrders
    {
        public int OrderNo { get; set; }
        public int QtyOrdered { get; set; }
        public decimal PricePerItem { get; set; }
        public DateTime DateOrdered { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public decimal TotalOrderValue { get { return PricePerItem * QtyOrdered; } }
        public int GameCode { get; set; }

        //public override string ToString()
        //{
        //    return
        //        OrderNo + "\t" +
        //        DateOrdered.ToShortDateString() + "\t" +
        //        GameCode + "\t" +
        //        TotalOrderValue.ToString();
        //}

    }
}
