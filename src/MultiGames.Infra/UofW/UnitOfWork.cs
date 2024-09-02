using MultiGames.Application.IUofW;
using MultiGames.Application.Repository;
using MultiGames.Infra.DataBase.Context;
using MultiGames.Infra.Repository;

namespace MultiGames.Infra.UofW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AddressRepository _addressRepository;
    private readonly BrotherRepository _brotherRepository;
    private readonly GameRepository _gameRepository;
   
    private readonly MultiGamesContext _context;

    public UnitOfWork(MultiGamesContext context)
    {
        _context = context;
    }

    public IAddressRepository IAddressRepository
    {
        get
        {
            if (_addressRepository == null)
            {
                return new AddressRepository(_context);
            }
            else
            {
                return _addressRepository;
            }
        }
    }

    public IBrotherRepository IBrotherRepository
    {
        get
        {
            if (_brotherRepository == null)
            {
                return new BrotherRepository(_context);
            }
            else
            {
                return _brotherRepository;
            }
        }
    }

    public IGameRepository IGameRepository
    {
        get
        {
            if (_gameRepository == null)
            {
                return new GameRepository(_context);
            }
            else
            {
                return _gameRepository;
            }
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}

