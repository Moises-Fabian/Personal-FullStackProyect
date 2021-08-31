using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTO
{
    public class PaginacionDTO
    {
        public int pagina { get; set; } = 1;

        private int recordsPorPagina = 10;
        private readonly int CantidadMaximaRecordsPorPagina = 50;

        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > CantidadMaximaRecordsPorPagina) ? CantidadMaximaRecordsPorPagina : value;
            }
        }
    }
}
