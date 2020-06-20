using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDataTests
{
    [Test]
    public void TileData_Instantiation_IsNotNull()
    {
        TileData tileData = new TileData();
        Assert.NotNull(tileData);
    }
}
