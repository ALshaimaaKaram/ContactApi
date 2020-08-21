using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Models.Repositories
{
	public interface IGenericRepository<TEntity>
	{
		IList<TEntity> List();
		TEntity FindById(int id);
		void Add(TEntity entity);
		void Edit(TEntity entity);
		void Delete(IList<int> id);
	}
}
