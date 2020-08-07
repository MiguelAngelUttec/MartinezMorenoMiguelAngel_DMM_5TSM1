using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Computadoras.Tablas
{
    public class sucursal
    {
        [PrimaryKey, AutoIncrement]
        public int id_sucursal { get; set; }
        [MaxLength(20)]
        public string nombre { get; set; }
        [MaxLength(70)]
        public string direccion { get; set; }
        [MaxLength(5)]
        public string codigoPostal { get; set; }
        public string id_gerente { get; set; }
    }
}
