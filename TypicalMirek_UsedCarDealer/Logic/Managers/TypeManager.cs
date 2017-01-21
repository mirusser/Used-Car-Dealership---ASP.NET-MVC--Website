using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using Type = TypicalMirek_UsedCarDealer.Models.Type;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class TypeManager : Manager, ITypeManager
    {
        #region Properties
        private readonly ITypeRepository typeRepository;
        private readonly ICarRepository carRepository;
        #endregion

        #region Constructors
        public TypeManager(IRepositoryFactory repositoryFactory)
        {
            typeRepository = repositoryFactory.Get<TypeRepository>();
            carRepository = repositoryFactory.Get<CarRepository>();
        }
        #endregion

        public Type Add(Type type)
        {
            if (typeRepository.GetById(type.Id) != null || typeRepository.CheckIfTypeWithExactNameExists(type.Name))
            {
                return null;
            }

            typeRepository.Add(type);
            typeRepository.Save();
            return type;
        }

        public Type Modify(Type type)
        {
            var typeToModify = typeRepository.GetById(type.Id);
            var isModyfiedNameEqual = type.Name.Equals(typeToModify.Name);

            if (typeRepository.CheckIfTypeWithExactNameExists(type.Name) && !isModyfiedNameEqual)
            {
                return null;
            }
            typeToModify.Name = type.Name;
            typeToModify.Description = type.Description;
            typeRepository.Save();
            return typeToModify;
        }

        public bool Delete(Type type)
        {
            if (type != null)
            {
                if (!carRepository.CheckIfExistCarForTypeId(type.Id))
                {
                    typeRepository.Delete(type);
                    typeRepository.Save();
                    return true;
                }
            }
            return false;
        }

        public Type GetById(int id)
        {
            return typeRepository.GetById(id);
        }

        public IQueryable<Type> GetAll()
        {
            return typeRepository.GetAll();
        }

        public void Dispose()
        {
            typeRepository.Dispose();
            carRepository.Dispose();
        }
    }
}