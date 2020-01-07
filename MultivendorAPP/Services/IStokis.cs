using MultivendorAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorAPP.Services
{
    public interface IStokis
    {

        Task<List<Users>> getStokis();

    }
}
