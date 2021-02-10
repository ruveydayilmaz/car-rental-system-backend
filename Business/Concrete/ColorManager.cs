using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        
        public void Add(Color color)
        {
                _colorDal.Add(color);
                Console.WriteLine("{0} succesfully added\n",color.ColorName);
        }

        public void Delete(Color color) 
        {
            _colorDal.Delete(color);
            Console.WriteLine("color succesfully deleted\n");
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("color succesfully updated\n");
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(p => p.ColorId == id);
        }

        public List<Color> GetAll()
        {
            Console.WriteLine("\nALL COLORS");
            return _colorDal.GetAll();
        }
    }
}
