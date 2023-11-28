using AutoMapper;
using Core.ApiModels;
using Core.Interfaces;
using DataAccess.Data;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class VariantsService : IVariantsService
    {
        private readonly SurveysDbContext _context;
        private readonly IMapper _mapper;

        public VariantsService(SurveysDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CreateVariantModel variant)
        {
            _context.Variants.Add(_mapper.Map<Variant>(variant));

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var variant = await _context.Variants.FindAsync(id);
            if (variant == null) throw new Exception();//TO DO

            _context.Variants.Remove(variant);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Variant variant)
        {
            _context.Variants.Update(variant);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Variant>>? Get()
        {
            return await _context.Variants.ToListAsync();
        }

        public async Task<Variant?> GetById(int id)
        {
            var variant = await _context.Variants.FindAsync(id);

            if (variant == null) throw new Exception();//TO DO

            return variant;
        }
    }
}
