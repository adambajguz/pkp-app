namespace TrainsOnline.Application.Interfaces.Documents
{
    using System.IO;

    public interface IDocumentComplexParagraphBuilder
    {
        IDocumentComplexParagraphBuilder AddRun(string text,
                                                double size = 10,
                                                bool bold = false,
                                                bool italic = false,
                                                System.Drawing.Color? fontColor = null);
        public IDocumentComplexParagraphBuilder AddRunLine(string text,
                                                           double size = 10,
                                                           bool bold = false,
                                                           bool italic = false,
                                                           System.Drawing.Color? fontColor = null);

        IDocumentComplexParagraphBuilder AddNewLine();
        IDocumentComplexParagraphBuilder AddSpecialCharacter(DocumentSpecialCharacters specialCharacter);

        IDocumentComplexParagraphBuilder AddImage(string imagePath,
                                                  double width,
                                                  double height);
        IDocumentComplexParagraphBuilder AddImage(Stream imageStream,
                                                  double width,
                                                  double height);
        IDocumentComplexParagraphBuilder AddImage(MemoryStream imageStream,
                                                  double width,
                                                  double height);
        IDocumentSectionBuilder FinishParagraph();
    }
}
