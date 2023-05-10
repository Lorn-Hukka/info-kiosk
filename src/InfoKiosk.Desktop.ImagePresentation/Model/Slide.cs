namespace InfoKiosk.Desktop.ImagePresentation.Model
{
    internal record Slide(string Id, SlideType Type, SourceFrom From, string Source, string Title, string Description);
}
