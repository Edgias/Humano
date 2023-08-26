using Edgias.Humano.UnitTests.Builders;

namespace Edgias.Humano.UnitTests.ApplicationCore.Entities.ProjectTests
{
    public class CalculatePercentageComplete
    {
        [Fact]
        public void IsCorrectGivenRelatedTimesheets()
        {
            var builder = new ProjectBuilder();
            var project = builder.WithTimesheets();

            Assert.Equal(32.57M, project.PercentageComplete());
        }
    }
}
