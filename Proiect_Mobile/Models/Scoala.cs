using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Mobile.Models
{
    public class Scoala
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ScoalaName { get; set; }
        public string Adress { get; set; }
        public string ScoalaDetails
        {
            get
            {
                return ScoalaName + " "+Adress;} }
        [OneToMany]
 public List<Rezervare> Rezervari { get; set; }
    }
}
