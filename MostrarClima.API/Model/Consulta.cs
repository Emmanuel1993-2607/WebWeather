using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MostrarClima.API.Model
{
    public class Consulta
    {
        /// <resumen>
        /// Clave principal, generada por la base de datos
        /// </summary>
        /// <ejemplo>
        /// 1
        /// </example>
        public int Id { get; set; }

        /// <resumen>
        /// Clave almacenada en el navegador del usuario, generada automáticamente en la primera consulta
        public string UserKey { get; set; }

        /// <summary>
        /// Consulta de clima realizada
        /// </summary>
        /// <example>
        /// {
        ///  "request": {
        ///    "type": "City",
        ///    "query": "Guatemala City, Guatemala",
        ///    "language": "en",
        ///    "unit": "m"
        ///  "current": {
        ///    "observation_time": "01:07 AM",
        ///    "temperature": 25,
        ///    "weather_code": 116,
        ///    "weather_icons": [
        ///      "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0004_black_low_cloud.png"
        ///    ],
        ///    "weather_descriptions": [
        ///      "Partly cloudy"
        ///    ],
        ///    "wind_speed": 19,
        ///    "wind_degree": 20,
        ///    "wind_dir": "NNE",
        ///    "pressure": 1021,
        ///    "precip": 0,
        ///    
        ///    "humidity": 44,
        ///    "cloudcover": 50,
        ///    "feelslike": 26,
        ///    "uv_index": 7,
        ///    "visibility": 10,
        ///    "is_day": "no"
        ///  }
        /// }
        /// </example>
        public string Weather { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime QueryDate { get; set; }
    }
}
