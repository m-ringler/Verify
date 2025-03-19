﻿namespace VerifyXunit;

public partial class VerifyBase
{
    [Pure]
    public Combination Combination(
        bool? captureExceptions = null,
        VerifySettings? settings = null,
        bool header = false,
        [CallerFilePath] string sourceFile = "") =>
        Verifier.Combination(captureExceptions, settings ?? this.settings, header, sourceFile);
}