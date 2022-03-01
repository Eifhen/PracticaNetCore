using LumenWorks.Framework.IO.Csv;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.Procesos
{
	public class CargarPaises
	{
		 public List<SelectListItem> ListadoDePaises() 
        {

            var listado_paises = new List<Paises>();

            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead("./Procesos/countrys.csv")), true))
            {
                csvTable.Load(csvReader);
            }

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                listado_paises.Add(new Paises 
                { 
                    EnglishShortName = csvTable.Rows[i][0].ToString(), 
                    Alpha3Code = csvTable.Rows[i][2].ToString()
                });
            }

            var listado = new List<SelectListItem>();
            foreach(var pais in listado_paises)
            {
                listado.Add(new SelectListItem { Text = pais.EnglishShortName, Value = pais.Alpha3Code });
            }

            return listado;
        }
	}
}
