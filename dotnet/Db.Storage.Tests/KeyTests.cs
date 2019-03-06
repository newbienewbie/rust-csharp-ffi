using Xunit;

namespace Db.Storage.Tests
{
    public class KeyTests
    {
        [Fact]
        public void Equality()
        {
            var a = Key.FromString("abcdefgh-1");
            var b = Key.FromString("abcdefgh-11");
            
            var c = Key.FromString("abcdefgh-1");
            var d = Key.FromString("abcdefgh-11");
            
            Assert.True(a == c);
            Assert.Equal(a, c);
            Assert.Equal(b, d);
            
            Assert.True(a != b);
            Assert.NotEqual(a, b);
        }
        
        [Fact]
        public void ConvertFromString()
        {
            var key = Key.FromString("abcdefgh-42");
            var (hi, lo) = key;

            Assert.Equal("abcdefgh", hi);
            Assert.Equal((ulong) 42, lo);
        }

        [Fact]
        public void ConvertToString()
        {
            var key = new Key("abcdefgh", 42);

            Assert.Equal("abcdefgh-42", key.ToString());
        }

        [Fact]
        public void ReadWriteKey()
        {
            var key = new Key("abcdefgh", 42);
            var (hi, lo) = key;

            Assert.Equal("abcdefgh", hi);
            Assert.Equal((ulong) 42, lo);
        }
    }
}