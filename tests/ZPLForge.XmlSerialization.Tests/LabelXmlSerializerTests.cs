using System;
using System.IO;
using System.Text;
using Xunit;

namespace ZPLForge.XmlSerialization.Tests
{
    public class LabelXmlSerializerTests
    {
        [Fact]
        public void LabelXmlSerializerSerializeThrowsWhenLabelIsNull()
        {
            using var ms = new MemoryStream();
            Assert.Throws<ArgumentNullException>(() => new LabelXmlSerializer().Serialize(ms, null));
        }

        [Fact]
        public void LabelXmlSerializerSerializeThrowsWhenStreamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new LabelXmlSerializer().Serialize(null, new Label()));
        }

        [Fact]
        public void LabelXmlSerializeSerializeContainsChildContentNode()
        {
            var sut = new LabelXmlSerializer();
            using var ms = new MemoryStream();
            using var reader = new StreamReader(ms);
            var label = new Label
            {
                Content =
                {
                    new TextElement
                    {
                        Content = "Hello World"
                    }
                }
            };

            sut.Serialize(ms, label);
            ms.Seek(0, SeekOrigin.Begin);

            string xml = reader.ReadToEnd();
            Assert.Contains("<Text>", xml);
        }

        [Fact]
        public void LabelXmlSerializerDeserializeThrowsWhenStreamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new LabelXmlSerializer().Deserialize(null));
        }

        [Fact]
        public void LabelXmlSerializerDeserializesSimpleLabel()
        {
            var sut = new LabelXmlSerializer();
            var bytes = Encoding.UTF8.GetBytes("<Label />");
            
            using var ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);

            var label = sut.Deserialize(ms);

            Assert.NotNull(label);
            Assert.IsType<Label>(label);
        }
    }
}
