using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fluent.Print.API
{
    public class StarMarkupElements : BaseMarkupElement
    {

        public static StarTextMarkupElement Text = new StarTextMarkupElement(0, typeof(TextDocumentElement).Name.ToLowerInvariant());
        public static StarImageMarkupElement Image = new StarImageMarkupElement(1, typeof(ImageDocumentElement).Name.ToLowerInvariant());
        public static StarAlignMarkupElement Align = new StarAlignMarkupElement(2, typeof(TextAlign).Name.ToLowerInvariant());
        public static StarBarCodeMarkupElement BarCode = new StarBarCodeMarkupElement(3, typeof(BaseMarkupElement).Name.ToLowerInvariant());
        public static StarBoldMarkupElement Bold = new StarBoldMarkupElement(4, typeof(StarBoldMarkupElement).Name.ToLowerInvariant());
        public static StarColumnMarkupElement Column = new StarColumnMarkupElement(5, typeof(DocumentGridColumn).Name.ToLowerInvariant());
        public static StarCommentMarkupElement Comment = new StarCommentMarkupElement(6, typeof(StarCommentMarkupElement).Name.ToLowerInvariant());
        public static StarCutMarkupElement Cut = new StarCutMarkupElement(7, typeof(CutDocumentElement).Name.ToLowerInvariant());
        public static StarFeedMarkupElement Feed = new StarFeedMarkupElement(8, typeof(StarFeedMarkupElement).Name.ToLowerInvariant());
        public static StarFontMarkupElement Font = new StarFontMarkupElement(9, typeof(StarFontMarkupElement).Name.ToLowerInvariant());
        public static StarLogoMarkupElement Logo = new StarLogoMarkupElement(10, typeof(StarLogoMarkupElement).Name.ToLowerInvariant());
        public static StarMagnifyMarkupElement Magnify = new StarMagnifyMarkupElement(11, typeof(StarMagnifyMarkupElement).Name.ToLowerInvariant());
        public static StarPlainMarkupElement Plain = new StarPlainMarkupElement(12, typeof(StarPlainMarkupElement).Name.ToLowerInvariant());
        public static StarSpaceMarkupElement Space = new StarSpaceMarkupElement(13, typeof(Space).Name.ToLowerInvariant());
        public static StarUnderLineMarkupElement UnderLine = new StarUnderLineMarkupElement(14, typeof(StarUnderLineMarkupElement).Name.ToLowerInvariant());
        public static StarUpperLineMarkupElement UpperLine = new StarUpperLineMarkupElement(15, typeof(StarUpperLineMarkupElement).Name.ToLowerInvariant());
        public static StarGridMarkupElement Grid = new StarGridMarkupElement(16, typeof(DocumentGridElement).Name.ToLowerInvariant());
        public static StarGridHeaderMarkupElement GridHeader = new StarGridHeaderMarkupElement(17, typeof(DocumentGridHeader).Name.ToLowerInvariant());
        public static StarGridRowMarkupElement GridRow = new StarGridRowMarkupElement(18, typeof(DocumentGridRow).Name.ToLowerInvariant());
        public static StarGridColumnMarkupElement GridColumn = new StarGridColumnMarkupElement(19, typeof(DocumentGridColumn).Name.ToLowerInvariant());
        public static StarGridSectionMarkupElement GridSection = new StarGridSectionMarkupElement(19, typeof(DocumentGridSection).Name.ToLowerInvariant());
        public static StarNegativeMarkupElement Negative = new StarNegativeMarkupElement(20, typeof(StarNegativeMarkupElement).Name.ToLowerInvariant());
        public static StarHorizontalLineMarkupElement HorizontalLine = new StarHorizontalLineMarkupElement(21, typeof(HorizontalLineDocumentElement).Name.ToLowerInvariant());
        public static StarDirectionMarkupElement Direction = new StarDirectionMarkupElement(22, typeof(TextDocumentElement).Name.ToLowerInvariant());
        public static StarNewLineMarkupElement NewLine = new StarNewLineMarkupElement(23, typeof(NewLineDocumentElement).Name.ToLowerInvariant());


        public StarMarkupElements(int id, string typeName)
           : base(id, typeName, string.Empty)
        {

        }
        public StarMarkupElements(int id, string typeName, string tagName)
         : base(id, typeName, tagName)
        {

        }
        public static IEnumerable<BaseMarkupElement> List()
        {
            var list = new BaseMarkupElement[] {

                 Text
                ,Image
                ,BarCode
                ,Bold
                ,Column
                ,Comment
                ,Cut
                ,Feed
                ,Font
                ,Logo
                ,Magnify
                ,Plain
                ,Space
                ,UnderLine
                ,UpperLine
                ,Grid
                ,NewLine
                ,GridHeader
                ,GridRow
                ,GridColumn
                ,HorizontalLine
           };

            return list;

        }
        public static BaseMarkupElement FromTypeName(string typeName)
        {
            var el = List().SingleOrDefault(s => string.Equals(s.Name, typeName, StringComparison.CurrentCultureIgnoreCase));
            return el;
        }

        public override string BuildPrintDocument(IEnumerable<IFluentPrintDocumentBuilder> fluentPrintDocuments)
        {
            var strBld = new StringBuilder();

            foreach (var document in fluentPrintDocuments)
            {
                var printDoc = document.Build(PaperWidthBaseAFontCharCount);
                foreach (var doc in printDoc)
                {
                    if (!doc.Visible)
                    {
                        continue;
                    }
                    var markup = FromTypeName(doc.GetType().Name.ToLowerInvariant());
                    var res = markup.CreateElement(doc);
                    strBld.Append(res);
                    strBld.Append(NewLine.CreateElement(default(IPrintDocumentElement)));
                }

                strBld.Append(Cut.CreateElement(default(IPrintDocumentElement)));
            }

            var strPrintDoc = strBld.ToString();

            return strPrintDoc;
        }

    }
}
