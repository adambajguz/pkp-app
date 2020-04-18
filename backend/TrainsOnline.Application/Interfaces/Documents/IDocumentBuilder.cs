namespace TrainsOnline.Application.Interfaces.Pdf
{
    public interface IDocumentBuilder
    {
        IDocumentBuilder AddSection();
        IDocumentBuilder AddParagraph();
        IDocumentBuilder AddRun();
        IDocumentBuilder AddSpecialCharacter();
        IDocumentBuilder AddTable();
        IDocumentBuilder AddImage();

        byte[] BuildDocx();
        byte[] BuildPdf();
        byte[] BuildXps();
        byte[] BuildImage();
        byte[] BuildHtml();
        byte[] BuildTxt();
        byte[] BuildRtf();
        byte[] BuildXml();
    }
}
