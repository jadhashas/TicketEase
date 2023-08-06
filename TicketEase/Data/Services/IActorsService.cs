﻿using TicketEase.Models;

namespace TicketEase.Data.Services
{
	public interface IActorsService
	{
		Task<IEnumerable<Actor>> GetAll();
		Actor GetById(int id);
        Task AddAsync(Actor actor);

        Actor Update(int id,Actor actor);

		void Delete(int id);
    }
}
