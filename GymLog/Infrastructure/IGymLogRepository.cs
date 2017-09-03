﻿using GymLog.Entities;
using System.Linq;

namespace GymLog.Infrastructure {
    public interface IGymLogRepository {
        bool SaveAll();

        //bool MuscleExist(int id);
        IQueryable<Muscle> GetMuscles();
        Muscle GetMuscle(int id);
        void Insert(Muscle muscle);
        bool Update(Muscle muscle);
        void Delete(Muscle muscle);

        //bool EquipmentExist(int id);
        IQueryable<Equipment> GetEquipments();
        Equipment GetEquipment(int id);
        void Insert(Equipment eq);
        bool Update(Equipment eq);
        void Delete(Equipment eq);

        IQueryable<Exercise> GetExercises();
        IQueryable<Exercise> GetExercisesWithExtras();
        Exercise GetExercise(int id);
        void Insert(Exercise ex);
        bool Update(Exercise ex);
        void Delete(Exercise ex);
    }
}
