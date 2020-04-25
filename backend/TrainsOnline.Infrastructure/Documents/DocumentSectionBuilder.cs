namespace TrainsOnline.Infrastructure.Documents
{
    using GemBox.Document;
    using GemBox.Document.Tables;
    using TrainsOnline.Application.Interfaces.Documents;

    internal class DocumentSectionBuilder : IDocumentSectionBuilder
    {
        private DocumentModel Document { get; }
        private DocumentBuilder Parent { get; }
        private Section Section { get; }

        public DocumentSectionBuilder(DocumentModel document, DocumentBuilder parent, Section section)
        {
            Document = document;
            Parent = parent;
            Section = section;
        }

        public IDocumentSectionBuilder AddParagraph(string text)
        {
            Paragraph paragraph = new Paragraph(Document, text);
            Section.Blocks.Add(paragraph);

            return this;
        }

        public IDocumentComplexParagraphBuilder AddComplexParagraph()
        {
            Paragraph paragraph = new Paragraph(Document);
            Section.Blocks.Add(paragraph);

            return new DocumentComplexParagraphBuilder(Document, this, paragraph);
        }

        public IDocumentSectionBuilder AddSimpleTable(object[,] tableData)
        {
            Table table = new Table(Document);
            table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);

            Section.Blocks.Add(table);

            int rowsCount = tableData.GetLength(0);
            int columnsCount = tableData.GetLength(1);

            for (int r = 0; r < rowsCount; ++r)
            {
                // Create a row and add it to table.
                TableRow row = new TableRow(Document);
                table.Rows.Add(row);

                for (int c = 0; c < columnsCount; ++c)
                {
                    // Create a cell and add it to row.
                    TableCell cell = new TableCell(Document);
                    row.Cells.Add(cell);

                    // Create a paragraph and add it to cell.
                    var paragraph = new Paragraph(Document, tableData[r, c].ToString());
                    cell.Blocks.Add(paragraph);
                }
            }

            return this;
        }

        public IDocumentBuilder FinishSection()
        {
            return Parent;
        }
    }
}
