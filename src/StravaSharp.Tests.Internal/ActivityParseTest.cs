using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace StravaSharp.Tests
{
    [TestFixture("activity_watersport.json")]
    public class ActivityParseTest
    {
        private readonly string _resourceName;

        public ActivityParseTest(string resourceName)
        {
            _resourceName = resourceName;
        }

        [Test]
        public void Parse()
        {
            var serializer = new JsonSerializer() { ObjectCreationHandling = ObjectCreationHandling.Reuse };
            using (var stream = Resource.GetStream(_resourceName))
            {
                var reader = new JsonTextReader(new StreamReader(stream));
                var result = serializer.Deserialize<Activity>(reader);
                Assert.NotNull(result);
                Assert.True(result.UploadId != 0);
            }
        }
    }

    [TestFixture]
    public class ActivityListParseTest
    {
        [Test]
        public void ParseJson()
        {
            var serializer = new JsonSerializer() { ObjectCreationHandling = ObjectCreationHandling.Reuse };
            using (var stream = Resource.GetStream("activities.json"))
            {
                var reader = new JsonTextReader(new StreamReader(stream));
                var activities = serializer.Deserialize<List<ActivitySummary>>(reader);
                Assert.NotNull(activities);
                Assert.IsNotEmpty(activities);
                Assert.AreEqual(65459843344, activities[0].UploadId);
            }
        }
    }
}
