using MultiGames.Application.Repository;

namespace MultiGames.Application.IUofW;

public interface IUnitOfWork
{
    IAddressRepository IAddressRepository { get; }
    IBrotherRepository IBrotherRepository { get; }
    IGameRepository IGameRepository { get; }
    Task Commit();
    void Dispose();
}
