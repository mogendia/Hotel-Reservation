using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel_Reservation.Application.Features.Reviews.Command.AddReview;
using Hotel_Reservation.Application.Features.Reviews.Queries.GetReviewRooms;
using Hotel_Reservation.Application.Features.Rooms.Commands.CreateRoom;
using Hotel_Reservation.Application.Features.Rooms.Commands.UpdateRoom;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Models;

namespace Hotel_Reservation.Application.Mapping
{
    public class ProfileMapping :Profile
    {
        public ProfileMapping() 
        {
            CreateMap<Room,RoomDto>().ReverseMap();
            CreateMap<CreateRoomCommand, Room>().ReverseMap();
            CreateMap<UpdateRoomCommand, Room>().ReverseMap();
            // Review Mapping
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<AddReviewCommand, ReviewCreateDto>().ReverseMap();
            CreateMap<GetRoomReviewQuery, ReviewDto>().ReverseMap();
            CreateMap<RoomReview, ReviewDto>().ReverseMap();
            CreateMap<Review,RoomReview >().ReverseMap();
        }
    }
}
