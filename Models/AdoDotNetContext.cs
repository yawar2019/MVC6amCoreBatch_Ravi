using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace MVC6amCoreBatch_Ravi.Models
{
    public class AdoDotNetContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");   
        public  List<EmployeeModel> GetEmployees()
        {
           
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("sp_Employee",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                emp.EmpName = Convert.ToString(dr["EmpName"]);
                emp.EmpSalary = Convert.ToInt32(dr["EmpSalary"]);
                listEmp.Add(emp);
            }
            return listEmp; 
        }
        public  List<EmployeeModel> GetEmployeesUsingDapper()
        { 
            List<EmployeeModel> listEmp = con.Query<EmployeeModel>("sp_Employee",con).ToList(); 
            return listEmp; 
        }
    }
}
