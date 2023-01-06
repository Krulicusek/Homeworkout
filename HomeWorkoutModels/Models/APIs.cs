using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkoutModels.Models  
{
    public class APIs
    {
        public const string BaseUrl = "https://localhost:7057";
        public const string AuthenticateUser = "/Account/login";
        public const string RegistrationUser = "/Account/register";
        public const string EditExerciseModel = "/ExerciseModels";
        public const string DeleteExerciseModel = "/ExerciseModels";
        public const string AddExerciseModel = "/ExerciseModels";
        public const string AddSequenceModel = "/HomeworkSequence";
        public const string GetSequenceModelByUserId = "/HomeworkSequence/userId";
    }
}
