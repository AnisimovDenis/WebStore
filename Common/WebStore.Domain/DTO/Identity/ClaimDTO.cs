using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.DTO.Identity
{
    public abstract class ClaimDTO : UserDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class AddClaim : ClaimDTO { }

    public class RemoveClaim : ClaimDTO { }

    public class ReplaceClaimDTO : UserDTO 
    {
        public Claim Claim { get; set; }

        public Claim NewClaim { get; set; }
    }
}
