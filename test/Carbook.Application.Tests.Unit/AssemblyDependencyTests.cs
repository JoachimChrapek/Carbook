using FluentAssertions;
using NetArchTest.Rules;
using Tests.Common;

namespace Carbook.Application.Tests.Unit;

public class AssemblyDependencyTests
{
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOnPresentationLayer()
    {
        TestResult? result = Types.InAssembly(Assemblies.Application)
            .Should()
            .NotHaveDependencyOn(Assemblies.Presentation.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOnInfrastructureLayer()
    {
        TestResult? result = Types.InAssembly(Assemblies.Application)
            .Should()
            .NotHaveDependencyOn(Assemblies.Infrastructure.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOnPersistenceLayer()
    {
        TestResult? result = Types.InAssembly(Assemblies.Application)
            .Should()
            .NotHaveDependencyOn(Assemblies.Persistence.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}