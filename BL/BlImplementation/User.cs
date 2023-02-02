using BlApi;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlImplementation;

internal class User : IUser
{
    private static readonly DalApi.IDal dal = DalApi.Factory.Get()!;
    public BO.User LogIn(string userName, int password)
    {
        throw new NotImplementedException();
    }
    public void sighUp(BO.User user)
    {
        throw new NotImplementedException();
    }
}
