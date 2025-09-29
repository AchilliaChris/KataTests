using KataTests;

namespace KataMethodTests
{
    public class UnitTests
    {
        private KataMethods CreateKataMethodsWithBoard(char?[] board)
        {
            var kata = new KataMethods();
            for (int i = 0; i < board.Length; i++)
                kata.board[i] = board[i];
            return kata;
        }

        [Fact]
        public void DisplayBoard_Returns_Correct_List_of_String_For_Empty_Board()
        {
            var kata = new KataMethods();
            var result = kata.DisplayBoard();
            Assert.Equal(7, result.Count);
            Assert.All(result, s => Assert.IsType<string>(s));
            Assert.Equal("-------", result[0]);
            Assert.Equal("-------", result[2]);
            Assert.Equal("-------", result[4]);
            Assert.Equal("-------", result[6]);
        }

        [Fact]
        public void DisplayBoard_Returns_Correct_List_of_String_For_Filled_Board()
        {
            var board = new char?[] { 'X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', 'X' };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.DisplayBoard();
            Assert.Contains("|X|O|X|", result);
            Assert.Contains("|O|X|O|", result);
            Assert.Contains("|X|O|X|", result);
        }

        [Fact]
        public void CheckForWin_Returns_Winner_When_Three_In_A_Row()
        {
            var board = new char?[] { 'X', 'X', 'X', null, null, null, null, null, null };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.checkForWin(1, 2, 3);
            Assert.Equal('X', result);
        }

        [Fact]
        public void CheckForWin_Returns_Null_When_Not_All_Filled()
        {
            var board = new char?[] { 'X', null, 'X', null, null, null, null, null, null };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.checkForWin(1, 2, 3);
            Assert.Null(result);
        }

        [Fact]
        public void CheckForWin_Returns_Null_When_Not_Matching()
        {
            var board = new char?[] { 'X', 'O', 'X', null, null, null, null, null, null };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.checkForWin(1, 2, 3);
            Assert.Null(result);
        }

        [Fact]
        public void CheckBoard_Returns_Winner_When_Exists()
        {
            var board = new char?[] { 'O', 'O', 'O', null, null, null, null, null, null };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.CheckBoard();
            Assert.Equal('O', result);
        }

        [Fact]
        public void CheckBoard_Returns_Null_When_No_Winner()
        {
            var board = new char?[] { 'X', 'O', 'X', 'O', 'X', 'O', 'O', 'X', 'O' };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.CheckBoard();
            Assert.Null(result);
        }

        [Fact]
        public void GetPosition_Returns_Valid_Index()
        {
            var kata = new KataMethods();
            for (int i = 0; i < 100; i++)
            {
                int pos = kata.GetPosition();
                Assert.InRange(pos, 0, 8);
            }
        }

        [Fact]
        public void GetRow_Returns_Correct_String_For_Empty_Row()
        {
            var kata = new KataMethods();
            var result = kata.GetRow(0);
            Assert.Equal("| | | |", result);
        }

        [Fact]
        public void GetRow_Returns_Correct_String_For_Filled_Row()
        {
            var board = new char?[] { 'X', 'O', 'X', null, null, null, null, null, null };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.GetRow(0);
            Assert.Equal("|X|O|X|", result);
        }

        [Fact]
        public void GetRow_Returns_Correct_String_For_Middle_Row()
        {
            var board = new char?[] { null, null, null, 'O', 'X', 'O', null, null, null };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.GetRow(3);
            Assert.Equal("|O|X|O|", result);
        }

        [Fact]
        public void GetRow_Returns_Correct_String_For_Last_Row()
        {
            var board = new char?[] { null, null, null, null, null, null, 'X', 'O', 'X' };
            var kata = CreateKataMethodsWithBoard(board);
            var result = kata.GetRow(6);
            Assert.Equal("|X|O|X|", result);
        }
    }
}