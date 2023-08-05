using Domain.Models;

namespace Application.DaoInterfaces;

public interface ISavePostDao
{
    Task<List<Save>> findByUserId(int userId);
    void saveSave(Save saveModel);
    void deleteSaveById(int id);
}