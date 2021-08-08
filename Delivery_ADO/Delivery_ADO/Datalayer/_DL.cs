using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Delivery_ADO.Models;
using Delivery_ADO.Enums;


namespace Delivery_ADO.Datalayer
{
   public static class _DL
    {
        public static class Order
        {
            public static string ConnectionString { get; private set; } = ConfigurationManager.ConnectionStrings["DeliveryDB"].ConnectionString;
            public static void AllByStatus(OrderStatuses orderStatus)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand getEmployeeByPosition = new SqlCommand("stp_OrderByStatusID", conn);

                    getEmployeeByPosition.CommandType = CommandType.StoredProcedure;
                    getEmployeeByPosition.Parameters.AddWithValue("@StatusID", orderStatus);

                    SqlDataReader reader = getEmployeeByPosition.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = (int)reader[0];
                        string AddressTo = reader[1].ToString();
                        string DescriptionOfCargo = reader[2].ToString();
                        DateTime OrderDate = DateTime.Parse(reader[3].ToString());
                        double Price = (double)reader[4];
                        int CourierID = (int)reader[5];
                        int StatusID = (int)reader[6];                       

                       OrdersModel order = new OrdersModel(ID, AddressTo, DescriptionOfCargo, OrderDate, Price, CourierID, StatusID);
                        Console.WriteLine($"ID : {order.OrderID},Address to: {order.AddressTo},DescriptionOfCargo : {order.DescriptionOfCargo}, Order Date : {order.OrderDate}, Price : {order.Price},CourierID : {order.CourierID},StatusID : {order.StatusID}");
                    }
                    reader.Close();

                }
            }
            public static List<OrdersModel> AllByStatusList(OrderStatuses orderStatus)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand getEmployeeByPosition = new SqlCommand("stp_OrderByStatusID", conn);

                    getEmployeeByPosition.CommandType = CommandType.StoredProcedure;
                    getEmployeeByPosition.Parameters.AddWithValue("@StatusID", orderStatus);

                    SqlDataReader reader = getEmployeeByPosition.ExecuteReader();
                    List<OrdersModel> OrdersListByStatus = new List<OrdersModel>();
                    while (reader.Read())
                    {
                        int ID = (int)reader[0];
                        string AddressTo = reader[1].ToString();
                        string DescriptionOfCargo = reader[2].ToString();
                        DateTime OrderDate = DateTime.Parse(reader[3].ToString());
                        double Price = (double)reader[4];
                        int CourierID = (int)reader[5];
                        int StatusID = (int)reader[6];
                        OrdersModel order = new OrdersModel(ID, AddressTo, DescriptionOfCargo, OrderDate, Price, CourierID, StatusID);
                        OrdersListByStatus.Add(order);
                        Console.WriteLine($"ID : {order.OrderID},Address to: {order.AddressTo},DescriptionOfCargo : {order.DescriptionOfCargo}, Order Date : {order.OrderDate}, Price : {order.Price},CourierID : {order.CourierID},StatusID : {order.StatusID}");
                    }
                    reader.Close();
                    return OrdersListByStatus;
                }
            }

            public static int InsertOrder(OrdersModel newOrder)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand insertOrder = new SqlCommand("stp_OrderInsert", conn);
                    insertOrder.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(insertOrder);
                    insertOrder.Parameters[1].Value = newOrder.AddressTo;
                    insertOrder.Parameters[2].Value = newOrder.DescriptionOfCargo;
                    insertOrder.Parameters[3].Value = newOrder.OrderDate;
                    insertOrder.Parameters[4].Value = newOrder.Price;
                    insertOrder.Parameters[5].Value = newOrder.CourierID;
                    insertOrder.Parameters[6].Value = newOrder.StatusID;             
                    insertOrder.Parameters[7].Value = DBNull.Value;
                    insertOrder.ExecuteNonQuery();
                    int newOrderID = (int)insertOrder.Parameters[7].Value;

                    return newOrderID;
                }
            }




        }

    }
}
