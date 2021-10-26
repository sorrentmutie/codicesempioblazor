using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaComponenti.Models
{
    public class LogData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string  Message { get; set; }
        [Required(ErrorMessage = "Il level è obbligatorio")]
        [StringLength(10, ErrorMessage = "Lunghezza Massima 10")]
        public string Level { get; set; }
    }
}
