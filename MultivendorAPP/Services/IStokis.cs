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


        //---------------------Get Agent Pending Approve
        Task<List<Users>> penAgent(int id);

        Task<bool> ApproveAgent(int id);


    }
}
