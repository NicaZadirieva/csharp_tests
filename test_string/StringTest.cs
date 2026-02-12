namespace test_string
{
    
    public class StringTest
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        [Theory]
        [InlineData(" ", "")]
        [InlineData("dada     ", "dada")]
        [InlineData("   dada     ", "dada")]
        public void Should_ReplaceWhitespaces(string a, string expected)
        {
            var result = a.Replace(" ", "");
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(" ", " ")]
        [InlineData("data", "atad")]
        [InlineData("dada     ", "     adad")]
        public void Should_ReverseStrings(string a, string expected)
        {
            var result = Reverse(a);
            Assert.Equal(expected, result);
        }
    }
}
