using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Exepciones;
using Archivos;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores 
        public Alumno() : base()
        {
            this.claseQueToma = default(Universidad.EClases);
            this.estadoCuenta = default(EEstadoCuenta);
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id,nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) 
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos 
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0}", base.MostrarDatos()));
            sb.AppendLine(String.Format("ESTADO DE CUENTA: {0}", this.estadoCuenta));
            sb.Append(String.Format("{0}", this.ParticiparEnClase()));

            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("TOMA CLASES DE: {0}", this.claseQueToma.ToString()));

            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
