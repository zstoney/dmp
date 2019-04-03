using dmp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmp.IBLL
{
    public interface IRoleBLL
    { 
        int Add(Role model);

        bool Update(Role model);

        Role GetUserByID(int id);

        List<Role> GetRoleList();
    }
}
