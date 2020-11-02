using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int legajo;

        public Universitario() : base()
        {
            this.legajo = default;
        }
        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0}", base.ToString()));
            sb.AppendLine(string.Format("LEGAJO NUMERO: {0}", this.legajo));

            return sb.ToString();
        }

        #region Operadores
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                if ((this.legajo == ((Universitario)obj).legajo || this.DNI == ((Universitario)obj).DNI))
                    return true;
            }
            return false;
        }

        public static bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            if (universitarioUno.Equals(universitarioDos) && (universitarioUno.legajo == universitarioDos.legajo 
                || universitarioUno.DNI == universitarioDos.DNI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }
        #endregion
    }
}
