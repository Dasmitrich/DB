using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface ItableBeh
    {
        DataTable editTable(string query);
        string deleteRow(string query);
        string updateRow(string tableName, string alterField, string keyField, string newField, string keyValue);
    }
}
