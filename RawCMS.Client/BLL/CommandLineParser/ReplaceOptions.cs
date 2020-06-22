﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using CommandLine;

namespace RawCMS.Client.BLL.CommandLineParser
{
    [Verb("replace", HelpText = "Replace data inside collection. Type replace for more help.")]
    public class ReplaceOptions
    {
        [Option('v', "verbose", Default = false, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('c', "collection", Required = true, HelpText = "Collection where to do the operation.")]
        public string Collection { get; set; }

        [Option('i', "id", Required = false, HelpText = "object id to replace.")]
        public string Id { get; set; }

        [Option('k', "key-id", Required = false, HelpText = "the name of key id instead of default id.")]
        public string KeyId { get; set; }

        [Option('f', "file", SetName = "file", HelpText = "Fle contains data to replace into collection. it can be a json file well-formatted.")]
        public string FilePath { get; set; }

        [Option('d', "folder", SetName = "file", HelpText = "Folder contains data to replace into collection. it can be a json file well-formatted.")]
        public string FolderPath { get; set; }

        [Option('r', "recursive", Required = false, HelpText = "Fle path contains data to replace into collection. it can be a json file well-formatted.")]
        public bool Recursive { get; set; }

        [Option('t', "dry-run", Required = false, HelpText = "do not perform any operations, just make a try.")]
        public bool DryRun { get; set; }
    }
}