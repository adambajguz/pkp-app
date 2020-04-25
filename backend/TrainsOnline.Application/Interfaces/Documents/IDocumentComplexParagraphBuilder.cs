﻿using System.IO;

namespace TrainsOnline.Application.Interfaces.Documents
{
    public interface IDocumentComplexParagraphBuilder
    {
        IDocumentComplexParagraphBuilder AddRun(string text,
                                                double size = 10,
                                                bool bold = false,
                                                bool italic = false);
        public IDocumentComplexParagraphBuilder AddRunLine(string text,
                                                           double size = 10,
                                                           bool bold = false,
                                                           bool italic = false);

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
