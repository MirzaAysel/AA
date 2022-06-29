using Business29.Services;
using DAL29.Data;
using DAL29.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business29.Implemantion
{
    public class CardRepository : ICardService
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Card entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            var data = await _context.Cards.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (data is null)
            {
                throw new NullReferenceException();
            }
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }
            var data = await _context.Cards.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data is null)
            {
                throw new NullReferenceException();
            }
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
           
        }

        public async Task<Card> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }
            var data = await _context.Cards.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data is null)
            {
                throw new NullReferenceException();
            }
            return data;
        }

        public async Task<List<Card>> GetAll()
        {
           var data = await _context.Cards.Where(x => x.IsDeleted).ToListAsync();
            return data;
        }

        public async Task Update(Card entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            var data = await _context.Cards.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (data is null)
            {
                throw new NullReferenceException();
            }
            
        }
    }
}
