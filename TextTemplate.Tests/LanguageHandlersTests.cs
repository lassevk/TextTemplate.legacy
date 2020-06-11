﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace TextTemplate.Tests
{
    [TestFixture]
    public class LanguageHandlersTests
    {
        public class DummyLanguageHandler : ITemplateLanguageHandler
        {
            public Assembly RewriteAndCompile(string language, IEnumerable<string> namespaceImports, IEnumerable<string> assemblyReferences, IEnumerable<string> codeParts, Type parameterType, string parameterName, out string code)
            {
                throw new NotImplementedException();
            }
        }

        public abstract class AbstractDummyLanguageHandler : ITemplateLanguageHandler
        {
            public Assembly RewriteAndCompile(string language, IEnumerable<string> namespaceImports, IEnumerable<string> assemblyReferences, IEnumerable<string> codeParts, Type parameterType, string parameterName, out string code)
            {
                throw new NotImplementedException();
            }
        }

        public class GenericDummyLanguageHandler<T> : ITemplateLanguageHandler
        {
            public Assembly RewriteAndCompile(string language, IEnumerable<string> namespaceImports, IEnumerable<string> assemblyReferences, IEnumerable<string> codeParts, Type parameterType, string parameterName, out string code)
            {
                throw new NotImplementedException();
            }
        }

        [TestCase((string)null)]
        [TestCase("")]
        [TestCase(" \t\r\n ")]
        public void RegisterHandler_NullOrEmptyLanguageName_ThrowsArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => LanguageHandlers.RegisterHandler(input, typeof(DummyLanguageHandler)));
        }

        [Test]
        public void RegisterHandler_NullHandlerType_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => LanguageHandlers.RegisterHandler("LANG1", null));
        }

        [Test]
        public void RegisterHandler_AbstractHandlerType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => LanguageHandlers.RegisterHandler("LANG2", typeof(AbstractDummyLanguageHandler)));
        }

        [Test]
        public void RegisterHandler_GenericHandlerType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => LanguageHandlers.RegisterHandler("LANG3", typeof(GenericDummyLanguageHandler<string>)));
        }

        [Test]
        public void GetRegisteredHandlers_IncludesRegisteredHandler()
        {
            LanguageHandlers.RegisterHandler("LANG4", typeof(DummyLanguageHandler));

            Assert.That(LanguageHandlers.GetRegisteredHandlers().ContainsKey("LANG4"), Is.True);
        }
    }
}