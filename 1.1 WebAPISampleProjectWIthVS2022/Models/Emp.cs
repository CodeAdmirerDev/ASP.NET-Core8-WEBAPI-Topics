using System.ComponentModel.DataAnnotations;

namespace WebAPISampleProjectWIthVS2022.Models
{
    public class Emp
    {
        public int EmpNo { get; set; }

        [Required]
        [StringLength(10)]
        public string EmpName { get; set; }
        [StringLength(100)]
        public string Job { get; set; }
        [Range(1000, 9999)]
        public int Salary { get; set; }

    }
}
