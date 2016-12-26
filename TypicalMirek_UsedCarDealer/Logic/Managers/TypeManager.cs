using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using Type = TypicalMirek_UsedCarDealer.Models.Type;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class TypeManager : Manager, ITypeManager
    {
        private readonly ITypeRepository typeRepository;
        private readonly IMainDataRepository mainDataRepository;

        public TypeManager(IRepositoryFactory repositoryFactory)
        {
            typeRepository = repositoryFactory.Get<TypeRepository>();
            mainDataRepository = repositoryFactory.Get<MainDataRepository>();
        }


        public Type Add(Type type)
        {
            if (typeRepository.GetByName(type.Name) != null)
            {
                //TODO inform user that he cannot add type with existing in database name
                return null;

            }

            typeRepository.Add(type);
            typeRepository.Save();
            return type;
        }

        public Type Modify(Type type)
        {
            var typeToModify = typeRepository.GetById(type.Id);
            if (typeToModify != null)
            {
                var typeWithTheSameName = typeRepository.GetByName(type.Name);
                if (typeWithTheSameName != null && typeToModify.Id != typeWithTheSameName.Id )
                {
                    //TODO inform user that type with that name already exists what is very baaad
                    return type;
                }
                typeToModify.Name = type.Name;
                typeToModify.Description = type.Description;
                typeRepository.Save();
                return typeToModify;
            }

            //TODO inform user that this type doesn't exist in database
            return type;
        }

        public void Delete(Type type)
        {
            var typeToDelete = typeRepository.GetById(type.Id);
            if (typeToDelete != null)
            {
                if (!mainDataRepository.Contains(typeToDelete))
                {
                    typeRepository.Delete(typeToDelete);
                    typeRepository.Save();
                }
                //TODO inform user that this field cannot be deleted because exists in anothe table as foreign key
            }
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
        }
    }
}