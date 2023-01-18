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
        //DO.User user;
        //try
        //{
        //    user = dal.User. GetByUserName(username);
        //    if (user.password != password)
        //        throw new BO.BlIncorrectDateException("Worng Password");

        //}
        //catch (DO.DalIdDoNotExistException ex)
        //{
        //    throw new BO.BlIdDoNotExistException(ex.Message);
        //}
        //return new BO.User
        //{
        //    userName = username,
        //    password = password,
        //    status = (BO.Status)user.Status
        //};

    }

    public void sighUp(BO.User user)
    {
        throw new NotImplementedException();
    }
}
