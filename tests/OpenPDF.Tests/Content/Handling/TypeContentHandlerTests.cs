﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenPDF.Content;
using OpenPDF.Content.Handling;

namespace OpenPDF.Tests.Content.Handling
{
    [TestClass]
    public class TypeContentHandlerTests
    {
        [DataTestMethod]
        [DataRow("true")]
        [DataRow("1")]
        [DataRow("some text")]
        public void HandleNonTypeContent(string input)
        {
            var sut = new TypeContentHandler(null);

            PdfObjectContent result = sut.Handle(input);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void HandleTypeContent()
        {
            const string Type = "sometype";
            var expected = new TypePdfObjectContent(Type);
            var sut = new TypeContentHandler(null);

            PdfObjectContent result = sut.Handle($"/{Type}");

            Assert.AreEqual(expected, result);
        }
    }
}
