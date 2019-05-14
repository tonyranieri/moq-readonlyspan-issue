using System;

namespace WebSample.Services
{
    public class FooService : IFooService
    {
        public ReadOnlySpan<char> GetSomeData()
        {
            return "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.".AsSpan();
        }
    }
}
