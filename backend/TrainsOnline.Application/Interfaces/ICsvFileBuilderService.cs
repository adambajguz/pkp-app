namespace TrainsOnline.Application.Interfaces
{
    using System.Collections.Generic;

    public interface ICsvFileBuilderService
    {
        byte[] BuildProductsFile<T>(IEnumerable<T> records);
    }
}
