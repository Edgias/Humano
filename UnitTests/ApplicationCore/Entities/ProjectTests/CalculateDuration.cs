using Edgias.Humano.UnitTests.Builders;

namespace Edgias.Humano.UnitTests.ApplicationCore.Entities.ProjectTests
{
    public class CalculateDuration
    {
        [Fact]
        public void IsCorrectGiven1Project()
        {
            var builder = new ProjectBuilder();
            var project = builder.WithDefaultValues();

            Assert.Equal(2880, project.DurationInHours());
        }
    }
}
