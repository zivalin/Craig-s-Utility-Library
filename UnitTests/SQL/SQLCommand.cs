﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Utilities.SQL;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Linq.Expressions;
using System.Data;
using Utilities.DataTypes.ExtensionMethods;
using Utilities.SQL.ParameterTypes;

namespace UnitTests.SQL
{
    public class SQLCommand
    {
        [Fact]
        public void SelectTest()
        {
            Utilities.SQL.MicroORM.Command BuiltCommand = Utilities.SQL.SQLCommand.Select("Test").Distinct().Where("Value1=@0", "@", "Test").Build();
            Assert.Equal("SELECT DISTINCT * FROM Test WHERE Value1=@0", BuiltCommand.SQLCommand);
            Assert.Contains(new StringEqualParameter("Test", "@0", 4), BuiltCommand.Parameters);
        }
    }
}