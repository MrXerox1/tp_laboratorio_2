using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;


namespace Archivos
{
    public interface IArchivo<T>
    {
        bool Leer(string archivo, out T datos);
        bool Guardar(string archivo, T datos);

    }
}
