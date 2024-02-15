﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using SchoolBackend.Business.Interfaces;
using SchoolBackend.DataAccess.Constants;
using SchoolBackend.DataAccess.Interfaces;
using SchoolBackend.DataAccess.Validators;
using SchoolBackend.Entities.DTOs;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.Business.Services;
public sealed class StudentService(
    IStudentRepository studentRepository,
    IMapper mapper) : IStudentService
{
    public string Create(CreateStudentDto request)
    {
        CreateStudentDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ArgumentException(string.Join(",", result.Errors));
        }

        bool isIdentityNumberExists =
            studentRepository
            .Any(p => p.IdentityNumber == request.IdentityNumber);

        if (isIdentityNumberExists)
        {
            throw new ArgumentException(MessageConstants.IdentityNumberAlreadyExists);
        }

        int studentNumber = studentRepository.GetNewStudentNumber();

        Student student = mapper.Map<Student>(request);
        student.StudentNumber = studentNumber;
        student.CreatedDate = DateTime.Now;
        student.CreatedBy = "Admin";

        studentRepository.Create(student);

        return MessageConstants.CreateIsSuccessfully;
    }

    public string DeleteById(Guid id)
    {
        studentRepository.DeleteById(id);
        return MessageConstants.DeleteIsSuccessfully;
    }

    public List<Student> GetAll()
    {
        List<Student> students = studentRepository
                                                .GetAll()
                                                .OrderBy(p => p.ClassRoomId)
                                                .ThenBy(p => p.FirstName)
                                                .ToList();

        return students;
    }

    public List<Student> GetAllByClassRoomId(Guid classRoomId)
    {
        List<Student> students = studentRepository
                                                .GetAll()
                                                .Where(p => p.ClassRoomId == classRoomId)
                                                .OrderBy(p => p.FirstName)
                                                .ToList();

        return students;
    }

    public string Update(UpdateStudentDto request)
    {
        UpdateStudentDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ValidationException(string.Join(", ", result.Errors.Select(s => s.ErrorMessage).ToList()));
        }

        Student? student = studentRepository.GetStudentById(request.Id);
        if (student is null)
        {
            throw new ArgumentException(MessageConstants.DataNotFound);
        }

        if (student.IdentityNumber != request.IdentityNumber)
        {
            bool isIdentityNumberExists =
                studentRepository
                .Any(p => p.IdentityNumber == request.IdentityNumber);

            if (isIdentityNumberExists)
            {
                throw new ArgumentException(MessageConstants.IdentityNumberAlreadyExists);
            }
        }

        mapper.Map(request, student);
        student.UpdatedDate = DateTime.Now;
        student.UpdatedBy = "Admin";

        studentRepository.Update(student);

        return MessageConstants.UpdateIsSuccessfully;
    }
}
