namespace TrainsOnline.Infrastructure.Documents
{
    using System.IO;
    using GemBox.Document;
    using TrainsOnline.Application.Interfaces.Documents;

    internal class DocumentComplexParagraphBuilder : IDocumentComplexParagraphBuilder
    {
        private DocumentModel Document { get; }
        private DocumentSectionBuilder Parent { get; }
        private Paragraph Paragraph { get; }

        public DocumentComplexParagraphBuilder(DocumentModel document, DocumentSectionBuilder parent, Paragraph paragraph)
        {
            Document = document;
            Parent = parent;
            Paragraph = paragraph;
        }

        public IDocumentComplexParagraphBuilder AddRun(string text,
                                                       double size = 10,
                                                       bool bold = false,
                                                       bool italic = false)
        {
            Run run = new Run(Document, text)
            {
                CharacterFormat = {
                    Size = size,
                    Bold = bold,
                    Italic = italic
                }
            };

            Paragraph.Inlines.Add(run);
            return this;
        }

        public IDocumentComplexParagraphBuilder AddSpecialCharacter(DocumentSpecialCharacters specialCharacter)
        {
            SpecialCharacter run = new SpecialCharacter(Document, (SpecialCharacterType)specialCharacter);
            Paragraph.Inlines.Add(run);

            return this;
        }

        public IDocumentComplexParagraphBuilder AddImage(string imagePath,
                                                         double width,
                                                         double height)
        {
            Picture picture = new Picture(Document, imagePath, width, height, LengthUnit.Millimeter);
            Paragraph.Inlines.Add(picture);

            return this;
        }
        
        public IDocumentComplexParagraphBuilder AddImage(Stream imageStream,
                                                         double width,
                                                         double height)
        {
            Picture picture = new Picture(Document, imageStream, width, height, LengthUnit.Millimeter);
            Paragraph.Inlines.Add(picture);

            return this;
        }

        public IDocumentSectionBuilder FinishParagraph()
        {
            return Parent;
        }
    }
}
