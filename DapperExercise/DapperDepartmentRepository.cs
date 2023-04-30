using System;
using System.Data;
using Dapper;

namespace DapperExercise
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{
		private readonly IDbConnection _connection;

		//Constructor
		public DapperDepartmentRepository(IDbConnection connection)
		{
			_connection = connection;
		}

        public IEnumerable<Department> GetAllDepartments()
        {
			return _connection.Query<Department>("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
			_connection.Execute("SELECT INTO DEPARTMENTS (Name) VALUES (@department);",
				new { DepartmentName = newDepartmentName });
        }
    }
}

