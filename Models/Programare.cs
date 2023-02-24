using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace ProgramareRevizie.Models
{
    public class Programare
    {
        [PrimaryKey, AutoIncrement]  //ID este marcat ca fiind Cheie Primara
        public int ID { get; set; }
        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
