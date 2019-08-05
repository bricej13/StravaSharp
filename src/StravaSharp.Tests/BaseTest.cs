//
// SegmentTest.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2015, Gabor Nemeth
//

using NUnit.Framework;
using System.Threading.Tasks;

namespace StravaSharp.Tests
{
    public class BaseTest
    {
        protected IStravaClient Client { get; private set; }

        [OneTimeSetUp]
        public async Task Setup()
        {
            Client = await TestHelper.StravaClientFromSettings();
        }

    }
}
