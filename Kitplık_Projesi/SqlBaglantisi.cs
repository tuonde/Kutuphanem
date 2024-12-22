using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Kitplık_Projesi
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection bgl = new SqlConnection("Data Source=TUNAHAN;Initial Catalog=Kitaplik;Integrated Security=True;");
            bgl.Open();
            return bgl;
        }
    }
}
