using Application.DaoInterfaces;
using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.SavePost;

namespace GrpcAcces.Grpc;

public class SaveGrpcService : ISavePostDao
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private SavePostGrpc.SavePostGrpcClient saveGrpcClient = new SavePostGrpc.SavePostGrpcClient(channel);

    public async Task<List<Save>> findByUserId(int userId)
    {
        var req = new SaveModelGrpc { UserId = userId };
        using var call = saveGrpcClient.findByUserId(req);
        List<Save> list = new List<Save>();
        while ( await call.ResponseStream.MoveNext())
        {
            SaveModelGrpc model = call.ResponseStream.Current;
            Save save = new Save(model.Id, model.UserId,model.PostId);
            list.Add(save);
        }

        return list;
    }

    public void saveSave(Save saveModel)
    {
        var saveModelGrpc = new SaveModelGrpc
        {
            Id = saveModel.id,
            UserId = saveModel.userId,
            PostId = saveModel.postSaveId
        };
        saveGrpcClient.saveSavePost(saveModelGrpc);
    }

    public void deleteSaveById(int id)
    {
        var request = new GetById { Id = id };
        saveGrpcClient.deleteById(request);
    }
}