using EmployeeAPI.Models;
namespace EmployeeAPI.Services
{
    public class EmployeeService
    {
        static List<Employee> employeeList { get; }
        static int NextEmpId = 3;
        static EmployeeService()
        {
            employeeList = new List<Employee>()
            {
                new Employee() {Id=1,Name="Ahmed",Title="Developer",Salary=1500},
                new Employee() {Id=2,Name="Asensio",Title="Accounter",Salary=1000},
                new Employee() {Id=3,Name="Ayman",Title="CEO",Salary=2500}  
            };
            
        }
        public static List<Employee> GetAll() => employeeList;
        public static Employee Get(int id) => employeeList.FirstOrDefault(p => p.Id == id);
        public static void Add(Employee employee)
        {
            employee.Id = NextEmpId++;
            employeeList.Add(employee);
        }
        public static void Update(Employee employee)
        {
            var index = employeeList.FindIndex(p=> p.Id== employee.Id);
            if (index==-1)
                return;
            employeeList[index] = employee;
        }

        public static void Delete(int id)
        {
            var employee = Get(id);
            if (employee is null) return;   
            employeeList.Remove(employee);
        }
    }
}
