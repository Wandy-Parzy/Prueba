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

        public bool Existe(int CarId)
        {
            return _contexto.Car.Any(o => o.CarId == CarId);
        }

        private bool Insertar(Car car)
        {
            _contexto.Car.Add(car);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Car car)
        {
            _contexto.Entry(car).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Car car)
        {
            if (!Existe(car.CarId))
                return this.Insertar(car);
            else
                return this.Modificar(car);
        }

        public bool Eliminar(Car car)
        {
            _contexto.Entry(car).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

          public bool  Eliminacion(Car car)
        {
            bool eliminar;
            if ( Existe(car.CarId))
                return eliminar = true && this.Eliminar(car);
            else
                return eliminar = false;
        }

        public Car? Buscar(int registroId)
        {
            return _contexto.Car
                    .Where(o => o.CarId == registroId)
                    .AsNoTracking()
                    .SingleOrDefault();
        }

        public List<Car> GetCar(Expression<Func<Car, bool>> Criterio)
        {
            return _contexto.Car
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }

}