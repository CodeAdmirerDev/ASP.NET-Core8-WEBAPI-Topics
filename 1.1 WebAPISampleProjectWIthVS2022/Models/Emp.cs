using System.ComponentModel.DataAnnotations;

namespace WebAPISampleProjectWIthVS2022.Models
{
    public class Emp
    {
        public int EmpNo { get; set; }

        [Required]
        public string EmpName { get; set; }
        public string Job { get; set; }
        [Range(1000, 9999)]
        public int Salary { get; set; }

    }
}
