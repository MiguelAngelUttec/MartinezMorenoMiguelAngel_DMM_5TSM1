using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Computadoras.Tablas
{
    public class gerentes
    {
        [PrimaryKey, AutoIncrement]
        public int id_gerente { get; set; }
        [MaxLength(20)]
        public string nombres { get; set; }
        [MaxLength(20)]
        public string apellido_Pat { get; set; }
        [MaxLength(20)]
        public string apellido_Mat { get; set; }
        [MaxLength(18)]
        public string curp { get; set; }
        [MaxLength(10)]
        public string rfc { get; set; }

    }
}
