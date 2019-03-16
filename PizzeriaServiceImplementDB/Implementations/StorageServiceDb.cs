using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using PizzeriaServiceImplementDB;

namespace ForgeServiceImplementList.Implementations
{
    public class StorageServiceDb : IStorageService
    {
        private AbstractDbContext context;

        public StorageServiceDb(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = context.Storages.Select(rec => new
           StorageViewModel
            {
                StorageId = rec.StorageId,
                StorageName = rec.StorageName,
                StorageIngredients = context.StorageIngredients
                    .Where(recPC => recPC.StorageId == rec.StorageId)
                    .Select(recPC => new StorageIngredientViewModel
                    {
                        StorageIngredientId = recPC.StorageIngredientId,
                        StorageId = recPC.StorageId,
                        IngredientId = recPC.IngredientId,
                        IngredientName = recPC.Ingredient.IngredientName,
                        StorageIngredientCount = recPC.StorageIngredientCount
                    })
                   .ToList()
            })
            .ToList();
            return result;
        }

        public StorageViewModel GetElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageId == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    StorageId = element.StorageId,
                    StorageName = element.StorageName,
                    StorageIngredients = context.StorageIngredients
                    .Where(recPC => recPC.StorageId == element.StorageId)
                    .Select(recPC => new StorageIngredientViewModel
                    {
                        StorageIngredientId = recPC.StorageIngredientId,
                        StorageId = recPC.StorageId,
                        IngredientId = recPC.IngredientId,
                        IngredientName = recPC.Ingredient.IngredientName,
                        StorageIngredientCount = recPC.StorageIngredientCount
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StorageBindingModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec =>
            rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = new Storage
            {
                StorageName = model.StorageName,
            };
            context.Storages.Add(element);
            context.SaveChanges();
        }

        public void UpdElement(StorageBindingModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec =>
                rec.StorageName == model.StorageName && rec.StorageId != model.StorageId);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Storages.FirstOrDefault(rec => rec.StorageId == model.StorageId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Storage element = context.Storages.FirstOrDefault(rec => rec.StorageId ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.StorageIngredients.RemoveRange(context.StorageIngredients.Where(rec =>
                        rec.StorageId == id));
                        context.Storages.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
