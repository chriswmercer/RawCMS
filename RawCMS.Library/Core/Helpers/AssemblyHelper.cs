﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RawCMS.Library.Core.Helpers
{
    public class AssemblyHelper
    {
        public static List<Assembly> GetAllAssembly()
        {
            List<Assembly> allAssembly = new List<Assembly>();
            allAssembly.AddRange(AppDomain.CurrentDomain.GetAssemblies());
            allAssembly.Add(Assembly.GetExecutingAssembly());
            allAssembly.Add(Assembly.GetEntryAssembly());
            return allAssembly;
        }
    }
}