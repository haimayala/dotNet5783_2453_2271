using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal class DalUser
{
    public void Add(User user)
    {
        if (DataSource.s_users.Exists(x => x?.userName == user.userName))
            throw new DalAllredyExsisExeption("Exist");
        DataSource.s_users.Add(user);


    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User?> GetAll(Func<User?, bool>? filter = null)
    {
        if (filter == null)
            return from item in DataSource.s_users
                   select item;
        return from item in DataSource.s_users
               where filter(item) == true
               select item;
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public User GetByUserName(string userName)
    {
        return DataSource.s_users.FirstOrDefault(x => x?.userName == userName) ?? throw new DalDoesNotExsistExeption("Not exist");
    }

   
    public void Update(User item)
    {


        throw new NotImplementedException();
    }

  
}
