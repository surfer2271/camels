using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models
{
    public class QuestionAndAnswers
    {
       [Key]
       public int QuestionAndAnswersId { get; set; }
       public string Question { get; set; }

       public string Answer { get; set; }
    }
}
