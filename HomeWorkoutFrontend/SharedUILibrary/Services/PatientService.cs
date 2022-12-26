using HomeWorkoutModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedUILibrary.Services
{
    public class PatientService
    {
        private readonly HttpClient httpClient;
        public PatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        //public List<UserBasicDetail> GetPhysiotherapists(int id)
        //{

        //}
        //public List<UserBasicDetail> GetPatients()
        //{

        //}
    }
}
