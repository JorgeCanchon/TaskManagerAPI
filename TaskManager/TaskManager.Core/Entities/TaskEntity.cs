using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Entities
{
    public class TaskEntity
    {
        public int Id { get; init; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CodigoEstado { get; set; }
        public int CodigoUsuario { get; set; }

        public TaskEntity(int Id, string Titulo, string Descripcion, int CodigoEstado, int CodigoUsuario)
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.CodigoEstado = CodigoEstado;
            this.CodigoUsuario = CodigoUsuario;
        }
    }
}
