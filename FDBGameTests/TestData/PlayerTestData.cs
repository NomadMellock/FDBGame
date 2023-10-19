using FDBGame.Models;
using System.Collections;

namespace FDBGameTests.TestData
{
    public class PlayerTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {new Player(1, 1)},
    };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
