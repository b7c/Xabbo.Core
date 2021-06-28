﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Xabbo.Core.Web
{
    public class ErrorInfos
    {
        [JsonPropertyName("error")]
        public string Error { get; set; } = string.Empty;

        [JsonPropertyName("errors")]
        public List<ErrorInfo> Errors { get; set; } = new();
    }
}
