using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sweetandcoffee.Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace com.sweetandcoffee.AccesoDatos
{
    public class LotesDal
    {
        public List<ELote> GetAll()
        {
            string Bodega = ConfigurationManager.AppSettings["Bodega"];
            List<ELote> lotes = new List<ELote>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connSweet"].ToString()))
            {
                conn.Open();
                string sql = "SELECT " +
                                "A.CODARTICULO AS CODIGO," +
                                "B.lote_articulodescripcion AS DESCRIPCION," +
                                "A.STOCK AS STOCK_FRONTS," +
                                "SUM(B.lote_cantidadfinal) AS STOCK_LOTES," +
                                "convert(decimal(10, 4), (A.STOCK - SUM(B.lote_cantidadfinal))) AS DIFERENCIA " +
                                "FROM [dbo].[STOCKS] A " +
                                "INNER JOIN [DBLOTES2.0].dbo.tblLote B " +
                                "ON A.CODARTICULO = B.lote_codarticulo " +
                                "AND A.CODALMACEN = '" + Bodega.ToString() + "'" +
                                " INNER JOIN [dbo].[ARTICULOS] C " +
                                "ON C.CODARTICULO = B.lote_codarticulo " +
                                "AND B.lote_articulodescripcion COLLATE Latin1_General_CS_AI = C.DESCRIPCION " +
                                "GROUP BY A.CODARTICULO, B.lote_articulodescripcion, A.STOCK " +
                                "HAVING a.STOCK <> SUM(B.lote_cantidadfinal) ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        ELote lote = new ELote
                                            {
                                                Codigo = Convert.ToInt32(data["CODIGO"]),
                                                Descripcion = Convert.ToString(data["DESCRIPCION"]),
                                                StockFront = Convert.ToDecimal(data["STOCK_FRONTS"]),
                                                StockLotes = Convert.ToDecimal(data["STOCK_LOTES"]),
                                                Diferencia = Convert.ToDecimal(data["DIFERENCIA"])
                        };
                        lotes.Add(lote);
                    }
                }
            }
            return lotes;
        }
    }
}
