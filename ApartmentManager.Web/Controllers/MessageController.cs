using ApartmentManager.Core.Models;
using ApartmentManager.Core.Services;
using ApartmentManager.Web.DTOs;
using ApartmentManager.Web.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Controllers
{
    
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper, IUserService userService)
        {
            _messageService = messageService;
            _mapper = mapper;
            _userService = userService;
        }

        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> SendBox()
        {
            var messageSendBox = await _messageService.GetAllPredicateAsync(x => x.Sender == "admin@admin.com");
            var listMessage = _mapper.Map<List<ListMessageDto>>(messageSendBox);
            return View(listMessage);
        }

        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> InBox()
        {
            var messaasageInBox = await _messageService.GetAllAsync();
            var messageInBox = await _messageService.GetAllPredicateAsync(x => x.Receiver == "admin@admin.com");
            var listMessage = _mapper.Map<List<ListMessageDto>>(messageInBox);
            return View(listMessage);
        }

        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AddMessage()
        {
            ViewBag.userList = await _userService.GetAllAsync();
            return View();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddMessage(MessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            int id = await _messageService.AddAsync(message);
            if (id > 0) return RedirectToAction("SendBox");
            return View();
        }

        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _messageService.GetAsync(x => x.Id == id);
            _messageService.Delete(message);
            return RedirectToAction("SendBox");
        }

        [Authorize(Roles = Roles.User)]
        public async Task<IActionResult> UserSendBox()
        {
            var username = HttpContext.User.Identity.Name;
            var user = await _userService.GetAsync(x => x.UserName == username);
            var messageSendBox = await _messageService.GetAllPredicateAsync(x => x.Sender == user.Email);
            var listMessage = _mapper.Map<List<ListMessageDto>>(messageSendBox);
            return View(listMessage);
        }

        [Authorize(Roles = Roles.User)]
        public async Task<IActionResult> UserInBox()
        {
            var username = HttpContext.User.Identity.Name;
            var user = await _userService.GetAsync(x => x.UserName == username);
            var messageInBox = await _messageService.GetAllPredicateAsync(x => x.Receiver == user.Email);
            var listMessage = _mapper.Map<List<ListMessageDto>>(messageInBox);
            return View(listMessage);
        }

        [Authorize(Roles = Roles.User)]
        public IActionResult UserAddMessage()
        {
            return View();
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost]
        public async Task<IActionResult> UserAddMessage(MessageDto messageDto)
        {
            if (!ModelState.IsValid)
                return View(messageDto);

            var user = await _userService.GetAsync(x => x.UserName == messageDto.Sender);
            messageDto.Sender = user.Email;
            var message = _mapper.Map<Message>(messageDto);
            int id = await _messageService.AddAsync(message);
            if (id > 0) return RedirectToAction("UserSendBox");
            return View();
        }
    }
}
