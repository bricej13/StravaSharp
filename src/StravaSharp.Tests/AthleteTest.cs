using NUnit.Framework;
using System.Threading.Tasks;

namespace StravaSharp.Tests
{
    /// <summary>
    /// Athlete tests
    /// Access token is read-write for gabor.nemeth.dev@gmail.com (Extrava Test Account)
    /// </summary>
    [TestFixture]
    public class AthleteTest : BaseTest
    {
        private const int TestAthleteId = 4076458; // gabor.nemeth1982@gmail.com

        [Test]
        public async Task GetCurrentAthlete()
        {
            var athlete = await Client.Athletes.GetCurrent();
            Assert.NotNull(athlete);
            Assert.IsTrue(athlete.FirstName == "Extrava" || athlete.FirstName == "Test");
        }

        [Test]
        public async Task GetAthlete()
        {
            var athlete = await Client.Athletes.Get((await Client.Athletes.GetCurrent()).Id);
            Assert.NotNull(athlete);
            Assert.IsTrue( athlete.FirstName == "Extrava" || athlete.FirstName=="Test");
        }
    }
}
