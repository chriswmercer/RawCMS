﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace RawCMS.Library.Lambdas
{
    public class AuditLambda : PreSaveLambda
    {
        public override string Name => "AuditLambda";

        public override string Description => "Add audit settings";

        public override void Execute(string collection, ref JObject Item, ref Dictionary<string, object> dataContext)
        {
            if (!Item.ContainsKey("_id") || string.IsNullOrEmpty(Item["_id"].ToString()))
            {
                Item["_createdon"] = DateTime.Now;
            }

            Item["_modifiedon"] = DateTime.Now;
        }
    }
}