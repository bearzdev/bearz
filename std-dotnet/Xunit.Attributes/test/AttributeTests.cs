using Xunit;

namespace Tests
{
    public class AttributeTests
    {
        private static readonly IAssert Assert = FlexAssert.Default;

        [UnitTest]
        public void Verify_UnitTestAttributeWorks()
        {
            const int left = 10, right = 20;
            Assert.NotEqual(left, right);
        }

        [IntegrationTest]
        public void Verify_IntegrationTestAttributeWorks()
        {
            const int left = 11, right = 21;
            Assert.NotEqual(left, right);
        }

        [FunctionalTest]
        public void Verify_FunctionalTestAttributeWorks()
        {
            const int left = 13, right = 23;
            Assert.NotEqual(left, right);
        }

        [UITest]
        public void Verify_UITestAttributeWorks()
        {
            const int left = 13, right = 24;
            Assert.NotEqual(left, right);
        }

        [UnitTest]
        [RequireOsArchitectures(TestOsArchitectures.Arm64)]
        public void Verify_SkipOnArchAttributeWorks()
        {
            const int left = 14, right = 24;
            Assert.NotEqual(left, right);
        }

        [UnitTest]
        [RequireTargetFrameworks("net472")]
        public void Verify_SkipOnTargetFrameworkAttributeWorks()
        {
            const int left = 14, right = 25;
            Assert.NotEqual(left, right);
        }

        [UnitTest]
        [RequireTargetFrameworks("> net5.0")]
        public void Verify_SkipOnTargetFrameworkAttributeWithCompare()
        {
            const int left = 14, right = 28;
            Assert.NotEqual(left, right);
        }

        [UnitTest]
        [RequireOsPlatforms(TestOsPlatforms.Linux)]
        public void Verify_SkipOnLinux()
        {
            const int left = 8, right = 30;
            Assert.NotEqual(left, right);
        }

        [UnitTest]
        [RequireOsPlatforms(TestOsPlatforms.Windows)]
        public void Verify_SkipOnWindows()
        {
            const int left = 8, right = 33;
            Assert.NotEqual(left, right);
        }

        [Fact]
        public void Verify_FactAttributeWorks()
        {
            const int left = 10, right = 21;
            Assert.NotEqual(left, right);
        }

        [InlineData(1, 11)]
        [Theory]
        public void Verify_TheoryAttributeWorks(int left, int right)
        {
            Assert.NotEqual(left, right);
        }
    }
}