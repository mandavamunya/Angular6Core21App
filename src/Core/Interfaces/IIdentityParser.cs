using System.Security.Principal;

namespace Application.Core.Interfaces
{
    interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
