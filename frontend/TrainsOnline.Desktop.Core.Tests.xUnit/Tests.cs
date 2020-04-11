using System.Threading.Tasks;

using TrainsOnline.Desktop.Core.Services;

using Xunit;

namespace TrainsOnline.Desktop.Core.Tests.XUnit
{
    // TODO WTS: Add appropriate unit tests.
    public class Tests
    {
        [Fact]
        public void Test1()
        {
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async void EnsureSampleDataServiceReturnsGridDataAsync()
        {
            System.Collections.Generic.IEnumerable<Models.SampleOrder> actual = await SampleDataService.GetGridDataAsync();

            Assert.NotEmpty(actual);
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsMasterDetailDataAsync()
        {
            System.Collections.Generic.IEnumerable<Models.SampleOrder> actual = await SampleDataService.GetMasterDetailDataAsync();

            Assert.NotEmpty(actual);
        }

        // TODO WTS: Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async void EnsureSampleDataServiceReturnsTreeViewDataAsync()
        {
            System.Collections.Generic.IEnumerable<Models.SampleCompany> actual = await SampleDataService.GetTreeViewDataAsync();

            Assert.NotEmpty(actual);
        }
    }
}
