using KataTests;


namespace KataMethodTests
{
    public class UnitTests
    {
        private readonly IKataMethods kataMethods = new KataMethods();
        [Fact]
        public void display_board_returns_List_of_string()
        {
            var result = kataMethods.DisplayBoard();
            Assert.Equal(typeof(List<string>), result.GetType());
            Assert.Equal(7, result.Count());
        }
        [Fact]
        public void check_for_win_returns_nullable_char()
        {
            var result = kataMethods.checkForWin(1, 2, 3);
            Assert.Null( result?.GetType());
        }

        [Fact]
        public void check_board_returns_nullable_char()
        {
            var result = kataMethods.CheckBoard();
            Assert.Null(result?.GetType());
        }

        [Fact]
        public void get_position_returns_int()
        {
            var result = kataMethods.GetPosition();
            Assert.IsType<int>(result);
        }
        [Fact]
        public void get_row_returns_string()
        {
            var result = kataMethods.GetRow(1);
            Assert.IsType<string>(result);
        }
    }
}