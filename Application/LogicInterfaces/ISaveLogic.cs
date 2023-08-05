using Domain.Models;

namespace Application.LogicInterfaces;

public interface ISaveLogic
{
    Task<List<Save>> findByUserId(int userId);
    void saveSave(Save saveModel);
    void deleteSaveById(int id);
}