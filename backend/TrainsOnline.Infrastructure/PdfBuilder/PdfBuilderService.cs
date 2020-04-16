namespace TrainsOnline.Infrastructure.PdfBuilder
{
    using System.IO;
    using GemBox.Document;
    using TrainsOnline.Application.Interfaces;

    public class PdfBuilderService : IPdfBuilderService
    {
        public byte[] BuildDocument()
        {
            // Create a new empty Word file.
            DocumentModel doc = new DocumentModel();

            // Add a new document content.
            doc.Sections.Add(new Section(doc, new Paragraph(doc, "Hello world!")));

            using (MemoryStream stream = new MemoryStream())
            {
                doc.Save(stream, SaveOptions.PdfDefault);
                byte[] b = stream.ToArray();

                return b;
            }
        }
    }
}
