using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceImplementList.Implementations
{
    public class StorageServiceList : IStorageService
    {
        private DataListSingleton source;

        public StorageServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = source.Storages
                .Select(rec => new StorageViewModel
                {
                    StorageId = rec.StorageId,
                    StorageName = rec.StorageName,
                    StorageIngredients = source.StorageIngredients
                        .Where(recPC => recPC.StorageId == rec.StorageId)
                        .Select(recPC => new StorageIngredientViewModel
                        {
                            StorageIngredientId = recPC.StorageIngredientId,
                            StorageId = recPC.StorageId,
                            IngredientId = recPC.IngredientId,
                            IngredientName = source.Ingredients
                                .FirstOrDefault(recC => recC.IngredientId ==
                                                        recPC.IngredientId)?.IngredientName,
                            StorageIngredientCount = recPC.StorageIngredientCount
                        })
                        .ToList()
                })
                .ToList();
            return result;
        }
        public StorageViewModel GetElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageId == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    StorageId = element.StorageId,
                    StorageName = element.StorageName,
                    StorageIngredients = source.StorageIngredients
                        .Where(recPC => recPC.StorageId == element.StorageId)
                        .Select(recPC => new StorageIngredientViewModel
                        {
                            StorageIngredientId = recPC.StorageIngredientId,
                            StorageId = recPC.StorageId,
                            IngredientId = recPC.IngredientId,
                            IngredientName = source.Ingredients
                                .FirstOrDefault(recC => recC.IngredientId ==
                                                        recPC.IngredientId)?.IngredientName,
                            StorageIngredientCount = recPC.StorageIngredientCount
                        })
                        .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageName ==
                                                                model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.StorageId) : 0;
            source.Storages.Add(new Storage
            {
                StorageId = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec =>
                rec.StorageName == model.StorageName && rec.StorageId !=
                model.StorageId);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Storages.FirstOrDefault(rec => rec.StorageId == model.StorageId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
        }
        public void DelElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageId == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.StorageIngredients.RemoveAll(rec => rec.StorageId == id);
                source.Storages.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
