using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BattleFieldUnitTests
{
    [TestMethod]
    public void IsValidBattleFieldWithSize5()
    {
        bool isValid = BattleField.BattleField.isValidFieldSize(5);

        Assert.IsTrue(isValid, "Invalid battle field size.\n");
    }

    [TestMethod]
    public void IsValidBattleFieldWithSize11()
    {
        bool isInvalid = !BattleField.BattleField.isValidFieldSize(11);

        Assert.IsTrue(isInvalid, "Invalid battle field size.\n");
    }


    [TestMethod]
    public void BuildBattleFieldWithSize3()
    {
    }
}
