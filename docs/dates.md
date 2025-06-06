<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/dates.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# Dates

By default dates and times (`DateTime`, `DateTimeOffset`, `DateOnly`, and `TimeOnly`) are sanitized during verification. This is done by finding each date and taking a counter based that that specific date. That counter is then used replace the date values. This allows for repeatable tests when date values are changing.

<!-- snippet: Date -->
<a id='snippet-Date'></a>
```cs
var dateTime = DateTime.Now;
var dateTimeOffset = DateTimeOffset.Now;
var target = new DateTimeTarget
{
    DateTime = dateTime,
    Date = new(dateTime.Year, dateTime.Month, dateTime.Day),
    DateNullable = new(dateTime.Year, dateTime.Month, dateTime.Day),
    DateString = new Date(dateTime.Year, dateTime.Month, dateTime.Day).ToString(),
    DateTimeNullable = dateTime,
    DateTimeString = dateTime.ToString("F"),
    DateTimeOffset = dateTimeOffset,
    DateTimeOffsetNullable = dateTimeOffset,
    DateTimeOffsetString = dateTimeOffset.ToString("F")
};

await Verify(target);
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1049-L1068' title='Snippet source file'>snippet source</a> | <a href='#snippet-Date' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in the following:

<!-- snippet: SerializationTests.ReUseDatetime.verified.txt -->
<a id='snippet-SerializationTests.ReUseDatetime.verified.txt'></a>
```txt
{
  DateTime: DateTime_1,
  DateTimeNullable: DateTime_1,
  Date: Date_1,
  DateNullable: Date_1,
  DateTimeOffset: DateTimeOffset_1,
  DateTimeOffsetNullable: DateTimeOffset_1,
  DateTimeString: DateTimeOffset_2,
  DateTimeOffsetString: DateTimeOffset_2,
  DateString: Date_1
}
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.ReUseDateTime.verified.txt#L1-L11' title='Snippet source file'>snippet source</a> | <a href='#snippet-SerializationTests.ReUseDatetime.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

To disable this behavior use:


### Instance

<!-- snippet: DontScrubDateTimes -->
<a id='snippet-DontScrubDateTimes'></a>
```cs
var target = new
{
    Date = new DateTime(2020, 10, 10, 0, 0, 0, DateTimeKind.Utc)
};

var settings = new VerifySettings();
settings.DontScrubDateTimes();

return Verify(target, settings);
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1713-L1725' title='Snippet source file'>snippet source</a> | <a href='#snippet-DontScrubDateTimes' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Fluent

<!-- snippet: DontScrubDateTimesFluent -->
<a id='snippet-DontScrubDateTimesFluent'></a>
```cs
var target = new
{
    Date = new DateTime(2020, 10, 10, 0, 0, 0, DateTimeKind.Utc)
};

return Verify(target)
    .DontScrubDateTimes();
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1731-L1741' title='Snippet source file'>snippet source</a> | <a href='#snippet-DontScrubDateTimesFluent' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Globally

<!-- snippet: DontScrubDateTimesGlobal -->
<a id='snippet-DontScrubDateTimesGlobal'></a>
```cs
[ModuleInitializer]
public static void ModuleInitializer() =>
    VerifierSettings.DontScrubDateTimes();
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1799-L1805' title='Snippet source file'>snippet source</a> | <a href='#snippet-DontScrubDateTimesGlobal' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## DisableDateCounting

If many calls are made to the current date/time in quick succession, the date counting behavior (`DateTime_x`) can result in inconsistent results. To revert to the simpler scrubbing convention (`{Scrubbed}`) use DisableDateCounting.


### Instance

<!-- snippet: DisableDateCounting -->
<a id='snippet-DisableDateCounting'></a>
```cs
var target = new
{
    Date = new DateTime(2020, 10, 10, 0, 0, 0, DateTimeKind.Utc)
};

var settings = new VerifySettings();
settings.DisableDateCounting();

return Verify(target, settings);
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1760-L1772' title='Snippet source file'>snippet source</a> | <a href='#snippet-DisableDateCounting' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Fluent

<!-- snippet: DisableDateCountingFluent -->
<a id='snippet-DisableDateCountingFluent'></a>
```cs
var target = new
{
    Date = new DateTime(2020, 10, 10, 0, 0, 0, DateTimeKind.Utc)
};

return Verify(target)
    .DisableDateCounting();
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1778-L1788' title='Snippet source file'>snippet source</a> | <a href='#snippet-DisableDateCountingFluent' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Globally

<!-- snippet: DisableDateCountingGlobal -->
<a id='snippet-DisableDateCountingGlobal'></a>
```cs
[ModuleInitializer]
public static void ModuleInitializer() =>
    VerifierSettings.DisableDateCounting();
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1747-L1753' title='Snippet source file'>snippet source</a> | <a href='#snippet-DisableDateCountingGlobal' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## AddExtraDateTimeFormat

`AddExtraDateTimeFormat` allows specifying custom date formats to be scrubbed.

<!-- snippet: AddExtraDateTimeFormat -->
<a id='snippet-AddExtraDateTimeFormat'></a>
```cs
[ModuleInitializer]
public static void UseAddExtraDateTimeFormat() =>
    VerifierSettings.AddExtraDateTimeFormat("yyyy-MM-dd");

[Fact]
public Task WithExtraDateTimeFormat() =>
    Verify(
        new
        {
            date = "2022-11-08"
        });
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L42-L56' title='Snippet source file'>snippet source</a> | <a href='#snippet-AddExtraDateTimeFormat' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Inline Dates

Strings containing inline dates can also be scrubbed. There a equivalent APIs for `DateOnly`, `DateTime`, and `DateTimeOffset`.


### Instance

<!-- snippet: ScrubInlineDateTimesInstance -->
<a id='snippet-ScrubInlineDateTimesInstance'></a>
```cs
[Fact]
public Task ScrubInlineDateTimesInstance()
{
    var settings = new VerifySettings();
    settings.ScrubInlineDateTimes("yyyy-MM-dd");
    return Verify(
        "content 2020-10-20 content",
        settings);
}
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1683-L1695' title='Snippet source file'>snippet source</a> | <a href='#snippet-ScrubInlineDateTimesInstance' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Fluent

<!-- snippet: ScrubInlineDateTimesFluent -->
<a id='snippet-ScrubInlineDateTimesFluent'></a>
```cs
[Fact]
public Task ScrubInlineDateTimesFluent() =>
    Verify("content 2020-10-20 content")
        .ScrubInlineDateTimes("yyyy-MM-dd");
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1674-L1681' title='Snippet source file'>snippet source</a> | <a href='#snippet-ScrubInlineDateTimesFluent' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Globally

<!-- snippet: ScrubInlineDateTimesGlobal -->
<a id='snippet-ScrubInlineDateTimesGlobal'></a>
```cs
public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init() =>
        VerifierSettings.ScrubInlineDateTimes("yyyy-MM-dd");
}
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1662-L1671' title='Snippet source file'>snippet source</a> | <a href='#snippet-ScrubInlineDateTimesGlobal' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Named Date and Times

Specific date or times can be named. When any of those values are found, they will be matched with the corresponding name.


### Instance

<!-- snippet: NamedDatesAndTimesInstance -->
<a id='snippet-NamedDatesAndTimesInstance'></a>
```cs
var settings = new VerifySettings();
settings.AddNamedDate(new(2020, 10, 11), "instanceNamedDate");
settings.AddNamedTime(new(1, 2), "instanceTime");
settings.AddNamedDateTime(new(2030, 1, 2), "instanceNamedDateTime");
settings.AddNamedDateTimeOffset(new DateTime(2030, 1, 2), "instanceNamedTimeOffset");
await Verify(target, settings);
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1231-L1240' title='Snippet source file'>snippet source</a> | <a href='#snippet-NamedDatesAndTimesInstance' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Instance

<!-- snippet: NamedDatesAndTimesFluent -->
<a id='snippet-NamedDatesAndTimesFluent'></a>
```cs
await Verify(target)
    .AddNamedDate(new(2020, 10, 11), "instanceNamedDate")
    .AddNamedTime(new(1, 2), "instanceTime")
    .AddNamedDateTime(new(2030, 1, 2), "instanceNamedDateTime")
    .AddNamedDateTimeOffset(new DateTime(2030, 1, 2), "instanceNamedTimeOffset");
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1188-L1196' title='Snippet source file'>snippet source</a> | <a href='#snippet-NamedDatesAndTimesFluent' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Globally

<!-- snippet: NamedDatesAndTimesGlobal -->
<a id='snippet-NamedDatesAndTimesGlobal'></a>
```cs
[ModuleInitializer]
public static void NamedDatesAndTimesGlobal()
{
    VerifierSettings.AddNamedDateTime(new(2030, 1, 1), "namedDateTime");
    VerifierSettings.AddNamedTime(new(1, 1), "namedTime");
    VerifierSettings.AddNamedDate(new(2030, 1, 1), "namedDate");
    VerifierSettings.AddNamedDateTimeOffset(new(new(2030, 1, 1)), "namedDateTimeOffset");
}
```
<sup><a href='/src/Verify.Tests/Serialization/SerializationTests.cs#L1143-L1154' title='Snippet source file'>snippet source</a> | <a href='#snippet-NamedDatesAndTimesGlobal' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Inferred Name

The name can be inferred from the variable name by omitting the name argument:

<!-- snippet: InferredNamedDateFluent -->
<a id='snippet-InferredNamedDateFluent'></a>
```cs
[Fact]
public Task InferredNamedDateFluent()
{
    var namedDate = new Date(1935, 10, 1);
    return Verify(
            new
            {
                value = namedDate
            })
        .AddNamedDate(namedDate);
}
```
<sup><a href='/src/Verify.Tests/DateScrubberTests.cs#L277-L291' title='Snippet source file'>snippet source</a> | <a href='#snippet-InferredNamedDateFluent' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Result: 

<!-- snippet: DateScrubberTests.InferredNamedDateFluent.verified.txt -->
<a id='snippet-DateScrubberTests.InferredNamedDateFluent.verified.txt'></a>
```txt
{
  value: namedDate
}
```
<sup><a href='/src/Verify.Tests/DateScrubberTests.InferredNamedDateFluent.verified.txt#L1-L3' title='Snippet source file'>snippet source</a> | <a href='#snippet-DateScrubberTests.InferredNamedDateFluent.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Custom Comparers

The following comparers can be overridden


### DateTime

Default Comparer:

<!-- snippet: DateTimeComparer -->
<a id='snippet-DateTimeComparer'></a>
```cs
class DateTimeComparer : IEqualityComparer<DateTime>
{
    public bool Equals(DateTime x, DateTime y) =>
        x == y &&
        x.Kind == y.Kind;

    public int GetHashCode(DateTime obj) =>
        obj.GetHashCode() + (int) obj.Kind;
}
```
<sup><a href='/src/Verify/Counter_DateTime.cs#L15-L25' title='Snippet source file'>snippet source</a> | <a href='#snippet-DateTimeComparer' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Custom Comparer:

<!-- snippet: CustomDateTimeComparer -->
<a id='snippet-CustomDateTimeComparer'></a>
```cs
[ModuleInitializer]
public static void UseCustomDateTimeComparer() =>
    Counter.UseDateTimeComparer(new CustomDateTimeComparer());

public class CustomDateTimeComparer :
    IEqualityComparer<DateTime>
{
    public bool Equals(DateTime x, DateTime y) =>
        new DateTime(x.Year, x.Month, x.Day) ==
        new DateTime(y.Year, y.Month, y.Day);

    public int GetHashCode(DateTime date) =>
        new DateTime(date.Year, date.Month, date.Day).GetHashCode();
}
```
<sup><a href='/src/StaticSettingsTests/CustomDateCompareTests.cs#L4-L21' title='Snippet source file'>snippet source</a> | <a href='#snippet-CustomDateTimeComparer' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### DateTimeOffset

Default Comparer:

<!-- snippet: DateTimeOffsetComparer -->
<a id='snippet-DateTimeOffsetComparer'></a>
```cs
class DateTimeOffsetComparer :
    IEqualityComparer<DateTimeOffset>
{
    public bool Equals(DateTimeOffset x, DateTimeOffset y) =>
        x == y && x.Offset == y.Offset;

    public int GetHashCode(DateTimeOffset obj) =>
        obj.GetHashCode() + (int) obj.Offset.TotalMinutes;
}
```
<sup><a href='/src/Verify/Counter_DateTimeOffset.cs#L15-L25' title='Snippet source file'>snippet source</a> | <a href='#snippet-DateTimeOffsetComparer' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Custom Comparer:

<!-- snippet: CustomDateTimeOffsetComparer -->
<a id='snippet-CustomDateTimeOffsetComparer'></a>
```cs
[ModuleInitializer]
public static void UseCustomDateTimeOffsetComparer() =>
    Counter.UseDateTimeOffsetComparer(new CustomDateTimeOffsetComparer());

public class CustomDateTimeOffsetComparer :
    IEqualityComparer<DateTimeOffset>
{
    public bool Equals(DateTimeOffset x, DateTimeOffset y) =>
        new DateTimeOffset(new(x.Year, x.Month, x.Day)) ==
        new DateTimeOffset(new(y.Year, y.Month, y.Day));

    public int GetHashCode(DateTimeOffset date)
    {
        var dateTime = new DateTime(date.Year, date.Month, date.Day);
        return new DateTimeOffset(dateTime)
            .GetHashCode();
    }
}
```
<sup><a href='/src/StaticSettingsTests/CustomDateCompareTests.cs#L42-L63' title='Snippet source file'>snippet source</a> | <a href='#snippet-CustomDateTimeOffsetComparer' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### TimeOnly

Default Comparer:

<!-- snippet: TimeComparer -->
<a id='snippet-TimeComparer'></a>
```cs
EqualityComparer<Time>.Default;
```
<sup><a href='/src/Verify/Counter_Time.cs#L14-L18' title='Snippet source file'>snippet source</a> | <a href='#snippet-TimeComparer' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Custom Comparer:

<!-- snippet: CustomTimeComparer -->
<a id='snippet-CustomTimeComparer'></a>
```cs
[ModuleInitializer]
public static void UseCustomTimeComparer() =>
    Counter.UseTimeComparer(new CustomTimeComparer());

public class CustomTimeComparer :
    IEqualityComparer<Time>
{
    public bool Equals(Time x, Time y) =>
        new Time(x.Hour, x.Minute, x.Second) ==
        new Time(y.Hour, y.Minute, y.Second);

    public int GetHashCode(Time date) =>
        new Time(date.Hour, date.Minute, date.Second).GetHashCode();
}
```
<sup><a href='/src/StaticSettingsTests/CustomDateCompareTests.cs#L23-L40' title='Snippet source file'>snippet source</a> | <a href='#snippet-CustomTimeComparer' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
