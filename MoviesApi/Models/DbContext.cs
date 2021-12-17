using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Models
{
    public class DbContext
    {
        public List<Metadata> metaData
        {
            get
            {
                using var streamReader = File.OpenText("metadata.csv");
                using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

                var moviesData = csvReader.GetRecords<Metadata>();
                return moviesData.ToList();
               
            }
        }
      
        public List<Stat> statData
        {
            get
            {
                using var streamReader = File.OpenText("stats.csv");
                using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.CurrentCulture) { PrepareHeaderForMatch = args => args.Header.ToLower() });
             

                var statsData = csvReader.GetRecords<Stat>();
                return statsData.ToList();
            }
        }
    }
}
