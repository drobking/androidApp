using Nursery.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
