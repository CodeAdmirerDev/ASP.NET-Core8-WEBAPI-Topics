
namespace WebAPISampleProjectWIthVS2022.Models.RepositoryPattren
{
    public class EmpRepository : IEmpRepository
    {
        private readonly List<Emp> _empList;

        public EmpRepository() {

            _empList = new List<Emp>
            {
            new Emp { EmpNo = 1, EmpName = "Shiva", Job = "Manager", Salary = 3000 },
            new Emp { EmpNo = 2, EmpName = "Rama", Job = "Clerk", Salary = 800 },
            new Emp { EmpNo = 3, EmpName = "Krishna", Job = "Salesman", Salary = 1600 }
            };
        
        }

        public void AddEmp(Emp emp)
        {

            emp.EmpNo = _empList.Max(e => e.EmpNo) + 1;
            _empList.Add(emp);
        }

        public void DeleteEmp(int EmpNo)
        {
            var emp = GetEmpByEmpId(EmpNo);
            if (emp != null)
            {
                _empList.Remove(emp);
            }
        }

        public bool IsEmpExists(int EmpNo)
        {
            return _empList.Any(e => e.EmpNo == EmpNo);   
        }

        public IEnumerable<Emp> GetAllEmp()
        {
           return _empList;
        }

        public Emp GetEmpByEmpId(int EmpNo)
        {
           return _empList.FirstOrDefault(e => e.EmpNo == EmpNo);
        }

        public void UpdateEmp(Emp emp)
        {
            //Get the existing employee by emp id
            var existingEmp = GetEmpByEmpId(emp.EmpNo);

            // delete the exsting object
            _empList.Remove(existingEmp);

            if (existingEmp != null)
            {
                existingEmp.EmpName = emp.EmpName;
                existingEmp.Job = emp.Job;
                existingEmp.Salary = emp.Salary;
            }
            //Re add the exsting employee with updated values
            _empList.Add(existingEmp);

        }

        public Emp GetEmpByEmpIdOrName(int EmpNo, string empname)
        {
            return _empList.FirstOrDefault(e => e.EmpNo == EmpNo || e.EmpName == empname);
        }
    }
}
