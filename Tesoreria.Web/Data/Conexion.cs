using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tesoreria.Web.Data
{
    public class Conexion
    {
        public static String rpt ;
        public static NpgsqlConnection obtenerConxion()
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            String servidor="127.0.0.1";
            String db="BDTesoreria";
            String puerto="5432";
            String usuario= "postgres";
            String clave= "12345";
            String cadena = 
                    "Server=" + servidor + 
                    ";Port=" + puerto + 
                    ";Database=" + db + 
                    ";UserId=" + usuario + 
                    ";Password=" + clave + ";";
            conexion.ConnectionString = cadena;
            try
            {
                rpt = "conecto";
                conexion.Open();
            }
            catch
            {
                rpt = "noConecto";
                conexion.Close();
            }
            
            return conexion;
        }
    }
    
}
