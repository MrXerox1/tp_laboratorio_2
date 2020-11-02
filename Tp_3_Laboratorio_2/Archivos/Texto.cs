using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = string.Empty;
            if (File.Exists(archivo))
            {
                StreamReader streamReader = null;
                try
                {
                    streamReader = new StreamReader(archivo);
                    datos = streamReader.ReadToEnd();
                    retorno = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                finally
                {
                    streamReader.Close();
                }
            }
            return retorno;
        }

        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.Write(datos);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                streamWriter.Close();
            }

            return retorno;
        }
    }
}
