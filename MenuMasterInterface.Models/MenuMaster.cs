using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMasterInterface.Models
{
    [Table("MenuMaster")]
    public class MenuMaster
    {
        [Key]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Enter ControllerName")]
        public string ControllerName { get; set; }

        [Required(ErrorMessage = "Enter ActionMethod")]
        public string ActionMethod { get; set; }

        [Required(ErrorMessage = "Enter MenuName")]
        public string MenuName { get; set; }
        public bool Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsCache { get; set; }
        public int UserId { get; set; }

    }
}
