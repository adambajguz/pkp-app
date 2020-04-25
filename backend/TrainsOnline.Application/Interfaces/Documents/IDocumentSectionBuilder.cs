namespace TrainsOnline.Application.Interfaces.Documents
{
    public interface IDocumentSectionBuilder
    {
        IDocumentSectionBuilder AddParagraph(string text);
        IDocumentComplexParagraphBuilder AddComplexParagraph();

        IDocumentSectionBuilder AddSimpleTable(object[,] tableData, bool hasHeader = true);

        IDocumentBuilder FinishSection();
    }
}
