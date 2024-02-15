﻿using SchoolBackend.Entities.Models;
using System.Linq.Expressions;

namespace SchoolBackend.DataAccess.Interfaces;
public interface IStudentRepository
{
    void Create(Student student);
    void Update(Student student);
    void DeleteById(Guid Id);
    IQueryable<Student> GetAll();
    Student? GetStudentById(Guid studentId);
    bool Any(Expression<Func<Student, bool>> predicate);
    int GetNewStudentNumber();
}