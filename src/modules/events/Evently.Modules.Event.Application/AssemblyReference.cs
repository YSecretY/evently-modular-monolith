using System.Reflection;

namespace Evently.Modules.Event.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
