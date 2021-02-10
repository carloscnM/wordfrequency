using Wordfrequency.APP.src;
using Xunit;

namespace Wordfrequency.Test
{

    public class WordsToolTest
    {
        [Theory]
        [InlineData("você", "voce")]
        [InlineData("módulo", "modulo")]
        [InlineData("código", "codigo")]
        [InlineData("está", "esta")]
        public void ShouldReturnWithoutAccent(string inPut, string outPut)
        {     
            Assert.Equal(WordsTool.RemoveAccent(inPut), outPut);
        }

        [Theory]
        [InlineData("voce,", "voce")]
        [InlineData("modulo.", "modulo")]
        [InlineData(",codigo", "codigo")]
        [InlineData("esta#", "esta")]
        public void ShouldResturnWithoutSpecialCharacters(string inPut, string outPut)
        {
            Assert.Equal(WordsTool.RemoveSpecialCharacters(inPut), outPut);
        }
    }
}
