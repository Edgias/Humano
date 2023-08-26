using Edgias.Humano.UnitTests.Builders;

namespace Edgias.Humano.UnitTests.ApplicationCore.Entities.ProjectTests
{
    public class CalculateTimeTaken
    {
        [Fact]
        public void IsCorrectGiven3Timesheets()
        {
            var builder = new ProjectBuilder();
            var project = builder.WithTimesheets();

            Assert.Equal(938, project.TimeTaken());
        }
    }
}
