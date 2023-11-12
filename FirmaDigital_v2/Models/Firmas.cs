using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigital_v2.Models {
    public class Firmas {
        private List<string> invalidData = new List<string>();
        private byte[] firma;
        private string firmaFilePath;
        private string nombre;
        private string descripcion;


        public Firmas() { }

        public Firmas(byte[] firma, string nombre, string descripcion) {
            this.Firma = firma;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public List<string> GetDatosInvalidos() {
            return this.invalidData;
        }




        [PrimaryKey, AutoIncrement]
        public int Id {get;set;}




        [Column("Firma")]
        public byte[] Firma {
            get { return this.firma; }

            set {
                if (value != null && value.Length > 0) {
                    this.firma = value;
                } else {
                    this.invalidData.Add("Firma");
                }
            }
        }


        [Column("FirmaFilePath")]
        public string FirmaFilePath {
            get { return this.firmaFilePath; }
            set {this.firmaFilePath = Path.Combine(App.firmasDirectory, value); }
        }



        [Column("Nombre")]
        public string Nombre {
            get { return this.nombre; }

            set {
                if (!string.IsNullOrEmpty(value)) {
                    this.nombre = value;
                    FirmaFilePath = value;
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
