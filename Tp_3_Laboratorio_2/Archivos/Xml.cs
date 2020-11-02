using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Exepciones;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            XmlTextReader reader = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                reader = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(reader);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(reader is null))
                    reader.Close();
            }
            return retorno;
        }

        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            XmlTextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(writer, datos);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(writer is null))
                    writer.Close();
            }
            return retorno;
        }
    }
}
