using FluentAssertions;
using Tateti.Domain;
using Xunit;

namespace Tateti.Test
{
    public class PlayerShould
    {
        private readonly Player _player = new Player((board) => { });

        [Theory]
        [InlineData(MarkTypeEnum.Circle)]
        [InlineData(MarkTypeEnum.Cross)]
        public void Assign_Mark(MarkTypeEnum markType)
        {
            _player.AssignMark(markType);

            _player.MarkType.Should().Be(markType);
        }
    }
}
