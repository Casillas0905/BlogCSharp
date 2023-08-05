using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic;

public class SaveLogic : ISaveLogic
{
    private readonly ISavePostDao savePostDao;

    public SaveLogic(ISavePostDao savePostDao)
    {
        this.savePostDao = savePostDao;
    }

    public Task<List<Save>> findByUserId(int userId)
    {
        return savePostDao.findByUserId(userId);
    }

    public void saveSave(Save saveModel)
    {
        savePostDao.saveSave(saveModel);
    }

    public void deleteSaveById(int id)
    {
        savePostDao.deleteSaveById(id);
    }
}