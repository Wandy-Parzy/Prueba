using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ejemplo1.DAl;
using Ejemplo1.Model;

namespace Ejemplo1.BLL
{
    public class CarBLL
    { 
        private Contexto _contexto;

        public CarBLL(Contexto contexto) 
        {
           _contexto = contexto;
         }

        public async Task<bool> Existe(int carID) {
            return await _contexto.Car.AllAsync(o => o.CarId == carID);
         }

        
        public async Task<bool> Insertar(Car car) 
        {
            await _contexto.Car.AddAsync(car);
            int cantidad = await _contexto.SaveChangesAsync();
            return cantidad > 0;
         }

        public async Task<bool> Modificar(Car car)
        {
            _contexto.Entry(car).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;

        }
        public async Task<bool> Guardar(Car car) 
        { 
            if (!await Existe(car.CarId))
            return await this.Insertar(car);
            else
            return await this.Modificar(car);
         }

          public async Task<bool> Eliminar(Car car)
        {
            _contexto.Entry(car).State = EntityState.Detached;
            return await _contexto.SaveChangesAsync() > 0;

        }

         public async Task<Car> Buscar(int carID)
         {
            return await _contexto.Car
            .Where(o => o.CarId == carID)
            .AsNoTracking()
            .SingleOrDefaultAsync();
         }

         public async Task<List<Car>> GetCar(Expression<Func<Car, bool>> Criterio)
         {
            return await _contexto.Car
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();

         }


     }
}