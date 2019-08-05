﻿//
// ActivityTest.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2015, Gabor Nemeth
//

using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StravaSharp.Tests
{
    [TestFixture]
    public class PolylineTest : BaseTest
    {
        [Test]
        public async Task DecodeMap()
        {
            var activities = await Client.Activities.GetAthleteActivities();
            Assert.True(activities.Count > 0);
            var activity = activities.FirstOrDefault(a => a.Map?.SummaryPolyline != null);
            Assert.NotNull(activity);
            activity = await Client.Activities.Get(activity.Id);
            Assert.NotNull(activity);
            var points = SharpGeo.Google.PolylineEncoder.Decode(activity.Map.SummaryPolyline);
            Assert.NotNull(points);
            Assert.True(points.Count > 0);
        }
    }
}
