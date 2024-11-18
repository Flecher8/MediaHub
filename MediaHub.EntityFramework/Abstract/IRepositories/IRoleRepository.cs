using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramewok.Abstract.IRepositories;
using MediaHub.EntityFramewok.Abstract;
using MediaHub.Models;

namespace MediaHub.EntityFramework.Abstract.IRepositories;
public interface IRoleRepository : IFilterableRepository<Role>
{
}
