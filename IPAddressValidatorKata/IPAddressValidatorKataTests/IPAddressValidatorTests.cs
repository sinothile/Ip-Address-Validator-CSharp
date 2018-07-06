using IPAddressValidatorKata;
using NUnit.Framework;


namespace IPAddressValidatorKataTests
{
    [TestFixture]
    public class IPAddressValidatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void ValidateIpv4Address_GivenEmptyOrNullIPAddress_ShouldReturnFalse(string ipAddress)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1")]
        [TestCase("5.9")]
        [TestCase("3.6.3")]
        public void ValidateIpv4Address_GivenIpAddressLessThan4Blocks_ShouldReturnFalse(string ipAddress)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1.1.1.1")]
        [TestCase("5.9.2.2")]
        [TestCase("3.6.3.4")]
        public void ValidateIpv4Address_GivenIpAddressWith4Blocks_ShouldReturnTrue(string ipAddress)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("255.255.255.255")]
        [TestCase("255.255.255.0")]
        [TestCase("1.1.1.0")]
        public void ValidateIpv4Address_GivenIpAddressThatEndsWith2550rZero_ShouldReturnFalse(string ipAddress)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
