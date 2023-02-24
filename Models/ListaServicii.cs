using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProgramareRevizie.Models
{
    public class ListaServicii
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Programare))]
        public int ProgramareID { get; set; }
        public int ServiciuID { get; set; }
    }
}
