using Carbook.API.Controllers;
using Carbook.Domain.Cars;
using System.Reflection;

namespace Tests.Common;

public static class Assemblies
{
    public static Assembly Domain { get; } = typeof(Car).Assembly;
    public static Assembly Application { get; } = typeof(Carbook.Application.DependencyInjection).Assembly;
    public static Assembly Presentation { get; } = typeof(ApiController).Assembly;
    public static Assembly Persistence { get; } = typeof(Carbook.Persistence.DependencyInjection).Assembly;
    public static Assembly Infrastructure { get; } = typeof(Carbook.Infrastructure.DependencyInjection).Assembly;
}