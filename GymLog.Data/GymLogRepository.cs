﻿using GymLog.Data.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace GymLog.Data {
    public class GymLogRepository : IGymLogRepository, IDisposable {

        private GymLogContext _ctx;

        public GymLogRepository(GymLogContext ctx) {
            _ctx = ctx;
        }

        public bool SaveAll() {
            return _ctx.SaveChanges() > 0;
        }

        public bool MuscleExist(int id) {
            return _ctx.Muscles.Count(m => m.Id == id) > 0;
        }

        public IQueryable<Muscle> GetMuscles() {
            return _ctx.Muscles;
        }

        public Muscle GetMuscle(int id) {
            return _ctx.Muscles.Where(m => m.Id == id).FirstOrDefault();
        }

        public void Insert(Muscle muscle) {
            _ctx.Muscles.Add(muscle);
        }

        public bool Update(Muscle muscle) {
            var existing = _ctx.Muscles.FirstOrDefault(m => m.Id == muscle.Id);
            if (existing == null) {
                return false;
            }
            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Muscles.Attach(muscle);
            _ctx.Entry(muscle).State = EntityState.Modified;
            return true;
        }

        public void Delete(Muscle muscle) {
            _ctx.Muscles.Remove(muscle);
        }

        public bool EquipmentExist(int id) {
            return _ctx.Equipments.Count(e => e.Id == id) > 0;
        }

        public IQueryable<Equipment> GetEquipments() {
            return _ctx.Equipments;
        }

        public Equipment GetEquipment(int id) {
            return _ctx.Equipments.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Insert(Equipment eq) {
            _ctx.Equipments.Add(eq);
        }

        public bool Update(Equipment eq) {
            var existing = _ctx.Equipments.FirstOrDefault(e => e.Id == eq.Id);
            if (existing == null) {
                return false;
            }
            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Equipments.Attach(eq);
            _ctx.Entry(eq).State = EntityState.Modified;
            return true;
        }

        public void Delete(Equipment eq) {
            _ctx.Equipments.Remove(eq);
        }

        public IQueryable<Exercise> GetExercises() {
            return _ctx.Exercises;
        }

        public IQueryable<Exercise> GetExercisesWithExtras() {
            return _ctx.Exercises.Include("Muscles").Include("Equipments");
        }

        public void Insert(Exercise ex) {
            _ctx.Exercises.Add(ex);
        }

        public Exercise GetExercise(int id) {
            return _ctx.Exercises.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool Update(Exercise ex) {
            var existing = _ctx.Exercises.FirstOrDefault(e => e.Id == ex.Id);
            if (existing == null) {
                return false;
            }
            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Exercises.Attach(ex);
            _ctx.Entry(ex).State = EntityState.Modified;
            return true;
        }

        public void Delete(Exercise ex) {
            _ctx.Exercises.Remove(ex);
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                if (_ctx != null) {
                    _ctx.Dispose();
                    _ctx = null;
                }
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
