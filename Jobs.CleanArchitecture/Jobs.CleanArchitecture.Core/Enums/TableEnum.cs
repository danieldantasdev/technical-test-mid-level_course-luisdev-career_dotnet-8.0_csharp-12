namespace Jobs.CleanArchitecture.Core.Enums;

internal enum TableEnum
{
   User = 0,
   Profile = 1 << 0,
   Job = 1 << 1,
   Subscribe = 1 << 2,
   Empthy = 1 << 3,
}
