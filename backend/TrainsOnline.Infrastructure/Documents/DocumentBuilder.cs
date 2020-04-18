namespace TrainsOnline.Infrastructure.Pdf
{
    using System.IO;
    using GemBox.Document;
    using TrainsOnline.Application.Interfaces.Pdf;

    public class DocumentBuilder : IDocumentBuilder
    {
        private DocumentModel Document { get; } = new DocumentModel();

        //https://www.gemboxsoftware.com/document/examples/c-sharp-vb-net-word-pdf-library/801
        public DocumentBuilder()
        {
            Document = new DocumentModel();
        }

        public DocumentBuilder(Stream stream)
        {
            Document = DocumentModel.Load(stream);
        }

        public DocumentBuilder(string path)
        {
            Document = DocumentModel.Load(path);
        }

        public IDocumentBuilder AddImage()
        {
            throw new System.NotImplementedException();
        }

        public IDocumentBuilder AddParagraph()
        {
            throw new System.NotImplementedException();
        }

        public IDocumentBuilder AddRun()
        {
            throw new System.NotImplementedException();
        }

        public IDocumentBuilder AddSection()
        {
            throw new System.NotImplementedException();
        }

        public IDocumentBuilder AddSpecialCharacter()
        {
            throw new System.NotImplementedException();
        }

        public IDocumentBuilder AddTable()
        {
            throw new System.NotImplementedException();
        }

        public byte[] BuildDocx()
        {
            return Build(SaveOptions.DocxDefault);
        }

        public byte[] BuildHtml()
        {
            return Build(SaveOptions.HtmlDefault);
        }

        public byte[] BuildImage()
        {
            return Build(SaveOptions.ImageDefault);
        }

        public byte[] BuildPdf()
        {
            return Build(SaveOptions.PdfDefault);
        }

        public byte[] BuildRtf()
        {
            return Build(SaveOptions.RtfDefault);
        }

        public byte[] BuildTxt()
        {
            return Build(SaveOptions.TxtDefault);
        }

        public byte[] BuildXml()
        {
            return Build(SaveOptions.XmlDefault);
        }

        public byte[] BuildXps()
        {
            return Build(SaveOptions.XpsDefault);
        }

        private byte[] Build(SaveOptions options)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document.Save(stream, options);
                byte[] array = stream.ToArray();

                return array;
            }
        }
    }
}
