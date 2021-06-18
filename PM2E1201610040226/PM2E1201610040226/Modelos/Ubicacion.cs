using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E1201610040226.Modelos
{
    public class Ubicacion
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250)]
        public Double latitud { get; set; }

        [MaxLength(250)]
        public Double longitud { get; set; }

        [MaxLength(250)]
        public String descripcion { get; set; }

        [MaxLength(300)]
        public String nombre { get; set; }

    }
}
