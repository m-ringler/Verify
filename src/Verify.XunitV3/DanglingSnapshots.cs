﻿namespace VerifyXunit;

[Experimental("VerifyDanglingSnapshots")]
public static class DanglingSnapshots
{
    public static void Run() => DanglingSnapshotsCheck.Run();
}