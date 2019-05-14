using System;

namespace WebSample.Services
{
    public interface IFooService
    {
        ReadOnlySpan<char> GetSomeData();
    }
}
