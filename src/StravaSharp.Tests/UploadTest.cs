using NUnit.Framework;
using System.Threading.Tasks;

namespace StravaSharp.Tests
{
    [TestFixture("2011-08-10-17-51-31.fit")]
    [TestFixture("gabornemeth.2018-04-21-20-04-57-385Z.GarminPush.19873008881.fit")]
    public class UploadTest : BaseTest
    {
        private readonly string _fileName;

        public UploadTest(string fileName)
        {
            _fileName = fileName;
        }


        [Test]
#if !DEBUG
        [Ignore("Delete requires application level permission.")]
#endif
        public async Task Upload()
        {
            if (Settings.GaborTokenUnavailable)
            {
                Assert.Ignore("Not running tests requiring tokens from Settings");
            }

            using (var stream = Resource.GetStream(_fileName))
            {
                Assert.NotNull(stream);
                // upload the activity (as private)
                var result = await Client.Activities.Upload(ActivityType.Ride, DataType.Fit, stream, _fileName, null, null, true);
                Assert.IsNotNull(result);
                Assert.True(string.IsNullOrEmpty(result.Error));
                // wait till upload has completed
                while (result.ActivityId == 0 && result.IsReady == false && string.IsNullOrEmpty(result.Error))
                {
                    result = await Client.Activities.GetUploadStatus(result.Id);
                    await Task.Delay(1000);
                }
                Assert.True(string.IsNullOrEmpty(result.Error));
            }
        }
    }
}
