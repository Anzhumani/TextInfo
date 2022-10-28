namespace TextInfo.Tests
{
    [TestClass]
    public class TextInfoTests
    {
        [TestMethod]
        public void SortString_btacza_return_aabctz()
        {
            // arrange
            string text = "btacza";
            string expected = "aabctz";


            // action
            string actual = SortString(text, false);

            // assert
            Assert.AreEqual(expected, actual);
        }
        public static string SortString(string input, bool reverse) // Этот метод выполняет сортировку строки. Если true - по убыванию, иначе - по возрастанию
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            if (reverse)
                Array.Reverse(characters);
            return new string(characters);
        }
    }
}