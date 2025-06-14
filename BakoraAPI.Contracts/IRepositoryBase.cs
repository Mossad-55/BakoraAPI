﻿using System.Linq.Expressions;

namespace BakoraAPI.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChages);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T? entity);
    void Update(T? entity);
    void Delete(T? entity);
}
