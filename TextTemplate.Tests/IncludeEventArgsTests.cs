﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace TextTemplate.Tests
{
    [TestFixture]
    public class IncludeEventArgsTests
    {
        [TestCase((string)null)]
        [TestCase("")]
        [TestCase(" \t\r\n ")]
        public void Constructor_NullOrEmptyName_ThrowsArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => new IncludeEventArgs(input));
        }
    }
}