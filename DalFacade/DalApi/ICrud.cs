﻿using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface ICrud<T>
{
    public int Add(T obj);
    public void Delete(int id);
    public T GetByID(int id);
    public void Uppdate(T obj);
    public IEnumerable <T?> GetAll();
}
