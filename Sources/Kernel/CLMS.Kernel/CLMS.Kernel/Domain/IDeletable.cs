using CSharpFunctionalExtensions;

namespace CLMS.Kernel.Domain
{
    public interface IDeletable
    {
        bool IsDeleted { get; }

        Result Delete();
    }
}