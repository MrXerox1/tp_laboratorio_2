using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Exepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Constructores
        public Persona()
        {
            this.Nombre = "";
            this.Apellido = "";
            this.dni = default;
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = ValidarNombreApellido(nombre);
            this.Apellido = ValidarNombreApellido(apellido);
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        #endregion

        #region Propiedades
        private string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value.ToString());
            }
        }
        private string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }



        #endregion

        #region Validaciones
        private string ValidarNombreApellido(string dato)
        {
            string auxDato = string.Empty;
            Regex rx = new Regex(@"^[A-Z][a-z ]+$");
            if (rx.IsMatch(dato))
            {
                auxDato = dato;
            }
            return auxDato;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoInt = default;
            Regex reg = new Regex(@"^[0-9]+$");
            if (int.TryParse(dato, out datoInt) && dato.Length <= 8 && reg.IsMatch(dato))
            {
                return datoInt;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\r\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad.ToString());

            return sb.ToString();
        }
    }
}
