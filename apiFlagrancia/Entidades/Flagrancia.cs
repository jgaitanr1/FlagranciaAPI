using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Entidades
{
    public class Flagrancia : IHaveId
    {
        //---- Datos del Detenido------//
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Nacionalidad { get; set; }
        public String Genero { get; set; }
        public String Documento { get; set; }

        //---- Datos Juridicos ------//
        public String SituacionJuridica { get; set; }
        public String Sentencia { get; set; }
        public String SentenciaDET { get; set; }
        public String Audiencia { get; set; }
        public String Acusacion { get; set; }
        public String Descripcion { get; set; }
        public String tipoArresto { get; set; }

        //---- Geoposicion ------//
        public String Latitud { get; set; }
        public String Longitud { get; set; }

        //---- Datos de Validacion------//
        public String UsuarioRegistro { get; set; }
        public String FecRegistro { get; set; }
        public String EstadoFlagrante { get; set; }
        public Boolean Estado { get; set; }
    }
}
