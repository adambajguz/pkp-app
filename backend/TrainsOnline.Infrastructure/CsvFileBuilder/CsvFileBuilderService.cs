namespace TrainsOnline.Infrastructure.CsvFileBuilder
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using Application.Interfaces;
    using CsvHelper;

    public class CsvFileBuilderService : ICsvFileBuilderService
    {
        public byte[] BuildProductsFile<T>(IEnumerable<T> records)
        {
            using MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream))
            {
                using CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.Configuration.RegisterClassMap(typeof(T));
                //csvWriter.Configuration.RegisterClassMap<T>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
