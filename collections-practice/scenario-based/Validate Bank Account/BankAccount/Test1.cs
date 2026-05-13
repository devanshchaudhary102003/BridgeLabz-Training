using System;
namespace BankAccount;

[TestClass]
public class Teat1
{
    [TestMethod]
    public void Test_Deposit_ValidAmount()
    {
        //Arrange
        BankAccountApp bank = new BankAccountApp(100);

        //Act
        bank.Deposit(250);

        //Assert
        Assert.AreEqual(350,bank.InitialBalance);
    }

    [TestMethod]
    public void Test_Deposit_NegativeAmount()
    {
        //Arrange
        BankAccountApp bank = new BankAccountApp(100);

        //Act
        try
        {
            bank.Deposit(-50);
        }
        catch(Exception ex)
        {
            //Assert
            Assert.AreEqual("Deposit amount cannot be negative",ex.Message);
        }
    }

    [TestMethod]
    public void Test_Withdraw_ValidAmount()
    {
        //Arrange
        BankAccountApp bank = new BankAccountApp(100);

        //Act
        bank.Withdraw(50);

        //Assert
        Assert.AreEqual(50,bank.InitialBalance);
    }

    [TestMethod]
    public void Test_Withdraw_NegaticeAmount()
    {
        //Arrange
        BankAccountApp bank = new BankAccountApp(200);

        //Act
        try
        {
            bank.Withdraw(250);
        }
        catch(Exception ex)
        {
            //Assert
            Assert.AreEqual("Insufficient Funds",ex.Message);
        }
    }
}