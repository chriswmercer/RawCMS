﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using System;

namespace RawCMS.Client.BLL.Model
{
    public class ConfigFile
    {
        public string Token { get; set; }
        public string ServerUrl { get; set; }
        public string User { get; set; }
        public string CreatedTime { get; set; }

        public ConfigFile()
        {
        }

        public ConfigFile(string content)
        {
            try
            {
                ConfigFile cf = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigFile>(content);
                Token = cf.Token;
                ServerUrl = cf.ServerUrl;
                User = cf.User;
                CreatedTime = cf.CreatedTime;
            }
            catch (Exception)
            {
                Token = "";
                ServerUrl = "";
                User = "";
                CreatedTime = "";
            }
        }
    }
}