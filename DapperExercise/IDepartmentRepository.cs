using System;
namespace DapperExercise
{
	public interface IDepartmentRepository
	{
		public IEnumerable<Department> GetAllDepartments();
		public void InsertDepartment(string newDepartment);
	}
}

