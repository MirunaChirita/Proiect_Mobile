using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Proiect_Mobile.Models
{
    public class Rezervare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250)]

        public string Descriere { get; set; }
        
        public DateTime DataProgramare { get; set; }
    }
}
