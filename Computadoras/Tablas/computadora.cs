using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Computadoras.Tablas
{
    public class computadora
    {
        [PrimaryKey, AutoIncrement]
        public int id_computadora { get; set; }
        [MaxLength (15)]
        public string marca { get; set; }
        [MaxLength(15)]
        public string modelo { get; set; }
        [MaxLength(18)]
        public string procesador { get; set; }
        [MaxLength(5)]
        public string ram { get; set; }
        [MaxLength(5)]
        public string rom { get; set; }        
        public string id_sucursal { get; set; }
    }
}
