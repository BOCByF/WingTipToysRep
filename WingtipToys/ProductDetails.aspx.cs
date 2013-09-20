using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProduct([QueryString("productID")]int? productId)
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Product> myQueryable = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                myQueryable = myQueryable.Where(p => p.ProductID == productId);
            }
            else
            {
                myQueryable = null;
            }
            return myQueryable;
        }
    }
}