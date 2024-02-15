﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBackend.Business.Interfaces;
using SchoolBackend.Entities.DTOs;

namespace SchoolBackend.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class StudentsController
    (IStudentService studentService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateStudentDto request)
    {
        string message = studentService.Create(request);
        return Ok(new { Message = message });
    }

    [HttpPost]
    public IActionResult Update(UpdateStudentDto request)
    {
        string message = studentService.Update(request);
        return Ok(new { Message = message });
    }

    [HttpGet("{id}")]
    public IActionResult DeleteById(Guid id) //?id=asdasd => query Params || /asdasdasd => routing params
    {
        string message = studentService.DeleteById(id);
        return Ok(new { Message = message });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = studentService.GetAll();
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAllByClassRoomId(Guid classRoomId)
    {
        var response = studentService.GetAllByClassRoomId(classRoomId);
        return Ok(response);
    }
}
