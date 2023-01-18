using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IUser
{
    BO.User LogIn(string userName, int password);
    void sighUp(BO.User user);
}
