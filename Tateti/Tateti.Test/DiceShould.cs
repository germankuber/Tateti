using FluentAssertions;
using Tateti.Domain;
using Xunit;

namespace Tateti.Test
{
    public class DiceShould
    {
        [Fact]
        public void Throw_Value_Between_1_and_6()
        {
            var dice = new Dice();
            int value = dice.Throw();
            value.Should().BeInRange(1, 6);
        }
    }
}
