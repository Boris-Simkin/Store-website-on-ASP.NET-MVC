﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> 
    {
        List<TEntity> List { get; }
        TEntity Find(string id);
    }
}
