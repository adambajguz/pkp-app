namespace TrainsOnline.Infrastructure.Pdf
{
    using System.IO;
    using GemBox.Document;
    using TrainsOnline.Application.Interfaces.Documents;
    using TrainsOnline.Infrastructure.Documents;

    public class DocumentsService : IDocumentsService
    {
        public DocumentsService()
        {

        }

        public IDocumentBuilder NewDocument()
        {
            return new DocumentBuilder();
        }

        public IDocumentBuilder EditDocument(Stream stream)
        {
            return new DocumentBuilder(stream);
        }

        public IDocumentBuilder EditDocument(string path)
        {
            return new DocumentBuilder(path);
        }

        public byte[] NewSampleDocument()
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
