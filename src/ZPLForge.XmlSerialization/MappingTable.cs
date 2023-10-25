using System;
using System.Collections.Generic;
using System.Linq;
using ZPLForge.Contracts;

namespace ZPLForge.XmlSerialization
{
    internal static class MappingTable
    {
        public static List<TypeMap> Maps = new List<TypeMap>
        {
            new TypeMap("Label", typeof(ILabel), typeof(LabelXmlNode), typeof(Label)),
            new TypeMap("Barcode", typeof(IBarcode), typeof(BarcodeXmlNode), typeof(BarcodeElement)),
            new TypeMap("DiagonalLine", typeof(IDiagonalLine), typeof(DiagonalLineXmlNode), typeof(DiagonalLineElement)),
            new TypeMap("Ellipse", typeof(IEllipse), typeof(EllipseXmlNode), typeof(EllipseElement)),
            new TypeMap("QrCode", typeof(IQrCode), typeof(QrCodeXmlNode), typeof(QrCodeElement)),
            new TypeMap("DataMatrix", typeof(IDataMatrix), typeof(DataMatrixXmlNode), typeof(DataMatrixElement)),
            new TypeMap("Rectangle", typeof(IRectangle), typeof(RectangleXmlNode), typeof(RectangleElement)),
            new TypeMap("Text", typeof(IText), typeof(TextXmlNode), typeof(TextElement)),
            new TypeMap("Image", typeof(IImage), typeof(ImageXmlNode), typeof(ImageElement)),
            new TypeMap("Symbol", typeof(ISymbol), typeof(SymbolXmlNode), typeof(SymbolElement))
        };

        public static Type XmlToElementType(Type xmlType)
        {
            return Maps.FirstOrDefault(x => x.XmlNodeType == xmlType).ElementType;
        }

        public static Type ElementToXmlType(Type elementType)
        {
            return Maps.FirstOrDefault(x => x.ElementType == elementType).XmlNodeType;
        }

        public static Type GetContractType(Type xmlOrElementType)
        {
            return Maps.FirstOrDefault(x => x.ElementType == xmlOrElementType || x.XmlNodeType == xmlOrElementType).ContractType;
        }

        public static TypeMap Find(Type type)
        {
            return Maps.FirstOrDefault(x => x.ElementType == type || x.ContractType == type || x.XmlNodeType == type);
        }

        public static TypeMap Find(string nodeName)
        {
            return Maps.FirstOrDefault(x => x.XmlNodeName.Equals(nodeName, StringComparison.OrdinalIgnoreCase));
        }

        internal class TypeMap
        {
            public TypeMap(string xmlNodeName, Type contractType, Type xmlNodeType, Type elementType)
            {
                XmlNodeName = xmlNodeName;
                ContractType = contractType;
                XmlNodeType = xmlNodeType;
                ElementType = elementType;
            }

            public string XmlNodeName { get; }
            public Type ContractType { get; }
            public Type XmlNodeType { get; }
            public Type ElementType { get; }
        }
    }
}
