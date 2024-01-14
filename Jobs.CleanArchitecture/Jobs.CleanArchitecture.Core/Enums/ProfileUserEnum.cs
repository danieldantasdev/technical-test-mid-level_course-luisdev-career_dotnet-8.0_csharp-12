namespace Jobs.CleanArchitecture.Core.Enums;

internal enum ProfileUserEnum
{
   Administrator = 0,
   Recruiter = 1 << 0,
   Candidate = 1 << 1,
}
