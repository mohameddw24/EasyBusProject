﻿using EasyBus.Models;

namespace EasyBusProject.RepoServices
{
    public class ScheduleRepoServices(MainDbContext context) : IRepository<Schedule>
    {
        public MainDbContext Context { get; } = context;

        public void Add(Schedule entity)
        {
            Context.Schedules.Add(entity);
            Context.SaveChanges();
        }

        public Schedule Details(int id)
        {
            var Schedule = Context.Schedules.Find(id);
            if (Schedule != null) 
                return Schedule;
            return new Schedule();
        }

        public List<Schedule> GetAll()
        {
            return Context.Schedules.ToList();
        }

        public void Remove(Schedule entity)
        {
            Context.Schedules.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(Schedule entity)
        {
            Context.Schedules.Update(entity);
            Context.SaveChanges();
        }
    }
}