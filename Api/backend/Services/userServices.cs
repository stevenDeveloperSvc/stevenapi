
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services;


public class userServices
{

    private readonly SalesDBContext _context;

    public userServices()
    {

    }
    public userServices(SalesDBContext context)
    {
        _context = context;

    }
    public async Task<IEnumerable<User>> getAllUser() => await _context.Users.AsNoTracking().ToListAsync();

    public async Task<User?> getUser (int id)=>  await _context.Users.FindAsync(id);



    public async Task postUser (User user)   {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
    }



    public  async void putUser (int id, User? user){

        var idUser =  await _context.Users.FindAsync(id);

                idUser!.FirstName = user!.FirstName;
                idUser.LastName = user.LastName;
                idUser.Id = user.Id;
                idUser.Role = user.Role;

              await _context.SaveChangesAsync();


    }

    public async Task deleteUsers(User user)
    {

        _context.Users.Remove(user);
        await   _context.SaveChangesAsync();


    }
    
    public async Task<User?> getById (int id) => await _context.Users.SingleOrDefaultAsync( p => p.Id == id);



}