namespace Jobs.CleanArchitecture.Core.Enums;

public enum ProfileUserEnum
{
   Administrator = 0,
   Recruiter = 1 << 0,
   Candidate = 1 << 1,
}
