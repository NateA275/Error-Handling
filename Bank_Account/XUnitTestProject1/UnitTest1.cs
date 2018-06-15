using System;
using Xunit;
using Bank_Account;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2)]
        [InlineData(1500)]
        [InlineData(12.50)]
        public void CanSetInitialBalance(decimal initialVal)
        {
            //Arrange
            Program.balance = initialVal;

            //Act
            decimal currentBalance = Program.balance;

            //Assert
            Assert.Equal(initialVal, currentBalance);
        }

        [Theory]
        [InlineData(50)]
        [InlineData(27.50)]
        [InlineData(500.22)]
        public void GetBalanceMethodReturnsCurrentBalance(decimal initValue)
        {
            //Arrange
            Program.balance = initValue;

            //Act
            decimal retrievedVal = Program.GetBalance();

            //Assert
            Assert.Equal(initValue, retrievedVal);

        }

        [Theory]
        [InlineData(50, 50)]
        [InlineData(20.25, 31.75)]
        [InlineData(0, 12.50)]
        public void AddToBalanceIncreasesBalance(decimal initValue, decimal addedAmount)
        {
            //Arrange
            Program.balance = initValue;

            //Act
            Program.AddToBalance(addedAmount);
            decimal currentBalance = Program.GetBalance();


            //Assert
            Assert.Equal(initValue + addedAmount, currentBalance);

        }

        [Theory]
        [InlineData(50, 50)]
        [InlineData(20.25, 2.50)]
        [InlineData(12.50, 0)]
        public void SubtractFromBalanceDecreasesBalance(decimal initValue, decimal subtractedAmount)
        {
            //Arrange
            Program.balance = initValue;

            //Act
            Program.SubtractFromBalance(subtractedAmount);
            decimal currentBalance = Program.GetBalance();

            //Assert
            Assert.Equal(initValue - subtractedAmount, currentBalance);

        }
    }
}
