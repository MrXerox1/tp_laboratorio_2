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
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random = new Random();

        #region Constructores
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion

        #region Metodos
        private void _randomClases()
        {
            Universidad.EClases clase = (Universidad.EClases)random.Next(0, 3);
            clasesDelDia.Enqueue(clase);
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0}", base.MostrarDatos()));
            sb.AppendLine(string.Format("{0}", this.ParticiparEnClase()));

            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
        #region Operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
