using Moq;
using WebSample.Controllers;
using WebSample.Services;
using Xunit;

namespace Test
{
    public class ValuesControllerTest
    {
        [Fact]
        public void Fails_At_Runtime()
        {
            var fooServiceMock = Mock.Of<IFooService>();

            var valuesController = new ValuesController(fooServiceMock);

            var result = valuesController.Get();
        }
    }
}
