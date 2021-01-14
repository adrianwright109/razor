﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Composition;
using Microsoft.Extensions.Logging;

namespace Microsoft.VisualStudio.LanguageServerClient.Razor.Feedback
{
    [Shared]
    [Export(typeof(HTMLCSharpLanguageServerFeedbackFileLoggerProvider))]
    internal class HTMLCSharpLanguageServerFeedbackFileLoggerProvider : ILoggerProvider
    {
        private static readonly string LogFileIdentifier = "HTMLCSharpLanguageServer";

        private readonly FeedbackFileLoggerProvider _loggerProvider;

        [ImportingConstructor]
        public HTMLCSharpLanguageServerFeedbackFileLoggerProvider(
            HTMLCSharpLanguageServerFeedbackFileLoggerProviderFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _loggerProvider = (FeedbackFileLoggerProvider)loggerFactory.GetOrCreate(LogFileIdentifier);
        }

        public ILogger CreateLogger(string categoryName) => _loggerProvider.CreateLogger(categoryName);

        public void Dispose()
        {
        }
    }
}