using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigital_v2.Models {
    public class Firmas {
        private List<string> invalidData = new List<string>();
        private byte[] firmaImageArray;
        private string firmaImagePath;
        private string nombre;
        private string descripcion;


        public Firmas() { }

        public Firmas(byte[] firmaImageArray, string firmaImagePath, string nombre, string descripcion) {
            this.FirmaImageArray = firmaImageArray;
            this.FirmaImagePath = firmaImagePath;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public List<string> GetDatosInvalidos() {
            return this.invalidData;
        }




        [PrimaryKey, AutoIncrement]
        public int Id {get;set;}




        [Column("FirmaImageArray")]
        public byte[] FirmaImageArray {
            get { return this.firmaImageArray; }

            set {
                if (value != null && value.Length > 0) {
                    this.firmaImageArray = value;
                } else {
                    this.invalidData.Add("FirmaImageArray");
                }
            }
        }


        [Column("FirmaImagePath")]
        public string FirmaImagePath {
            get { return this.firmaImagePath; }

            set {
                if (!string.IsNullOrEmpty(value)) {
                    this.firmaImagePath = value;
                } else {
                    this.invalidData.Add("FirmaImagePath");
                }
            }
        }



        [Column("Nombre")]
        public string Nombre {
            get { return this.nombre; }

            set {
                if (!string.IsNullOrEmpty(value)) {
                    this.nombre = value;
                } else {
                    this.invalidData.Add("Nombre");
                }
            }
        }



        [Column("Descripcion")]
        public string Descripcion {
            get { return this.descripcion; }

            set {
                if (!string.IsNullOrEmpty(value)) {
                    this.descripcion = value;
                } else {
                    this.invalidData.Add("Descripcion");
                }
            }
        }



    }
}
