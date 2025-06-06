﻿public class ParametersHashSample
{
    #region UseParametersHashInstanceXunit

    [Theory]
    [InlineData("Value1")]
    [InlineData("Value2")]
    public Task HashParametersUsage(string arg)
    {
        var settings = new VerifySettings();
        settings.UseParameters(arg);
        settings.HashParameters();
        return Verify(arg, settings);
    }

    #endregion

    #region UseParametersHashFluentXunit

    [Theory]
    [InlineData("Value1")]
    [InlineData("Value2")]
    public Task HashParametersUsageFluent(string arg) =>
        Verify(arg)
            .UseParameters(arg)
            .HashParameters();

    #endregion
}