using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Tests.Common;

namespace Carbook.Application.Tests.Unit;

public class NamingTests
{
    [Fact]
    public void Requests_ShouldHaveNameEndingwihtCommandOrQuery()
    {
        TestResult? result = Types.InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(IRequest))
            .Or()
            .ImplementInterface(typeof(IRequest<>))
            .Should()
            .HaveNameEndingWith("Command")
            .Or()
            .HaveNameEndingWith("Query")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void RequestHandlers_ShouldHaveNameEndingwihtCommandHandlerOrQueryHandler()
    {
        TestResult? result = Types.InAssembly(Assemblies.Application)
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .Or()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}