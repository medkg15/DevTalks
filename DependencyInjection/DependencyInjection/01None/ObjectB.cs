using System.Data.SqlClient;

namespace DependencyInjection._1None
{
    public class ObjectB : InterfaceB
    {
        public void DoStuff()
        {
            var connection = new SqlConnection();
        }
    }
}
