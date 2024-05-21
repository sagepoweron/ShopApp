﻿using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository => throw new NotImplementedException();

        private readonly ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			CategoryRepository = new CategoryRepository(_context);
		}

		//public Task SaveAsync()
		//{
		//	return _context.SaveChangesAsync();
		//}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
