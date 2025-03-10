namespace WebAPISampleProjectWIthVS2022.Models.RepositoryPattren
{
    public interface IEmpRepository
    {
        IEnumerable<Emp> GetAllEmp();
        Emp GetEmpByEmpId(int EmpNo);
        void AddEmp(Emp emp);
        void UpdateEmp(Emp emp);
        void DeleteEmp(int EmpNo);
        bool IsEmpExists(int EmpNo);

    }
}
